using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class PetReservationDB
    {
        public DataTable GetFullPetResInfo()
        {
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION");

        }

        public int Add(int petPetNumber, int resResNumber, int? runRunNumber = null)
        {
            int seqNextVal = Convert.ToInt16(HVK_SqlConnection.GetData("", "SELECT hvk_pet_res_seq.NEXTVAL FROM DUAL").Rows[0][0]);
            string cmdStr = "Insert into hvk_pet_reservation (PET_RES_NUMBER, PET_PET_NUMBER, RES_RESERVATION_NUMBER," +
                                "RUN_RUN_NUMBER)" +
                                " values (" + seqNextVal + "," + petPetNumber + "," + resResNumber + ", null" +
                                 ")";
            return HVK_SqlConnection.AddRow(cmdStr) != -1 ? seqNextVal : -1;
        }

        public bool Update(int petResNumber, int petPetNumber, int resResNumber, int? runRunNumber = null)
        {
            string cmd = "Update hvk_pet_reservation " +
                                "set pet_pet_number = " + petPetNumber +
                                ", res_reservation_number = " + resResNumber +
                                ", run_run_number = " + ((runRunNumber == null) ? "null" : runRunNumber.ToString()) +
                                    " where pet_res_number = " + petResNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }

        public bool RemoveEntireRes(int petResNumber)
        {
            string cmd = @"Delete from hvk_pet_reservation where res_reservation_number = " + petResNumber;
            return HVK_SqlConnection.Delete(cmd);
        }

        public bool RemovePetRes(int petNumber)
        {
            string cmd = @"Delete from hvk_pet_reservation 
                                where PET_PET_NUMBER = " + petNumber;
            return HVK_SqlConnection.Delete(cmd);
        }

        public bool RemovePetFromRes(int petNumber, int resNumber) {
            string cmd = @"Delete from hvk_pet_reservation 
                                where res_reservation_number = " + resNumber
                               + "and pet_pet_number = " + petNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
