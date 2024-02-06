namespace DI.Core;

public class DiContainer : IDiContainer
{
    private readonly Dictionary<Type, Binding> types = new();

    public void Register(Type interfaceType, Type implementationType, Scope scope)
    {
        types[interfaceType] = new Binding()
        {
            ImplementationType = implementationType,
            Scope = scope
        };
    }

    public void Register<TInterface, TImplementation>(Scope scope)
    {
        Register(typeof(TInterface), typeof(TImplementation), scope);
    }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }
    
    public object Resolve(Type type)
    {
        return ResolveInternal(type, new List<Type>());

        object ResolveInternal(Type interfaceType, List<Type> resolutionsChain)
        {
            var binding = types[interfaceType];
            if (binding.ImplementationObject != null)
            {
                return binding.ImplementationObject;
            }

            if (resolutionsChain.Contains(interfaceType))
            {
                throw new Exception(
                    $"Cyclic dependency found during resolution of {type}: {string.Join(",", resolutionsChain.Select(t => t.Name))}. " +
                    $"Got {interfaceType} again");
            }
            resolutionsChain.Add(interfaceType);

            var constructor = binding.ImplementationType.GetConstructors().First();
            var parameters = new List<object>();
            foreach (var parameter in constructor.GetParameters())
            {
                parameters.Add(ResolveInternal(parameter.ParameterType, resolutionsChain));
            }

            var instance = constructor.Invoke(parameters.ToArray());
            if (binding.Scope == Scope.Singleton)
            {
                binding.ImplementationObject = instance;
            }
            return instance;
        }
    }

    class Binding
    {
        public Type ImplementationType { get; init; }
        
        
        public object? ImplementationObject { get; set; }
        
        public Scope Scope { get; init; }
    }
}