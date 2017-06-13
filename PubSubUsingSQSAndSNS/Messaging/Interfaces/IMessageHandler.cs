using Messaging.Messages;

namespace Messaging.Interfaces
{
    public interface IMessageHandler
    {
        void Handle(Message message);
    }
}
