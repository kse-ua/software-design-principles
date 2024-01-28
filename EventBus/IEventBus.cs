namespace EventBus;

public interface IEventBus
{
    void Publish<T>(T ev) where T : IEvent;

    void Subscribe<T>(Action<T> subscription) where T : IEvent;
}

public class EventBus : IEventBus
{
    private readonly List<Subscription> subscriptions = new();

    public void Publish<T>(T ev) where T : IEvent
    {
        foreach (var subscription in subscriptions)
        {
            if (subscription.CanHandle(ev))
            {
                subscription.Process(ev);
            }
        }
    }

    public void Subscribe<T>(Action<T> subscription) where T : IEvent
    {
        subscriptions.Add(new Subscription<T>(subscription));
    }

    abstract class Subscription
    {

        public abstract bool CanHandle<T>(T ev) where T : IEvent;
        public abstract void Process(IEvent ev);
    }
    
    class Subscription<T> : Subscription where T : IEvent
    {
        private Action<T> action;

        public Subscription(Action<T> action)
        {
            this.action = action;
        }

        public override bool CanHandle<T1>(T1 ev)
        {
            return ev is T;
        }

        public override void Process(IEvent ev)
        {
            action((T)ev);
        }

    }
}