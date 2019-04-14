using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class PetReservationDB {
        public DataTable GetFullPetResInfo() {
            //            dsHvkTableAdapters.HVK_PET_RESERVATIONTableAdapter adapter = new dsHvkTableAdapters.HVK_PET_RESERVATIONTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION");

        }
        public int Add( int petPetNumber, int resResNumber, int runRunNumber, int prSharing)
        {
            string cmdStr = "Insert into hvk_pet_reservation (PET_RES_NUMBER, PET_PET_NUMBER, RES_RESERVATION_NUMBER," +
                                "RUN_RUN_NUMBER, PR_SHARING_WITH)" +
                                " values (hvk_pet_reservation_seq.nextval"  + "," + petPetNumber + "," + resResNumber + "," + runRunNumber +
                                "," + prSharing + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_pet_reservation_seq");
        }

        public bool Update(int petResNumber, int petPetNumber, int resResNumber, int runRunNumber, int prSharing)
        {
            string cmd = @"Update hvk_pet_reservation 
                                set pet_pet_number = :petPetNumber, 
                                res_reservation_number = :resResNumber,
                                run_run_number = :runRunNumber,
                                pr_sharing_with = :prSharing
                                    where pet_res_number = :petResNumber;";
            List<string> list = new List<string>();
            list.Add("petResNumber~" + petResNumber);
            list.Add("petPetNumber~" + petPetNumber);
            list.Add("resResNumber~" + resResNumber);
            list.Add("runRunNumber~" + runRunNumber);
            list.Add("prSharing~" + prSharing);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }

        public bool Delete(int resNumber)
        {
            string cmd = @"Delete from hvk_pet_reservation 
                                where res_reservation_number = " + resNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
