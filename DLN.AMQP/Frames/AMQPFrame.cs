using DLN.AMQP.Frames.Performatives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DLN.AMQP.Frames
{
    class AMQPFrame : Frame
    {

        public AMQPFrame(BinaryReader reader, int doff, int size, int channelNumber)
        {

        }


        public virtual PerformativeType Performative { get; }

        internal static Frame ReadFromStream(BinaryReader br, int size, byte dataOffset, FrameType frameType)
        {
            var channelNumber = br.ReadUInt16();

            var ignoredExtendedHeader = br.ReadBytes((dataOffset * 4) - 8);

            var performative = (PerformativeType)(int)br.ReadByte();

            AMQPFrame frame = null;

            switch (performative)
            {
                case PerformativeType.Open:
                    frame = new OpenFrame(br, dataOffset, size, channelNumber);
                    break;
            }

            return frame;

        }
    }
}
