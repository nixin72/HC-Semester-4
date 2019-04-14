using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class Pet {
        public int number { get; set; }
        public String name { get; set; }
        public Char sex { get; set; }
        public Boolean _fixed { get; set; }
        public String breed { get; set; }
        public DateTime birthdate { get; set; }
        public byte picture { get; set; }
        public Char size { get; set; }
        public String special_notes { get; set; }
        public List<Vaccination> vaccinations { get; set; }
        public List<PetReservation> reservations {get; set;} 

        public Pet() {
            this.number = 0;
            this.name = "";
            this.sex = 'M';
            this._fixed = true;
            this.breed = "";
            this.birthdate = new DateTime();
            this.picture = 0;
            this.size = 's';
            this.special_notes = "";
            vaccinations = new List<Vaccination>();
            this.reservations = new List<PetReservation>();
        }

        public Pet(int num, String name, Char sex, bool pFixed) {
            this.number = num;
            this.name = name;
            this.sex = sex;
            this._fixed = pFixed;
            this.breed = "";
            this.birthdate = new DateTime();
            this.picture = 0;
            this.size = 's';
            this.special_notes = "";
            vaccinations = new List<Vaccination>();
            this.reservations = new List<PetReservation>();
        }

        public Pet(int num, String name, Char sex, bool pFixed,
            String breed, DateTime birth, byte pic, Char size, String notes) {
            this.number = num;
            this.name = name;
            this.sex = sex;
            this._fixed = pFixed;
            this.breed = breed;
            this.birthdate = birth;
            this.picture = pic;
            this.size = size;
            this.special_notes = notes;
            this.vaccinations = new List<Vaccination>();
            this.reservations = new List<PetReservation>();
        }

        public Pet(int num, String name, Char sex, bool pFixed, String breed, 
            DateTime birth, byte picture, Char size, String notes, List<Vaccination> vaccs) {
            this.number = num;
            this.name = name;
            this.sex = sex;
            this._fixed = pFixed;
            this.breed = breed;
            this.birthdate = birth;
            this.picture = picture;
            this.size = size;
            this.special_notes = notes;
            this.vaccinations = vaccs;
            this.reservations = new List<PetReservation>();
        }

        //Wouldn't every actually use this constructor, just for testing.
        //You wouldn't ever create a pet and reservations at the same time. 
        public Pet(int num, String name, Char sex, bool pFixed, String breed,
    DateTime birth, byte picture, Char size, String notes, List<Vaccination> vaccs, List<PetReservation> res)
        {
            this.number = num;
            this.name = name;
            this.sex = sex;
            this._fixed = pFixed;
            this.breed = breed;
            this.birthdate = birth;
            this.picture = picture;
            this.size = size;
            this.special_notes = notes;
            this.vaccinations = vaccs;
            this.reservations = res;
        }

        public int CompareTo(Pet pet2) {
            return this.name.CompareTo(pet2.name);
        }

        public bool Equals(Pet pet2) {
            return this.name == pet2.name;
        }
    }
}
