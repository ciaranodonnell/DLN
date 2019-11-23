using DLN.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core
{
    public class Broker
    {
        private BrokerConfig config;

        public void Run(BrokerConfig config)
        {

            this.config = config;
        }


        public void Shutdown()
        {

        }

    }
}
