using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DLN.AMQP
{
    public class Server : Container
    {
        private int portNumber;
        private TcpListener listener;

        public Server(int portNumber)
        {

            this.portNumber = portNumber;
        }


        public void StartListening(CancellationToken cancelToken)
        {
            this.listener = System.Net.Sockets.TcpListener.Create(this.portNumber);

            listener.Start();


            while (!cancelToken.IsCancellationRequested)
            {
                listener.AcceptTcpClient();
                


            }


        }




    }
}
