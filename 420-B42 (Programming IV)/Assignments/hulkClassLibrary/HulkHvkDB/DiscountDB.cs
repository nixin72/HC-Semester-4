using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class DiscountDB {
        public DataTable GetFullDiscountInfo() {
            //            dsHvkTableAdapters.HVK_DISCOUNTTableAdapter adapter = new dsHvkTableAdapters.HVK_DISCOUNTTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_DISCOUNT");
        }

        public DataTable GetFullPetReservationDiscountInfo() {
            //            dsHvkTableAdapters.HVK_PET_RESERVATION_DISCOUNTTableAdapter adapter = new dsHvkTableAdapters.HVK_PET_RESERVATION_DISCOUNTTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION_DISCOUNT");
        }

        public DataTable GetFullReservationDiscountInfo() {
//            dsHvkTableAdapters.HVK_RESERVATION_DISCOUNTTableAdapter adapter = new dsHvkTableAdapters.HVK_RESERVATION_DISCOUNTTableAdapter();
//            adapter.ClearBeforeFill = true;
//            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_RESERVATION_DISCOUNT");

        }

        public int Add(string desc, double percentage, char dType)
        {
            string cmdStr = "Insert into hvk_discount (DISCOUNT_NUMBER, DISCOUNT_DESCRIPTION," +
                                "DISCOUNT_PERCENTAGE, DISCOUNT_TYPE)" +
                                " values (HVK_DISCOUNT_SEQ.NEXTVAL," + desc + "," + percentage + "," + dType + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_discount_seq");
        }

        public bool Update(int dNumber, string desc, double percentage, char dType)
        {
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
    }
}
