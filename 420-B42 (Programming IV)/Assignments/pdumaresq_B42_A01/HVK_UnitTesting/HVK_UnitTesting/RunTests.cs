using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVK_UnitTesting {
    class RunTests {
        public static void Main(string[] args) {
            Console.SetBufferSize(Console.BufferWidth, 500);
            Console.Write("TESTING ACCESSOR AND MUTATOR METHODS\n");
            Console.Write("----------------------------------------------------------------------\n");
            TestAccessorsMutators.testDailyRate();
            TestAccessorsMutators.testDiscount();
            TestAccessorsMutators.testFood();
            TestAccessorsMutators.testKennelLog();
            TestAccessorsMutators.testMedication();
            TestAccessorsMutators.testOwner();
            TestAccessorsMutators.testPet();
            TestAccessorsMutators.testPetReservation();
            TestAccessorsMutators.testRun();
            TestAccessorsMutators.testService();
            TestAccessorsMutators.testVaccination();
            TestAccessorsMutators.testVetrinarian();

            Console.Write("\n\n\nTESTING CONSTRUCTOR METHODS\n");
            Console.Write("----------------------------------------------------------------------\n");
            TestConstructors.testDailyRateC();
            TestConstructors.testDiscountC();
            TestConstructors.testFoodC();
            TestConstructors.testKennelLogC();
            TestConstructors.testMedicationC();
            TestConstructors.testOwnerC();
            TestConstructors.testPetC();
            TestConstructors.testPetReservationC();
            TestConstructors.testRunC();
            TestConstructors.testServiceC();
            TestConstructors.testVaccinationC();
            TestConstructors.testVetrinarianC();

            exit();
        }

        public static void exit() {
            Console.Write("\n\nEnter \"exit\" to terminate the program.\n>> ");
            String e = Console.ReadLine();
            if (e == "exit") {
                System.Environment.Exit(0);
            }
            else {
                exit();
            }
        }
    }
}
