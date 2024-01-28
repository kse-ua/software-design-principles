namespace SmartHome;

using EventBus;

public interface ISensorEventTrigger
{
    bool TrySubscribeTo(ISensor sensor, IEventBus bus);
    
    void Check();
}

public abstract class SensorEventTrigger<TSensor> : ISensorEventTrigger where TSensor : ISensor
{
    private TSensor _sensor;

    private IEventBus bus;

    public bool TrySubscribeTo(ISensor sensor, IEventBus bus)
    {
        if (sensor is TSensor typed)
        {
            _sensor = typed;
            this.bus = bus;
            return true;
        }

        return false;
    }

    public void Check() => CheckInternal(_sensor);
    
    protected abstract void CheckInternal(TSensor sensor);


    protected void Publish<T>(T ev) where T : ISensorEvent
    {
        bus.Publish(ev);
    }
}