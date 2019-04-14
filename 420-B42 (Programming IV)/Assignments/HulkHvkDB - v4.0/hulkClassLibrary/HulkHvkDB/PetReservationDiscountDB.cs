using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB
{
    public class PetReservationDiscountDB
    {
        public DataTable GetFullPetReservationDiscountInfo()
        {
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION_DISCOUNT");
        }
        public int Add(int discountNumber, int petResNumber)
        {
            string cmdStr = "Insert into hvk_pet_reservation_discount (DISC_DISCOUNT_NUMBER," +
                                "PR_PET_RES_NUMBER)" +
                                " values (" + discountNumber + "," + petResNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"");
        }

        public bool Update(int discountNumber, int petResNumber)
        {
            string cmd = @"Update hvk_pet_reservation_discount 
                                set disc_discount_number = :discountNumber                                
                                    where pr_pet_res_number = :petResNumber;";
            List<string> list = new List<string>();
            list.Add("discountNumber~" + discountNumber);
            list.Add("petResNumber~" + petResNumber);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }

        public bool Delete(int petResNumber)
        {
            string cmd = @"Delete from hvk_pet_reservation_discount 
                                where pr_pet_res_number = " + petResNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
