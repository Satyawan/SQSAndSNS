using Messaging;
using Messaging.Events;
using Messaging.Interfaces;
using Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber
{
    public static class TopicSubscriber
    {

        private static Random Random = new Random();
        private static ITopicClient TopicClient;

        public static void Run(string[] args)
        {
            string subName;
            if (args.Length < 1)
            {
                Console.WriteLine("Subscription name?");
                subName = Console.ReadLine();
            }
            else
            {
                subName = args[0];
            }
            Console.Title = "Topic subscriber: " + subName;
            Subscribe(subName);
        }

        private static void Subscribe(string subName)
        {
            TopicClient = new TopicClient(Topic.Top10Projects, subName);
            TopicClient.Subscribe(OnMessageReceived);

            Console.ReadLine();
        }

        private static void OnMessageReceived(Message message)
        {
            var top10 = message.Body as NewTop10;
            Console.WriteLine("Message received to this subscription ");
            foreach (var summary in top10.ProjectSummaries.OrderBy(x => x.Id))
            {
                Console.WriteLine(summary);
            }
            Console.WriteLine("");
            
        }
    }
}
