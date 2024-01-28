namespace SmartHome;

using EventBus;

public interface ISensorEventHandler
{
    void SubscribeTo(IEventBus bus);
}

public abstract class SensorEventHandler<TEvent> : ISensorEventHandler where TEvent : ISensorEvent
{
    public void SubscribeTo(IEventBus bus)
    {
        bus.Subscribe<TEvent>(OnEvent);
    }

    protected abstract void OnEvent(TEvent ev);
}