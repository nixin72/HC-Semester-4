using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using HulkHvkDB;

namespace hulkUnitTest {
    [TestClass]
    class TestDailyRate {
        [TestMethod]
        public void TestDailyRateConstructors() {
            DailyRate daily1 = new DailyRate();
            Assert.AreEqual(0, daily1.number, "Testing daily1 number");
            Assert.AreEqual(0, daily1.rate, "Testing daily1 rate");
            Assert.AreEqual('s', daily1.dogSize, "Testing daily1 dog size");
            Assert.AreEqual(0, daily1.serviceNumber, "Testing daily1 service number");

            DailyRate daily2 = new DailyRate(3, 12F);
            Assert.AreEqual(3, daily2.number, "Testing daily2 number");
            Assert.AreEqual(12F, daily2.rate, "Testing daily2 rate");
            Assert.AreEqual('s', daily2.dogSize, "Testing daily2 dog size");
            Assert.AreEqual(0, daily2.serviceNumber, "Testing daily2 service number");

            DailyRate daily3 = new DailyRate(7, 2F, 's', 3);
            Assert.AreEqual(7, daily3.number, "Testing daily3 number");
            Assert.AreEqual(2F, daily3.rate, "Testing daily3 rate");
            Assert.AreEqual('s', daily3.dogSize, "Testing daily3 dog size");
            Assert.AreEqual(3, daily3.serviceNumber, "Testing daily3 service number");
        }

        public void TestMutateFields() {
            DailyRate daily1 = new DailyRate(7, 2F, 's', 3);
            Assert.AreEqual(7, daily1.number, "Testing daily1 number");
            Assert.AreEqual(2F, daily1.rate, "Testing daily1 rate");
            Assert.AreEqual('s', daily1.dogSize, "Testing daily1 dog size");
            Assert.AreEqual(3, daily1.serviceNumber, "Testing daily1 service number");

            daily1.number = 4;
            daily1.rate = 1F;
            daily1.dogSize = 'L';
            daily1.serviceNumber = 9;

            Assert.AreEqual(4, daily1.number, "Testing daily1 number");
            Assert.AreEqual(1F, daily1.rate, "Testing daily1 rate");
            Assert.AreEqual('L', daily1.dogSize, "Testing daily1 dog size");
            Assert.AreEqual(9, daily1.serviceNumber, "Testing daily1 service number");
        }
    }
}
