using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using HulkHvkDB;

namespace hulkUnitTest {
    class TestDiscount {
        [TestMethod]
        public void TestDiscountConstructors() {
            Discount disc1 = new Discount();
            Assert.AreEqual(0, disc1.number, "Testing disc1 number");
            Assert.AreEqual("", disc1.desc, "Testing disc1 description");
            Assert.AreEqual(0, disc1.per, "Testing disc1 percentage");
            Assert.AreEqual('t', disc1.type, "Testing disc1 type");

            Discount disc2 = new Discount(3, "Own Food", 0.1F, 'D');
            Assert.AreEqual(3, disc2.number, "Testing disc2 number");
            Assert.AreEqual("Own Food", disc2.desc, "Testing disc2 description");
            Assert.AreEqual(0.1F, disc2.per, "Testing disc2 percentage");
            Assert.AreEqual('D', disc2.type, "Testing disc2 type");
        }

        public void TestMutateFields() {
            Discount disc1 = new Discount(3, "Own Food", 0.1F, 'D');
            Assert.AreEqual(3, disc1.number, "Testing disc1 number");
            Assert.AreEqual("Own Food", disc1.desc, "Testing disc1 description");
            Assert.AreEqual(0.1F, disc1.per, "Testing disc1 percentage");
            Assert.AreEqual('D', disc1.type, "Testing disc1 type");

            disc1.number = 9;
            disc1.desc = "All Discounts combined";
            disc1.per = 0.9F;
            disc1.type = 'S';

            Assert.AreEqual(9, disc1.number, "Testing disc1 number");
            Assert.AreEqual("All Discounts combined", disc1.desc, "Testing disc1 description");
            Assert.AreEqual(0.9F, disc1.per, "Testing disc1 percentage");
            Assert.AreEqual('S', disc1.type, "Testing disc1 type");
        }
    }
}
