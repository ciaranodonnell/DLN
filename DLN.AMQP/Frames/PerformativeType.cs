namespace DLN.AMQP.Frames
{
    public enum PerformativeType
    {
        Open = 0x10,
        Begin = 0x11,
        Attach = 0x12,
        Flow = 0x13,
        Transfer = 0x14,
        Disposition = 0x15,
        Detach = 0x16,
        End = 0x17,
        Close = 0x18
    }
}