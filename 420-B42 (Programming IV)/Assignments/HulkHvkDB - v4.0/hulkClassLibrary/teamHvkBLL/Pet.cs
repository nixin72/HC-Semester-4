using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamHvkBLL {
    class Pet {
        public int number { get; set; }
        public String name { get; set; }
        public Char sex { get; set; }
        public Boolean _fixed { get; set; }
        public String breed { get; set; }
        public DateTime birthdate { get; set; }
        public byte picture { get; set; }
        public Char size { get; set; }
        public String special_notes { get; set; }
        public int ownerNumber { get; set; }

        private List<Vaccination> vaccs;
        public List<Vaccination> vaccinations {
            get { return vaccs; }
            set { vaccs = value; }
        }

        private List<Reservation> res;
        public List<Reservation> reservations {
            get { return res; }
            set { res = value; }
        }


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
            this.ownerNumber = 0;
            vaccinations = new List<Vaccination>();

        }

        public Pet(int num, String name, Char sex, bool pFixed, int owner) {
            this.number = num;
            this.name = name;
            this.sex = sex;
            this._fixed = pFixed;
            this.breed = "";
            this.birthdate = new DateTime();
            this.picture = 0;
            this.size = 's';
            this.special_notes = "";
            this.ownerNumber = owner;
            vaccinations = new List<Vaccination>();
        }

        public Pet(int num, String name, Char sex, bool pFixed,
            String breed, DateTime birth, byte pic, Char size, String notes, int owner) {
            this.number = num;
            this.name = name;
            this.sex = sex;
            this._fixed = pFixed;
            this.breed = breed;
            this.birthdate = birth;
            this.picture = pic;
            this.size = size;
            this.special_notes = notes;
            this.ownerNumber = owner;
            vaccinations = new List<Vaccination>();
        }

        public int CompareTo(Pet pet2) {
            return this.name.CompareTo(pet2.name);
        }

        public bool Equals(Pet pet2) {
            return this.name == pet2.name;
        }

        public List<Pet> ListPets() {
            return new List<Pet>();
        }

        public List<Pet> ListPets(int ownerNumber) {
            return ListPets();
        }

        
    }
}
