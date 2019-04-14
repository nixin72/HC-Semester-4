using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;

namespace hulkUnitTest {
    class TestVaccination {
        [TestMethod]
        public void TestVaccinationConstructors() {
            Vaccination vacc1 = new Vaccination();
            Assert.AreEqual(0, vacc1.number, "Testing vacc1 number");
            Assert.AreEqual("", vacc1.name, "Testing vacc1 name");
            Assert.AreEqual(0, vacc1.petNumber, "Testing vacc1 pet number");
            Assert.AreEqual(false, vacc1.checkedStatus, "Testing vacc1 checked status");
            Assert.AreEqual(new DateTime(), vacc1.expiryDate, "Testing vacc1 expiry date");

            Vaccination vacc2 = new Vaccination(3, "Hepatitus");
            Assert.AreEqual(3, vacc2.number, "Testing vacc2 number");
            Assert.AreEqual("Hepatitus", vacc2.name, "Testing vacc2 name");
            Assert.AreEqual(0, vacc2.petNumber, "Testing vacc2 pet number");
            Assert.AreEqual(false, vacc2.checkedStatus, "Testing vacc2 checked status");
            Assert.AreEqual(new DateTime(), vacc2.expiryDate, "Testing vacc2 expiry date");

            Vaccination vacc3 = new Vaccination(4, "Parainfluenza", 13, true, DateTime.Now.AddDays(40));
            Assert.AreEqual(4, vacc3.number, "Testing vacc3 number");
            Assert.AreEqual("Parainfluenza", vacc3.name, "Testing vacc3 name");
            Assert.AreEqual(13, vacc3.petNumber, "Testing vacc3 pet number");
            Assert.AreEqual(true, vacc3.checkedStatus, "Testing vacc3 checked status");
            Assert.AreEqual(DateTime.Now.AddDays(40), vacc3.expiryDate, "Testing vacc3 expiry date");
        }

         public void TestMutateFields() {
            Vaccination vacc1 = new Vaccination(4, "Parainfluenza", 13, true, DateTime.Now.AddDays(40));
            Assert.AreEqual(4, vacc1.number, "Testing vacc1 number");
            Assert.AreEqual("Parainfluenza", vacc1.name, "Testing vacc1 name");
            Assert.AreEqual(13, vacc1.petNumber, "Testing vacc1 pet number");
            Assert.AreEqual(true, vacc1.checkedStatus, "Testing vacc1 checked status");
            Assert.AreEqual(DateTime.Now.AddDays(40), vacc1.expiryDate, "Testing vacc1 expiry date");

            vacc1.number = 7;
            vacc1.name = "Hay Fever";
            vacc1.petNumber = 7;
            vacc1.checkedStatus = false;
            vacc1.expiryDate = DateTime.Now.AddDays(12);

            Assert.AreEqual(7, vacc1.number, "Testing vacc1 number");
            Assert.AreEqual("Hay Fever", vacc1.name, "Testing vacc1 name");
            Assert.AreEqual(7, vacc1.petNumber, "Testing vacc1 pet number");
            Assert.AreEqual(false, vacc1.checkedStatus, "Testing vacc1 checked status");
            Assert.AreEqual(DateTime.Now.AddDays(12), vacc1.expiryDate, "Testing vacc1 expiry date");

        }
    }
}
