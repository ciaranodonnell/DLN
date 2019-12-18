using DLN.AMQP.Frames;
using NUnit.Framework;
using System.IO;

namespace DLN.AMQP.UnitTests
{
    public class AQMPSerializerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWriteAndReadShortString()
        {

            MemoryStream ms = new MemoryStream();

            BinaryWriter bw = new BinaryWriter(ms);


            bw.WriteAMQPValue("hello world");

            ms.Position = 0;

            BinaryReader br = new BinaryReader(ms);

            var value = br.ReadAMQPString();

            Assert.AreEqual("hello world", value);


        }


        [Test]
        public void TestWriteAndRead2ShortStrings()
        {

            MemoryStream ms = new MemoryStream();

            BinaryWriter bw = new BinaryWriter(ms);


            bw.WriteAMQPValue("hello world");

            bw.WriteAMQPValue("this is a test");

            ms.Position = 0;

            BinaryReader br = new BinaryReader(ms);

            var value = br.ReadAMQPString();
            var value2 = br.ReadAMQPString();

            Assert.AreEqual("hello world", value);
            Assert.AreEqual("this is a test", value2);


        }

        [Test]
        public void TestReadAndWriteFalse()
        {

            MemoryStream ms = new MemoryStream();

            BinaryWriter bw = new BinaryWriter(ms);

            bw.WriteAMQPValue(false);
            ms.Position = 0;

            BinaryReader br = new BinaryReader(ms);

            var value = br.ReadAMQPBoolean();

            Assert.AreEqual(false, value);


        }

        [Test]
        public void TestReadAndWriteTrue()
        {

            MemoryStream ms = new MemoryStream();

            BinaryWriter bw = new BinaryWriter(ms);

            bw.WriteAMQPValue(true);
            ms.Position = 0;

            BinaryReader br = new BinaryReader(ms);

            var value = br.ReadAMQPBoolean();

            Assert.AreEqual(true, value);


        }


        [Test]
        public void TestReadLongFalse()
        {

            MemoryStream ms = new MemoryStream();

            BinaryWriter bw = new BinaryWriter(ms);

                       
            bw.Write((byte)0x56);
            bw.Write((byte)0x00);

            bw.WriteAMQPValue(false);
            ms.Position = 0;

            BinaryReader br = new BinaryReader(ms);

            var value = br.ReadAMQPBoolean();

            Assert.AreEqual(false, value);


        }

        [Test]
        public void TestReadLongTrue()
        {

            MemoryStream ms = new MemoryStream();

            BinaryWriter bw = new BinaryWriter(ms, System.Text.Encoding.BigEndianUnicode);

            bw.Write((byte)0x56);
            bw.Write((byte)0x01);

            ms.Position = 0;

            BinaryReader br = new BinaryReader(ms);

            var value = br.ReadAMQPBoolean();

            Assert.AreEqual(true, value);


        }

        [Test]
        public void TestReadAndWriteAllBools()
        {

            MemoryStream ms = new MemoryStream();

            BinaryWriter bw = new BinaryWriter(ms);


            bw.WriteAMQPValue(false);

            bw.WriteAMQPValue(true);
            bw.Write((byte)0x56);
            bw.Write((byte)0x00);
            bw.Write((byte)0x56);
            bw.Write((byte)0x01);
            ms.Position = 0;

            BinaryReader br = new BinaryReader(ms);

            var value = br.ReadAMQPBoolean();
            var value2 = br.ReadAMQPBoolean();
            var value3 = br.ReadAMQPBoolean();
            var value4 = br.ReadAMQPBoolean();

            Assert.AreEqual(false, value);
            Assert.AreEqual(true, value2);
            Assert.AreEqual(false, value3);
            Assert.AreEqual(true, value4);


        }
    }
}