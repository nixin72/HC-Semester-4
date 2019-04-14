using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace HulkHvkBLL {
    public class Pet {
        public int number { get; set; }
        public String name { get; set; }
        public Char sex { get; set; }
        public Boolean _fixed { get; set; }
        public String breed { get; set; }
        public DateTime? birthdate { get; set; }
        public int? picture { get; set; }
        public Char? size { get; set; }
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
            this.size = 'S';
            this.special_notes = "";
            this.ownerNumber = 0;
            vaccinations = new List<Vaccination>();
        }

        public Pet( int num, String name, Char sex, bool pFixed, int owner ) {
            this.number = num;
            this.name = name;
            this.sex = sex;
            this._fixed = pFixed;
            this.breed = "";
            this.birthdate = new DateTime();
            this.picture = 0;
            this.size = 'S';
            this.special_notes = "";
            this.ownerNumber = owner;
            vaccinations = new List<Vaccination>();
        }

        public Pet( int num, String name, Char sex, bool pFixed,
            String breed, DateTime? birth, int owner, int? pic, Char? size, String notes ) {
            this.number = num;
            this.name = name;
            this.sex = sex;
            this._fixed = pFixed;
            this.breed = breed;
            this.birthdate = birth;
            this.ownerNumber = owner;
            this.picture = pic;
            this.size = size;
            this.special_notes = notes;
            vaccinations = new List<Vaccination>();
        }

        public void AddVaccinations() {
            Vaccination vacc = new Vaccination();
            vaccinations = vacc.ListVaccinations(this.number);
        }

        public int CompareTo( Pet pet2 ) {
            return this.name.CompareTo(pet2.name);
        }

        public bool Equals( Pet pet2 ) {
            return this.name == pet2.name;
        }

        public List<Pet> listPets() {
            PetDB petDB = new PetDB();
            DataTable data = petDB.GetFullPetInfo();
            return GetPets(data).OrderBy(p => p.name).ToList();
        }

        

        public static List<Pet> listPetsDir() {
            Pet pet = new Pet();
            return pet.listPets();
        }

        public List<Pet> listPets( int ownerNumber ) {
            return listPets().FindAll(p => p.ownerNumber == ownerNumber);
        }

        public Pet getPet( int petNumber ) {
            Pet pet = listPets().Find(p => p.number == petNumber);
            pet.AddVaccinations();
            return pet;
        }

        private List<Pet> GetPets( DataTable data ) {
            List<Pet> list = new List<Pet>();
            Vaccination vacc = new Vaccination();
            List<Vaccination> vaccs = vacc.ListVaccinations();
            foreach ( DataRow r in data.Rows ) {
                try {
                    Pet temp = new Pet(
                        (int)r[0],
                        (String)r[1],
                        r[2].ToString().ElementAt(0),
                        (String)r[3] == "T" ? true : false,
                        !r.IsNull(4) ? r[4].ToString() : "",
                        !r.IsNull(5) ? (DateTime)r[5] : new DateTime(),
                        !r.IsNull(6) ? (int)r[6] : -1,
                        !r.IsNull(7) ? (int)r[7] : -1,
                        !r.IsNull(8) ? r[8].ToString().ElementAt(0) : ' ',
                        !r.IsNull(9) ? r[9].ToString() : ""
                    );
                    //temp.vaccinations = vaccs.Where(v => v.petNumber == temp.number).ToList();
                    list.Add(temp);
                } catch { }
            };

            return data != null ? list : null;
        }

        public e AddPet( String petName, char petSex, bool isFixed, String breed,
            DateTime? brithdate, int owner, char dogSize, String notes ) {
            e errCode = e.success;
            PetDB petDB = new PetDB();
            if ( petDB.Add(petName, petSex, isFixed ? 'T' : 'F', breed,
                brithdate, owner, dogSize, notes) != 0 ) {
                errCode = e.insertFail;
            }
            return errCode;
        }

        public e Update( int petNumber, String petName, char petSex, bool isFixed, String breed,
            DateTime brithdate, int owner, char dogSize, String notes ) {
            e errCode = e.success;
            PetDB petDB = new PetDB();
            if (petDB.Update(petNumber, petName, petSex, isFixed ? 'T' : 'F', breed,
                brithdate, owner, dogSize, notes) == false ) {
                errCode = e.updateFail;
            }
            return errCode;
        }

        public e removePet(int petNumber) {
            e errCode = e.success;
            

            PetReservation petRes = new PetReservation();
            List<PetReservation> petResList = petRes.ListPetReservations().FindAll(p => p.petNum == petNumber);

            Reservation res = new Reservation();

            for (int i = 0; i < petResList.Count; i++)
            {
                if(res.ListActiveReservation().Find(r => r.number == petResList[i].reservationNum) != null)
                {
                    errCode = e.petInRes;
                }
            }

            if (errCode == e.success)
            {
                PetDB petDB = new PetDB();
                if (petDB.Delete(petNumber) == false)
                {
                    errCode = e.deleteFail;
                }
            }
            return errCode;
        }
    }
}
