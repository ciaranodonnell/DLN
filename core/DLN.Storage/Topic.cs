using DLN.Core.Interfaces;
using DLN.Core.Partitioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DLN.Storage
{
    public class Topic : ITopic
    {
        private List<Partition> partitions;
        long nextSequenceNumber = 0;
        public Topic(string topicName, bool isPrimary, string mainStorageFolder, int partitionCount, IPartitionChooser partitionChooser)
        {
            this.TopicName = topicName;
            this.IsPrimary = IsPrimary;

            this.PartitionCount = partitionCount;
            this.PartitionChooser = partitionChooser;

            InitializeTopic(mainStorageFolder);
        }

        private void InitializeTopic(string rootStorageFolder)
        {
            this.StorageFolder = Path.Combine(rootStorageFolder, TopicName);

            this.partitions = new List<Partition>(PartitionCount);

            for (int x = 0; x < PartitionCount; x++)
            {
                var p = new Partition(this, x);
                partitions.Add(p);
                if (nextSequenceNumber < p.MaxSequenceNumber) nextSequenceNumber = p.MaxSequenceNumber; 
            }
            //its set to the max, increment so its the next sequence number
            nextSequenceNumber++;


        }

        public string TopicName { get; set; }

        public int PartitionCount
        {
            get; private set;
        }


        public IPartitionChooser PartitionChooser { get; private set; }

        public string StorageFolder { get; set; }


        public bool IsPrimary { get; set; }

        public byte[] Consume(long sequenceNumber)
        {
            throw new NotImplementedException();
        }

        public long Publish(PublishRequest pubRequest)
        {
            //Set the sequence number to the next sequence number. this is incremented at the end so failed writes dont increment the number causing gaps.
            pubRequest.SequenceNumber = nextSequenceNumber;
            var partition = PartitionChooser.WhatPartition(pubRequest.PartitionKey);
            partitions[partition].Produce(pubRequest);
            nextSequenceNumber++;

            return 0;
        }
    }
}
