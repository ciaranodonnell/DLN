using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core
{
    class ConsumerGroup
    {

        public string Name { get; set; }

        public ConcurrentDictionary<string, ConcurrentDictionary<int, long>> TopicPartitionOffsets { get; private set; }


    }
}
