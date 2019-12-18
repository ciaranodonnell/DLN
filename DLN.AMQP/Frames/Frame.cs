using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace DLN.AMQP.Frames
{
    class Frame
    {
        private const int BufferSize = 4096;

        internal static Frame ReadFromStream(Stream stream)
        {
            Frame frame = new Frame();


            byte[] buffer = new byte[BufferSize];

            BinaryReader br = new BinaryReader(stream);
            var size = br.ReadInt32();
            var dataOffset = br.ReadByte();
            var type = br.ReadByte();

            var frameType = (FrameType)((int)type);

            if (frameType == FrameType.AMQP)
            {
                return AMQPFrame.ReadFromStream(br, size, dataOffset, frameType);

            }
            else if (frameType == FrameType.SASL)
            {

            }
            else
            {
                throw new Exception("Unknown FrameType " + frameType.ToString());
            }

            stream.Read(buffer, 0, 8);



            return frame;
        }




        
        protected static String ReadString(BinaryReader reader, int? length=null)
        {
            return reader.ReadString();
        }


    }
}
