using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB
{
    public class PetVaccinationDB
    {
        public DataTable GetFullPetVaccinationInfo()
        {
            return HVK_SqlConnection.GetData("HVK_PET_VACCINATION");
        }
        public int Add(DateTime expiryDate, int vaccinationNumber, int petNumber, char vacChecked)
        {
            string cmdStr = "Insert into hvk_pet_vaccination (VACCINATION_EXPIRY_DATE,VACC_VACCINATION_NUMBER," +
                                "PET_PET_NUMBER,VACCINATION_CHECKED_STATUS)" +
                                " values (" + expiryDate.ToShortDateString() + ", " + vaccinationNumber + ", " +
                                petNumber + ", " + vacChecked + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"");
        }

        public bool Update(DateTime expiryDate, int vaccinationNumber, int petNumber, char vacChecked)
        {
            string cmd = @"Update hvk_pet_vaccination 
                                set vaccination_expiry_date = :expiryDate, 
                                vaccination_checked_status = :vacChecked                                
                                    where vacc_vaccination_number = :vaccinationNumber and
                                        pet_pet_number = :petNumber";
            List<string> list = new List<string>();
            list.Add("expiryDate~" + expiryDate.ToShortDateString());
            list.Add("vaccinationNumber~" + vaccinationNumber);
            list.Add("petNumber~" + petNumber);
            list.Add("vacChecked~" + vacChecked);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
