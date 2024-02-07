using DI.Core;

var container = new DiContainer();
// 1. register dependencies
container.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
container.Register<ISecondInterface, SecondImplementation>(Scope.Transient);

// 2. Create instances
var firstA = container.Resolve<IFirstInterface>();
var firstB = container.Resolve<IFirstInterface>();
var secondA = container.Resolve<ISecondInterface>();
var secondB = container.Resolve<ISecondInterface>();

Console.WriteLine();

interface IFirstInterface
{
    
}

class FirstImplementation : IFirstInterface
{
    private ISecondInterface secondInterface;

    public FirstImplementation(ISecondInterface secondInterface)
    {
        this.secondInterface = secondInterface;
    }

    public override string ToString()
    {
        return $"{GetHashCode()}";
    }
}


interface ISecondInterface
{
    
}

class SecondImplementation : ISecondInterface
{
    private IFirstInterface firstInterface;

    public SecondImplementation(IFirstInterface firstInterface)
    {
        this.firstInterface = firstInterface;
    }
    
    public override string ToString()
    {
        return $"{GetHashCode()}";
    }


}