using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class PetDB {
        public DataTable GetFullPetInfo() {
            //            dsHvkTableAdapters.HVK_PETTableAdapter adapter = new dsHvkTableAdapters.HVK_PETTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_PET");

        }

        public DataTable GetDataByOwnerNumber(int ownerNumber) {
            //            dsHvkTableAdapters.HVK_PETTableAdapter adapter = new dsHvkTableAdapters.HVK_PETTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetDataByOwnerNumber(ownerNumber);
            return HVK_SqlConnection.GetData("HVK_PET","select * from HVK_PET where own_owner_number = " + ownerNumber);
        }
        public int Add(string name, char gender, char isFixed, string breed,
            DateTime birthdate, int ownerNumber, char dogSize, string notes)
        {
            string cmdStr = "Insert into hvk_pet (PET_NUMBER, PET_NAME, PET_GENDER," +
                                "PET_FIXED, PET_BREED, PET_BIRTHDATE, OWN_OWNER_NUMBER, DOG_SIZE," +
                                "SPECIAL_NOTES)" +
                                " values (HVK_PET_SEQ.NEXTVAL," + name + "," + gender + "," + isFixed + "," + breed +
                                "," + birthdate.ToShortDateString() + "," + ownerNumber + "," + dogSize + "," +
                                notes  + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_pet_seq");
        }

        public bool Update(int petNumber, string name, char gender, char isFixed, string breed,
            DateTime birthdate, int ownerNumber, char dogSize, string notes)
        {
            string cmd = @"Update hvk_pet 
                                set pet_name = :name, 
                                pet_gender = :gender,
                                pet_fixed = :isFixed,
                                pet_breed = :breed,
                                pet_birthdate = :birthdate,
                                own_owner_number = :ownerNumber,
                                dog_size = :dogSize,
                                special_notes = :notes
                                    where pet_number = :petNumber;";
            List<string> list = new List<string>();
            list.Add("petNumber~" + petNumber);
            list.Add("name~" + name);
            list.Add("gender~" + gender);
            list.Add("isFixed~" + isFixed);
            list.Add("breed~" + breed);
            list.Add("birthdate~" + birthdate.ToShortDateString());
            list.Add("ownerNumber~" + ownerNumber);
            list.Add("dogSize~" + dogSize);
            list.Add("notes~" + notes);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
