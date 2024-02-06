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
    
    public object Resolve(Type interfaceType)
    {
        var binding = types[interfaceType];
        if (binding.ImplementationObject != null)
        {
            return binding.ImplementationObject;
        }

        var constructor = binding.ImplementationType.GetConstructors().First();
        var parameters = new List<object>();
        foreach (var parameter in constructor.GetParameters())
        {
            parameters.Add(Resolve(parameter.ParameterType));
        }

        var instance = constructor.Invoke(parameters.ToArray());
        if (binding.Scope == Scope.Singleton)
        {
            binding.ImplementationObject = instance;
        }
        return instance;
    }

    class Binding
    {
        public Type ImplementationType { get; init; }
        
        
        public object? ImplementationObject { get; set; }
        
        public Scope Scope { get; init; }
    }
}