using DI.Core;

var container = new DiContainer();
// 1. register dependencies
container.Register<IFirstInterface, FirstImplementation>();
container.Register<ISecondInterface, SecondImplementation>();

// 2. Create instances
var first = container.Resolve<IFirstInterface>();
var second = container.Resolve<ISecondInterface>();
Console.WriteLine();

interface IFirstInterface
{
    
}

class FirstImplementation : IFirstInterface
{
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


}