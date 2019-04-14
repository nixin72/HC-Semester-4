using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdumaresq_B42_A01;

namespace HVK_UnitTesting {
    class TestAccessorsMutators {
        public static void testDailyRate() {
            Console.Write("\n");
            DailyRate rateAll = new DailyRate();
            rateAll.number = 100;
            rateAll.rate = 10;
            rateAll.dogSize = 'l';
            rateAll.serviceNumber = 5;
            Assert.Equals(rateAll.number, 100, "Custom dailyRate number");
            Assert.Equals(rateAll.rate, 10, "Custom daily rate");
            Assert.Equals(rateAll.dogSize, 'l', "Custom dog size");
            Assert.Equals(rateAll.serviceNumber, 5, "Custom service number");
        }

        public static void testDiscount() {
            Console.Write("\n");
            Discount disAll = new Discount();
            disAll.number = 100;
            disAll.desc = "sharing run";
            disAll.per = 10;
            disAll.type = 'd';
            Assert.Equals(disAll.number, 100, "Custom discount number");
            Assert.Equals(disAll.desc, "sharing run", "Custom discount description");
            Assert.Equals(disAll.per, 10, "Custom discount percentage");
            Assert.Equals(disAll.type, 'd', "Custom discount type");
        }

        public static void testFood() {
            Console.Write("\n");
            Food foodAll = new Food();
            foodAll.number = 10;
            foodAll.brand = "Doge";
            foodAll.variety = "food";
            foodAll.frequency = 2;
            foodAll.quantity = "quantity";
            Assert.Equals(foodAll.number, 10, "Custom food number");
            Assert.Equals(foodAll.brand, "Doge", "Custom food brand");
            Assert.Equals(foodAll.variety, "food", "Custom food variety");
            Assert.Equals(foodAll.frequency, 2, "Custom food variety");
            Assert.Equals(foodAll.quantity, "quantity", "Custom food variety");
        }

        public static void testKennelLog() {
            Console.Write("\n");
            KennelLog logAll = new KennelLog();
            logAll.logDate = new DateTime(17, 1, 30);
            logAll.seqNum = 10;
            logAll.notes = "notes";
            logAll.video = 99;
            Assert.Equals(logAll.logDate, new DateTime(17, 1, 30), "custom log date");
            Assert.Equals(logAll.seqNum, 10, "custom log number");
            Assert.Equals(logAll.notes, "notes", "custom log notes");
            Assert.Equals(logAll.video, Convert.ToByte(99), "custom log video");
        }

        public static void testMedication() {
            Console.Write("\n");
            Medication medAll = new Medication();
            medAll.number = 10;
            medAll.name = "Advil";
            medAll.dosage = "Twice a day";
            medAll.instructions = "ground it up into his water";
            medAll.endDate = new DateTime(2017, 2, 25);
            medAll.pet_res_num = 100;
            Assert.Equals(medAll.number, 10, "Custom medication number");
            Assert.Equals(medAll.name, "Advil", "Custom medication name");
            Assert.Equals(medAll.dosage, "Twice a day", "Custom medication dose");
            Assert.Equals(medAll.instructions, "ground it up into his water", "Custom medication instructions");
            Assert.Equals(medAll.endDate, new DateTime(2017, 2, 25), "Custom medication end date");
            Assert.Equals(medAll.pet_res_num, 100, "Custom medication petResNum");
        }

        public static void testOwner() {
            List<Pet> testList = new List<Pet>();
            testList.Add(new Pet(10, "Sparky", 'm', true));

            Console.Write("\n");
            Owner ownAll = new Owner();
            ownAll.number = 10;
            ownAll.first = "Philip";
            ownAll.last = "Dumaresq";
            ownAll.street = "tartan";
            ownAll.city = "AY";
            ownAll.province = "QC";
            ownAll.postal = "J9J0W2";
            ownAll.email = "pdumaresq";
            ownAll.phone = "1231231234";
            ownAll.emg_first = "Sophie";
            ownAll.emg_last = "Demers";
            ownAll.emg_phone = "3213214321";
            ownAll.vet_number = 5;
            ownAll.pets = testList;
            Assert.Equals(ownAll.number, 10, "Custom owner number");
            Assert.Equals(ownAll.first, "Philip", "Custom owner first name");
            Assert.Equals(ownAll.last, "Dumaresq", "Custom owner last name");
            Assert.Equals(ownAll.street, "tartan", "Custom owner street");
            Assert.Equals(ownAll.city, "AY", "Custom owner city");
            Assert.Equals(ownAll.province, "QC", "Custom owner province");
            Assert.Equals(ownAll.postal, "J9J0W2", "Custom owner postal");
            Assert.Equals(ownAll.email, "pdumaresq", "Custom owner email");
            Assert.Equals(ownAll.phone, "1231231234", "Custom owner phone");
            Assert.Equals(ownAll.emg_first, "Sophie", "Custom owner emg first name");
            Assert.Equals(ownAll.emg_last, "Demers", "Custom owner emg last name");
            Assert.Equals(ownAll.emg_phone, "3213214321", "Custom owner emg phone");
            Assert.Equals(ownAll.vet_number, 5, "Custom owner vet");
            Assert.Equals(ownAll.pets, testList, "Custom owner's pets");
        }

        public static void testPet() {
            List<Vaccination> testVaccs = new List<Vaccination>();
            testVaccs.Add(new Vaccination());

            Console.Write("\n");
            Pet petAll = new Pet();
            petAll.number = 10;
            petAll.name = "Sparky";
            petAll.sex = 'F';
            petAll._fixed = false;
            petAll.breed = "Husky";
            petAll.birthdate = new DateTime(2011, 1, 1);
            petAll.number = 10;
            petAll.size = 'm';
            petAll.special_notes = "notes";
            petAll.vaccinations = testVaccs;
            Assert.Equals(petAll.number, 10, "custom pet number");
            Assert.Equals(petAll.name, "Sparky", "custom pet name");
            Assert.Equals(petAll.sex, 'F', "custom pet sex");
            Assert.Equals(petAll._fixed, false, "custom pet fixed");
            Assert.Equals(petAll.breed, "Husky", "custom pet breed");
            Assert.Equals(petAll.birthdate, new DateTime(2011, 1, 1), "custom pet birthday");
            Assert.Equals(petAll.number, 10, "custom pet owner");
            Assert.Equals(petAll.size, 'm', "custom pet size");
            Assert.Equals(petAll.special_notes, "notes", "custom pet notes");
            Assert.ListsEqual(petAll.vaccinations, testVaccs, "custom pet vaccinations");
        }

        public static void testPetReservation() {
            List<Discount> listDis = new List<Discount>();
            listDis.Add(new Discount());
            List<Medication> listMed = new List<Medication>();
            listMed.Add(new Medication());
            List<KennelLog> listLog = new List<KennelLog>();
            listLog.Add(new KennelLog());
            List<Service> listSer = new List<Service>();
            listSer.Add(new Service());

            Console.Write("\n");
            PetReservation prAll = new PetReservation();
            prAll.petResNum = 1;
            prAll.petNum = 2;
            prAll.reservationNum = 3;
            prAll.runNum = 4;
            prAll.PRpetResNum = 5;
            prAll.run = new Run(2, 's');
            prAll.food = new Food(30, "brand", "variety");
            prAll.res = new Reservation(10, new DateTime(2017, 3, 2), new DateTime(2017, 3, 9));
            prAll.discounts = listDis;
            prAll.meds = listMed;
            prAll.logs = listLog;
            prAll.services = listSer;
            Assert.Equals(prAll.petResNum, 1, "Custom petRes num");
            Assert.Equals(prAll.petNum, 2, "Custom petRes pet");
            Assert.Equals(prAll.reservationNum, 3, "Custom petRes reservation");
            Assert.Equals(prAll.runNum, 4, "Custom petRes run");
            Assert.Equals(prAll.PRpetResNum, 5, "Custom petRes petResNum");
            Assert.Equals(prAll.run, new Run(2, 's'), "Custom petRes run");
            Assert.Equals(prAll.food, new Food(30, "brand", "variety"), "Custom petRes food");
            Assert.Equals(prAll.res, new Reservation(10, new DateTime(2017, 3, 2),
                new DateTime(2017, 3, 9)), "Custom petRes reservation");
            Assert.ListsEqual(prAll.discounts, listDis, "Custom petRes discounts");
            Assert.ListsEqual(prAll.meds, listMed, "Custom petRes medication");
            Assert.ListsEqual(prAll.logs, listLog, "Custom petRes kennel logs");
            Assert.ListsEqual(prAll.services, listSer, "Custom petRes services");
        }

        public static void testReservation() {
            List<Discount> testList = new List<Discount>();
            testList.Add(new Discount());

            Console.Write("\n");
            Reservation resAll = new Reservation();
            resAll.number = 10;
            resAll.sDate = new DateTime(2017, 3, 1);
            resAll.eDate = new DateTime(2017, 3, 2);
            Assert.Equals(resAll.number, 10, "Custom res number");
            Assert.Equals(resAll.sDate, new DateTime(2017, 3, 1), "Custom res start date");
            Assert.Equals(resAll.eDate, new DateTime(2017, 3, 2), "Custom res end date");
        }

        public static void testRun() {
            Console.Write("\n");
            Run runAll = new Run();
            runAll.number = 10;
            runAll.size = 'l';
            runAll.covered = 'n';
            runAll.location = 'b';
            runAll.status = 2;
            Assert.Equals(runAll.number, 10, "Custom run number");
            Assert.Equals(runAll.size, 'l', "Custom run size");
            Assert.Equals(runAll.covered, 'n', "Custom run covered");
            Assert.Equals(runAll.location, 'b', "Custom run location");
            Assert.Equals(runAll.status, 2, "Custom run status");
        }

        public static void testService() {
            Console.Write("\n");
            Service serAll = new Service();
            serAll.number = 10;
            serAll.desc = "desc";
            serAll.petResNumber = 100;
            serAll.frequency = 2;
            serAll.rate = new DailyRate(3, 10);
            Assert.Equals(serAll.number, 10, "Custom service number");
            Assert.Equals(serAll.desc, "desc", "Custom service description");
            Assert.Equals(serAll.petResNumber, 100, "Custom service petRes number");
            Assert.Equals(serAll.frequency, 2, "Custom service frequency");
            Assert.Equals(serAll.rate, new DailyRate(3, 10), "Custom service frequency");
        }

        public static void testVaccination() {
            Console.Write("\n");
            Vaccination vacRequired = new Vaccination(10, "Bordetella");
            vacRequired.number = 10;
            vacRequired.name = "Bordetella";
            vacRequired.expiryDate = new DateTime(2019, 9, 4);
            Assert.Equals(vacRequired.number, 10, "Custom vaccination number");
            Assert.Equals(vacRequired.name, "Bordetella", "Custom vaccination name");
            Assert.Equals(vacRequired.expiryDate, new DateTime(2019, 9, 4), "Custom vaccination name");
        }

        public static void testVetrinarian() {
            Console.Write("\n");
            Vetrinarian vetAll = new Vetrinarian();
            vetAll.number = 10;
            vetAll.name = "dr. watson";
            vetAll.phone = "1234567890";
            vetAll.street = "221B baker";
            vetAll.city = "London";
            vetAll.province = "ON";
            vetAll.postal = "A1A 1A1";
            Assert.Equals(vetAll.number, 10, "Custom vet number");
            Assert.Equals(vetAll.name, "dr. watson", "Custom vet name");
            Assert.Equals(vetAll.phone, "1234567890", "Custom vet phone");
            Assert.Equals(vetAll.street, "221B baker", "Custom vet street");
            Assert.Equals(vetAll.city, "London", "Custom vet city");
            Assert.Equals(vetAll.province, "ON", "Custom vet province");
            Assert.Equals(vetAll.postal, "A1A 1A1", "Custom vet postal ");
        }
    }
}
