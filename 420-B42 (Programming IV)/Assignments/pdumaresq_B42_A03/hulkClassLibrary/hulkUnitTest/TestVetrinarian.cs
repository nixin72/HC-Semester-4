using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using HulkHvkDB;

namespace hulkUnitTest {
    class TestVetrinarian {
        [TestMethod]
        public void TestVeterinarianConstructors() {
            Vetrinarian vet1 = new Vetrinarian();
            Assert.AreEqual(0, vet1.number, "Testing vet1 number");
            Assert.AreEqual("", vet1.name, "Testing vet1 name");
            Assert.AreEqual("", vet1.phone, "Testing vet1 phone");
            Assert.AreEqual("", vet1.street, "Testing vet1 street");
            Assert.AreEqual("", vet1.city, "Testing vet1 city");
            Assert.AreEqual("", vet1.province, "Testing vet1 province");
            Assert.AreEqual("", vet1.postal, "Testing vet1 postal");

            Vetrinarian vet2 = new Vetrinarian(6, "Dr. Frankenstein", "8888888888");
            Assert.AreEqual(6, vet2.number, "Testing vet2 number");
            Assert.AreEqual("Dr. Frankenstein", vet2.name, "Testing vet2 name");
            Assert.AreEqual("8888888888", vet2.phone, "Testing vet2 phone");
            Assert.AreEqual("", vet2.street, "Testing vet2 street");
            Assert.AreEqual("", vet2.city, "Testing vet2 city");
            Assert.AreEqual("", vet2.province, "Testing vet2 province");
            Assert.AreEqual("", vet2.postal, "Testing vet2 postal");

            Vetrinarian vet3 = new Vetrinarian(2, "Dr. Sandy Beech", "8195559238", "No Street", "No City", "QC", "No Postal Code");
            Assert.AreEqual(2, vet3.number, "Testing vet3 number");
            Assert.AreEqual("Dr. Sandy Beech", vet3.name, "Testing vet3 name");
            Assert.AreEqual("8195559238", vet3.phone, "Testing vet3 phone");
            Assert.AreEqual("No Street", vet3.street, "Testing vet3 street");
            Assert.AreEqual("No City", vet3.city, "Testing vet3 city");
            Assert.AreEqual("QC", vet3.province, "Testing vet3 province");
            Assert.AreEqual("No Postal Code", vet3.postal, "Testing vet3 postal");
        }

        public void TestMutateFields() {
            Vetrinarian vet1 = new Vetrinarian(2, "Dr. Sandy Beech", "8195559238", "No Street", "No City", "QC", "No Postal Code");
            Assert.AreEqual(2, vet1.number, "Testing vet1 number");
            Assert.AreEqual("Dr. Sandy Beech", vet1.name, "Testing vet1 name");
            Assert.AreEqual("8195559238", vet1.phone, "Testing vet1 phone");
            Assert.AreEqual("No Street", vet1.street, "Testing vet1 street");
            Assert.AreEqual("No City", vet1.city, "Testing vet1 city");
            Assert.AreEqual("QC", vet1.province, "Testing vet1 province");
            Assert.AreEqual("No Postal Code", vet1.postal, "Testing vet1 postal");

            vet1.number = 5;
            vet1.name = "Dora Nob";
            vet1.phone = "8191111111";
            vet1.street = "New Springfield St.";
            vet1.city = "Springfield";
            vet1.province = "ON";
            vet1.postal = "E3R4T5";

            Assert.AreEqual(5, vet1.number, "Testing vet1 number");
            Assert.AreEqual("Dora Nob", vet1.name, "Testing vet1 name");
            Assert.AreEqual("8191111111", vet1.phone, "Testing vet1 phone");
            Assert.AreEqual("New Springfield St.", vet1.street, "Testing vet1 street");
            Assert.AreEqual("Springfield", vet1.city, "Testing vet1 city");
            Assert.AreEqual("ON", vet1.province, "Testing vet1 province");
            Assert.AreEqual("E3R4T5", vet1.postal, "Testing vet1 postal");

        }
    }
}
