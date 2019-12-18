using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace DLN.AMQP
{
    internal class AMQPHeader
    {

        const byte A = 41;
        const byte M = 77;
        const byte Q = 51;
        const byte P = 50;

        static AMQPHeader()
        {
        }

        public static byte[] AMQPBytes { get; }

        internal static void WriteToStream(Stream stream)
        {

            stream.WriteByte(A);
            stream.WriteByte(M);
            stream.WriteByte(P);
            stream.WriteByte(Q);
            stream.WriteByte(0);
            stream.WriteByte(1);
            stream.WriteByte(0);
            stream.WriteByte(0);

            stream.Flush();

        }

        internal static bool ReadAndValidateHeader(Stream stream)
        {
            byte[] header = new byte[8];
            stream.Read(header, 0, 8);

            if (header[0] != A) return false;
            if (header[0] != M) return false;
            if (header[0] != Q) return false;
            if (header[0] != P) return false;
            if (header[0] != 0) return false;
            if (header[0] != 1) return false;
            if (header[0] != 0) return false;
            if (header[0] != 0) return false;

            return true;
        }
    }
}