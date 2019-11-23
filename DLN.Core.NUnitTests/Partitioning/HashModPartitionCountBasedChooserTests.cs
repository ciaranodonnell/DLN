using DLN.Core.Partitioning;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core.NUnitTests.Partitioning
{
    public class HashModPartitionCountBasedChooserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestItWorksWith4()
        {

            var pc = new HashModPartitionCountBasedChooser(4);
            Assert.AreEqual(pc.WhatPartition("any value"), pc.WhatPartition("any value"));
            Assert.AreEqual(pc.WhatPartition("17"), pc.WhatPartition("17"));
            

        }

    }
}
