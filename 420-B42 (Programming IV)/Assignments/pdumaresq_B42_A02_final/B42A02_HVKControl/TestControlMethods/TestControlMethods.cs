using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B42A02_HVKControl;
using pdumaresq_B42_A01;
using stubMethods;

namespace TestBusinessRules {
    [TestClass]
    public class TestBusinessRules {
        [TestMethod]
        public void testListOwners() {
            var test = new BusinessRules();

            Assert.AreEqual(19, test.listOwners().Count);
            Assert.AreEqual(test.listOwners()[0].ToString(), new Owner(1, "Jane", "Smith").ToString());
            Assert.AreEqual(test.listOwners()[18].ToString(), new Owner(20, "Anita", "Alibi").ToString());
        }

        [TestMethod]
        public void TestListPets() {
            var test = new BusinessRules();

            Assert.AreEqual(test.listPets().Count, 23);
            Assert.AreEqual(test.listPets()[0].ToString(), new Pet(1, "Scrabble", 'F', !false, 1).ToString());
            Assert.AreEqual(test.listPets()[22].ToString(), new Pet(35, "Bella", 'F', !false, 20).ToString());
        }

        [TestMethod]
        public void TestListPetOverride() {
            var test = new BusinessRules();
            
            foreach (var o in test.listOwners()) {
                var x = 0;
                foreach (var p in test.listPets(o.number)) {
                    Assert.AreEqual(p.ownerNumber, o.number);
                    x++;
                }
            }
        }

        [TestMethod]
        public void TestListReservations() {
            var test = new BusinessRules();

            Assert.AreEqual(test.listReservations()[0].ToString(), new Reservation(100, DateTime.Parse("15-09-12"), DateTime.Parse("15-09-19"), 1).ToString());
            Assert.AreEqual(test.listReservations()[1].ToString(), new Reservation(100, DateTime.Parse("15-09-12"), DateTime.Parse("15-09-19"), 1).ToString());
            Assert.AreEqual(test.listReservations()[2].ToString(), new Reservation(102, DateTime.Parse("15-09-16"), DateTime.Parse("15-09-18"), 3).ToString());
            Assert.AreEqual(test.listReservations()[3].ToString(), new Reservation(103, DateTime.Parse("15-10-01"), DateTime.Parse("15-11-05"), 2).ToString());
            Assert.AreEqual(test.listReservations()[4].ToString(), new Reservation(104, DateTime.Parse("15-10-15"), DateTime.Parse("15-10-22"), 6).ToString());
            Assert.AreEqual(test.listReservations()[5].ToString(), new Reservation(105, DateTime.Parse("16-01-01"), DateTime.Parse("16-01-20"), 2).ToString());
            Assert.AreEqual(test.listReservations()[6].ToString(), new Reservation(106, DateTime.Parse("16-04-10"), DateTime.Parse("16-04-17"), 2).ToString());
            Assert.AreEqual(test.listReservations()[7].ToString(), new Reservation(106, DateTime.Parse("16-04-10"), DateTime.Parse("16-04-17"), 2).ToString());
            Assert.AreEqual(test.listReservations()[8].ToString(), new Reservation(108, DateTime.Parse("16-04-30"), DateTime.Parse("16-05-04"), 2).ToString());
            Assert.AreEqual(test.listReservations()[9].ToString(), new Reservation(109, DateTime.Parse("16-07-01"), DateTime.Parse("16-07-18"), 7).ToString());
            Assert.AreEqual(test.listReservations()[10].ToString(), new Reservation(110, DateTime.Parse("16-07-01"), DateTime.Parse("16-07-18"), 7).ToString());
            Assert.AreEqual(test.listReservations()[11].ToString(), new Reservation(110, DateTime.Parse("16-07-01"), DateTime.Parse("16-07-18"), 7).ToString());
            Assert.AreEqual(test.listReservations()[12].ToString(), new Reservation(110, DateTime.Parse("16-07-01"), DateTime.Parse("16-07-18"), 7).ToString());
            Assert.AreEqual(test.listReservations()[13].ToString(), new Reservation(112, DateTime.Parse("16-07-12"), DateTime.Parse("16-07-19"), 1).ToString());
            Assert.AreEqual(test.listReservations()[14].ToString(), new Reservation(112, DateTime.Parse("16-07-12"), DateTime.Parse("16-07-19"), 1).ToString());
            Assert.AreEqual(test.listReservations()[15].ToString(), new Reservation(114, DateTime.Parse("16-07-15"), DateTime.Parse("16-07-18"), 8).ToString());
            Assert.AreEqual(test.listReservations()[16].ToString(), new Reservation(115, DateTime.Parse("16-07-15"), DateTime.Parse("16-07-17"), 2).ToString());
            Assert.AreEqual(test.listReservations()[17].ToString(), new Reservation(115, DateTime.Parse("16-07-15"), DateTime.Parse("16-07-17"), 2).ToString());
            Assert.AreEqual(test.listReservations()[18].ToString(), new Reservation(120, DateTime.Parse("16-07-16"), DateTime.Parse("16-07-18"), 6).ToString());
            Assert.AreEqual(test.listReservations()[19].ToString(), new Reservation(122, DateTime.Parse("17-01-01"), DateTime.Parse("17-01-05"), 2).ToString());
            Assert.AreEqual(test.listReservations()[20].ToString(), new Reservation(123, DateTime.Parse("17-01-01"), DateTime.Parse("17-01-31"), 6).ToString());
            Assert.AreEqual(test.listReservations()[21].ToString(), new Reservation(131, DateTime.Parse("16-12-01"), DateTime.Parse("17-01-07"), 12).ToString());
            Assert.AreEqual(test.listReservations()[22].ToString(), new Reservation(136, DateTime.Parse("16-12-31"), DateTime.Parse("17-01-09"), 7).ToString());
            Assert.AreEqual(test.listReservations()[23].ToString(), new Reservation(137, DateTime.Parse("16-12-31"), DateTime.Parse("17-01-10"), 7).ToString());
            Assert.AreEqual(test.listReservations()[24].ToString(), new Reservation(138, DateTime.Parse("16-12-31"), DateTime.Parse("17-01-10"), 3).ToString());
            Assert.AreEqual(test.listReservations()[25].ToString(), new Reservation(139, DateTime.Parse("17-01-01"), DateTime.Parse("17-01-10"), 8).ToString());
            Assert.AreEqual(test.listReservations()[26].ToString(), new Reservation(140, DateTime.Parse("16-12-25"), DateTime.Parse("17-01-10"), 15).ToString());
            Assert.AreEqual(test.listReservations()[27].ToString(), new Reservation(140, DateTime.Parse("16-12-25"), DateTime.Parse("17-01-10"), 15).ToString());
            Assert.AreEqual(test.listReservations()[28].ToString(), new Reservation(140, DateTime.Parse("16-12-25"), DateTime.Parse("17-01-10"), 15).ToString());
            Assert.AreEqual(test.listReservations()[29].ToString(), new Reservation(143, DateTime.Parse("16-12-03"), DateTime.Parse("16-12-05"), 16).ToString());
            Assert.AreEqual(test.listReservations()[30].ToString(), new Reservation(144, DateTime.Parse("16-12-25"), DateTime.Parse("17-01-10"), 16).ToString());
            Assert.AreEqual(test.listReservations()[31].ToString(), new Reservation(145, DateTime.Parse("17-01-06"), DateTime.Parse("17-01-08"), 17).ToString());
            Assert.AreEqual(test.listReservations()[32].ToString(), new Reservation(145, DateTime.Parse("17-01-06"), DateTime.Parse("17-01-08"), 17).ToString());
            Assert.AreEqual(test.listReservations()[33].ToString(), new Reservation(146, DateTime.Parse("16-12-28"), DateTime.Parse("17-01-01"), 17).ToString());
            Assert.AreEqual(test.listReservations()[34].ToString(), new Reservation(148, DateTime.Parse("17-01-09"), DateTime.Parse("17-01-12"), 7).ToString());
            Assert.AreEqual(test.listReservations()[35].ToString(), new Reservation(148, DateTime.Parse("17-01-09"), DateTime.Parse("17-01-12"), 7).ToString());
            Assert.AreEqual(test.listReservations()[36].ToString(), new Reservation(594, DateTime.Parse("16-12-01"), DateTime.Parse("17-01-05"), 1).ToString());
            Assert.AreEqual(test.listReservations()[37].ToString(), new Reservation(594, DateTime.Parse("16-12-01"), DateTime.Parse("17-01-05"), 1).ToString());
            Assert.AreEqual(test.listReservations()[38].ToString(), new Reservation(595, DateTime.Parse("17-02-28"), DateTime.Parse("17-03-01"), 2).ToString());
            Assert.AreEqual(test.listReservations()[39].ToString(), new Reservation(601, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 15).ToString());
            Assert.AreEqual(test.listReservations()[40].ToString(), new Reservation(601, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 15).ToString());
            Assert.AreEqual(test.listReservations()[41].ToString(), new Reservation(603, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 17).ToString());
            Assert.AreEqual(test.listReservations()[42].ToString(), new Reservation(603, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 17).ToString());
            Assert.AreEqual(test.listReservations()[43].ToString(), new Reservation(605, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 7).ToString());
            Assert.AreEqual(test.listReservations()[44].ToString(), new Reservation(605, DateTime.Parse("17-03-01"), DateTime.Parse("17-03-07"), 7).ToString());
            Assert.AreEqual(test.listReservations()[45].ToString(), new Reservation(615, DateTime.Parse("17-02-07"), DateTime.Parse("17-02-14"), 2).ToString());
            Assert.AreEqual(test.listReservations()[46].ToString(), new Reservation(620, DateTime.Parse("16-04-08"), DateTime.Parse("16-05-09"), 4).ToString());
            Assert.AreEqual(test.listReservations()[47].ToString(), new Reservation(625, DateTime.Parse("17-03-15"), DateTime.Parse("17-03-20"), 12).ToString());
            Assert.AreEqual(test.listReservations()[48].ToString(), new Reservation(630, DateTime.Parse("17-03-05"), DateTime.Parse("17-03-13"), 18).ToString());
            Assert.AreEqual(test.listReservations()[49].ToString(), new Reservation(631, DateTime.Parse("16-01-01"), DateTime.Parse("16-01-04"), 4).ToString());
            Assert.AreEqual(test.listReservations()[50].ToString(), new Reservation(632, DateTime.Parse("17-01-07"), DateTime.Parse("17-01-09"), 12).ToString());
            Assert.AreEqual(test.listReservations()[51].ToString(), new Reservation(633, DateTime.Parse("17-01-07"), DateTime.Parse("17-01-09"), 17).ToString());
            Assert.AreEqual(test.listReservations()[52].ToString(), new Reservation(635, DateTime.Parse("17-03-20"), DateTime.Parse("17-03-25"), 7).ToString());
            Assert.AreEqual(test.listReservations()[53].ToString(), new Reservation(636, DateTime.Parse("17-01-09"), DateTime.Parse("17-01-12"), 2).ToString());
            Assert.AreEqual(test.listReservations()[54].ToString(), new Reservation(636, DateTime.Parse("17-01-09"), DateTime.Parse("17-01-12"), 2).ToString());
            Assert.AreEqual(test.listReservations()[55].ToString(), new Reservation(696, DateTime.Parse("16-11-07"), DateTime.Parse("16-11-16"), 6).ToString());
            Assert.AreEqual(test.listReservations()[56].ToString(), new Reservation(700, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 10).ToString());
            Assert.AreEqual(test.listReservations()[57].ToString(), new Reservation(701, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 17).ToString());
            Assert.AreEqual(test.listReservations()[58].ToString(), new Reservation(702, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 18).ToString());
            Assert.AreEqual(test.listReservations()[59].ToString(), new Reservation(703, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 1).ToString());
            Assert.AreEqual(test.listReservations()[60].ToString(), new Reservation(703, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 1).ToString());
            Assert.AreEqual(test.listReservations()[61].ToString(), new Reservation(704, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 17).ToString());
            Assert.AreEqual(test.listReservations()[62].ToString(), new Reservation(705, DateTime.Parse("17-01-10"), DateTime.Parse("17-01-12"), 19).ToString());
            Assert.AreEqual(test.listReservations()[63].ToString(), new Reservation(707, DateTime.Parse("17-03-15"), DateTime.Parse("17-03-20"), 15).ToString());
            Assert.AreEqual(test.listReservations()[64].ToString(), new Reservation(708, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 6).ToString());
            Assert.AreEqual(test.listReservations()[65].ToString(), new Reservation(709, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 7).ToString());
            Assert.AreEqual(test.listReservations()[66].ToString(), new Reservation(709, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 7).ToString());
            Assert.AreEqual(test.listReservations()[67].ToString(), new Reservation(711, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 3).ToString());
            Assert.AreEqual(test.listReservations()[68].ToString(), new Reservation(712, DateTime.Parse("17-04-15"), DateTime.Parse("17-04-20"), 8).ToString());
            Assert.AreEqual(test.listReservations()[69].ToString(), new Reservation(713, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 15).ToString());
            Assert.AreEqual(test.listReservations()[70].ToString(), new Reservation(713, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 15).ToString());
            Assert.AreEqual(test.listReservations()[71].ToString(), new Reservation(713, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 15).ToString());
            Assert.AreEqual(test.listReservations()[72].ToString(), new Reservation(716, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 16).ToString());
            Assert.AreEqual(test.listReservations()[73].ToString(), new Reservation(717, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 17).ToString());
            Assert.AreEqual(test.listReservations()[74].ToString(), new Reservation(717, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 17).ToString());
            Assert.AreEqual(test.listReservations()[75].ToString(), new Reservation(717, DateTime.Parse("17-04-10"), DateTime.Parse("17-04-25"), 17).ToString());
            Assert.AreEqual(test.listReservations()[76].ToString(), new Reservation(720, DateTime.Parse("17-04-25"), DateTime.Parse("17-04-30"), 2).ToString());
            Assert.AreEqual(test.listReservations()[77].ToString(), new Reservation(721, DateTime.Parse("17-04-05"), DateTime.Parse("17-04-09"), 2).ToString());
            Assert.AreEqual(test.listReservations()[78].ToString(), new Reservation(800, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 17).ToString());
            Assert.AreEqual(test.listReservations()[79].ToString(), new Reservation(800, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 17).ToString());
            Assert.AreEqual(test.listReservations()[80].ToString(), new Reservation(801, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 15).ToString());
            Assert.AreEqual(test.listReservations()[81].ToString(), new Reservation(801, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 15).ToString());
            Assert.AreEqual(test.listReservations()[82].ToString(), new Reservation(802, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 7).ToString());
            Assert.AreEqual(test.listReservations()[83].ToString(), new Reservation(802, DateTime.Parse("17-06-20"), DateTime.Parse("17-06-26"), 7).ToString());
            Assert.AreEqual(test.listReservations()[84].ToString(), new Reservation(804, DateTime.Parse("17-08-20"), DateTime.Parse("17-08-26"), 7).ToString());
            Assert.AreEqual(test.listReservations()[85].ToString(), new Reservation(804, DateTime.Parse("17-08-20"), DateTime.Parse("17-08-26"), 7).ToString());
            Assert.AreEqual(test.listReservations()[86].ToString(), new Reservation(804, DateTime.Parse("17-08-20"), DateTime.Parse("17-08-26"), 7).ToString());
            Assert.AreEqual(test.listReservations()[87].ToString(), new Reservation(809, DateTime.Parse("17-07-02"), DateTime.Parse("17-07-09"), 7).ToString());
            Assert.AreEqual(test.listReservations()[88].ToString(), new Reservation(809, DateTime.Parse("17-07-02"), DateTime.Parse("17-07-09"), 7).ToString());
            Assert.AreEqual(test.listReservations()[89].ToString(), new Reservation(810, DateTime.Parse("17-03-12"), DateTime.Parse("17-03-17"), 18).ToString());
            Assert.AreEqual(test.listReservations()[90].ToString(), new Reservation(811, DateTime.Parse("17-06-26"), DateTime.Parse("17-07-05"), 3).ToString());
        }

        [TestMethod]
        public void ListReservationsOverride() {
            var test = new BusinessRules();

            foreach (var o in test.listOwners()) {
                foreach (var r in test.listReservations(o.number)) {
                    Assert.AreEqual(r.ownerNumber, o.number);
                }
            }
        }

        [TestMethod]
        public void ListPetReservations() {
            var test = new BusinessRules();

            Assert.AreEqual(test.listPetReservation()[0].ToString(), new PetReservation(200, 7, 631, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[1].ToString(), new PetReservation(201, 20, 632, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[2].ToString(), new PetReservation(202, 32, 633, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[3].ToString(), new PetReservation(204, 20, 625, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[4].ToString(), new PetReservation(205, 33, 630, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[5].ToString(), new PetReservation(206, 10, 635, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[6].ToString(), new PetReservation(207, 9, 696, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[7].ToString(), new PetReservation(208, 26, 707, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[8].ToString(), new PetReservation(209, 9, 708, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[9].ToString(), new PetReservation(210, 11, 709, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[10].ToString(), new PetReservation(211, 13, 711, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[11].ToString(), new PetReservation(212, 14, 712, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[12].ToString(), new PetReservation(213, 26, 713, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[13].ToString(), new PetReservation(214, 29, 716, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[14].ToString(), new PetReservation(215, 30, 717, 27, 273).ToString());
            Assert.AreEqual(test.listPetReservation()[15].ToString(), new PetReservation(216, 3, 720, 27, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[16].ToString(), new PetReservation(217, 3, 721, 27, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[17].ToString(), new PetReservation(219, 3, 595, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[18].ToString(), new PetReservation(223, 13, 102, 28, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[19].ToString(), new PetReservation(224, 6, 103, 36, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[20].ToString(), new PetReservation(225, 9, 104, 29, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[21].ToString(), new PetReservation(226, 6, 105, 27, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[22].ToString(), new PetReservation(227, 3, 108, 36, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[23].ToString(), new PetReservation(228, 10, 109, 35, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[24].ToString(), new PetReservation(229, 14, 114, 1, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[25].ToString(), new PetReservation(230, 3, 115, 27, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[26].ToString(), new PetReservation(231, 9, 120, 30, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[27].ToString(), new PetReservation(232, 9, 123, 35, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[28].ToString(), new PetReservation(233, 20, 131, 29, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[29].ToString(), new PetReservation(234, 10, 136, 28, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[30].ToString(), new PetReservation(235, 12, 137, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[31].ToString(), new PetReservation(236, 13, 138, 21, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[32].ToString(), new PetReservation(237, 14, 139, 30, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[33].ToString(), new PetReservation(239, 27, 140, 1, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[34].ToString(), new PetReservation(240, 29, 143, 28, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[35].ToString(), new PetReservation(241, 29, 144, 14, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[36].ToString(), new PetReservation(242, 30, 145, 27, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[37].ToString(), new PetReservation(243, 31, 146, 27, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[38].ToString(), new PetReservation(249, 6, 122, 36, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[39].ToString(), new PetReservation(250, 6, 615, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[40].ToString(), new PetReservation(251, 16, 700, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[41].ToString(), new PetReservation(252, 7, 620, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[42].ToString(), new PetReservation(253, 30, 701, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[43].ToString(), new PetReservation(254, 33, 702, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[44].ToString(), new PetReservation(255, 2, 703, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[45].ToString(), new PetReservation(256, 32, 704, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[46].ToString(), new PetReservation(257, 34, 705, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[47].ToString(), new PetReservation(261, 1, 703, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[48].ToString(), new PetReservation(264, 6, 115, 27, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[49].ToString(), new PetReservation(268, 12, 709, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[50].ToString(), new PetReservation(270, 27, 713, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[51].ToString(), new PetReservation(271, 28, 713, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[52].ToString(), new PetReservation(272, 31, 145, 13, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[53].ToString(), new PetReservation(273, 31, 717, 0, 215).ToString());
            Assert.AreEqual(test.listPetReservation()[54].ToString(), new PetReservation(274, 32, 717, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[55].ToString(), new PetReservation(284, 6, 636, 0, 285).ToString());
            Assert.AreEqual(test.listPetReservation()[56].ToString(), new PetReservation(285, 3, 636, 0, 284).ToString());
            Assert.AreEqual(test.listPetReservation()[57].ToString(), new PetReservation(286, 1, 594, 36, 287).ToString());
            Assert.AreEqual(test.listPetReservation()[58].ToString(), new PetReservation(287, 2, 594, 36, 286).ToString());
            Assert.AreEqual(test.listPetReservation()[59].ToString(), new PetReservation(288, 26, 601, 0, 289).ToString());
            Assert.AreEqual(test.listPetReservation()[60].ToString(), new PetReservation(289, 27, 601, 0, 288).ToString());
            Assert.AreEqual(test.listPetReservation()[61].ToString(), new PetReservation(292, 31, 603, 0, 293).ToString());
            Assert.AreEqual(test.listPetReservation()[62].ToString(), new PetReservation(293, 32, 603, 0, 292).ToString());
            Assert.AreEqual(test.listPetReservation()[63].ToString(), new PetReservation(294, 11, 605, 0, 295).ToString());
            Assert.AreEqual(test.listPetReservation()[64].ToString(), new PetReservation(295, 12, 605, 0, 294).ToString());
            Assert.AreEqual(test.listPetReservation()[65].ToString(), new PetReservation(296, 26, 140, 2, 297).ToString());
            Assert.AreEqual(test.listPetReservation()[66].ToString(), new PetReservation(297, 28, 140, 2, 296).ToString());
            Assert.AreEqual(test.listPetReservation()[67].ToString(), new PetReservation(298, 11, 148, 27, 299).ToString());
            Assert.AreEqual(test.listPetReservation()[68].ToString(), new PetReservation(299, 10, 148, 27, 298).ToString());
            Assert.AreEqual(test.listPetReservation()[69].ToString(), new PetReservation(300, 1, 112, 29, 301).ToString());
            Assert.AreEqual(test.listPetReservation()[70].ToString(), new PetReservation(301, 2, 112, 29, 300).ToString());
            Assert.AreEqual(test.listPetReservation()[71].ToString(), new PetReservation(302, 1, 100, 29, 303).ToString());
            Assert.AreEqual(test.listPetReservation()[72].ToString(), new PetReservation(303, 2, 100, 29, 302).ToString());
            Assert.AreEqual(test.listPetReservation()[73].ToString(), new PetReservation(304, 3, 106, 27, 305).ToString());
            Assert.AreEqual(test.listPetReservation()[74].ToString(), new PetReservation(305, 6, 106, 27, 304).ToString());
            Assert.AreEqual(test.listPetReservation()[75].ToString(), new PetReservation(306, 11, 110, 36, 307).ToString());
            Assert.AreEqual(test.listPetReservation()[76].ToString(), new PetReservation(307, 12, 110, 36, 306).ToString());
            Assert.AreEqual(test.listPetReservation()[77].ToString(), new PetReservation(308, 10, 110, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[78].ToString(), new PetReservation(400, 31, 800, 0, 401).ToString());
            Assert.AreEqual(test.listPetReservation()[79].ToString(), new PetReservation(401, 32, 800, 0, 400).ToString());
            Assert.AreEqual(test.listPetReservation()[80].ToString(), new PetReservation(402, 26, 801, 0, 403).ToString());
            Assert.AreEqual(test.listPetReservation()[81].ToString(), new PetReservation(403, 27, 801, 0, 402).ToString());
            Assert.AreEqual(test.listPetReservation()[82].ToString(), new PetReservation(404, 10, 802, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[83].ToString(), new PetReservation(405, 11, 802, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[84].ToString(), new PetReservation(410, 10, 804, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[85].ToString(), new PetReservation(411, 11, 804, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[86].ToString(), new PetReservation(412, 12, 804, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[87].ToString(), new PetReservation(424, 11, 809, 0, 425).ToString());
            Assert.AreEqual(test.listPetReservation()[88].ToString(), new PetReservation(425, 12, 809, 0, 424).ToString());
            Assert.AreEqual(test.listPetReservation()[89].ToString(), new PetReservation(426, 33, 810, 0, 0).ToString());
            Assert.AreEqual(test.listPetReservation()[90].ToString(), new PetReservation(427, 13, 811, 0, 0).ToString());
        }

        [TestMethod]
        public void TestListActiveReservations() {
            var test = new BusinessRules();

            Assert.AreEqual(test.listActiveReservations().Count, 0);
        }

        [TestMethod]
        public void TestListActiveReservationsOverride() {
            var test = new BusinessRules();

            foreach (var o in test.listOwners()) {
                Assert.AreEqual(test.listActiveReservations(o.number).Count, 0);
            }
        }

        [TestMethod]
        public void TestListVaccinations() {
            var test = new BusinessRules();

            foreach (var p in test.listPets()) {
                var vaccs = new List<Vaccination>();
                foreach (var r in test.listReservations(p.number)) {
                    p.vaccinations.FindAll(v => v.expiryDate < r.eDate).ForEach(v => vaccs.Add(v) );


                    var a = vaccs.SequenceEqual(test.checkVaccination(r.number, p.number));
                    var b = test.checkVaccination(r.number, p.number).SequenceEqual(vaccs);
                    Assert.AreEqual(a, b);
                }
            }
        }

        [TestMethod]
        public void TestUpcomingReservations() {
            var test = new BusinessRules();
            
            Assert.AreEqual(test.upcomingReservations(new DateTime(2017, 2, 13)).Count, 53);

        }
    }
}
