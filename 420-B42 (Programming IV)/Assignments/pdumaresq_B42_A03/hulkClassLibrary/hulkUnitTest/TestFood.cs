using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using HulkHvkDB;

namespace hulkUnitTest {
    class TestFood {
        [TestMethod]
        public void TestFoodConstructors() {
            Food food1 = new Food();
            Assert.AreEqual(0, food1.number, "Testing food1 number");
            Assert.AreEqual("", food1.brand, "Testing food1 brand");
            Assert.AreEqual("", food1.variety, "Testing food1 variety");
            Assert.AreEqual(0, food1.frequency, "Testing food1 frequency");
            Assert.AreEqual("", food1.quantity, "Testing food1 quantity");

            Food food2 = new Food(1, "Iams");
            Assert.AreEqual(1, food2.number, "Testing food2 number");
            Assert.AreEqual("Iams", food2.brand, "Testing food2 brand");
            Assert.AreEqual("", food2.variety, "Testing food2 variety");
            Assert.AreEqual(0, food2.frequency, "Testing food2 frequency");
            Assert.AreEqual("", food2.quantity, "Testing food2 quantity");

            Food food3 = new Food(5, "President's Choice", "Xtra meaty chicken and rice");
            Assert.AreEqual(5, food3.number, "Testing food3 number");
            Assert.AreEqual("President's Choice", food3.brand, "Testing food3 brand");
            Assert.AreEqual("Xtra meaty chicken and rice", food3.variety, "Testing food3 variety");
            Assert.AreEqual(0, food3.frequency, "Testing food3 frequency");
            Assert.AreEqual("", food3.quantity, "Testing food3 quantity");

            Food food4 = new Food(7, "Purina", "Dog Chow", 4);
            Assert.AreEqual(7, food4.number, "Testing food4 number");
            Assert.AreEqual("Purina", food4.brand, "Testing food4 brand");
            Assert.AreEqual("Dog Chow", food4.variety, "Testing food4 variety");
            Assert.AreEqual(4, food4.frequency, "Testing food4 frequency");
            Assert.AreEqual("", food4.quantity, "Testing food4 quantity");

            Food food5 = new Food(11, "Science Diet", "Allergy Formula", 7, "Twice a day");
            Assert.AreEqual(11, food5.number, "Testing food5 number");
            Assert.AreEqual("Science Diet", food5.brand, "Testing food5 brand");
            Assert.AreEqual("Allergy Formula", food5.variety, "Testing food5 variety");
            Assert.AreEqual(7, food5.frequency, "Testing food5 frequency");
            Assert.AreEqual("Twice a day", food5.quantity, "Testing food5 quantity");
        }

        public void TestMutateFields() {
            Food food1 = new Food(11, "Science Diet", "Allergy Formula", 7, "Twice a day");
            Assert.AreEqual(11, food1.number, "Testing food1 number");
            Assert.AreEqual("Science Diet", food1.brand, "Testing food1 brand");
            Assert.AreEqual("Allergy Formula", food1.variety, "Testing food1 variety");
            Assert.AreEqual(7, food1.frequency, "Testing food1 frequency");
            Assert.AreEqual("Twice a day", food1.quantity, "Testing food1 quantity");

            food1.number = 32;
            food1.brand = "Bill Nye Diet";
            food1.variety = "Intellegence Formula";
            food1.frequency = 15;
            food1.quantity = "Once a day";

            Assert.AreEqual(32, food1.number, "Testing food1 number");
            Assert.AreEqual("Bill Nye Diet", food1.brand, "Testing food1 brand");
            Assert.AreEqual("Intellegence Formula", food1.variety, "Testing food1 variety");
            Assert.AreEqual(15, food1.frequency, "Testing food1 frequency");
            Assert.AreEqual("Once a day", food1.quantity, "Testing food1 quantity");
        }
    }
}
