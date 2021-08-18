using System;
using Easy.MessageHub;

namespace EventAggregator
{
    public class MessageEvent
    {
        private readonly IMessageHub _messageHub;

        public MessageEvent()
        {
            //adding comment
            _messageHub = new MessageHub();
            _messageHub.RegisterGlobalHandler((type, eventObject) => Console.WriteLine($"Type: {type} - Event: {eventObject}"));
        }

        private static MessageEvent _masterMessage;
        public static MessageEvent MakeInstance()
        {
            _masterMessage = new MessageEvent();
            return _masterMessage;
        }

        public static MessageEvent GetInstance()
        {
            return _masterMessage;
        }

        public void Publish<T>(T message)
        {
            _messageHub.Publish(message);
        }

        public Guid Subscribe<T>(System.Action<T> action)
        {
            return _messageHub.Subscribe(action);
        }

        public void UnSubscribe(Guid token)
        {
            _messageHub.Unsubscribe(token);
        }
    }
}
