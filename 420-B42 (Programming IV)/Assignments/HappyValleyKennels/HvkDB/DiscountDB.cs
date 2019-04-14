using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class DiscountDB
    {
        public DataTable GetFullDiscountInfo()
        {
            return HVK_SqlConnection.GetData("HVK_DISCOUNT");
        }

        public DataTable GetFullPetReservationDiscountInfo()
        {
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION_DISCOUNT");
        }

        public DataTable GetFullReservationDiscountInfo()
        {
            return HVK_SqlConnection.GetData("HVK_RESERVATION_DISCOUNT");
        }

        public DataTable GetPetResDiscountInfo() {
            return HVK_SqlConnection.GetData("", 
                "SELECT DISCOUNT_NUMBER, DISCOUNT_DESCRIPTION, DISCOUNT_PERCENTAGE, DISCOUNT_TYPE, PR_PET_RES_NUMBER " +
                "FROM HVK_DISCOUNT d " +
                "LEFT JOIN HVK_PET_RESERVATION_DISCOUNT prd " +
                    "ON DISCOUNT_NUMBER = DISC_DISCOUNT_NUMBER "
            );
        }

        public int Add(string desc, double percentage, char dType)
        {
            string cmdStr = "Insert into hvk_discount (DISCOUNT_NUMBER, DISCOUNT_DESCRIPTION," +
                                "DISCOUNT_PERCENTAGE, DISCOUNT_TYPE)" +
                                " values (HVK_DISCOUNT_SEQ.NEXTVAL," + desc + "," + percentage + "," + dType + ")";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(int dNumber, string desc, double percentage, char dType)
        {
            string cmd = "Update hvk_discount " +
                                "set discount_description = '" + desc +
                                "', discount_percentage = " + percentage +
                                ", discount_type = '" + dType +
                                    "' where discount_number = " + dNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }
        public bool Delete(int discountNumber)
        {
            string cmd = @"Delete from hvk_discount 
                                where discount_number = " + discountNumber;
            return HVK_SqlConnection.Delete(cmd);
        }

        /*
         * RESERVATION_DISCOUNT
         */

        public int AddResDis(int discountNumber, int reservationNumber)
        {
            string cmdStr = "Insert into hvk_reservation_discount (DISC_DISCOUNT_NUMBER," +
                                "RES_RESERVATION_NUMBER)" +
                                " values (" + discountNumber + "," + reservationNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool DeleteResDis(int resNumber)
        {
            string cmd = @"Delete from hvk_reservation_discount 
                                where res_reservation_number = " + resNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
