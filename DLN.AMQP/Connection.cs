using DLN.AMQP.Frames;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DLN.AMQP
{
    public class Connection
    {
        private TcpClient client;
        private ILog log;
        private Thread controllerThread;
        private NetworkStream networkStream;

        public Connection(TcpClient tcpClient, ILog log)
        {
            this.client = tcpClient;

            this.log = log;

            this.controllerThread = new Thread(this.Run);

            this.controllerThread.Start();
            
        }

        private void Run(object obj)
        {

            //start new connection by writing protocal header

            log.Info($"Connection Received From {client.Client.RemoteEndPoint.ToString()}");

            this.networkStream = client.GetStream();

            AMQPHeader.WriteToStream(networkStream);

            if (!AMQPHeader.ReadAndValidateHeader(networkStream))
            {
                log.Info("Client sent invalid/mismatched protocol header");
                CloseConnection();
                return;
            }

            while (true)
            {
                var frame = Frame.ReadFromStream(networkStream);
            }



        }

        private void CloseConnection()
        {
            log.Info("Closing Connection");
            client.Close();
        }
    }
}
