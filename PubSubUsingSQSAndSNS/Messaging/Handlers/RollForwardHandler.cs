
using Messaging.Commands;
using Messaging.Interfaces;
using Messaging.Messages;

namespace Messaging.Handlers
{
    public class RollForwardHandler : IMessageHandler
    {
        public void Handle(Message message)
        {
            var rollForwardMessage = message.Body as RollForward;
            if(rollForwardMessage != null)
            {
                //handle the message 
            }
            
        }
    }
}
