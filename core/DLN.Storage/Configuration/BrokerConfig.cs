using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core.Configuration
{
    public class BrokerConfig
    {

        public BrokerConfig()
        {
            KnownTopicConfigs = new Dictionary<string, TopicConfig>();
        }


        public StorageConfig Storage { get; set; }

        public TopicConfig DefaultTopicConfig { get; set; }

        public Dictionary<string, TopicConfig> KnownTopicConfigs { get; protected set; }
        
        
        public string ClusterName { get; set; }
        
        public int BrokerId { get; internal set; }


    }
}
