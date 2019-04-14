using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB {
    public class PetReservationDB {
        public DataTable GetFullPetResInfo() {
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION");

        }

        public int Add( int petPetNumber, int resResNumber, int? runRunNumber = null ) {
            string cmdStr = "Insert into hvk_pet_reservation (PET_RES_NUMBER, PET_PET_NUMBER, RES_RESERVATION_NUMBER," +
                                "RUN_RUN_NUMBER, PR_SHARING_WITH)" +
                                " values (hvk_pet_reservation_seq.nextval" + "," + petPetNumber + "," + resResNumber + "," + runRunNumber +
                                 ")";
            return HVK_SqlConnection.AddRow(cmdStr, "hvk_pet_reservation_seq");
        }

        public bool Update( int petResNumber, int petPetNumber, int resResNumber, int? runRunNumber = null ) {
            string cmd = @"Update hvk_pet_reservation 
                                set pet_pet_number = :petPetNumber, 
                                res_reservation_number = :resResNumber,
                                run_run_number = :runRunNumber
                                    where pet_res_number = :petResNumber;";
            List<string> list = new List<string>();
            list.Add("petResNumber~" + petResNumber);
            list.Add("petPetNumber~" + petPetNumber);
            list.Add("resResNumber~" + resResNumber);
            list.Add("runRunNumber~" + runRunNumber);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }

        public bool Delete( int resNumber ) {
            string cmd = @"Delete from hvk_pet_reservation 
                                where res_reservation_number = " + resNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
