using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdumaresq_B42_A01;

namespace HVK_UnitTesting { 
    class TestConstructors {
        public static void testDailyRateC() {
            DailyRate rateDefault = new DailyRate();
            Assert.Equals(rateDefault.number, 0, "Default dailyRate number");
            Assert.Equals(rateDefault.rate, 0, "Default daily rate");
            Assert.Equals(rateDefault.dogSize, 's', "Default dog size");
            Assert.Equals(rateDefault.serviceNumber, 0, "Default service number");
            Console.Write("\n");
            DailyRate rateRequired = new DailyRate(100, 10);
            Assert.Equals(rateRequired.number, 100, "Custom dailyRate number");
            Assert.Equals(rateRequired.rate, 10, "Custom daily rate");
            Assert.Equals(rateRequired.dogSize, 's', "Default dog size");
            Assert.Equals(rateRequired.serviceNumber, 0, "Default service number");
            Console.Write("\n");
            DailyRate rateAll = new DailyRate(100, 10, 'l', 5);
            Assert.Equals(rateAll.number, 100, "Custom dailyRate number");
            Assert.Equals(rateAll.rate, 10, "Custom daily rate");
            Assert.Equals(rateAll.dogSize, 'l', "Custom dog size");
            Assert.Equals(rateAll.serviceNumber, 5, "Custom service number");
        }

        public static void testDiscountC() {
            Console.Write("\n");
            Discount disDefault = new Discount();
            Assert.Equals(disDefault.number, 0, "Default discount number");
            Assert.Equals(disDefault.desc, "", "Default discount description");
            Assert.Equals(disDefault.per, 0, "Default discount percentage");
            Assert.Equals(disDefault.type, 't', "Default discount type");

            Console.Write("\n");
            Discount disRequired = new Discount(100, "sharing run", 10, 'd');
            Assert.Equals(disRequired.number, 100, "Custom discount number");
            Assert.Equals(disRequired.desc, "sharing run", "Custom discount description");
            Assert.Equals(disRequired.per, 10, "Custom discount percentage");
            Assert.Equals(disRequired.type, 'd', "Custom discount type");

            Console.Write("\n");
            Discount disAll = new Discount(100, "sharing run", 10, 'd');
            Assert.Equals(disAll.number, 100, "Custom discount number");
            Assert.Equals(disAll.desc, "sharing run", "Custom discount description");
            Assert.Equals(disAll.per, 10, "Custom discount percentage");
            Assert.Equals(disAll.type, 'd', "Custom discount type");
        }

        public static void testFoodC() {
            Console.Write("\n");
            Food foodDefault = new Food();
            Assert.Equals(foodDefault.number, 0, "Default food number");
            Assert.Equals(foodDefault.brand, "", "Default food brand");
            Assert.Equals(foodDefault.variety, "", "Default food variety");
            Assert.Equals(foodDefault.frequency, 0, "Default food variety");
            Assert.Equals(foodDefault.quantity, "", "Default food variety");

            Console.Write("\n");
            Food foodRequired = new Food(10, "Doge");
            Assert.Equals(foodRequired.number, 10, "Custom food number");
            Assert.Equals(foodRequired.brand, "Doge", "Custom food brand");
            Assert.Equals(foodRequired.variety, "", "Default food variety");
            Assert.Equals(foodDefault.frequency, 0, "Default food variety");
            Assert.Equals(foodDefault.quantity, "", "Default food variety");

            Console.Write("\n");
            Food foodAll = new Food(10, "Doge", "food");
            Assert.Equals(foodAll.number, 10, "Custom food number");
            Assert.Equals(foodAll.brand, "Doge", "Custom food brand");
            Assert.Equals(foodAll.variety, "food", "Custom food variety");
            Assert.Equals(foodDefault.frequency, 0, "Default food variety");
            Assert.Equals(foodDefault.quantity, "", "Default food variety");

            Console.Write("\n");
            Food foodAssc = new Food(10, "Doge", "food", 10, "quant");
            Assert.Equals(foodAssc.number, 10, "Custom food number");
            Assert.Equals(foodAssc.brand, "Doge", "Custom food brand");
            Assert.Equals(foodAssc.variety, "food", "Custom food variety");
            Assert.Equals(foodAssc.frequency, 10, "Default food variety");
            Assert.Equals(foodAssc.quantity, "quant", "Default food variety");

        }

        public static void testKennelLogC() {
            Console.Write("\n");
            KennelLog logDefault = new KennelLog();
            Assert.Equals(logDefault.logDate, new DateTime(), "Default log date");
            Assert.Equals(logDefault.seqNum, 0, "Default log number");
            Assert.Equals(logDefault.notes, "", "Default log notes");
            Assert.Equals(logDefault.video, Convert.ToByte(0), "Default log video");

            Console.Write("\n");
            KennelLog logRequired = new KennelLog(new DateTime(17, 1, 30), 10, "notes");
            Assert.Equals(logRequired.logDate, new DateTime(17, 1, 30), "custom log date");
            Assert.Equals(logRequired.seqNum, 10, "custom log number");
            Assert.Equals(logRequired.notes, "notes", "custom log notes");
            Assert.Equals(logRequired.video, Convert.ToByte(0), "Default log video");

            Console.Write("\n");
            KennelLog logAll = new KennelLog(new DateTime(17, 1, 30), 10, "notes", 99);
            Assert.Equals(logRequired.logDate, new DateTime(17, 1, 30), "custom log date");
            Assert.Equals(logRequired.seqNum, 10, "custom log number");
            Assert.Equals(logRequired.notes, "notes", "custom log notes");
            Assert.Equals(logAll.video, Convert.ToByte(99), "custom log video");
        } 

        public static void testMedicationC() {
            Console.Write("\n");
            Medication medDefault = new Medication();
            Assert.Equals(medDefault.number, 0, "Default medication number");
            Assert.Equals(medDefault.name, "", "Default medication name");
            Assert.Equals(medDefault.dosage, "", "Default medication dose");
            Assert.Equals(medDefault.instructions, "", "Default medication instructions");
            Assert.Equals(medDefault.endDate, new DateTime(), "Default medication end date");
            Assert.Equals(medDefault.pet_res_num, 0, "default medication petResNum");

            Console.Write("\n");
            Medication medRequired = new Medication(10, "Advil");
            Assert.Equals(medRequired.number, 10, "Custom medication number");
            Assert.Equals(medRequired.name, "Advil", "Custom medication name");
            Assert.Equals(medRequired.dosage, "", "Default medication dose");
            Assert.Equals(medRequired.instructions, "", "Default medication instructions");
            Assert.Equals(medRequired.endDate, new DateTime(), "Default medication end date");
            Assert.Equals(medRequired.pet_res_num, 0, "default medication petResNum");

            Console.Write("\n");
            Medication medAll = new Medication(10, "Advil", "Twice a day", "ground it up into his water", new DateTime(2017, 2, 25), 100);
            Assert.Equals(medAll.number, 10, "Custom medication number");
            Assert.Equals(medAll.name, "Advil", "Custom medication name");
            Assert.Equals(medAll.dosage, "Twice a day", "Custom medication dose");
            Assert.Equals(medAll.instructions, "ground it up into his water", "Custom medication instructions");
            Assert.Equals(medAll.endDate, new DateTime(2017, 2, 25), "Custom medication end date");
            Assert.Equals(medAll.pet_res_num, 100, "Custom medication petResNum");
        }

        public static void testOwnerC() {
            Console.Write("\n");
            Owner ownDefault = new Owner();
            Assert.Equals(ownDefault.number, 0, "Default owner number");
            Assert.Equals(ownDefault.first, "", "Default owner first name");
            Assert.Equals(ownDefault.last, "", "Default owner last name");
            Assert.Equals(ownDefault.street, "", "Default owner street");
            Assert.Equals(ownDefault.city, "", "Default owner city");
            Assert.Equals(ownDefault.province, "", "Default owner province");
            Assert.Equals(ownDefault.postal, "", "Default owner postal");
            Assert.Equals(ownDefault.email, "", "Default owner email");
            Assert.Equals(ownDefault.phone, "", "Default owner phone");
            Assert.Equals(ownDefault.emg_first, "", "Default owner emg first name");
            Assert.Equals(ownDefault.emg_last, "", "Default owner emg last name");
            Assert.Equals(ownDefault.emg_phone, "", "Default owner emg phone");
            Assert.Equals(ownDefault.vet_number, 0, "Default owner vet");
            Assert.ListsEqual(ownDefault.pets, new List<Pet>(), "Default owner's pets");

            Console.Write("\n");
            Owner ownRequired = new Owner(10, "Philip", "Dumaresq");
            Assert.Equals(ownRequired.number, 10, "Custom owner number");
            Assert.Equals(ownRequired.first, "Philip", "Custom owner first name");
            Assert.Equals(ownRequired.last, "Dumaresq", "Custom owner last name");
            Assert.Equals(ownRequired.street, "", "Default owner street");
            Assert.Equals(ownRequired.city, "", "Default owner city");
            Assert.Equals(ownRequired.province, "", "Default owner province");
            Assert.Equals(ownRequired.postal, "", "Default owner postal");
            Assert.Equals(ownRequired.email, "", "Custom owner email");
            Assert.Equals(ownRequired.phone, "", "Custom owner phone");
            Assert.Equals(ownRequired.emg_first, "", "Default owner emg first name");
            Assert.Equals(ownRequired.emg_last, "", "Default owner emg last name");
            Assert.Equals(ownRequired.emg_phone, "", "Default owner emg phone");
            Assert.Equals(ownRequired.vet_number, 0, "Default owner vet");
            Assert.ListsEqual(ownRequired.pets, new List<Pet>(), "Default owner's pets");

            Console.Write("\n");
            Owner ownAll = new Owner(10, "Philip", "Dumaresq", "tartan", "AY", "QC", "J9J0W2", "pdumaresq", "1231231234", "Sophie", "Demers", "3213214321", 5);
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
            Assert.ListsEqual(ownAll.pets, new List<Pet>(), "Default owner's pets");

            List<Pet> testList = new List<Pet>();
            testList.Add(new Pet(10, "Sparky", 'm', true));
            Console.Write("\n");
            Owner ownList = new Owner(10, "Philip", "Dumaresq", "tartan", "AY", "QC", "J9J0W2", "pdumaresq", 
                "1231231234", "Sophie", "Demers", "3213214321", 5, testList);

            Assert.Equals(ownList.number, 10, "Custom owner number");
            Assert.Equals(ownList.first, "Philip", "Custom owner first name");
            Assert.Equals(ownList.last, "Dumaresq", "Custom owner last name");
            Assert.Equals(ownList.street, "tartan", "Custom owner street");
            Assert.Equals(ownList.city, "AY", "Custom owner city");
            Assert.Equals(ownList.province, "QC", "Custom owner province");
            Assert.Equals(ownList.postal, "J9J0W2", "Custom owner postal");
            Assert.Equals(ownList.email, "pdumaresq", "Custom owner email");
            Assert.Equals(ownList.phone, "1231231234", "Custom owner phone");
            Assert.Equals(ownList.emg_first, "Sophie", "Custom owner emg first name");
            Assert.Equals(ownList.emg_last, "Demers", "Custom owner emg last name");
            Assert.Equals(ownList.emg_phone, "3213214321", "Custom owner emg phone");
            Assert.Equals(ownList.vet_number, 5, "Custom owner vet");
            Assert.ListsEqual(ownList.pets, testList, "Custom owner's pets");
        }

        public static void testPetC() {
            Console.Write("\n");
            Pet petDefault = new Pet();
            Assert.Equals(petDefault.number, 0, "Default pet number");
            Assert.Equals(petDefault.name, "", "Default pet name");
            Assert.Equals(petDefault.sex, 'M', "Default pet sex");
            Assert.Equals(petDefault._fixed, true, "Default pet fixed");
            Assert.Equals(petDefault.breed, "", "Default pet breed");
            Assert.Equals(petDefault.birthdate, new DateTime(), "Default pet birthday");
            Assert.Equals(petDefault.picture, Convert.ToByte(0), "Default pet picture");
            Assert.Equals(petDefault.size, 's', "Default pet size");
            Assert.Equals(petDefault.special_notes, "", "Default pet notes");
            Assert.ListsEqual(petDefault.vaccinations, new List<Vaccination>(), "Default pet vaccinations");
            Assert.ListsEqual(petDefault.reservations, new List<PetReservation>(), "default pet reservations");

            Console.Write("\n");
            Pet petRequired = new Pet(10, "Sparky", 'F', false);
            Assert.Equals(petRequired.number, 10, "custom pet number");
            Assert.Equals(petRequired.name, "Sparky", "custom pet name");
            Assert.Equals(petRequired.sex, 'F', "custom pet sex");
            Assert.Equals(petRequired._fixed, false, "custom pet fixed");
            Assert.Equals(petRequired.breed, "", "Default pet breed");
            Assert.Equals(petRequired.birthdate, new DateTime(), "Default pet birthday");
            Assert.Equals(petRequired.picture, Convert.ToByte(0), "Default pet picture");
            Assert.Equals(petRequired.size, 's', "Default pet size");
            Assert.Equals(petRequired.special_notes, "", "Default pet notes");
            Assert.ListsEqual(petRequired.vaccinations, new List<Vaccination>(), "Default pet vaccinations");
            Assert.ListsEqual(petRequired.reservations, new List<PetReservation>(), "default pet reservations");

            Console.Write("\n");
            Pet petAll = new Pet(10, "Sparky", 'F', false, "Husky", new DateTime(2011, 1, 1), 100, 'm', "notes" );
            Assert.Equals(petAll.number, 10, "custom pet number");
            Assert.Equals(petAll.name, "Sparky", "custom pet name");
            Assert.Equals(petAll.sex, 'F', "custom pet sex");
            Assert.Equals(petAll._fixed, false, "custom pet fixed");
            Assert.Equals(petAll.breed, "Husky", "custom pet breed");
            Assert.Equals(petAll.birthdate, new DateTime(2011, 1, 1), "custom pet birthday");
            Assert.Equals(petAll.picture, Convert.ToByte(100), "Custom pet picture");
            Assert.Equals(petAll.size, 'm', "custom pet size");
            Assert.Equals(petAll.special_notes, "notes", "custom pet notes");
            Assert.ListsEqual(petAll.vaccinations, new List<Vaccination>(), "Default pet vaccinations");
            Assert.ListsEqual(petAll.reservations, new List<PetReservation>(), "default pet reservations");

            List<Vaccination> testVaccs = new List<Vaccination>();
            testVaccs.Add(new Vaccination());
            Console.Write("\n");
            Pet petList = new Pet(10, "Sparky", 'F', false, "Husky", new DateTime(2011, 1, 1), 100, 'm', "notes", testVaccs);
            Assert.Equals(petList.number, 10, "custom pet number");
            Assert.Equals(petList.name, "Sparky", "custom pet name");
            Assert.Equals(petList.sex, 'F', "custom pet sex");
            Assert.Equals(petList._fixed, false, "custom pet fixed");
            Assert.Equals(petList.breed, "Husky", "custom pet breed");
            Assert.Equals(petList.birthdate, new DateTime(2011, 1, 1), "custom pet birthday");
            Assert.Equals(petList.picture, Convert.ToByte(100), "Custom pet picture");
            Assert.Equals(petList.size, 'm', "custom pet size");
            Assert.Equals(petList.special_notes, "notes", "custom pet notes");
            Assert.ListsEqual(petList.vaccinations, testVaccs, "custom pet vaccinations");
            Assert.ListsEqual(petList.reservations, new List<PetReservation>(), "default pet reservations");

            List<PetReservation> petRes = new List<PetReservation>();
            petRes.Add(new PetReservation());
            Console.Write("\n");
            Pet petTemp = new Pet(10, "Sparky", 'F', false, "Husky", new DateTime(2011, 1, 1), 100, 'm', "notes", testVaccs, petRes);
            Assert.Equals(petTemp.number, 10, "custom pet number");
            Assert.Equals(petTemp.name, "Sparky", "custom pet name");
            Assert.Equals(petTemp.sex, 'F', "custom pet sex");
            Assert.Equals(petTemp._fixed, false, "custom pet fixed");
            Assert.Equals(petTemp.breed, "Husky", "custom pet breed");
            Assert.Equals(petTemp.birthdate, new DateTime(2011, 1, 1), "custom pet birthday");
            Assert.Equals(petTemp.picture, Convert.ToByte(100), "Custom pet picture");
            Assert.Equals(petTemp.size, 'm', "custom pet size");
            Assert.Equals(petTemp.special_notes, "notes", "custom pet notes");
            Assert.ListsEqual(petTemp.vaccinations, testVaccs, "custom pet vaccinations");
            Assert.ListsEqual(petTemp.reservations, petRes, "custom pet reservations");
        }

        public static void testPetReservationC() {
            Console.Write("\n");
            PetReservation prDefault = new PetReservation();
            Assert.Equals(prDefault.petResNum, 0, "Default petRes num");
            Assert.Equals(prDefault.petNum, 0, "Default petRes pet");
            Assert.Equals(prDefault.reservationNum, 0, "Default petRes reservation");
            Assert.Equals(prDefault.runNum, 0, "Default petRes run");
            Assert.Equals(prDefault.PRpetResNum, 0, "Default petRes petResNum");
            Assert.Equals(prDefault.run, new Run(), "Default petRes run");
            Assert.Equals(prDefault.food, new Food(), "Default petRes food");
            Assert.Equals(prDefault.res, new Reservation(), "Default petRes reservation");
            Assert.ListsEqual(prDefault.discounts, new List<Discount>(), "Default petRes discounts");
            Assert.ListsEqual(prDefault.meds, new List<Medication>(), "Default petRes medication");
            Assert.ListsEqual(prDefault.logs, new List<KennelLog>(), "Default petRes kennel logs");
            Assert.ListsEqual(prDefault.services, new List<Service>(), "Default petRes services");

            Console.Write("\n");
            PetReservation prRequired = new PetReservation(1, 2, 3);
            Assert.Equals(prRequired.petResNum, 1, "Custom petRes num");
            Assert.Equals(prRequired.petNum, 2, "Custom petRes pet");
            Assert.Equals(prRequired.reservationNum, 3, "Custom petRes reservation");
            Assert.Equals(prRequired.runNum, 0, "Default petRes run");
            Assert.Equals(prRequired.PRpetResNum, 0, "Default petRes petResNum");
            Assert.Equals(prRequired.run, new Run(), "Default petRes run");
            Assert.Equals(prRequired.food, new Food(), "Default petRes food");
            Assert.Equals(prRequired.res, new Reservation(), "Default petRes reservation");
            Assert.ListsEqual(prRequired.discounts, new List<Discount>(), "Default petRes discounts");
            Assert.ListsEqual(prRequired.meds, new List<Medication>(), "Default petRes medication");
            Assert.ListsEqual(prRequired.logs, new List<KennelLog>(), "Default petRes kennel logs");
            Assert.ListsEqual(prRequired.services, new List<Service>(), "Default petRes services");

            Console.Write("\n");
            PetReservation prAll = new PetReservation(1,2,3,4,5);
            Assert.Equals(prAll.petResNum, 1, "Custom petRes num");
            Assert.Equals(prAll.petNum, 2, "Custom petRes pet");
            Assert.Equals(prAll.reservationNum, 3, "Custom petRes reservation");
            Assert.Equals(prAll.runNum, 4, "Custom petRes run");
            Assert.Equals(prAll.PRpetResNum, 5, "Custom petRes petResNum");
            Assert.Equals(prAll.run, new Run(), "Default petRes run");
            Assert.Equals(prAll.food, new Food(), "Default petRes food");
            Assert.Equals(prAll.res, new Reservation(), "Default petRes reservation");
            Assert.ListsEqual(prAll.discounts, new List<Discount>(), "Default petRes discounts");
            Assert.ListsEqual(prAll.meds, new List<Medication>(), "Default petRes medication");
            Assert.ListsEqual(prAll.logs, new List<KennelLog>(), "Default petRes kennel logs");
            Assert.ListsEqual(prAll.services, new List<Service>(), "Default petRes services");

            List<Discount> listDis = new List<Discount>();
            listDis.Add(new Discount());
            List<Medication> listMed = new List<Medication>();
            listMed.Add(new Medication());
            List<KennelLog> listLog = new List<KennelLog>();
            listLog.Add(new KennelLog());
            List<Service> listSer = new List<Service>();
            listSer.Add(new Service());

            Console.Write("\n");
            PetReservation prList = new PetReservation(1, 2, 3, 4, 5, new Run(2, 's'), 
                new Food(30, "brand", "variety"), 
                new Reservation(10, new DateTime(2017, 3, 2), new DateTime(2017, 3, 9)),
                listDis, listMed, listLog, listSer);
            Assert.Equals(prList.petResNum, 1, "Custom petRes num");
            Assert.Equals(prList.petNum, 2, "Custom petRes pet");
            Assert.Equals(prList.reservationNum, 3, "Custom petRes reservation");
            Assert.Equals(prList.runNum, 4, "Custom petRes run");
            Assert.Equals(prList.PRpetResNum, 5, "Custom petRes petResNum");
            Assert.Equals(prList.run, new Run(2, 's'), "Custom petRes run");
            Assert.Equals(prList.food, new Food(30, "brand", "variety"), "Custom petRes food");
            Assert.Equals(prList.res, new Reservation(10, new DateTime(2017, 3, 2), 
                new DateTime(2017, 3, 9)), "Custom petRes reservation");
            Assert.ListsEqual(prList.discounts, listDis, "Custom petRes discounts");
            Assert.ListsEqual(prList.meds, listMed, "Custom petRes medication");
            Assert.ListsEqual(prList.logs, listLog, "Custom petRes kennel logs");
            Assert.ListsEqual(prList.services, listSer, "Custom petRes services");
        }

        public static void testReservationC() {
            Console.Write("\n");
            Reservation resDefault = new Reservation();
            Assert.Equals(resDefault.number, 0, "Default res number");
            Assert.Equals(resDefault.sDate, new DateTime(), "Default res start date");
            Assert.Equals(resDefault.eDate, new DateTime(), "Default res end date");

            Console.Write("\n");
            Reservation resRequired = new Reservation(10, new DateTime(2017, 3, 1), new DateTime(2017, 3, 2));
            Assert.Equals(resRequired.number, 10, "Custom res number");
            Assert.Equals(resRequired.sDate, new DateTime(2017, 3, 1), "Custom res start date");
            Assert.Equals(resRequired.eDate, new DateTime(2017, 3, 2), "Custom res end date");

            Console.Write("\n");
            Reservation resList = new Reservation(10, new DateTime(2017, 3, 1), new DateTime(2017, 3, 2));
            Assert.Equals(resList.number, 10, "Custom res number");
            Assert.Equals(resList.sDate, new DateTime(2017, 3, 1), "Custom res start date");
            Assert.Equals(resList.eDate, new DateTime(2017, 3, 2), "Custom res end date");
        }

        public static void testRunC() {
            Console.Write("\n");
            Run runDefault = new Run();
            Assert.Equals(runDefault.number, 0, "Default run number");
            Assert.Equals(runDefault.size, 's', "Default run size");
            Assert.Equals(runDefault.covered, 'y', "Default run covered");
            Assert.Equals(runDefault.location, 'f', "Default run location");
            Assert.Equals(runDefault.status, 0, "Default run status");

            Console.Write("\n");
            Run runRequired = new Run(10, 'l');
            Assert.Equals(runRequired.number, 10, "Custom run number");
            Assert.Equals(runRequired.size, 'l', "Custom run size");
            Assert.Equals(runRequired.covered, 'y', "Default run covered");
            Assert.Equals(runRequired.location, 'f', "Default run location");
            Assert.Equals(runRequired.status, 0, "Default run status");

            Console.Write("\n");
            Run runAll = new Run(10, 'l', 'n', 'b', 2);
            Assert.Equals(runAll.number, 10, "Custom run number");
            Assert.Equals(runAll.size, 'l', "Custom run size");
            Assert.Equals(runAll.covered, 'n', "Custom run covered");
            Assert.Equals(runAll.location, 'b', "Custom run location");
            Assert.Equals(runAll.status, 2, "Custom run status");
        }

        public static void testServiceC() {
            Console.Write("\n");
            DailyRate rateD = new DailyRate();
            Service serDefault = new Service();
            Assert.Equals(serDefault.number, 0, "Default service number");
            Assert.Equals(serDefault.desc, "", "Default service description");
            Assert.Equals(serDefault.petResNumber, 0, "Default service petRes number");
            Assert.Equals(serDefault.frequency, 0, "Default service frequency");
            Assert.Equals(serDefault.rate, rateD, "Default service rate");

            Console.Write("\n");
            Service serRequired = new Service(10, "desc", 100);
            Assert.Equals(serRequired.number, 10, "Custom service number");
            Assert.Equals(serRequired.desc, "desc", "Custom service description");
            Assert.Equals(serRequired.petResNumber, 100, "Default service petRes number");
            Assert.Equals(serRequired.frequency, 0, "Custom service frequency");
            Assert.Equals(serRequired.rate, rateD, "Default service rate");

            Console.Write("\n");
            Service serAll = new Service(10, "desc", 100, 2);
            Assert.Equals(serAll.number, 10, "Custom service number");
            Assert.Equals(serAll.desc, "desc", "Custom service description");
            Assert.Equals(serAll.petResNumber, 100, "Custom service petRes number");
            Assert.Equals(serAll.frequency, 2, "Custom service frequency");
            Assert.Equals(serAll.rate, rateD, "Default service rate");

            Console.Write("\n");
            DailyRate rateC = new DailyRate(10, 7, 's', 10);
            Service serRate = new Service(10, "desc", 100, 2, rateC);
            Assert.Equals(serRate.number, 10, "Custom service number");
            Assert.Equals(serRate.desc, "desc", "Custom service description");
            Assert.Equals(serRate.petResNumber, 100, "Custom service petRes number");
            Assert.Equals(serRate.frequency, 2, "Custom service frequency");
            Assert.Equals(serRate.rate, rateC, "Custom service rate");
        }

        public static void testVaccinationC() {
            Console.Write("\n");
            Vaccination vacDefault = new Vaccination();
            Assert.Equals(vacDefault.number, 0, "Default vaccination number");
            Assert.Equals(vacDefault.name, "", "Default vaccination name");
            Assert.Equals(vacDefault.expiryDate, new DateTime(), "Default vaccination expiry");

            Console.Write("\n");
            Vaccination vacRequired = new Vaccination(10, "Bordetella", new DateTime(2018, 11, 30));
            Assert.Equals(vacRequired.number, 10, "Custom vaccination number");
            Assert.Equals(vacRequired.name, "Bordetella", "Custom vaccination name");
            Assert.Equals(vacRequired.expiryDate, new DateTime(2018,11,30), "Custom vaccination expiry");
        }

        public static void testVetrinarianC() {
            Console.Write("\n");
            Vetrinarian vetDefault = new Vetrinarian();
            Assert.Equals(vetDefault.number, 0, "Default vet number");
            Assert.Equals(vetDefault.name, "", "Default vet name");
            Assert.Equals(vetDefault.phone, "", "Default vet phone");
            Assert.Equals(vetDefault.street, "", "Default vet street");
            Assert.Equals(vetDefault.city, "", "Default vet city");
            Assert.Equals(vetDefault.province, "", "Default vet province");
            Assert.Equals(vetDefault.postal, "", "Default vet postal ");

            Console.Write("\n");
            Vetrinarian vetRequired = new Vetrinarian(10, "dr. watson", "1234567890");
            Assert.Equals(vetRequired.number, 10, "Custom vet number");
            Assert.Equals(vetRequired.name, "dr. watson", "Custom vet name");
            Assert.Equals(vetRequired.phone, "1234567890", "Custom vet phone");
            Assert.Equals(vetRequired.street, "", "Default vet street");
            Assert.Equals(vetRequired.city, "", "Default vet city");
            Assert.Equals(vetRequired.province, "", "Default vet province");
            Assert.Equals(vetRequired.postal, "", "Default vet postal ");

            Console.Write("\n");
            Vetrinarian vetAll = new Vetrinarian(10, "dr. watson", "1234567890", "221B baker", "London", "ON", "A1A 1A1");
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