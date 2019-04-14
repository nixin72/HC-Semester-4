using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class PetDB
    {
        public DataTable GetFullPetInfo()
        {
            return HVK_SqlConnection.GetData("HVK_PET");
        }

        public DataTable GetDataByOwnerNumber(int ownerNumber)
        {
            return HVK_SqlConnection.GetData("HVK_PET", "select * from HVK_PET where own_owner_number = " + ownerNumber);
        }

        public int Add(string name, char gender, char isFixed, string breed,
            DateTime? birthdate, int ownerNumber, char dogSize, string notes)
        {
            string cmdStr = null;
            if (birthdate.HasValue)
            {
                cmdStr = "Insert into hvk_pet (PET_NUMBER, PET_NAME, PET_GENDER," +
                                "PET_FIXED, PET_BREED, PET_BIRTHDATE, OWN_OWNER_NUMBER, DOG_SIZE," +
                                "SPECIAL_NOTES)" +
                                " values (HVK_PET_SEQ.NEXTVAL,'" + name + "','" + gender + "','" + isFixed + "','" + breed + "',  to_date('" + birthdate.Value.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd')," + ownerNumber + ",'" + dogSize + "','" + notes + "')";
            }
            else
            {
                cmdStr = "Insert into hvk_pet (PET_NUMBER, PET_NAME, PET_GENDER," +
                "PET_FIXED, PET_BREED, PET_BIRTHDATE, OWN_OWNER_NUMBER, DOG_SIZE," +
                "SPECIAL_NOTES)" +
                " values (HVK_PET_SEQ.NEXTVAL,'" + name + "','" + gender + "','" + isFixed + "','" + breed + "','" + birthdate + "'," + ownerNumber + ",'" + dogSize + "','" + notes + "')";
            }


            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(int petNumber, string name, char gender, char isFixed, string breed,
            DateTime birthdate, int ownerNumber, char dogSize, string notes)
        {
            string cmd = "Update hvk_pet " +
                                "set pet_name = '" + name +
                                "', pet_gender = '" + gender +
                                "', pet_fixed = '" + isFixed +
                                "', pet_breed = '" + breed +
                                "', pet_birthdate = to_date('" + birthdate.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd')" +
                                ", own_owner_number = " + ownerNumber +
                                ", dog_size = '" + dogSize +
                                "', special_notes = '" + notes +
                                    "' where pet_number = " + petNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }
        public bool Delete(int petNumber)
        {
            //Change this to Different DB Class Calls
            //string cmd1 = @"Delete from hvk_pet_vaccination where PET_PET_NUMBER = " + petNumber;

            VaccinationDB vaccDB = new VaccinationDB();
            //vaccDB.DeletePetVaccination(petNumber);

            string cmd2 = @"Delete from HVK_PET_RESERVATION_SERVICE
                            WHERE PR_PET_RES_NUMBER IN
                            (SELECT pr.PET_RES_NUMBER
                            FROM HVK_PET_RESERVATION pr
                            JOIN HVK_PET_RESERVATION_SERVICE prs
                            ON pr.PET_RES_NUMBER    = prs.PR_PET_RES_NUMBER
                            WHERE pr.PET_PET_NUMBER = " + petNumber + ")";

            //string cmd3 = "Delete from hvk_pet_reservation where PET_PET_NUMBER = " + petNumber;
            PetReservationDB petDB = new PetReservationDB();
            //petDB.RemovePetRes(petNumber);

            string cmd4 = @"Delete from hvk_pet where pet_number = " + petNumber;
            if (vaccDB.DeletePetVaccination(petNumber))
                if (HVK_SqlConnection.Delete(cmd2))
                    if (petDB.RemovePetRes(petNumber))
                        if (HVK_SqlConnection.Delete(cmd4))
                            return true;
            return false;
        }
    }
}
