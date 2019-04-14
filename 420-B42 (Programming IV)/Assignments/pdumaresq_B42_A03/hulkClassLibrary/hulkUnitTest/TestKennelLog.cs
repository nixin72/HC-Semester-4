using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using HulkHvkDB;

namespace hulkUnitTest {
    class TestKennelLog {
        [TestMethod]
        public void TestKennelLogConstructors() {
            KennelLog kennelLog1 = new KennelLog();
            Assert.AreEqual(new DateTime(), kennelLog1.logDate, "Testing kennelLog1 lodate");
            Assert.AreEqual(0, kennelLog1.seqNum, "Testing kennelLog1 sequence number");
            Assert.AreEqual("", kennelLog1.notes, "Testing kennelLog1 notes");
            Assert.AreEqual(0, kennelLog1.video, "Testing kennelLog1 video");

            KennelLog kennelLog2 = new KennelLog(DateTime.Now, 22, "Confirmed with morty's owner that the medicaton dosage is 150mg");
            Assert.AreEqual(DateTime.Now, kennelLog2.logDate, "Testing kennelLog2 lodate");
            Assert.AreEqual(22, kennelLog2.seqNum, "Testing kennelLog2 sequence number");
            Assert.AreEqual("Confirmed with morty's owner that the medicaton dosage is 150mg", kennelLog2.notes, "Testing kennelLog2 notes");
            Assert.AreEqual(0, kennelLog2.video, "Testing kennelLog2 video");

            KennelLog kennelLog3 = new KennelLog(DateTime.Now.AddDays(4), 34, "Mr Fluffs bit one of the workers, we need to inform the owner", 12);

            Assert.AreEqual(34, kennelLog3.seqNum, "Testing kennelLog3 sequence number");
            Assert.AreEqual("Mr Fluffs bit one of the workers, we need to inform the owner", kennelLog3.notes, "Testing kennelLog3 notes");
            Assert.AreEqual(12, kennelLog3.video, "Testing kennelLog3 video");


            KennelLog kennelLog4 = new KennelLog(DateTime.Now.AddDays(333), 65, "N/A", 15, new List<PetReservation>());
            Assert.AreEqual(DateTime.Now.AddDays(333), kennelLog4.logDate, "Testing kennelLog4 lodate");
            Assert.AreEqual(65, kennelLog4.seqNum, "Testing kennelLog4 sequence number");
            Assert.AreEqual("N/A", kennelLog4.notes, "Testing kennelLog4 notes");
            Assert.AreEqual(15, kennelLog4.video, "Testing kennelLog4 video");
        }

        public void TestMutateFields() {
            KennelLog kennelLog1 = new KennelLog(DateTime.Now.AddDays(333), 65, "N/A", 15, new List<PetReservation>());
            Assert.AreEqual(DateTime.Now.AddDays(333), kennelLog1.logDate, "Testing kennelLog1 lodate");
            Assert.AreEqual(65, kennelLog1.seqNum, "Testing kennelLog1 sequence number");
            Assert.AreEqual("N/A", kennelLog1.notes, "Testing kennelLog1 notes");
            Assert.AreEqual(15, kennelLog1.video, "Testing kennelLog1 video");

            kennelLog1.logDate = DateTime.Now.AddDays(222);
            kennelLog1.seqNum = 76;
            kennelLog1.notes = "vaccinations documentation was forged for owner #43";
            kennelLog1.video = 34;

            Assert.AreEqual(DateTime.Now.AddDays(222), kennelLog1.logDate, "Testing kennelLog1 lodate");
            Assert.AreEqual(76, kennelLog1.seqNum, "Testing kennelLog1 sequence number");
            Assert.AreEqual("vaccinations documentation was forged for owner #43", kennelLog1.notes, "Testing kennelLog1 notes");
            Assert.AreEqual(34, kennelLog1.video, "Testing kennelLog1 video");
        }
    }
}
