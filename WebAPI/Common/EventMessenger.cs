using Easy.MessageHub;

namespace Common
{
    public class EventMessenger
    {
        private static EventMessenger _masterMessenger = null!;
        private readonly MessageHub _messageHub;

        public EventMessenger()
        {
            _messageHub = MessageHub.Instance;
        }

        public static EventMessenger MakeInstance()
        {
            _masterMessenger = new EventMessenger();
            return _masterMessenger;
        }

        public static EventMessenger GetInstance() => _masterMessenger;

        public void Publish<T>(T message)
        {
            _messageHub.Publish(message);
        }

        public Guid Subscribe<T>(Action<T> action) => _messageHub.Subscribe(action);

        public void UnSubscribe(Guid token)
        {
            _messageHub.UnSubscribe(token);

        }
    }
}
