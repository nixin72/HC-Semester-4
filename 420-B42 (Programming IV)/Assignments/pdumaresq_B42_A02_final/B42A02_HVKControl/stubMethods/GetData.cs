using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdumaresq_B42_A01;

namespace stubMethods {
    public class GetData {
        public List<DailyRate> dailyRates { get { return getRates(); } }
        public List<Discount> discounts { get { return getDiscounts(); } }
        public List<Food> foods { get { return getFoods(); } }
        public List<KennelLog> kennelLogs { get { return getLogs(); } }
        public List<Medication> medications { get { return getMeds(); } }
        public List<Owner> owners { get { return getOwners(); } }
        public List<Pet> pets { get { return getPets(); } }
        public List<PetReservation> petReservations { get { return getPetRes(); } }
        public List<Reservation> reservations { get { return getRes(); } }
        public List<Run> runs { get { return getRuns();  } }
        public List<Service> services { get { return getServices(); } }
        public List<Vaccination> vaccinations { get { return getVaccs(); } }
        public List<Vetrinarian> vetrinarians { get { return getVets(); } }

        private List<Owner> getOwners() {
            List<Owner> retList = new List<Owner>();
            retList.Add(new Owner(1, "Jane", "Smith"));
            retList.Add(new Owner(2, "Mike", "O'Phone"));
            retList.Add(new Owner(3, "Dwight", "Wong"));
            retList.Add(new Owner(4, "Mahatma", "Coate"));
            retList.Add(new Owner(5, "Sue", "Metu"));
            retList.Add(new Owner(6, "Jeff", "Summers"));
            retList.Add(new Owner(7, "Peter", "Piper"));
            retList.Add(new Owner(8, "Amanda", "Linn"));
            retList.Add(new Owner(10, "April", "Showers"));
            retList.Add(new Owner(11, "Salton", "Pepper"));
            retList.Add(new Owner(12, "Ella", "Mentary"));
            retList.Add(new Owner(13, "Sam", "Ovar"));
            retList.Add(new Owner(14, "Carrie", "Mehome"));
            retList.Add(new Owner(15, "Bayo", "Wolfe"));
            retList.Add(new Owner(16, "Moe", "Bilhome"));
            retList.Add(new Owner(17, "Polly", "Morphek"));
            retList.Add(new Owner(18, "Bard B.", "Que"));
            retList.Add(new Owner(19, "Chester", "Drawers"));
            retList.Add(new Owner(20, "Anita", "Alibi"));

            return retList;
        }

        private List<Pet> getPets() {
            List<Pet> all = new List<Pet>();

            all.Add(new Pet(1, "Scrabble", 'F', !false, 1));
            all.Add(new Pet(2, "Archie", 'F', !false, 1));
            all.Add(new Pet(3, "Jasper", 'M', !false, 2));
            all.Add(new Pet(6, "Huxley", 'M', !false, 2));
            all.Add(new Pet(7, "Charlie", 'M', !false, 4));
            all.Add(new Pet(9, "Parker", 'M', !false, 6));
            all.Add(new Pet(10, "Pete", 'M', !false, 7));
            all.Add(new Pet(11, "Max", 'M', !false, 7));
            all.Add(new Pet(12, "Kitoo", 'F', !false, 7));
            all.Add(new Pet(13, "Logan", 'M', !false, 3));
            all.Add(new Pet(14, "Grizzlie", 'F', !false, 8));
            all.Add(new Pet(16, "Maggie", 'F', false, 10));
            all.Add(new Pet(20, "Poppy", 'F', false, 12));
            all.Add(new Pet(26, "Skarpa", 'F', false, 15));
            all.Add(new Pet(27, "Bothvar", 'M', false, 15));
            all.Add(new Pet(28, "Foxfire", 'F', false, 15));
            all.Add(new Pet(29, "Shaboo", 'F', false, 16));
            all.Add(new Pet(30, "Suki", 'F', false, 17));
            all.Add(new Pet(31, "Sam", 'M', false, 17));
            all.Add(new Pet(32, "Snoop Dogg", 'M', false, 17));
            all.Add(new Pet(33, "Willie", 'M', !false, 18));
            all.Add(new Pet(34, "Aurora", 'F', !false, 19));
            all.Add(new Pet(35, "Bella", 'F', !false, 20));

            return all;
        }

        private List<Reservation> getRes() {
            List<Reservation> reservations = new List<Reservation>();
            reservations.Add(new Reservation(100, DateTime.Parse("15-09-12"), DateTime.Parse("15-09-19"), 1));
            reservations.Add(new Reservation(100, DateTime.Parse("15-09-12"), DateTime.Parse("15-09-19"), 1));
            reservations.Add(new Reservation(102, DateTime.Parse("15-09-16"), DateTime.Parse("15-09-18"), 3));
            reservations.Add(new Reservation(103, DateTime.Parse("15-10-01"), DateTime.Parse("15-11-05"), 2));
            reservations.Add(new Reservation(104, DateTime.Parse("15-10-15"), DateTime.Parse("15-10-22"), 6));
            reservations.Add(new Reservation(105, DateTime.Parse("16-01-01"), DateTime.Parse("16-01-20"), 2));
            reservations.Add(new Reservation(106, DateTime.Parse("16-04-10"), DateTime.Parse("16-04-17"), 2));
            reservations.Add(new Reservation(106, DateTime.Parse("16-04-10"), DateTime.Parse("16-04-17"), 2));
            reservations.Add(new Reservation(108, DateTime.Parse("16-04-30"), DateTime.Parse("16-05-04"), 2));
            reservations.Add(new Reservation(109, DateTime.Parse("16-07-01"), DateTime.Parse("16-07-18"), 7));
            reservations.Add(new Reservation(110, DateTime.Parse("16-07-01"), DateTime.Parse("16-07-18"), 7));
            reservations.Add(new Reservation(110, DateTime.Parse("16-07-01"), DateTime.Parse("16-07-18"), 7));
            reservations.Add(new Reservation(110, DateTime.Parse("16-07-01"), DateTime.Parse("16-07-18"), 7));
            reservations.Add(new Reservation(112, DateTime.Parse("16-07-12"), DateTime.Parse("16-07-19"), 1));
            reservations.Add(new Reservation(112, DateTime.Parse("16-07-12"), DateTime.Parse("16-07-19"), 1));
            reservations.Add(new Reservation(114, DateTime.Parse("16-07-15"), DateTime.Parse("16-07-18"), 8));
            reservations.Add(new Reservation(115, DateTime.Parse("16-07-15"), DateTime.Parse("16-07-17"), 2));
            reservations.Add(new Reservation(115, DateTime.Parse("16-07-15"), DateTime.Parse("16-07-17"), 2));
            reservations.Add(new Reservation(120, DateTime.Parse("16-07-16"), DateTime.Parse("16-07-18"), 6));
            reservations.Add(new Reservation(122, DateTime.Parse("17-01-01"), DateTime.Parse("17-01-05"), 2));
            reservations.Add(new Reservation(123, DateTime.Parse("17-01-01"), DateTime.Parse("17-01-31"), 6));
            reservations.Add(new Reservation(131, DateTime.Parse("16-12-01"), DateTime.Parse("17-01-07"), 12));
            reservations.Add(new Reservation(136, DateTime.Parse("16-12-31"), DateTime.Parse("17-01-09"), 7));
            reservations.Add(new Reservation(137, DateTime.Parse("16-12-31"), DateTime.Parse("17-01-10"), 7));
            reservations.Add(new Reservation(138, DateTime.Parse("16-12-31"), DateTime.Parse("17-01-10"), 3));
            reservations.Add(new Reservation(139, DateTime.Parse("17-01-01"), DateTime.Parse("17-01-10"), 8));
            reservations.Add(new Reservation(140, DateTime.Parse("16-12-25"), DateTime.Parse("17-01-10"), 15));
            reservations.Add(new Reservation(140, DateTime.Parse("16-12-25"), DateTime.Parse("17-01-10"), 15));
            reservations.Add(new Reservation(140, DateTime.Parse("16-12-25"), DateTime.Parse("17-01-10"), 15));
            reservations.Add(new Reservation(143, DateTime.Parse("16-12-03"), DateTime.Parse("16-12-05"), 16));
            reservations.Add(new Reservation(144, DateTime.Parse("16-12-25"), DateTime.Parse("17-01-10"), 16));
            reservations.Add(new Reservation(145, DateTime.Parse("17-01-06"), DateTime.Parse("17-01-08"), 17));
            reservations.Add(new Reservation(145, DateTime.Parse("17-01-06"), DateTime.Parse("17-01-08"), 17));
            reservations.Add(new Reservation(146, DateTime.Parse("16-12-28"), DateTime.Parse("17-01-01"), 17));
            reservations.Add(new Reservation(148, DateTime.Parse("17-01-09"), DateTime.Parse("17-01-12"), 7));
            reservations.Add(new Reservation(148, DateTime.Parse("17-01-09"), DateTime.Parse("17-01-12"), 7));
            reservations.Add(new Reservation(594, DateTime.Parse("16-12-01"), DateTime.Parse("17-01-05"), 1));
            reservations.Add(new Reservation(594, DateTime.Parse("16-12-01"), DateTime.Parse("17-01-05"), 1));
            reservations.Add(new Reservation(595, DateTime.Parse("17-02-28"), DateTime.Parse("17-03-01"), 2));
            reservations.Add(new Reservation(601, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 15));
            reservations.Add(new Reservation(601, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 15));
            reservations.Add(new Reservation(603, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 17));
            reservations.Add(new Reservation(603, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 17));
            reservations.Add(new Reservation(605, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 7));
            reservations.Add(new Reservation(605, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 7));
            reservations.Add(new Reservation(615, DateTime.Parse("17-02-07"), DateTime.Parse("17-02-14"), 2));
            reservations.Add(new Reservation(620, DateTime.Parse("16-04-08"), DateTime.Parse("16-05-09"), 4));
            reservations.Add(new Reservation(625, DateTime.Parse("17-03-15"), DateTime.Parse("17-03-20"), 12));
            reservations.Add(new Reservation(630, DateTime.Parse("17-03-05"), DateTime.Parse("17-03-13"), 18));
            reservations.Add(new Reservation(631, DateTime.Parse("16-01-01"), DateTime.Parse("16-01-04"), 4));
            reservations.Add(new Reservation(632, DateTime.Parse("17-01-07"), DateTime.Parse("17-01-09"), 12));
            reservations.Add(new Reservation(633, DateTime.Parse("17-01-07"), DateTime.Parse("17-01-09"), 17));
            reservations.Add(new Reservation(635, DateTime.Parse("17-03-20"), DateTime.Parse("17-03-25"), 7));
            reservations.Add(new Reservation(636, DateTime.Parse("17-01-09"), DateTime.Parse("17-01-12"), 2));
            reservations.Add(new Reservation(636, DateTime.Parse("17-01-09"), DateTime.Parse("17-01-12"), 2));
            reservations.Add(new Reservation(696, DateTime.Parse("16-11-07"), DateTime.Parse("16-11-16"), 6));
            reservations.Add(new Reservation(700, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 10));
            reservations.Add(new Reservation(701, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 17));
            reservations.Add(new Reservation(702, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 18));
            reservations.Add(new Reservation(703, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 1));
            reservations.Add(new Reservation(703, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 1));
            reservations.Add(new Reservation(704, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 17));
            reservations.Add(new Reservation(705, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 19));
            reservations.Add(new Reservation(707, DateTime.Parse("17-03-15"), DateTime.Parse("17-03-20"), 15));
            reservations.Add(new Reservation(708, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 6));
            reservations.Add(new Reservation(709, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 7));
            reservations.Add(new Reservation(709, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 7));
            reservations.Add(new Reservation(711, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 3));
            reservations.Add(new Reservation(712, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 8));
            reservations.Add(new Reservation(713, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 15));
            reservations.Add(new Reservation(713, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 15));
            reservations.Add(new Reservation(713, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 15));
            reservations.Add(new Reservation(716, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 16));
            reservations.Add(new Reservation(717, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 17));
            reservations.Add(new Reservation(717, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 17));
            reservations.Add(new Reservation(717, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 17));
            reservations.Add(new Reservation(720, DateTime.Parse("17-04-25"), DateTime.Parse("17-04-30"), 2));
            reservations.Add(new Reservation(721, DateTime.Parse("17-04-05"), DateTime.Parse("17-04-09"), 2));
            reservations.Add(new Reservation(800, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 17));
            reservations.Add(new Reservation(800, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 17));
            reservations.Add(new Reservation(801, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 15));
            reservations.Add(new Reservation(801, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 15));
            reservations.Add(new Reservation(802, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 7));
            reservations.Add(new Reservation(802, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 7));
            reservations.Add(new Reservation(804, DateTime.Parse("17-08-20"), DateTime.Parse("17-08-26"), 7));
            reservations.Add(new Reservation(804, DateTime.Parse("17-08-20"), DateTime.Parse("17-08-26"), 7));
            reservations.Add(new Reservation(804, DateTime.Parse("17-08-20"), DateTime.Parse("17-08-26"), 7));
            reservations.Add(new Reservation(809, DateTime.Parse("17-07-02"), DateTime.Parse("17-07-09"), 7));
            reservations.Add(new Reservation(809, DateTime.Parse("17-07-02"), DateTime.Parse("17-07-09"), 7));
            reservations.Add(new Reservation(810, DateTime.Parse("17-03-12"), DateTime.Parse("17-03-17"), 18));
            reservations.Add(new Reservation(811, DateTime.Parse("17-06-26"), DateTime.Parse("17-07-05"), 3));

            return reservations;
        }

        private List<PetReservation> getPetRes() {
            List<PetReservation> pr = new List<PetReservation>();
            pr.Add(new PetReservation(200, 7, 631, 0, 0));
            pr.Add(new PetReservation(201, 20, 632, 0, 0));
            pr.Add(new PetReservation(202, 32, 633, 0, 0));
            pr.Add(new PetReservation(204, 20, 625, 0, 0));
            pr.Add(new PetReservation(205, 33, 630, 0, 0));
            pr.Add(new PetReservation(206, 10, 635, 0, 0));
            pr.Add(new PetReservation(207, 9, 696, 0, 0));
            pr.Add(new PetReservation(208, 26, 707, 0, 0));
            pr.Add(new PetReservation(209, 9, 708, 0, 0));
            pr.Add(new PetReservation(210, 11, 709, 0, 0));
            pr.Add(new PetReservation(211, 13, 711, 0, 0));
            pr.Add(new PetReservation(212, 14, 712, 0, 0));
            pr.Add(new PetReservation(213, 26, 713, 0, 0));
            pr.Add(new PetReservation(214, 29, 716, 0, 0));
            pr.Add(new PetReservation(215, 30, 717, 27, 273));
            pr.Add(new PetReservation(216, 3, 720, 27, 0));
            pr.Add(new PetReservation(217, 3, 721, 27, 0));
            pr.Add(new PetReservation(219, 3, 595, 0, 0));
            pr.Add(new PetReservation(223, 13, 102, 28, 0));
            pr.Add(new PetReservation(224, 6, 103, 36, 0));
            pr.Add(new PetReservation(225, 9, 104, 29, 0));
            pr.Add(new PetReservation(226, 6, 105, 27, 0));
            pr.Add(new PetReservation(227, 3, 108, 36, 0));
            pr.Add(new PetReservation(228, 10, 109, 35, 0));
            pr.Add(new PetReservation(229, 14, 114, 1, 0));
            pr.Add(new PetReservation(230, 3, 115, 27, 0));
            pr.Add(new PetReservation(231, 9, 120, 30, 0));
            pr.Add(new PetReservation(232, 9, 123, 35, 0));
            pr.Add(new PetReservation(233, 20, 131, 29, 0));
            pr.Add(new PetReservation(234, 10, 136, 28, 0));
            pr.Add(new PetReservation(235, 12, 137, 0, 0));
            pr.Add(new PetReservation(236, 13, 138, 21, 0));
            pr.Add(new PetReservation(237, 14, 139, 30, 0));
            pr.Add(new PetReservation(239, 27, 140, 1, 0));
            pr.Add(new PetReservation(240, 29, 143, 28, 0));
            pr.Add(new PetReservation(241, 29, 144, 14, 0));
            pr.Add(new PetReservation(242, 30, 145, 27, 0));
            pr.Add(new PetReservation(243, 31, 146, 27, 0));
            pr.Add(new PetReservation(249, 6, 122, 36, 0));
            pr.Add(new PetReservation(250, 6, 615, 0, 0));
            pr.Add(new PetReservation(251, 16, 700, 0, 0));
            pr.Add(new PetReservation(252, 7, 620, 0, 0));
            pr.Add(new PetReservation(253, 30, 701, 0, 0));
            pr.Add(new PetReservation(254, 33, 702, 0, 0));
            pr.Add(new PetReservation(255, 2, 703, 0, 0));
            pr.Add(new PetReservation(256, 32, 704, 0, 0));
            pr.Add(new PetReservation(257, 34, 705, 0, 0));
            pr.Add(new PetReservation(261, 1, 703, 0, 0));
            pr.Add(new PetReservation(264, 6, 115, 27, 0));
            pr.Add(new PetReservation(268, 12, 709, 0, 0));
            pr.Add(new PetReservation(270, 27, 713, 0, 0));
            pr.Add(new PetReservation(271, 28, 713, 0, 0));
            pr.Add(new PetReservation(272, 31, 145, 13, 0));
            pr.Add(new PetReservation(273, 31, 717, 0, 215));
            pr.Add(new PetReservation(274, 32, 717, 0, 0));
            pr.Add(new PetReservation(284, 6, 636, 0, 285));
            pr.Add(new PetReservation(285, 3, 636, 0, 284));
            pr.Add(new PetReservation(286, 1, 594, 36, 287));
            pr.Add(new PetReservation(287, 2, 594, 36, 286));
            pr.Add(new PetReservation(288, 26, 601, 0, 289));
            pr.Add(new PetReservation(289, 27, 601, 0, 288));
            pr.Add(new PetReservation(292, 31, 603, 0, 293));
            pr.Add(new PetReservation(293, 32, 603, 0, 292));
            pr.Add(new PetReservation(294, 11, 605, 0, 295));
            pr.Add(new PetReservation(295, 12, 605, 0, 294));
            pr.Add(new PetReservation(296, 26, 140, 2, 297));
            pr.Add(new PetReservation(297, 28, 140, 2, 296));
            pr.Add(new PetReservation(298, 11, 148, 27, 299));
            pr.Add(new PetReservation(299, 10, 148, 27, 298));
            pr.Add(new PetReservation(300, 1, 112, 29, 301));
            pr.Add(new PetReservation(301, 2, 112, 29, 300));
            pr.Add(new PetReservation(302, 1, 100, 29, 303));
            pr.Add(new PetReservation(303, 2, 100, 29, 302));
            pr.Add(new PetReservation(304, 3, 106, 27, 305));
            pr.Add(new PetReservation(305, 6, 106, 27, 304));
            pr.Add(new PetReservation(306, 11, 110, 36, 307));
            pr.Add(new PetReservation(307, 12, 110, 36, 306));
            pr.Add(new PetReservation(308, 10, 110, 0, 0));
            pr.Add(new PetReservation(400, 31, 800, 0, 401));
            pr.Add(new PetReservation(401, 32, 800, 0, 400));
            pr.Add(new PetReservation(402, 26, 801, 0, 403));
            pr.Add(new PetReservation(403, 27, 801, 0, 402));
            pr.Add(new PetReservation(404, 10, 802, 0, 0));
            pr.Add(new PetReservation(405, 11, 802, 0, 0));
            pr.Add(new PetReservation(410, 10, 804, 0, 0));
            pr.Add(new PetReservation(411, 11, 804, 0, 0));
            pr.Add(new PetReservation(412, 12, 804, 0, 0));
            pr.Add(new PetReservation(424, 11, 809, 0, 425));
            pr.Add(new PetReservation(425, 12, 809, 0, 424));
            pr.Add(new PetReservation(426, 33, 810, 0, 0));
            pr.Add(new PetReservation(427, 13, 811, 0, 0));

            return pr;
        }

        private List<Vaccination> getVaccs() {
            List<Vaccination> vaccs = new List<Vaccination>();
            vaccs.Add(new Vaccination(1, "Bordetella", 1, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(6, "Rabies", 1, 'N' == 'Y' ? true : false, DateTime.Parse("18-03-05")));
            vaccs.Add(new Vaccination(5, "Parovirus", 1, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 1, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 1, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(2, "Distemper", 1, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(5, "Parovirus", 2, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(6, "Rabies", 2, 'N' == 'Y' ? true : false, DateTime.Parse("18-03-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 2, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 2, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(2, "Distemper", 2, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(1, "Bordetella", 2, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-05")));
            vaccs.Add(new Vaccination(1, "Bordetella", 3, 'Y' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(5, "Parovirus", 3, 'Y' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 3, 'Y' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 3, 'Y' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(6, "Rabies", 3, 'Y' == 'Y' ? true : false, DateTime.Parse("18-09-05")));
            vaccs.Add(new Vaccination(2, "Distemper", 3, 'Y' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 6, 'Y' == 'Y' ? true : false, DateTime.Parse("16-03-07")));
            vaccs.Add(new Vaccination(6, "Rabies", 6, 'Y' == 'Y' ? true : false, DateTime.Parse("17-08-07")));
            vaccs.Add(new Vaccination(5, "Parovirus", 6, 'Y' == 'Y' ? true : false, DateTime.Parse("16-03-07")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 6, 'Y' == 'Y' ? true : false, DateTime.Parse("16-03-07")));
            vaccs.Add(new Vaccination(2, "Distemper", 6, 'Y' == 'Y' ? true : false, DateTime.Parse("16-10-03")));
            vaccs.Add(new Vaccination(1, "Bordetella", 6, 'Y' == 'Y' ? true : false, DateTime.Parse("16-03-07")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 7, 'N' == 'Y' ? true : false, DateTime.Parse("16-07-07")));
            vaccs.Add(new Vaccination(2, "Distemper", 7, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-07")));
            vaccs.Add(new Vaccination(1, "Bordetella", 7, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-07")));
            vaccs.Add(new Vaccination(6, "Rabies", 7, 'N' == 'Y' ? true : false, DateTime.Parse("17-11-17")));
            vaccs.Add(new Vaccination(2, "Distemper", 9, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(1, "Bordetella", 9, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(6, "Rabies", 9, 'N' == 'Y' ? true : false, DateTime.Parse("18-09-05")));
            vaccs.Add(new Vaccination(5, "Parovirus", 9, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 9, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 9, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 11, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(6, "Rabies", 11, 'N' == 'Y' ? true : false, DateTime.Parse("18-09-05")));
            vaccs.Add(new Vaccination(2, "Distemper", 11, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(1, "Bordetella", 11, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 11, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(5, "Parovirus", 11, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(5, "Parovirus", 12, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 12, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 12, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(2, "Distemper", 12, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(1, "Bordetella", 12, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(6, "Rabies", 12, 'N' == 'Y' ? true : false, DateTime.Parse("18-09-05")));
            vaccs.Add(new Vaccination(1, "Bordetella", 13, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(2, "Distemper", 13, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 13, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(6, "Rabies", 13, 'N' == 'Y' ? true : false, DateTime.Parse("18-09-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 13, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(5, "Parovirus", 13, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 14, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 14, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(2, "Distemper", 14, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(1, "Bordetella", 14, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(5, "Parovirus", 14, 'N' == 'Y' ? true : false, DateTime.Parse("17-09-05")));
            vaccs.Add(new Vaccination(1, "Bordetella", 16, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-21")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 16, 'N' == 'Y' ? true : false, DateTime.Parse("17-03-02")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 16, 'N' == 'Y' ? true : false, DateTime.Parse("16-03-21")));
            vaccs.Add(new Vaccination(6, "Rabies", 16, 'N' == 'Y' ? true : false, DateTime.Parse("18-06-02")));
            vaccs.Add(new Vaccination(2, "Distemper", 20, 'N' == 'Y' ? true : false, DateTime.Parse("18-04-02")));
            vaccs.Add(new Vaccination(6, "Rabies", 20, 'N' == 'Y' ? true : false, DateTime.Parse("18-06-02")));
            vaccs.Add(new Vaccination(5, "Parovirus", 20, 'N' == 'Y' ? true : false, DateTime.Parse("18-03-21")));
            vaccs.Add(new Vaccination(1, "Bordetella", 20, 'N' == 'Y' ? true : false, DateTime.Parse("18-04-02")));
            vaccs.Add(new Vaccination(6, "Rabies", 26, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(1, "Bordetella", 26, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(2, "Distemper", 26, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(5, "Parovirus", 26, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 26, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 26, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(2, "Distemper", 27, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(1, "Bordetella", 27, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 27, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(5, "Parovirus", 27, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(6, "Rabies", 27, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 27, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(2, "Distemper", 28, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 28, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 28, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(5, "Parovirus", 28, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(6, "Rabies", 28, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(1, "Bordetella", 28, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(6, "Rabies", 29, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(5, "Parovirus", 29, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 29, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 29, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(2, "Distemper", 29, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(1, "Bordetella", 29, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(1, "Bordetella", 30, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 30, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 30, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(5, "Parovirus", 30, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(6, "Rabies", 30, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(2, "Distemper", 30, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(1, "Bordetella", 31, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(6, "Rabies", 31, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(5, "Parovirus", 31, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 31, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 31, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(2, "Distemper", 31, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(6, "Rabies", 32, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(5, "Parovirus", 32, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 32, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 32, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(2, "Distemper", 32, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(1, "Bordetella", 32, 'N' == 'Y' ? true : false, DateTime.Parse("17-12-08")));
            vaccs.Add(new Vaccination(6, "Rabies", 33, 'N' == 'Y' ? true : false, DateTime.Parse("18-05-12")));
            vaccs.Add(new Vaccination(5, "Parovirus", 33, 'N' == 'Y' ? true : false, DateTime.Parse("18-05-12")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 33, 'N' == 'Y' ? true : false, DateTime.Parse("17-05-12")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 33, 'N' == 'Y' ? true : false, DateTime.Parse("17-05-12")));
            vaccs.Add(new Vaccination(2, "Distemper", 33, 'N' == 'Y' ? true : false, DateTime.Parse("17-05-12")));
            vaccs.Add(new Vaccination(1, "Bordetella", 33, 'N' == 'Y' ? true : false, DateTime.Parse("17-05-12")));
            vaccs.Add(new Vaccination(1, "Bordetella", 35, 'N' == 'Y' ? true : false, DateTime.Parse("17-01-10")));
            vaccs.Add(new Vaccination(2, "Distemper", 35, 'N' == 'Y' ? true : false, DateTime.Parse("17-01-10")));
            vaccs.Add(new Vaccination(3, "Hepatitis", 35, 'N' == 'Y' ? true : false, DateTime.Parse("17-01-10")));
            vaccs.Add(new Vaccination(4, "Parainfluenza", 35, 'N' == 'Y' ? true : false, DateTime.Parse("17-01-10")));
            vaccs.Add(new Vaccination(5, "Parovirus", 35, 'N' == 'Y' ? true : false, DateTime.Parse("17-01-10")));
            vaccs.Add(new Vaccination(6, "Rabies", 35, 'N' == 'Y' ? true : false, DateTime.Parse("17-01-10")));
            return vaccs;
        }

        private List<Service> getServices() {
            List<Service> servs = new List<Service>();
            servs.Add(new Service(4, "Medication", 264, 0));
            servs.Add(new Service(1, "Boarding", 200, 0));
            servs.Add(new Service(1, "Boarding", 201, 0));
            servs.Add(new Service(1, "Boarding", 202, 0));
            servs.Add(new Service(1, "Boarding", 204, 0));
            servs.Add(new Service(1, "Boarding", 205, 0));
            servs.Add(new Service(1, "Boarding", 206, 0));
            servs.Add(new Service(1, "Boarding", 219, 0));
            servs.Add(new Service(1, "Boarding", 225, 0));
            servs.Add(new Service(5, "Playtime", 225, 0));
            servs.Add(new Service(1, "Boarding", 231, 0));
            servs.Add(new Service(5, "Playtime", 231, 0));
            servs.Add(new Service(1, "Boarding", 223, 0));
            servs.Add(new Service(2, "Walk", 223, 0));
            servs.Add(new Service(1, "Boarding", 224, 0));
            servs.Add(new Service(5, "Playtime", 224, 0));
            servs.Add(new Service(3, "Grooming", 224, 2));
            servs.Add(new Service(1, "Boarding", 229, 0));
            servs.Add(new Service(2, "Walk", 229, 0));
            servs.Add(new Service(3, "Grooming", 229, 1));
            servs.Add(new Service(1, "Boarding", 230, 0));
            servs.Add(new Service(5, "Playtime", 230, 0));
            servs.Add(new Service(1, "Boarding", 264, 0));
            servs.Add(new Service(5, "Playtime", 264, 0));
            servs.Add(new Service(3, "Grooming", 264, 1));
            servs.Add(new Service(1, "Boarding", 232, 0));
            servs.Add(new Service(5, "Playtime", 232, 0));
            servs.Add(new Service(1, "Boarding", 228, 0));
            servs.Add(new Service(2, "Walk", 228, 0));
            servs.Add(new Service(1, "Boarding", 226, 0));
            servs.Add(new Service(1, "Boarding", 227, 0));
            servs.Add(new Service(1, "Boarding", 233, 0));
            servs.Add(new Service(2, "Walk", 233, 0));
            servs.Add(new Service(1, "Boarding", 234, 0));
            servs.Add(new Service(1, "Boarding", 235, 0));
            servs.Add(new Service(1, "Boarding", 236, 0));
            servs.Add(new Service(1, "Boarding", 237, 0));
            servs.Add(new Service(1, "Boarding", 239, 0));
            servs.Add(new Service(1, "Boarding", 240, 0));
            servs.Add(new Service(1, "Boarding", 241, 0));
            servs.Add(new Service(1, "Boarding", 242, 0));
            servs.Add(new Service(1, "Boarding", 243, 0));
            servs.Add(new Service(1, "Boarding", 272, 0));
            servs.Add(new Service(1, "Boarding", 298, 0));
            servs.Add(new Service(1, "Boarding", 249, 0));
            servs.Add(new Service(5, "Playtime", 249, 0));
            servs.Add(new Service(3, "Grooming", 249, 1));
            servs.Add(new Service(3, "Grooming", 237, 1));
            servs.Add(new Service(4, "Medication", 240, 0));
            servs.Add(new Service(3, "Grooming", 233, 2));
            servs.Add(new Service(3, "Grooming", 234, 3));
            servs.Add(new Service(5, "Playtime", 234, 0));
            servs.Add(new Service(2, "Walk", 234, 0));
            servs.Add(new Service(1, "Boarding", 250, 0));
            servs.Add(new Service(1, "Boarding", 252, 0));
            servs.Add(new Service(1, "Boarding", 251, 0));
            servs.Add(new Service(1, "Boarding", 253, 0));
            servs.Add(new Service(1, "Boarding", 254, 0));
            servs.Add(new Service(1, "Boarding", 255, 0));
            servs.Add(new Service(1, "Boarding", 256, 0));
            servs.Add(new Service(1, "Boarding", 257, 0));
            servs.Add(new Service(1, "Boarding", 261, 0));
            servs.Add(new Service(1, "Boarding", 299, 0));
            servs.Add(new Service(1, "Boarding", 207, 0));
            servs.Add(new Service(1, "Boarding", 208, 0));
            servs.Add(new Service(1, "Boarding", 209, 0));
            servs.Add(new Service(1, "Boarding", 210, 0));
            servs.Add(new Service(1, "Boarding", 211, 0));
            servs.Add(new Service(1, "Boarding", 212, 0));
            servs.Add(new Service(1, "Boarding", 213, 0));
            servs.Add(new Service(1, "Boarding", 214, 0));
            servs.Add(new Service(1, "Boarding", 215, 0));
            servs.Add(new Service(1, "Boarding", 216, 0));
            servs.Add(new Service(1, "Boarding", 217, 0));
            servs.Add(new Service(1, "Boarding", 268, 0));
            servs.Add(new Service(1, "Boarding", 270, 0));
            servs.Add(new Service(1, "Boarding", 271, 0));
            servs.Add(new Service(1, "Boarding", 273, 0));
            servs.Add(new Service(1, "Boarding", 274, 0));
            servs.Add(new Service(1, "Boarding", 404, 0));
            servs.Add(new Service(1, "Boarding", 405, 0));
            servs.Add(new Service(1, "Boarding", 410, 0));
            servs.Add(new Service(1, "Boarding", 411, 0));
            servs.Add(new Service(1, "Boarding", 412, 0));
            servs.Add(new Service(2, "Walk", 405, 0));
            servs.Add(new Service(1, "Boarding", 285, 0));
            servs.Add(new Service(1, "Boarding", 284, 0));
            servs.Add(new Service(1, "Boarding", 287, 0));
            servs.Add(new Service(5, "Playtime", 287, 0));
            servs.Add(new Service(3, "Grooming", 287, 2));
            servs.Add(new Service(1, "Boarding", 286, 0));
            servs.Add(new Service(1, "Boarding", 288, 0));
            servs.Add(new Service(1, "Boarding", 289, 0));
            servs.Add(new Service(1, "Boarding", 292, 0));
            servs.Add(new Service(1, "Boarding", 293, 0));
            servs.Add(new Service(1, "Boarding", 294, 0));
            servs.Add(new Service(1, "Boarding", 295, 0));
            servs.Add(new Service(1, "Boarding", 296, 0));
            servs.Add(new Service(1, "Boarding", 302, 0));
            servs.Add(new Service(2, "Walk", 302, 0));
            servs.Add(new Service(4, "Medication", 302, 0));
            servs.Add(new Service(1, "Boarding", 303, 0));
            servs.Add(new Service(2, "Walk", 303, 0));
            servs.Add(new Service(1, "Boarding", 300, 0));
            servs.Add(new Service(2, "Walk", 300, 0));
            servs.Add(new Service(4, "Medication", 300, 0));
            servs.Add(new Service(1, "Boarding", 301, 0));
            servs.Add(new Service(2, "Walk", 301, 0));
            servs.Add(new Service(1, "Boarding", 304, 0));
            servs.Add(new Service(5, "Playtime", 304, 0));
            servs.Add(new Service(1, "Boarding", 305, 0));
            servs.Add(new Service(5, "Playtime", 305, 0));
            servs.Add(new Service(3, "Grooming", 305, 1));
            servs.Add(new Service(1, "Boarding", 306, 0));
            servs.Add(new Service(2, "Walk", 306, 0));
            servs.Add(new Service(3, "Grooming", 306, 1));
            servs.Add(new Service(1, "Boarding", 307, 0));
            servs.Add(new Service(2, "Walk", 307, 0));
            servs.Add(new Service(3, "Grooming", 307, 1));
            servs.Add(new Service(4, "Medication", 287, 0));
            servs.Add(new Service(3, "Grooming", 296, 2));
            servs.Add(new Service(2, "Walk", 296, 0));
            servs.Add(new Service(5, "Playtime", 296, 0));
            servs.Add(new Service(1, "Boarding", 297, 0));
            servs.Add(new Service(1, "Boarding", 400, 0));
            servs.Add(new Service(1, "Boarding", 401, 0));
            servs.Add(new Service(1, "Boarding", 402, 0));
            servs.Add(new Service(1, "Boarding", 403, 0));
            servs.Add(new Service(1, "Boarding", 424, 0));
            servs.Add(new Service(1, "Boarding", 425, 0));
            servs.Add(new Service(1, "Boarding", 426, 0));
            servs.Add(new Service(1, "Boarding", 427, 0));
            servs.Add(new Service(1, "Boarding", 308, 0));
            servs.Add(new Service(4, "Medication", 308, 0));

            return servs;
        }

        private List<DailyRate> getRates() {
            List<DailyRate> rates = new List<DailyRate>();
            rates.Add(new DailyRate(1, 10, 'S', 1));
            rates.Add(new DailyRate(2, 11, 'M', 1));
            rates.Add(new DailyRate(3, 12, 'L', 1));
            rates.Add(new DailyRate(4, 2, 'S', 2));
            rates.Add(new DailyRate(5, 3, 'M', 2));
            rates.Add(new DailyRate(6, 4, 'L', 2));
            rates.Add(new DailyRate(7, 2, 'S', 3));
            rates.Add(new DailyRate(8, 3, 'M', 3));
            rates.Add(new DailyRate(9, 4, 'L', 3));
            rates.Add(new DailyRate(10, 2, 'I', 5));
            rates.Add(new DailyRate(11, 1, 'I', 4));

            return rates;
        }

        private List<Food> getFoods() {
            List<Food> foods = new List<Food>();
            foods.Add(new Food(1, "Iams", "Mini Chunks"));
            foods.Add(new Food(2, "Iams", "Large dog"));
            foods.Add(new Food(3, "Iams", "Weight Control"));
            foods.Add(new Food(4, "Iams", "Beef and rice formula"));
            foods.Add(new Food(5, "President's choice", "Xtra Meaty Chicken and Rice"));
            foods.Add(new Food(6, "President's choice", "Xtra Meaty Lamb and Rice"));
            foods.Add(new Food(7, "Purina", "Dog Chow"));
            foods.Add(new Food(11, "Science Diet", "Allergy Formula"));
            foods.Add(new Food(14, "Pedigree", "Choice Cuts in Sauce Country Stew"));
            foods.Add(new Food(15, "Purina", "Moist Meaty Burger with Cheddar Cheese Burger with Cheddar Cheese"));

            return foods;
        }

        private List<KennelLog> getLogs() {
            List<KennelLog> log = new List<KennelLog>();

            return log;
        }

        private List<Medication> getMeds() {
            List<Medication> meds = new List<Medication>();
            meds.Add(new Medication(2, "Tapzole", "1/2 tablet once daily", null, DateTime.Parse(""), 264));
            meds.Add(new Medication(4, "Medicam", "36 kg", null, DateTime.Parse(""), 240));
            meds.Add(new Medication(3, "Prednisone", "1 tablet twice daily", null, DateTime.Parse(""), 287));
            meds.Add(new Medication(1, "Prednisone", "1 tablet twice daily", null, DateTime.Parse(""), 300));
            meds.Add(new Medication(10, "Medicam", "15 kg", null, DateTime.Parse(""), 308));
            return meds;
        }

        private List<Discount> getDiscounts() {
            List<Discount> dis = new List<Discount>();
            dis.Add(new Discount(1, "Share run", 10, 'D'));
            dis.Add(new Discount(2, "Multiple pets", 7, 'T'));
            dis.Add(new Discount(3, "Own food", 10, 'D'));

            return dis;

        }

        private List<Vetrinarian> getVets() {
            List<Vetrinarian> vets = new List<Vetrinarian>();
            vets.Add(new Vetrinarian(1, "Dr. I. Care", "8195552122"));
            vets.Add(new Vetrinarian(2, "Dr. Sandy Beech", "8195559238"));
            vets.Add(new Vetrinarian(5, "Dr. Frankenstein", "8888888888"));
            vets.Add(new Vetrinarian(6, "Dr. Jorge Potter", "1234567890"));
            vets.Add(new Vetrinarian(7, "Dr. Akura Petforu", "1234567890"));

            return vets;
        }

        private List<Run> getRuns() {
            List<Run> run = new List<Run>();
            run.Add(new Run(1, 'R', 'F', 'F', 1));
            run.Add(new Run(2, 'R', 'F', 'F', 1));
            run.Add(new Run(13, 'L', 'F', 'F', 1));
            run.Add(new Run(14, 'L', 'F', 'F', 1));
            run.Add(new Run(21, 'L', 'F', 'B', 1));
            run.Add(new Run(22, 'L', 'F', 'B', 1));
            run.Add(new Run(27, 'L', 'T', 'B', 1));
            run.Add(new Run(28, 'L', 'T', 'B', 1));
            run.Add(new Run(29, 'R', 'T', 'B', 1));
            run.Add(new Run(30, 'R', 'T', 'B', 1));
            run.Add(new Run(35, 'R', 'F', 'B', 1));
            run.Add(new Run(36, 'R', 'F', 'B', 1));

            return run;
        }
    }
}
