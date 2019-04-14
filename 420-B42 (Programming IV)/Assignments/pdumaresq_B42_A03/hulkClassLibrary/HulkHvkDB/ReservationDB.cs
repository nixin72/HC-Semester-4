using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB {
    public class ReservationDB {
        public DataTable GetFullReservationInfo() {
            return HVK_SqlConnection.GetData("HVK_RESERVATION");

        }

        public DataTable GetReservationByOwnerNumber( int ownerNumber ) {
            return HVK_SqlConnection.GetData("HVK_RESERVATION", @"select r.* from
                              hvk_reservation r
                              inner join hvk_pet_reservation pr
                              on pr.res_reservation_number = r.reservation_number
                              inner join hvk_pet p
                              on p.pet_number = pr.pet_pet_number
                              where p.own_owner_number = " + ownerNumber);

        }

        public int Add( DateTime startDate, DateTime endDate ) {
            string cmdStr = "Insert into hvk_reservation (RESERVATION_NUMBER, RESERVATION_START_DATE, " +
                                "RESERVATION_END_DATE)" +
                                " values (HVK_RESERVATION_SEQ.NEXTVAL," + startDate.ToShortDateString() + ","
                                + endDate.ToShortDateString() + ")";
            return HVK_SqlConnection.AddRow(cmdStr, "hvk_reservation_seq");
        }

        public bool Update( int resNumber, DateTime startDate, DateTime endDate ) {
            string cmd = @"Update hvk_reservation 
                                set reservation_start_date = :sDate, 
                                reservation_end_date = :eDate
                                    where reservation_number = " + resNumber + ";";
            List<string> list = new List<string>();
            list.Add("sDate~" + startDate.ToShortDateString());
            list.Add("eDate~" + endDate.ToShortDateString());

            return HVK_SqlConnection.UpdateRow(cmd, list);
        }

        public bool Delete( int resNumber ) {
            string cmd = @"Delete from hvk_reservation 
                                where reservation_number = " + resNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
