using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DLN.AMQP.Frames
{
    public static class AMQPSerializer
    {

        public static string ReadAMQPString(this BinaryReader reader)
        {
            int length = 0;
            var type = (Encodings)(int)reader.ReadByte();
            if (type == Encodings.string8)
            {
                length = reader.ReadByte();
            }
            else if (type == Encodings.string32)
            {
                length = reader.ReadInt32();
            }else if (type== Encodings.Null)
            {
                return null;
            }

            var bytes = reader.ReadBytes(length);

            return System.Text.Encoding.UTF8.GetString(bytes);

        }

        public static void WriteAMQPValue(this BinaryWriter writer, string value)
        {
            if (value.Length <= byte.MaxValue)
            {
                writer.Write((byte)Encodings.string8);
                writer.Write((byte)value.Length);

            }
            else
            {
                writer.Write((byte)Encodings.string32);
                writer.Write(value.Length);

            }
            writer.Write(System.Text.Encoding.UTF8.GetBytes(value));
            writer.Flush();
        }

        public static void WriteAMQPValue(this BinaryWriter writer, bool value)
        {
            if (value)
            {
                writer.Write((byte)Encodings.BooleanTrue);
            }
            else
            {
                writer.Write((byte)Encodings.BooleanFalse);
            }
            writer.Flush();
        }

        public static bool ReadAMQPBoolean(this BinaryReader reader)
        {

            var type = (Encodings)(int)reader.ReadByte();
            if (type == Encodings.BooleanTrue) return true;
            if (type == Encodings.BooleanFalse) return false;
            if (type == Encodings.boolean) return reader.ReadByte() != 0x00;
            throw new AMQPSerializationException("Type code is not a boolean. Its " + type.ToString());
        }
    }
}
