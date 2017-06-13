using Messaging.Messages;

namespace Messaging.Interfaces
{
    public interface IQueueClient : IClient
    {
        string QueueName { get; }
        void Send(Message message);
        void DeleteQueue();
    }
}
