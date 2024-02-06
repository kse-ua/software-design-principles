namespace DI.Core;

public interface IDiContainer
{
    void Register(Type interfaceType, Type implementationType);
    
    void Register<TInterface, TImplementation>();

    T Resolve<T>();
}

public class DiContainer : IDiContainer
{
    private Dictionary<Type, Type> types = new();

    public void Register(Type interfaceType, Type implementationType)
    {
        types[interfaceType] = implementationType;
    }

    public void Register<TInterface, TImplementation>()
    {
        Register(typeof(TInterface), typeof(TImplementation));
    }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }
    
    public object Resolve(Type interfaceType)
    {
        var implementationType = types[interfaceType];

        var constructor = implementationType.GetConstructors().First();
        var parameters = new List<object>();
        foreach (var parameter in constructor.GetParameters())
        {
            parameters.Add(Resolve(parameter.ParameterType));
        }

        return constructor.Invoke(parameters.ToArray());
    }
}