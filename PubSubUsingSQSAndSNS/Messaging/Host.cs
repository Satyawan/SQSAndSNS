using Messaging.Interfaces;
using Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging
{
    public class Host
    {
        private static List<Task> _clientTasks;
        private static Dictionary<string, IQueueClient> _clients;
        private ManualResetEvent _completedEvent;


        private void EnsureAndSubscribeQueue(string queueName)
        {
            if (!_clients.ContainsKey(queueName))
            {
                var client = new QueueClient(queueName);
                client.Subscribe(OnMessageReceived);
                _clients.Add(queueName, client);
            }
        }

        private static void OnMessageReceived(Message message)
        {
            try
            {
                var handler = MessageHandlerFactory.GetMessageHandler(message);
                handler.Handle(message);
            }
            catch (Exception ex)
            {
                //TODO - Log exception.
            }
        }

        public void Start(bool keepAlive = true)
        {
            try
            {
                _clients = new Dictionary<string, IQueueClient>();
                _clientTasks = new List<Task>
                {
                    Task.Factory.StartNew(() => EnsureAndSubscribeQueue(Queue.RollFowardQueue)),
                };
                if (keepAlive)
                {
                    _completedEvent = new ManualResetEvent(false);
                    _completedEvent.WaitOne();
                }
            }
            catch (Exception ex)
            {
                //TODO - Log exception.
            }
        }

        public void Stop()
        {
            _clientTasks.ForEach(x => x.Dispose());
            _clients = new Dictionary<string, IQueueClient>();
            if (_completedEvent != null)
            {
                _completedEvent.Set();
            }
        }

    }
}
