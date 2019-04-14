using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class VaccinationDB {
        public DataTable GetFullVaccinationInfo() {
            //            dsHvkTableAdapters.HVK_VACCINATIONTableAdapter adapter = new dsHvkTableAdapters.HVK_VACCINATIONTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_VACCINATION");

        }

        public DataTable GetFullPetVaccinationInfo() {
            //            dsHvkTableAdapters.HVK_PET_VACCINATIONTableAdapter adapter = new dsHvkTableAdapters.HVK_PET_VACCINATIONTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_PET_VACCINATION");

        }

        public DataTable GetVaccinationInfoForPet(int petNumber) {
            //            dsHvkTableAdapters.PetVaccinationInformationTableAdapter adapter = new dsHvkTableAdapters.PetVaccinationInformationTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData(petNumber);
            return HVK_SqlConnection.GetData("HVK_PET_VACCINATION","select * from HVK_PET_VACCINATION where pet_pet_number = "+petNumber);
        }

        public int Add(string vaccinationName)
        {
            string cmdStr = "Insert into hvk_vaccination (VACCINATION_NUMBER, VACCINATION_NAME)" +
                                " values (HVK_VACCINATION_SEQ.NEXTVAL," + vaccinationName + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_vaccination_seq");
        }

        public bool Update(int vaccinationNumber, string vaccinationName)
        {
            string cmd = @"Update hvk_vaccination 
                                set vaccination_name = :vaccinationName
                                    where vaccination_number = :vaccinationNumber";
            List<string> list = new List<string>();
            list.Add("vaccinationNumber~" + vaccinationNumber);
            list.Add("vaccinationName~" + vaccinationName);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
