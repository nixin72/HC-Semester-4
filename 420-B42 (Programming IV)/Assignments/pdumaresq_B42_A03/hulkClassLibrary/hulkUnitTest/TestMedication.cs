using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;

namespace hulkUnitTest {
    [TestClass]
    public class TestMedication {
        [TestMethod]
        public void TestMedicationConstructors() {
            Medication med1 = new Medication();
            Assert.AreEqual(0, med1.number, "Testing med1 number");
            Assert.AreEqual("", med1.name, "Testing med1 sequence name");
            Assert.AreEqual("", med1.dosage, "Testing med1 dosage");
            Assert.AreEqual("", med1.instructions, "Testing med1 instructions");
            Assert.AreEqual(new DateTime(), med1.endDate, "Testing med1 enddate");
            Assert.AreEqual(0, med1.pet_res_num, "Testing med1 pet reservation number");

            Medication med2 = new Medication(4, "Medicam");
            Assert.AreEqual(4, med2.number, "Testing med2 number");
            Assert.AreEqual("Medicam", med2.name, "Testing med2 sequence name");
            Assert.AreEqual("", med2.dosage, "Testing med2 dosage");
            Assert.AreEqual("", med2.instructions, "Testing med2 instructions");
            Assert.AreEqual(new DateTime(), med2.endDate, "Testing med2 enddate");
            Assert.AreEqual(0, med2.pet_res_num, "Testing med2 pet reservation number");

            Medication med3 = new Medication(2, "Tapzole", "1/2 tablet once daily", "No Instructions", DateTime.Parse("03-MAR-2017"), 264);
            Assert.AreEqual(2, med3.number, "Testing med3 number");
            Assert.AreEqual("Tapzole", med3.name, "Testing med3 sequence name");
            Assert.AreEqual("1/2 tablet once daily", med3.dosage, "Testing med3 dosage");
            Assert.AreEqual("No Instructions", med3.instructions, "Testing med3 instructions");
            Assert.AreEqual(DateTime.Parse("03-MAR-2017"), med3.endDate, "Testing med3 enddate");
            Assert.AreEqual(264, med3.pet_res_num, "Testing med3 pet reservation number");
        }

        public void TestMutateFields() {
            Medication med1 = new Medication(2, "Tapzole", "1/2 tablet once daily", "No Instructions", DateTime.Parse("03-MAR-2017"), 264);
            Assert.AreEqual(2, med1.number, "Testing med1 number");
            Assert.AreEqual("Tapzole", med1.name, "Testing med1 sequence name");
            Assert.AreEqual("1/2 tablet once daily", med1.dosage, "Testing med1 dosage");
            Assert.AreEqual("No Instructions", med1.instructions, "Testing med1 instructions");
            Assert.AreEqual(DateTime.Parse("03-MAR-2017"), med1.endDate, "Testing med1 enddate");
            Assert.AreEqual(264, med1.pet_res_num, "Testing med1 pet reservation number");

            med1.number = 6;
            med1.name = "Pennisilin";
            med1.dosage = "Twice Daily";
            med1.instructions = "Place in food";
            med1.endDate = DateTime.Parse("09-MAR-2017");
            med1.pet_res_num = 333;

            Assert.AreEqual(6, med1.number, "Testing med1 number");
            Assert.AreEqual("Pennisilin", med1.name, "Testing med1 sequence name");
            Assert.AreEqual("Twice Daily", med1.dosage, "Testing med1 dosage");
            Assert.AreEqual("Place in food", med1.instructions, "Testing med1 instructions");
            Assert.AreEqual(DateTime.Parse("09-MAR-2017"), med1.endDate, "Testing med1 enddate");
            Assert.AreEqual(333, med1.pet_res_num, "Testing med1 pet reservation number");
        }
    }
}
