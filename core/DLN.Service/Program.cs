using DLN.Core.Partitioning;
using DLN.Storage;
using System;
using System.IO;

namespace DLN.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var topic = new Topic
            (
                 "topic",
                true,
                Path.Combine(System.Environment.CurrentDirectory),
                4,
                new RoundRobinPartitionChooser(4)
            );

            for (int x = 0; x < 10; x++)
            {

                topic.Publish(new PublishRequest
                {
                    MessageData = System.Text.Encoding.UTF8.GetBytes("test message " + x.ToString()),
                    PartitionKey = x.ToString(),
                    PublishedAt = DateTimeOffset.UtcNow
                });
            }
        }
    }
}
