using System;
using Messaging.Messages;

namespace Messaging.Interfaces
{
    public interface IClient
    {
        void Subscribe(Action<Message> onMessageReceived);
        void Unsubscribe();
        bool HasMessages();
        bool IsListening();
    }
}
