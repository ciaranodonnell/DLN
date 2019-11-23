using DLN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Storage
{
    public class Topic : ITopic
    {

        public string TopicName { get; set; }


        public string StorageFolder { get; set; }


        public bool IsPrimary { get; set; }
                
        public byte[] Consume(long sequenceNumber)
        {
            throw new NotImplementedException();
        }

        public long Publish(byte[] message)
        {


            return 0;
        }
    }
}
