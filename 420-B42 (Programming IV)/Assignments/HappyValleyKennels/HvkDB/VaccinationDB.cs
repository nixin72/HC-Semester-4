using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class VaccinationDB
    {
        public DataTable GetFullVaccinationInfo()
        {
            return HVK_SqlConnection.GetData("HVK_VACCINATION");

        }

        public DataTable GetFullPetVaccinationInfo()
        {
            return HVK_SqlConnection.GetData("HVK_PET_VACCINATION");

        }

        public DataTable GetVaccinationInfoForPet(int petNumber)
        {
            return HVK_SqlConnection.GetData("HVK_PET_VACCINATION", "select * from HVK_PET_VACCINATION where pet_pet_number = " + petNumber);
        }

        public int Add(string vaccinationName)
        {
            string cmdStr = "Insert into hvk_vaccination (VACCINATION_NUMBER, VACCINATION_NAME)" +
                                " values (HVK_VACCINATION_SEQ.NEXTVAL," + vaccinationName + ")";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(int vaccinationNumber, string vaccinationName)
        {
            string cmd = "Update hvk_vaccination " +
                                "set vaccination_name = '" + vaccinationName +
                                    "' where vaccination_number = " + vaccinationNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }
        public bool DeleteVaccination(int vaccNumber)
        {
            string cmd = @"Delete from hvk_vaccination 
                                where vaccination_number = " + vaccNumber;
            return HVK_SqlConnection.Delete(cmd);
        }

        /*
         * PET_VACCINATION
         */

        public int Add(DateTime expiryDate, int vaccinationNumber, char vacChecked)
        {
            string cmdStr = "Insert into hvk_pet_vaccination (VACCINATION_EXPIRY_DATE,VACC_VACCINATION_NUMBER," +
                                "PET_PET_NUMBER,VACCINATION_CHECKED_STATUS)" +
                                " values (to_date('" + expiryDate.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd'), " + vaccinationNumber + ", HVK_PET_SEQ.CURRVAL, '" + vacChecked + "')";
            return HVK_SqlConnection.AddRow(cmdStr);
        }//add vaccination for newly added pet

        public int Add(DateTime expiryDate, int vaccinationNumber, int petNumber, char vacChecked)
        {
            string cmdStr = "Insert into hvk_pet_vaccination (VACCINATION_EXPIRY_DATE,VACC_VACCINATION_NUMBER," +
                                "PET_PET_NUMBER,VACCINATION_CHECKED_STATUS)" +
                                " values (to_date('" + expiryDate.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd'), " + vaccinationNumber + ", " + petNumber + ", '" + vacChecked + "')";
            return HVK_SqlConnection.AddRow(cmdStr);
        }



        public bool Update(DateTime expiryDate, int vaccinationNumber, int petNumber, char vacChecked)
        {
            string cmd = "Update hvk_pet_vaccination " +
                                "set vaccination_expiry_date = to_date('" + expiryDate.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd')" +
                                ", vaccination_checked_status = '" + vacChecked +
                                    "' where vacc_vaccination_number = " + vaccinationNumber +
                                    " and pet_pet_number = " + petNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }
        public bool DeletePetVaccination(int petNumber)
        {
            string cmd = @"Delete from hvk_pet_vaccination 
                                where pet_pet_number = " + petNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
