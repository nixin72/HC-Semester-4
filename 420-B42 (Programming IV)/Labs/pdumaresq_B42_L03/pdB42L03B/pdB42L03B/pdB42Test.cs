using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankLibrary;

namespace pdB42L03B
{
    [TestClass]
    public class pdB42Test
    {
        [TestMethod]
        public void testConstructors() {
            BankAccount acc = new BankAccount("Philip", 100.00);
            Assert.AreEqual("Philip", acc.CustomerName);
            Assert.AreEqual(100.00, acc.Balance);

        }

        [TestMethod]
        public void testDebit() {

        }
    }
}
