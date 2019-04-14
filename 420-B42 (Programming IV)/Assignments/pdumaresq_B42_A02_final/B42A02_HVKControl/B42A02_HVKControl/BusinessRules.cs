using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdumaresq_B42_A01;
using stubMethods;

namespace B42A02_HVKControl
{
    public class BusinessRules
    {
        GetData data = new GetData();

        public List<Owner> listOwners() {
            return data.owners;
        }

        public List<Pet> listPets() {
            List<Pet> all = data.pets;

            all.ForEach(p => p.vaccinations
                .AddRange(data.vaccinations
                .FindAll(v => v.petNumber == p.number)));

            
            return all;
        }

        public List<Pet> listPets(int ownerNumber) {
            List<Pet> all = listPets();
            return all.FindAll(p => p.ownerNumber == ownerNumber);
        }

       
        public List<Reservation> listReservations() {
            List<Reservation> reservations = data.reservations;

            return reservations;
        }

        public List<Reservation> listReservations(int ownerNumber) {   
            return data.reservations.FindAll(r => r.ownerNumber == ownerNumber);
        }

        public List<PetReservation> listPetReservation() {
            List<PetReservation> pr = data.petReservations;
            return pr;
        }

        public List<List<String>> listActiveReservations() {
            List<Owner> owners = data.owners;
            List<Pet> pets = data.pets;
            List<Reservation> reservations = data.reservations;
            List<PetReservation> petRes = data.petReservations;

            List<List<String>> activeRes = new List<List<string>>();
            foreach (var x in reservations) {
                if (x.sDate > DateTime.Now && x.eDate < DateTime.Now) {
                    List<String> info = new List<string>();
                    info.Add(x.number.ToString());
                    info.Add(owners.Find(o => o.number == x.ownerNumber).ToString());
                    
                    foreach (Pet p in pets.FindAll(p => p.reservations.Exists(r => r.number == x.number))) {
                        info.Add(p.number.ToString());
                        info.Add(p.name);
                        info.Add(petRes.Find(pr => pr.petNum == p.number && pr.res.number == x.number).runNum.ToString());
                    }

                    info.Add(x.sDate.ToString("MM/dd/yyyy"));
                    info.Add(x.eDate.ToString("MM/dd/yyyy"));

                    activeRes.Add(info);
                }
            }
            return activeRes;
        }

        public List<List<String>> listActiveReservations(int ownerNumber) {
            return listActiveReservations().FindAll(l => l[1] == ownerNumber.ToString());
        }

        public List<Vaccination> listVaccinations(int petNumber) {
            return listPets().Find(p => p.number == petNumber).vaccinations;
        }

        public List<Vaccination> checkVaccination(int reservationNumber, int petNumber) {
            List<Vaccination> vaccs = new List<Vaccination>();
            
            //foreach(Pet p in listPets()) {
            //    if (p.number == petNumber)
            //    foreach (Vaccination v in p.vaccinations) {
                    
            //    }
            //}

            foreach (Vaccination p in listPets().Find(p => p.number == petNumber).vaccinations) {
                if (p.expiryDate <= listReservations().Find(r => r.number == reservationNumber).eDate) {
                    vaccs.Add(p);
                }
            }

            return vaccs;
        }

        public List<List<String>> upcomingReservations(DateTime date) {
            List<Reservation> res = listReservations();
            List<Pet> pets = listPets();

            List<List<String>> list = new List<List<string>>();
            foreach (Reservation r in res.FindAll(r => r.sDate <= date)) {
                List<String> thisres = new List<String>();

                thisres.Add(r.number.ToString());
                thisres.Add(r.ownerNumber.ToString());

                foreach (Pet p in pets
                        .FindAll(p => listOwners()
                        .Find(o => o.number == r.ownerNumber).number == p.ownerNumber)) {

                    Owner own = listOwners().Find(o => o.number == r.ownerNumber);
                    thisres.Add(p.number.ToString());
                }

                thisres.Add(r.sDate.ToString("MM/dd/yyyy"));
                thisres.Add(r.eDate.ToString("MM/dd/yyyy"));
                list.Add(thisres);
            }
            return list;
        }
    }
}
