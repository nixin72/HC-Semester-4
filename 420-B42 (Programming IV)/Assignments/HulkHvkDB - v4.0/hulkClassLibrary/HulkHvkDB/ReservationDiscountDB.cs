using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB
{
    public class ReservationDiscountDB
    {
        public DataTable GetFullReservationDiscountInfo()
        {
           return HVK_SqlConnection.GetData("HVK_RESERVATION_DISCOUNT");
        }
        public int Add(int discountNumber, int reservationNumber)
        {
            string cmdStr = "Insert into hvk_reservation_discount (DISC_DISCOUNT_NUMBER," +
                                "RES_RESERVATION_NUMBER)" +
                                " values (" + discountNumber + "," + reservationNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"");
        }
        public bool Delete(int resNumber)
        {
            string cmd = @"Delete from hvk_reservation_discount 
                                where res_reservation_number = " + resNumber;
            return HVK_SqlConnection.Delete(cmd);
        }

    }
}
