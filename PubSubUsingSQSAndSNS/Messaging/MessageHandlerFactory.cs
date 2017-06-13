using System.Collections.Generic;
using Messaging.Interfaces;
using Messaging.Commands;
using Messaging.Messages;
using Messaging.Extensions;
using Messaging.Handlers;

namespace Messaging
{
    public static class MessageHandlerFactory
    {
        private static Dictionary<string, IMessageHandler> _Handlers;

        static MessageHandlerFactory()
        {
            _Handlers = new Dictionary<string, IMessageHandler>();
            _Handlers.Add(typeof(RollForward).GetMessageType(), new RollForwardHandler());
        }

        public static IMessageHandler GetMessageHandler(Message message)
        {
            return _Handlers[message.Body.GetMessageType()];
        }
    }
}
