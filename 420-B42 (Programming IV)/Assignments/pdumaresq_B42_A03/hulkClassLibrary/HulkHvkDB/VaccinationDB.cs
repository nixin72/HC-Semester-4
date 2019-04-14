using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB {
    public class VaccinationDB {
        public DataTable GetFullVaccinationInfo() {
            return HVK_SqlConnection.GetData("HVK_VACCINATION");

        }

        public DataTable GetFullPetVaccinationInfo() {
            return HVK_SqlConnection.GetData("HVK_PET_VACCINATION");

        }

        public DataTable GetVaccinationInfoForPet( int petNumber ) {
            return HVK_SqlConnection.GetData("HVK_PET_VACCINATION", "select * from HVK_PET_VACCINATION where pet_pet_number = " + petNumber);
        }

        public int Add( string vaccinationName ) {
            string cmdStr = "Insert into hvk_vaccination (VACCINATION_NUMBER, VACCINATION_NAME)" +
                                " values (HVK_VACCINATION_SEQ.NEXTVAL," + vaccinationName + ")";
            return HVK_SqlConnection.AddRow(cmdStr, "hvk_vaccination_seq");
        }

        public bool Update( int vaccinationNumber, string vaccinationName ) {
            string cmd = @"Update hvk_vaccination 
                                set vaccination_name = :vaccinationName
                                    where vaccination_number = :vaccinationNumber";
            List<string> list = new List<string>();
            list.Add("vaccinationNumber~" + vaccinationNumber);
            list.Add("vaccinationName~" + vaccinationName);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }

        /*
         * PET_VACCINATION
         */

        public int Add( DateTime expiryDate, int vaccinationNumber, int petNumber, char vacChecked ) {
            string cmdStr = "Insert into hvk_pet_vaccination (VACCINATION_EXPIRY_DATE,VACC_VACCINATION_NUMBER," +
                                "PET_PET_NUMBER,VACCINATION_CHECKED_STATUS)" +
                                " values (" + expiryDate.ToShortDateString() + ", " + vaccinationNumber + ", " +
                                petNumber + ", " + vacChecked + ")";
            return HVK_SqlConnection.AddRow(cmdStr, "");
        }

        public bool Update( DateTime expiryDate, int vaccinationNumber, int petNumber, char vacChecked ) {
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
