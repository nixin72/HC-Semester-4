using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB {
    public class DiscountDB {
        public DataTable GetFullDiscountInfo() {
            return HVK_SqlConnection.GetData("HVK_DISCOUNT");
        }

        public DataTable GetFullPetReservationDiscountInfo() {
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION_DISCOUNT");
        }

        public DataTable GetFullReservationDiscountInfo() {
            return HVK_SqlConnection.GetData("HVK_RESERVATION_DISCOUNT");

        }

        public int Add( string desc, double percentage, char dType ) {
            string cmdStr = "Insert into hvk_discount (DISCOUNT_NUMBER, DISCOUNT_DESCRIPTION," +
                                "DISCOUNT_PERCENTAGE, DISCOUNT_TYPE)" +
                                " values (HVK_DISCOUNT_SEQ.NEXTVAL," + desc + "," + percentage + "," + dType + ")";
            return HVK_SqlConnection.AddRow(cmdStr, "hvk_discount_seq");
        }

        public bool Update( int dNumber, string desc, double percentage, char dType ) {
            string cmd = @"Update hvk_discount 
                                set discount_description = :desc, 
                                discount_percentage = :percentage,
                                discount_type = :dType
                                    where discount_number = :dNumber;";
            List<string> list = new List<string>();
            list.Add("dNumber~" + dNumber);
            list.Add("desc~" + desc);
            list.Add("percentage~" + percentage);
            list.Add("dType~" + dType);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }

        /*
         * RESERVATION_DISCOUNT
         */

        public int AddResDis( int discountNumber, int reservationNumber ) {
            string cmdStr = "Insert into hvk_reservation_discount (DISC_DISCOUNT_NUMBER," +
                                "RES_RESERVATION_NUMBER)" +
                                " values (" + discountNumber + "," + reservationNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr, "");
        }
        public bool DeleteResDis( int resNumber ) {
            string cmd = @"Delete from hvk_reservation_discount 
                                where res_reservation_number = " + resNumber;
            return HVK_SqlConnection.Delete(cmd);
        }

        /*
         * PET_RESERVATION_DISCOUNT
         */

        public int AddPetResDis( int discountNumber, int petResNumber ) {
            string cmdStr = "Insert into hvk_pet_reservation_discount (DISC_DISCOUNT_NUMBER," +
                                "PR_PET_RES_NUMBER)" +
                                " values (" + discountNumber + "," + petResNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr, "");
        }

        public bool UpdatePetResDis( int discountNumber, int petResNumber ) {
            string cmd = @"Update hvk_pet_reservation_discount 
                                set disc_discount_number = :discountNumber                                
                                    where pr_pet_res_number = :petResNumber;";
            List<string> list = new List<string>();
            list.Add("discountNumber~" + discountNumber);
            list.Add("petResNumber~" + petResNumber);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }

        public bool DeletePetResDis( int petResNumber ) {
            string cmd = @"Delete from hvk_pet_reservation_discount 
                                where pr_pet_res_number = " + petResNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
