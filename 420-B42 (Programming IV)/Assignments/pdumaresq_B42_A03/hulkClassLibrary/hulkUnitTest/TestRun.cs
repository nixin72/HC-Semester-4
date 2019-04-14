using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using HulkHvkDB;

namespace hulkUnitTest {
    class TestRun {
        [TestMethod]
        public void TestRunConstructors() {
            Run run1 = new Run();
            Assert.AreEqual(0, run1.number, "Testing run1 number");
            Assert.AreEqual('s', run1.size, "Testing run1 size");
            Assert.AreEqual('y', run1.covered, "Testing run1 covered");
            Assert.AreEqual('f', run1.location, "Testing run1 location");
            Assert.AreEqual(0, run1.status, "Testing run1 status");

            Run run2 = new Run(40, 'm');
            Assert.AreEqual(40, run2.number, "Testing run2 number");
            Assert.AreEqual('m', run2.size, "Testing run2 size");
            Assert.AreEqual('y', run2.covered, "Testing run2 covered");
            Assert.AreEqual('f', run2.location, "Testing run2 location");
            Assert.AreEqual(0, run2.status, "Testing run2 status");

            Run run3 = new Run(32, 'l', 'n', 'b', 1);
            Assert.AreEqual(32, run3.number, "Testing run3 number");
            Assert.AreEqual('l', run3.size, "Testing run3 size");
            Assert.AreEqual('n', run3.covered, "Testing run3 covered");
            Assert.AreEqual('b', run3.location, "Testing run3 location");
            Assert.AreEqual(1, run3.status, "Testing run3 status");
        }

        public void TestMutateFields() {
            Run run1 = new Run(32, 'l', 'n', 'b', 1);
            Assert.AreEqual(32, run1.number, "Testing run1 number");
            Assert.AreEqual('l', run1.size, "Testing run1 size");
            Assert.AreEqual('n', run1.covered, "Testing run1 covered");
            Assert.AreEqual('b', run1.location, "Testing run1 location");
            Assert.AreEqual(1, run1.status, "Testing run1 status");

            run1.number = 22;
            run1.size = 'S';
            run1.covered = 'y';
            run1.location = 'b';
            run1.status = 2;

            Assert.AreEqual(22, run1.number, "Testing run1 number");
            Assert.AreEqual('S', run1.size, "Testing run1 size");
            Assert.AreEqual('y', run1.covered, "Testing run1 covered");
            Assert.AreEqual('b', run1.location, "Testing run1 location");
            Assert.AreEqual(2, run1.status, "Testing run1 status");
        }
    }
}
