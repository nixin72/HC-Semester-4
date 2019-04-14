using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using teamHvkBLL;
using System.Collections.Generic;

namespace hulkUnitTest {
    [TestClass]
    public class TestOwner {
        [TestMethod]
        public void TestOwnerConstructors() {
            Owner owner1 = new Owner();
            Assert.AreEqual(0, owner1.number, "Testing owner1 number");
            Assert.AreEqual("", owner1.first, "Testing owner1 first");
            Assert.AreEqual("", owner1.last, "Testing owner1 last");
            Assert.AreEqual("", owner1.street, "Testing owner1 street");
            Assert.AreEqual("", owner1.city, "Testing owner1 city");
            Assert.AreEqual("", owner1.province, "Testing owner1 province");
            Assert.AreEqual("", owner1.postal, "Testing owner1 postal");
            Assert.AreEqual("", owner1.email, "Testing owner1 email");
            Assert.AreEqual("", owner1.phone, "Testing owner1 phone");
            Assert.AreEqual("", owner1.emg_first, "Testing owner1 emg_first");
            Assert.AreEqual("", owner1.emg_last, "Testing owner1 emg_last");
            Assert.AreEqual("", owner1.emg_phone, "Testing owner1 emg_phone");
            Assert.AreEqual(0, owner1.vet_number, "Testing owner1 vet_number");

            Owner owner2 = new Owner(19, "Barb B.", "Que");
            Assert.AreEqual(19, owner2.number, "Testing owner2 number");
            Assert.AreEqual("Barb B.", owner2.first, "Testing owner2 first");
            Assert.AreEqual("Que", owner2.last, "Testing owner2 last");
            Assert.AreEqual("", owner2.street, "Testing owner2 street");
            Assert.AreEqual("", owner2.city, "Testing owner2 city");
            Assert.AreEqual("", owner2.province, "Testing owner2 province");
            Assert.AreEqual("", owner2.postal, "Testing owner2 postal");
            Assert.AreEqual("", owner2.email, "Testing owner2 email");
            Assert.AreEqual("", owner2.phone, "Testing owner2 phone");
            Assert.AreEqual("", owner2.emg_first, "Testing owner2 emg_first");
            Assert.AreEqual("", owner2.emg_last, "Testing owner2 emg_last");
            Assert.AreEqual("", owner2.emg_phone, "Testing owner2 emg_phone");
            Assert.AreEqual(0, owner2.vet_number, "Testing owner2 vet_number");

            Owner owner3 = new Owner(3, "Dwight", "Wong", "384 Garten", "Ottawa", "ON", "K8Y6T3", "dwong@gmail.com", "8195555222", "N/A", "N/A", "N/A", 1);
            Assert.AreEqual(3, owner3.number, "Testing owner3 number");
            Assert.AreEqual("Dwight", owner3.first, "Testing owner3 first");
            Assert.AreEqual("Wong", owner3.last, "Testing owner3 last");
            Assert.AreEqual("384 Garten", owner3.street, "Testing owner3 street");
            Assert.AreEqual("Ottawa", owner3.city, "Testing owner3 city");
            Assert.AreEqual("ON", owner3.province, "Testing owner3 province");
            Assert.AreEqual("K8Y6T3", owner3.postal, "Testing owner3 postal");
            Assert.AreEqual("dwong@gmail.com", owner3.email, "Testing owner3 email");
            Assert.AreEqual("8195555222", owner3.phone, "Testing owner3 phone");
            Assert.AreEqual("N/A", owner3.emg_first, "Testing owner3 emg_first");
            Assert.AreEqual("N/A", owner3.emg_last, "Testing owner3 emg_last");
            Assert.AreEqual("N/A", owner3.emg_phone, "Testing owner3 emg_phone");
            Assert.AreEqual(1, owner3.vet_number, "Testing owner3 vet_number");

            Owner owner4 = new Owner(3, "Dwight", "Wong", "384 Garten", "Ottawa", "ON", "K8Y6T3", "dwong@gmail.com", "8195555222", "N/A", "N/A", "N/A", 1, new List<Pet>(), new List<Reservation>());
            Assert.AreEqual(3, owner4.number, "Testing owner4 number");
            Assert.AreEqual("Dwight", owner4.first, "Testing owner4 first");
            Assert.AreEqual("Wong", owner4.last, "Testing owner4 last");
            Assert.AreEqual("384 Garten", owner4.street, "Testing owner4 street");
            Assert.AreEqual("Ottawa", owner4.city, "Testing owner4 city");
            Assert.AreEqual("ON", owner4.province, "Testing owner4 province");
            Assert.AreEqual("K8Y6T3", owner4.postal, "Testing owner4 postal");
            Assert.AreEqual("dwong@gmail.com", owner4.email, "Testing owner4 email");
            Assert.AreEqual("8195555222", owner4.phone, "Testing owner4 phone");
            Assert.AreEqual("N/A", owner4.emg_first, "Testing owner4 emg_first");
            Assert.AreEqual("N/A", owner4.emg_last, "Testing owner4 emg_last");
            Assert.AreEqual("N/A", owner4.emg_phone, "Testing owner4 emg_phone");
            Assert.AreEqual(1, owner4.vet_number, "Testing owner4 vet_number");
        }

        [TestMethod]
        public void TestListOwners() {
            Owner control = new Owner();
            List<Owner> owners = control.ListOwners();
            Assert.AreEqual("Alibi", owners[0].last, "Testing if owners are listed alphabetically for owners[0] lastname");
            Assert.AreEqual("Bilhome", owners[1].last, "Testing if owners are listed alphabetically for owners[1] lastname");
            Assert.AreEqual("Coate", owners[2].last, "Testing if owners are listed alphabetically for owners[2] lastname");
            Assert.AreEqual("Drawers", owners[3].last, "Testing if owners are listed alphabetically for owners[3] lastname");
            Assert.AreEqual("Linn", owners[4].last, "Testing if owners are listed alphabetically for owners[4] lastname");
            Assert.AreEqual("Mehome", owners[5].last, "Testing if owners are listed alphabetically for owners[5] lastname");
            Assert.AreEqual("Mentary", owners[6].last, "Testing if owners are listed alphabetically for owners[6] lastname");
            Assert.AreEqual("Metu", owners[7].last, "Testing if owners are listed alphabetically for owners[7] lastname");
            Assert.AreEqual("Morfek", owners[8].last, "Testing if owners are listed alphabetically for owners[8] lastname");
            Assert.AreEqual("O'Phone", owners[9].last, "Testing if owners are listed alphabetically for owners[9] lastname");
            Assert.AreEqual("Ovar", owners[10].last, "Testing if owners are listed alphabetically for owners[10] lastname");
            Assert.AreEqual("Pepper", owners[11].last, "Testing if owners are listed alphabetically for owners[11] lastname");
            Assert.AreEqual("Piper", owners[12].last, "Testing if owners are listed alphabetically for owners[12] lastname");
            Assert.AreEqual("Que", owners[13].last, "Testing if owners are listed alphabetically for owners[13] lastname");
            Assert.AreEqual("Showers", owners[14].last, "Testing if owners are listed alphabetically for owners[14] lastname");
            Assert.AreEqual("Smith", owners[15].last, "Testing if owners are listed alphabetically for owners[15] lastname");
            Assert.AreEqual("Summers", owners[16].last, "Testing if owners are listed alphabetically for owners[16] lastname");
            Assert.AreEqual("Wolfe", owners[17].last, "Testing if owners are listed alphabetically for owners[17] lastname");
            Assert.AreEqual("Wong", owners[18].last, "Testing if owners are listed alphabetically for owners[18] lastname");

            Assert.AreEqual("Alibi, Anita", owners[0].last + ", " + owners[0].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[0]");
            Assert.AreEqual("Bilhome, Moe", owners[1].last + ", " + owners[1].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[1]");
            Assert.AreEqual("Coate, Mahatma", owners[2].last + ", " + owners[2].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[2]");
            Assert.AreEqual("Drawers, Chester", owners[3].last + ", " + owners[3].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[3]");
            Assert.AreEqual("Linn, Amanda", owners[4].last + ", " + owners[4].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[4]");
            Assert.AreEqual("Mehome, Carrie", owners[5].last + ", " + owners[5].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[5]");
            Assert.AreEqual("Mentary, Ella", owners[6].last + ", " + owners[6].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[6]");
            Assert.AreEqual("Metu, Sue", owners[7].last + ", " + owners[7].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[7]");
            Assert.AreEqual("Morfek, Polly", owners[8].last + ", " + owners[8].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[8]");
            Assert.AreEqual("O'Phone, Mike", owners[9].last + ", " + owners[9].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[9]");
            Assert.AreEqual("Ovar, Sam", owners[10].last + ", " + owners[10].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[10]");
            Assert.AreEqual("Pepper, Salton", owners[11].last + ", " + owners[11].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[11]");
            Assert.AreEqual("Piper, Peter", owners[12].last + ", " + owners[12].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[12]");
            Assert.AreEqual("Que, Barb B.", owners[13].last + ", " + owners[13].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[13]");
            Assert.AreEqual("Showers, April", owners[14].last + ", " + owners[14].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[14]");
            Assert.AreEqual("Smith, Jane", owners[15].last + ", " + owners[15].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[15]");
            Assert.AreEqual("Summers, Jeff", owners[16].last + ", " + owners[16].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[16]");
            Assert.AreEqual("Wolfe, Bayo", owners[17].last + ", " + owners[17].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[17]");
            Assert.AreEqual("Wong, Dwight", owners[18].last + ", " + owners[18].first, "Testing if listing of alphabetical names is displayed properly formatted for owners[18]");
        }

        public void TestMutateFields() {
            Owner owner1 = new Owner(3, "Dwight", "Wong", "384 Garten", "Ottawa", "ON", "K8Y6T3", "dwong@gmail.com", "8195555222", "N/A", "N/A", "N/A", 1, new List<Pet>(), new List<Reservation>());
            Assert.AreEqual(3, owner1.number, "Testing owner1 number");
            Assert.AreEqual("Dwight", owner1.first, "Testing owner1 first");
            Assert.AreEqual("Wong", owner1.last, "Testing owner1 last");
            Assert.AreEqual("384 Garten", owner1.street, "Testing owner1 street");
            Assert.AreEqual("Ottawa", owner1.city, "Testing owner1 city");
            Assert.AreEqual("ON", owner1.province, "Testing owner1 province");
            Assert.AreEqual("K8Y6T3", owner1.postal, "Testing owner1 postal");
            Assert.AreEqual("dwong@gmail.com", owner1.email, "Testing owner1 email");
            Assert.AreEqual("8195555222", owner1.phone, "Testing owner1 phone");
            Assert.AreEqual("N/A", owner1.emg_first, "Testing owner1 emg_first");
            Assert.AreEqual("N/A", owner1.emg_last, "Testing owner1 emg_last");
            Assert.AreEqual("N/A", owner1.emg_phone, "Testing owner1 emg_phone");
            Assert.AreEqual(1, owner1.vet_number, "Testing owner1 vet_number");

            owner1.number = 5;
            owner1.first = "Petey";
            owner1.last = "McGee";
            owner1.street = "Downtown st.";
            owner1.city = "Montreal";
            owner1.province = "QC";
            owner1.postal = "H4H3J9";
            owner1.email = "Petey@gmail.com";
            owner1.phone = "1222222222";
            owner1.emg_first = "Kyle";
            owner1.emg_last = "Mcanderson";
            owner1.emg_phone = "2222222222";
            owner1.vet_number = 12;

            Assert.AreEqual(5, owner1.number, "Testing owner1 number");
            Assert.AreEqual("Petey", owner1.first, "Testing owner1 first");
            Assert.AreEqual("McGee", owner1.last, "Testing owner1 last");
            Assert.AreEqual("Downtown st.", owner1.street, "Testing owner1 street");
            Assert.AreEqual("Montreal", owner1.city, "Testing owner1 city");
            Assert.AreEqual("QC", owner1.province, "Testing owner1 province");
            Assert.AreEqual("H4H3J9", owner1.postal, "Testing owner1 postal");
            Assert.AreEqual("Petey@gmail.com", owner1.email, "Testing owner1 email");
            Assert.AreEqual("1222222222", owner1.phone, "Testing owner1 phone");
            Assert.AreEqual("Kyle", owner1.emg_first, "Testing owner1 emg_first");
            Assert.AreEqual("Mcanderson", owner1.emg_last, "Testing owner1 emg_last");
            Assert.AreEqual("2222222222", owner1.emg_phone, "Testing owner1 emg_phone");
            Assert.AreEqual(12, owner1.vet_number, "Testing owner1 vet_number");
        }
    }
}
