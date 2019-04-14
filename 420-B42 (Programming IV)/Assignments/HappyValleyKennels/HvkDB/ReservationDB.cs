using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class ReservationDB
    {
        public DataTable GetFullReservationInfo()
        {
            return HVK_SqlConnection.GetData("HVK_RESERVATION");

        }

        public DataTable GetReservationWithOwnerNumbers() {
            return HVK_SqlConnection.GetData("",
                @"SELECT DISTINCT r.reservation_number, r.reservation_start_Date, r.reservation_end_date, p.own_owner_number 
                    FROM hvk_reservation r 
                    left join hvk_pet_reservation pr 
                        ON pr.res_reservation_number = r.reservation_number 
                    left join hvk_pet p 
                        ON p.pet_number = pr.pet_pet_number");
        }

        public DataTable GetReservationByOwnerNumber(int ownerNumber)
        {
            return HVK_SqlConnection.GetData("HVK_RESERVATION", @"select r.* from
                              hvk_reservation r
                              inner join hvk_pet_reservation pr
                              on pr.res_reservation_number = r.reservation_number
                              inner join hvk_pet p
                              on p.pet_number = pr.pet_pet_number
                              where p.own_owner_number = " + ownerNumber);

        }

        public int Add(DateTime startDate, DateTime endDate)
        {
            int seqNextVal = Convert.ToInt16(HVK_SqlConnection.GetData("", "SELECT HVK_RESERVATION_SEQ.NEXTVAL FROM DUAL").Rows[0][0]);
            string cmdStr = @"
                Insert into hvk_reservation (
                    RESERVATION_NUMBER, RESERVATION_START_DATE, RESERVATION_END_DATE
                ) values (
                    " + seqNextVal + ", to_date('" + startDate.ToString("dd-MM-yy") + "', 'dd-MM-yy')," + 
                    "to_date('" + endDate.ToString("dd-MM-yy") + "', 'dd-MM-yy') " + 
                ")";
            HVK_SqlConnection.AddRow(cmdStr);
            return seqNextVal;
        }

        public bool Update(int resNumber, DateTime startDate, DateTime endDate)
        {
            string cmd = "Update hvk_reservation " +
                                "set reservation_start_date = to_date('" + startDate.ToString("yyyy/mm/dd") + "', 'yyyy/mm/dd')" +
                                ", reservation_end_date = to_date('" + endDate.ToString("yyyy/mm/dd") + "', 'yyyy/mm/dd')" +
                                    " where reservation_number = " + resNumber;
            return HVK_SqlConnection.UpdateRow(cmd);
        }

        public bool Delete(int resNumber)
        {
            string cmd = @"Delete from hvk_reservation 
                                where reservation_number = " + resNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
