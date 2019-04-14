using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class DailyRateDB {
        public DataTable GetFullRateInfo() {
            // Original Code
            //            dsHvkTableAdapters.HVK_DAILY_RATETableAdapter adapter = new dsHvkTableAdapters.HVK_DAILY_RATETableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();

            return HVK_SqlConnection.GetData("HVK_DAILY_RATE");
        }
        public int Add(double dailyRate, char dogSize, int serviceNumber)
        {
            string cmdStr = "Insert into hvk_daily_rate (DAILY_RATE_NUMBER,DAILY_RATE," +
                                "DAILY_RATE_DOG_SIZE, SERV_SERVICE_NUMBER)" +
                                " values (HVK_DAILY_RATE_SEQ.NEXTVAL," + dailyRate + "," + dogSize + "," + serviceNumber 
                                + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_daily_rate_seq");
        }

        public bool Update(int drNumber, double dailyRate, char dogSize, int serviceNumber)
        {
            string cmd = @"Update hvk_daily_rate 
                                set daily_rate = :dailyRate, 
                                daily_rate_dog_size = :dogSize,
                                serv_service_number = :serviceNumber,
                                    where daily_rate_number = :drNumber;";
            List<string> list = new List<string>();
            list.Add("drNumber~" + drNumber);
            list.Add("dogSize~" + dogSize);
            list.Add("serviceNumber~" + serviceNumber);
            list.Add("dailyRate~" + dailyRate);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
