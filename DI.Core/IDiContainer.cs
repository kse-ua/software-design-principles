namespace DI.Core;

public interface IDiContainer
{
    void Register(Type interfaceType, Type implementationType, Scope scope);
    
    void Register<TInterface, TImplementation>(Scope scope);

    T Resolve<T>();

    T Instantiate<T>(Type type);
}

public enum Scope
{
    Singleton, Transient
}