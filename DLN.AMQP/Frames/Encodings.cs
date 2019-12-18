using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.AMQP.Frames
{
    public enum Encodings
    {
        /// <summary>
        /// fixed/0 the null value
        /// </summary>
        Null = 0x40,
        /// <summary>
        /// fixed/1 boolean with the octet 0x00 being false and octet 0x01 being true
        /// </summary>
        boolean = 0x56,
        /// <summary>
        /// fixed/0 the boolean value true
        /// </summary>
        BooleanTrue = 0x41,
        /// <summary>
        /// fixed/0 the boolean value false
        /// </summary>
        BooleanFalse = 0x42,
        /// <summary>
        /// fixed/1 8-bit unsigned integer
        /// </summary>
        ubyte = 0x50,
        /// <summary>
        /// fixed/2 16-bit unsigned integer in network byte order
        /// </summary>
        @ushort = 0x60,
        /// <summary>
        /// fixed/4 32-bit unsigned integer in network byte order
        /// </summary>
        @uint = 0x70,
        /// <summary>
        /// smalluint 0x52 fixed/1 unsigned integer value in the range 0 to 255 inclusive
        /// </summary>
        @uint8 = 0x52,
        /// <summary>
        /// fixed/0 the uint value 0
        /// </summary>
        @uint0 = 0x43,
        /// <summary>
        /// fixed/8 64-bit unsigned integer in network byte order
        /// </summary>
        @ulong = 0x80,
        /// <summary>
        /// fixed/1 unsigned long value in the range 0 to 255 inclusive
        /// </summary>
        @ulong8 = 0x53,
        /// <summary>
        /// fixed/0 the ulong value 0
        /// </summary>
        @ulong0 = 0x44,
        /// <summary>
        ///  fixed/1 8-bit two’s-complement integer
        /// </summary>
        @byte = 0x51,
        /// <summary>
        /// fixed/2 16-bit two’s-complement integer in network byte order
        /// </summary>
        @short = 0x61,
        /// <summary>
        /// fixed/4 32-bit two’s-complement integer in network byte order
        /// </summary>
        @int = 0x71,
        /// <summary>
        /// // fixed/1 signed integer value in the range -128 to 127 inclusive
        /// </summary>
        @int8 = 0x54,
        /// <summary>
        /// fixed/8 64-bit two’s-complement integer in network byte order
        /// </summary>
        @long64 = 0x81,
        /// <summary>
        ///fixed/1 signed long value in the range -128 to 127 inclusive
        /// </summary>
        @long8 = 0x55,
        /// <summary>
        /// fixed/4 IEEE 754-2008 binary32
        /// </summary>
        @float = 0x72,
        /// <summary>
        /// fixed/8 IEEE 754-2008 binary64
        /// </summary>
        @double = 0x82,
        /// <summary>
        /// fixed/4 IEEE 754-2008 decimal32 using the Binary Integer Decimal encoding
        /// </summary>
        decimal32 = 0x74,
        /// <summary>
        /// fixed/ 8 IEEE 754 - 2008 decimal64 using the Binary Integer Decimal encoding
        /// </summary>
        decimal64 = 0x84,
        /// <summary>
        /// fixed/ 16 IEEE 754 - 2008 decimal128 using the Binary    Integer Decimal encoding
        /// </summary>
        decimal128 = 0x94,
        /// <summary>
        ///  fixed/ 4 a UTF - 32BE encoded unicode character 
        /// </summary>
        char_utf32 = 0x73,
        /// <summary>
        /// fixed/ 8 64 - bit signed integer representing milliseconds since the unix epoch
        /// </summary>
        timestamp = 0x83,
        /// <summary>
        /// fixed/ 16 UUID as defined in section 4.1.2 of RFC - 4122
        /// </summary>
        uuid = 0x98,
        /// <summary>
        /// variable / 1 up to 2^8 - 1 octets of binary data
        /// </summary>
        binary8 = 0xa0,
        /// <summary>
        /// variable / 4 up to 232 - 1 octets of binary data
        /// </summary>
        binary32 = 0xb0,
        /// <summary>
        /// variable / 1 up to 2^8 - 1 octets worth of
        /// </summary>
        @string8 = 0xa1,
        /// <summary>
        /// variable/4 up to 232 - 1 octets worth of UTF-8 unicode (with no byte order mark)
        /// </summary>
        @string32 = 0xb1,

        /// <summary>
        ///  variable/1 up to 2^8 - 1 seven bit ASCII characters representing a symbolic value
        /// </summary>
        symbol8 = 0xa3,
        /// <summary>
        /// variable/4 up to 2^32 - 1 seven bit ASCII characters representing a symbolic value
        /// </summary>
        symbol32 = 0xb3,
        /// <summary>
        ///  fixed/0 the empty list (i.e. the list with no elements)
        /// </summary>
        list0 = 0x45,
        /// <summary>
        /// compound/1 up to 2^8- 1 list elements with total size less than 28 octets
        /// /// </summary>
        list8 = 0xc0,
        /// <summary>
        ///  compound/4 up to 232 - 1 list elements with total size less than 232 octets
        /// </summary>
        list32 = 0xd0,
        /// <summary>
        /// compound/1 up to 28 - 1 octets of encoded map data
        /// </summary>
        map8 = 0xc1,
        /// <summary>
        /// compound/4 up to 232 - 1 octets of encoded map data
        /// </summary>
        map32 = 0xd1,
        /// <summary>
        /// array/4 up to 232 - 1 array
        /// </summary>
        array8 = 0xe0,
        /// <summary>
        /// array/4 up to 232 - 1 array
        /// </summary>
        array32 = 0xf0
    }
}
