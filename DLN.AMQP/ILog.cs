using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.AMQP
{
    public interface ILog
    {

        void Trace(string message);
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
        void Info(string message);
    }
}
