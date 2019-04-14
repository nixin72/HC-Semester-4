using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using System.Collections.Generic;

namespace hulkUnitTest {
    [TestClass]
    public class TestPet {
        [TestMethod]
        public void TestPetConstructors() {
            Pet pet1 = new Pet();
            Assert.AreEqual(0, pet1.number, "Testing default pet number");
            Assert.AreEqual("", pet1.name, "Testing default pet name");
            Assert.AreEqual('M', pet1.sex, "Testing default pet sex");
            Assert.AreEqual(true, pet1._fixed, "Testing default pet fixed");
            Assert.AreEqual("", pet1.breed, "Testing default pet breed");
            Assert.AreEqual(new DateTime(), pet1.birthdate, "Testing default pet birthdate");
            Assert.AreEqual(0, pet1.picture, "Testing default pet picture");
            Assert.AreEqual('s', pet1.size, "Testing default pet size");
            Assert.AreEqual("", pet1.special_notes, "Testing default pet special_notes");
            Assert.AreEqual(0, pet1.ownerNumber, "Testing default pet owner number");

            Pet pet2 = new Pet(12, "Poochy", 'M', true, 1);
            Assert.AreEqual(12, pet2.number, "Testing pet2 number");
            Assert.AreEqual("Poochy", pet2.name, "Testing pet2 name");
            Assert.AreEqual('M', pet2.sex, "Testing pet2 sex");
            Assert.AreEqual(true, pet2._fixed, "Testing pet2 fixed");
            Assert.AreEqual("", pet2.breed, "Testing pet2 breed");
            Assert.AreEqual(new DateTime(), pet2.birthdate, "Testing pet2 birthdate");
            Assert.AreEqual(0, pet2.picture, "Testing pet2 picture");
            Assert.AreEqual('s', pet2.size, "Testing pet2 size");
            Assert.AreEqual("", pet2.special_notes, "Testing pet2 special_notes");
            Assert.AreEqual(1, pet2.ownerNumber, "Testing pet2 owner number");

            Pet pet3 = new Pet(34, "Morty", 'F', false, "Newfoundland", DateTime.Now.AddYears(-5), 13, 1, 'L', "");
            Assert.AreEqual(34, pet3.number, "Testing pet3 number");
            Assert.AreEqual("Morty", pet3.name, "Testing pet3 name");
            Assert.AreEqual('F', pet3.sex, "Testing pet3 sex");
            Assert.AreEqual(false, pet3._fixed, "Testing pet3 fixed");
            Assert.AreEqual("Newfoundland", pet3.breed, "Testing pet3 breed");

            Assert.AreEqual(1, pet3.picture, "Testing pet3 picture");
            Assert.AreEqual('L', pet3.size, "Testing pet3 size");
            Assert.AreEqual("", pet3.special_notes, "Testing pet3 special_notes");
            Assert.AreEqual(13, pet3.ownerNumber, "Testing pet3 owner number");
        }

        [TestMethod]
        public void TestListPets() {
            Pet control = new Pet();
            List<Pet> owner1Pets = control.listPets(1);
            Assert.IsTrue(owner1Pets[0].Equals(new Pet(2, "Archie", 'F', true, 1)), "Testing listing pets alphabetically for owner 1");
            Assert.IsTrue(owner1Pets[1].Equals(new Pet(1, "Scrabble", 'F', true, 1)), "Testing listing pets alphabetically for owner 1");

            List<Pet> owner2Pets = control.listPets(7);
            Assert.IsTrue(owner2Pets[0].Equals(new Pet(12, "Kitoo", 'F', true, 7)), "Testing listing pets alphabetically for owner 7");
            Assert.IsTrue(owner2Pets[1].Equals(new Pet(11, "Max", 'M', true, 7)), "Testing listing pets alphabetically for owner 7");
            Assert.IsTrue(owner2Pets[2].Equals(new Pet(10, "Pete", 'M', true, 7)), "Testing listing pets alphabetically for owner 7");

            List<Pet> owner3Pets = control.listPets(15);
            Assert.IsTrue(owner3Pets[0].Equals(new Pet(27, "Bothvar", 'M', false, 15)), "Testing listing pets alphabetically for owner 15");
            Assert.IsTrue(owner3Pets[1].Equals(new Pet(28, "Foxfire", 'F', false, 15)), "Testing listing pets alphabetically for owner 15");
            Assert.IsTrue(owner3Pets[2].Equals(new Pet(26, "Skarpa", 'F', false, 15)), "Testing listing pets alphabetically for owner 15");

            List<Pet> owner4Pets = control.listPets(17);
            Assert.IsTrue(owner4Pets[0].Equals(new Pet(31, "Sam", 'M', false, 17)), "Testing listing pets alphabetically for owner 17");
            Assert.IsTrue(owner4Pets[1].Equals(new Pet(32, "Snoop Dogg", 'M', false, 17)), "Testing listing pets alphabetically for owner 17");
            Assert.IsTrue(owner4Pets[2].Equals(new Pet(30, "Suki", 'F', false, 17)), "Testing listing pets alphabetically for owner 17");

            List<Pet> owner5Pets = control.listPets(19);
            Assert.IsTrue(owner5Pets[0].Equals(new Pet(34, "Aurora", 'F', true, 19)), "Testing listing pets alphabetically for owner 19");

            List<Pet> owner6Pets = control.listPets(20);
            Assert.IsTrue(owner6Pets[0].Equals(new Pet(35, "Bella", 'F', true, 20)), "Testing listing pets alphabetically for owner 20");
        }

        public void TestMutateFields() {
            Pet pet1 = new Pet(34, "Morty", 'F', false, "Newfoundland", DateTime.Parse("2015-MAR-03"), 13, 1, 'L', "");
            Assert.AreEqual(34, pet1.number, "Testing pet1 number");
            Assert.AreEqual("Morty", pet1.name, "Testing pet1 name");
            Assert.AreEqual('F', pet1.sex, "Testing pet1 sex");
            Assert.AreEqual(false, pet1._fixed, "Testing pet1 fixed");
            Assert.AreEqual("Newfoundland", pet1.breed, "Testing pet1 breed");
            Assert.AreEqual(DateTime.Parse("2015-MAR-03"), pet1.birthdate, "Testing pet1 birthdate");
            Assert.AreEqual(1, pet1.picture, "Testing pet1 picture");
            Assert.AreEqual('L', pet1.size, "Testing pet1 size");
            Assert.AreEqual("", pet1.special_notes, "Testing pet1 special_notes");
            Assert.AreEqual(13, pet1.ownerNumber, "Testing pet1 owner number");

            pet1.number = 99;
            pet1.name = "Blue";
            pet1.sex = 'M';
            pet1._fixed = true;
            pet1.breed = "Mastif";
            pet1.birthdate = DateTime.Parse("2013-MAR-01");
            pet1.picture = 0;
            pet1.size = 'M';
            pet1.special_notes = "Drools a lot";
            pet1.ownerNumber = 12;

            Assert.AreEqual(99, pet1.number, "Testing pet1 number");
            Assert.AreEqual("Blue", pet1.name, "Testing pet1 name");
            Assert.AreEqual('M', pet1.sex, "Testing pet1 sex");
            Assert.AreEqual(true, pet1._fixed, "Testing pet1 fixed");
            Assert.AreEqual("Mastif", pet1.breed, "Testing pet1 breed");
            Assert.AreEqual(DateTime.Parse("2013-MAR-01"), pet1.birthdate, "Testing pet1 birthdate");
            Assert.AreEqual(0, pet1.picture, "Testing pet1 picture");
            Assert.AreEqual('M', pet1.size, "Testing pet1 size");
            Assert.AreEqual("Drools a lot", pet1.special_notes, "Testing pet1 special_notes");
            Assert.AreEqual(12, pet1.ownerNumber, "Testing pet1 owner number");
        }
    }
}
