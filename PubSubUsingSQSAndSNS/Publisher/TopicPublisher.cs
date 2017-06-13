using Messaging;
using Messaging.Entities;
using Messaging.Events;
using Messaging.Interfaces;
using Messaging.Messages;
using System;
using System.Collections.Generic;

namespace Publisher
{
    public class TopicPublisher
    {
        private static ITopicClient TopicClient;

        public static void Run()
        {
            SetupTopicClient();
            PublishTopic();
        }

        private static void SetupTopicClient()
        {
            TopicClient = new Messaging.TopicClient(Topic.Top10Projects);
            Console.WriteLine("--Publisher ready--");
        }

        private static void PublishTopic()
        {

            var cmd = Console.ReadLine();
            while (cmd != "x")
            {
                PublishMockTop10();
                cmd = Console.ReadLine();
            }
        }

        private static void PublishMockTop10()
        {
            var top10 = GetMockTop10();
            TopicClient.Publish(new Message
            {
                Body = top10
            });
            Console.WriteLine("Published new Top 10");
        }

        public static NewTop10 GetMockTop10()
        {
            var count = (long)Math.Round(new Random().NextDouble() * 100);
            var summaries = new List<ProjectSummary>();
            for (int i = 1; i < 11; i++)
            {
                summaries.Add(new ProjectSummary()
                {
                    Id = i,
                    Title = Program.GetRandomProjects(),
                    Transactions = (11 - i) * count
                });
            }
            var top10 = new NewTop10()
            {
                ProjectSummaries = summaries,
                LastUpdated = DateTime.UtcNow
            };
            return top10;
        }
    }
}
