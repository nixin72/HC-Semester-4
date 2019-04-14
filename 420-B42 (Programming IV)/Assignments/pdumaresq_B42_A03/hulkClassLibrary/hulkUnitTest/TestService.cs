using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using HulkHvkDB;

namespace hulkUnitTest {
    class TestService {
        [TestMethod]
        public void TestServiceConstructors() {
            Service serv1 = new Service();
            Assert.AreEqual(0, serv1.number, "Testing serv1 number");
            Assert.AreEqual("", serv1.desc, "Testing serv1 description");
            Assert.AreEqual(0, serv1.petResNumber, "Testing serv1 pet reservation number");
            Assert.AreEqual(0, serv1.frequency, "Testing serv1 frequency");
            Assert.AreEqual(new DailyRate(), serv1.rate, "Testing serv1 rate");

            Service serv2 = new Service(1, "Boarding", 12);
            Assert.AreEqual(1, serv2.number, "Testing serv2 number");
            Assert.AreEqual("Boarding", serv2.desc, "Testing serv2 description");
            Assert.AreEqual(12, serv2.petResNumber, "Testing serv2 pet reservation number");
            Assert.AreEqual(0, serv2.frequency, "Testing serv2 frequency");
            Assert.AreEqual(new DailyRate(), serv2.rate, "Testing serv2 rate");

            Service serv3 = new Service(3, "Grooming", 15, 2);
            Assert.AreEqual(3, serv3.number, "Testing serv3 number");
            Assert.AreEqual("Grooming", serv3.desc, "Testing serv3 description");
            Assert.AreEqual(15, serv3.petResNumber, "Testing serv3 pet reservation number");
            Assert.AreEqual(2, serv3.frequency, "Testing serv3 frequency");
            Assert.AreEqual(new DailyRate(), serv3.rate, "Testing serv3 rate");

            Service serv4 = new Service(5, "Playtime", 123, 1, new DailyRate());
            Assert.AreEqual(5, serv4.number, "Testing serv4 number");
            Assert.AreEqual("Playtime", serv4.desc, "Testing serv4 description");
            Assert.AreEqual(123, serv4.petResNumber, "Testing serv4 pet reservation number");
            Assert.AreEqual(1, serv4.frequency, "Testing serv4 frequency");
            Assert.AreEqual(new DailyRate(), serv4.rate, "Testing serv4 rate");
        }

        public void TestMutateFields() {
            Service serv1 = new Service(5, "Playtime", 123, 1, new DailyRate());
            Assert.AreEqual(5, serv1.number, "Testing serv1 number");
            Assert.AreEqual("Playtime", serv1.desc, "Testing serv1 description");
            Assert.AreEqual(123, serv1.petResNumber, "Testing serv1 pet reservation number");
            Assert.AreEqual(1, serv1.frequency, "Testing serv1 frequency");
            Assert.AreEqual(new DailyRate(), serv1.rate, "Testing serv1 rate");

            serv1.number = 7;
            serv1.desc = "Pet palooza";
            serv1.petResNumber = 4;
            serv1.frequency = 2;
            serv1.rate = new DailyRate();

            Assert.AreEqual(7, serv1.number, "Testing serv1 number");
            Assert.AreEqual("Pet palooza", serv1.desc, "Testing serv1 description");
            Assert.AreEqual(4, serv1.petResNumber, "Testing serv1 pet reservation number");
            Assert.AreEqual(2, serv1.frequency, "Testing serv1 frequency");
            Assert.AreEqual(new DailyRate(), serv1.rate, "Testing serv1 rate");
        }
    }
}
