using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.AMQP
{
    public enum ConnectionState
    {
        Start,
        HeaderReceived,
        HeaderSent,
        HeaderExchanged,
        OpenPipe,
        OCPipe,
        OpenReceived,
        OpenSent,
        ClosePipe,
        Opened,
        CloseReceived,
        ClosedSent,
        Discarding,
        End
    }
}
