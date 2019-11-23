using DLN.Core.Partitioning;
using NUnit.Framework;

namespace DLN.Core.NUnitTests
{
    public class RoundRobinPartitioningTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestItWorksWith4()
        {
            RoundRobinPartitionChooser pc = new RoundRobinPartitionChooser(4);
            Assert.AreEqual(pc.WhatPartition("any value"), 0);
            Assert.AreEqual(pc.WhatPartition("any value"), 1);
            Assert.AreEqual(pc.WhatPartition("any value"), 2);
            Assert.AreEqual(pc.WhatPartition(null), 3);
            Assert.AreEqual(pc.WhatPartition(null), 0);
        }


        public void TestItWorksWith2()
        {
            RoundRobinPartitionChooser pc = new RoundRobinPartitionChooser(2);
            Assert.AreEqual(pc.WhatPartition("any value"), 0);
            Assert.AreEqual(pc.WhatPartition("any value"), 1);
            Assert.AreEqual(pc.WhatPartition("any value"), 0);
            Assert.AreEqual(pc.WhatPartition("any value"), 1);
            Assert.AreEqual(pc.WhatPartition("any value"), 0);
            Assert.AreEqual(pc.WhatPartition(null), 1);
            Assert.AreEqual(pc.WhatPartition(null), 0);
            Assert.AreEqual(pc.WhatPartition(null), 1);
        }
    }
}