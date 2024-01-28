namespace SmartHome;

using EventBus;

public interface ISmartHome
{
    void Start();
}

public class SmartHome : ISmartHome
{
    private readonly List<ISensorEventTrigger> triggers = new();

    public SmartHome(List<ISensor> sensors, Func<List<ISensorEventTrigger>> triggersFactory, List<ISensorEventHandler> handlers)
    {
        var bus = new EventBus();
        foreach (var sensor in sensors)
        {
            var newTriggers = triggersFactory();
            foreach (var trigger in newTriggers)
            {
                if (trigger.TrySubscribeTo(sensor, bus))
                {
                    triggers.Add(trigger);
                }
            }
        }

        foreach (var handler in handlers)
        {
            handler.SubscribeTo(bus);
        }
    }

    public void Start()
    {
        while (true)
        {
            foreach (var trigger in triggers)
            {
                trigger.Check();
                Thread.Sleep(500);
            }
        }
    }
}