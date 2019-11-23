using DLN.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core.Interfaces
{
    public interface ITopic
    {

        string TopicName { get; }

        long Publish(PublishRequest pubRequest);


        byte[] Consume(long sequenceNumber);


    }
}
