using DLN.Core.Configuration;
using DLN.Storage;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DLN.Core
{
    public class Broker
    {
        private BrokerConfig config;

        private ConcurrentDictionary<string, Topic> topics = new ConcurrentDictionary<string, Topic>();


        public void Run(BrokerConfig config)
        {

            this.config = config;

            LoadTopicsFromConfig(config);

            LoadTopicsFromDisk(config);


        }

        private void LoadTopicsFromDisk(BrokerConfig config)
        {
            var storageFolder = new DirectoryInfo(config.Storage.TopicsFolder);

            var subfolders = storageFolder.GetDirectories();

            foreach (var topicFolder in subfolders)
            {
                if (!topics.TryGetValue(topicFolder.Name, out Topic value))
                {

                }
            }
        
        }

        private void LoadTopicsFromConfig(BrokerConfig config)
        {
            foreach (var topicConfig in config.KnownTopicConfigs)
            {
                var topic = new Topic(topicConfig.Key,
                    topicConfig.Value.PrimaryBrokerId == config.BrokerId, config.Storage.TopicsFolder, topicConfig.Value.PartitionCount);

                if (!topics.TryAdd(topic.TopicName, topic))
                {
                    throw new DLNException($"Couldnt add topic from configuration. Topic '{topic.TopicName}'. Exists = {topics.TryGetValue(topic.TopicName, out Topic previous)}");
                }
            }
        }

    



        public void Shutdown()
        {

        }

    }
}
