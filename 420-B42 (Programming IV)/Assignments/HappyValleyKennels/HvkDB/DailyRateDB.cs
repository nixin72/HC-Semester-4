using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class DailyRateDB
    {
        public DataTable GetFullRateInfo()
        {
            return HVK_SqlConnection.GetData("HVK_DAILY_RATE");
        }
        public int Add(double dailyRate, char dogSize, int serviceNumber)
        {
            string cmdStr = "Insert into hvk_daily_rate (DAILY_RATE_NUMBER,DAILY_RATE," +
                                "DAILY_RATE_DOG_SIZE, SERV_SERVICE_NUMBER)" +
                                " values (HVK_DAILY_RATE_SEQ.NEXTVAL," + dailyRate + "," + dogSize + "," + serviceNumber
                                + ")";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(int drNumber, double dailyRate, char dogSize, int serviceNumber)
        {
            string cmd = "Update hvk_daily_rate " +
                                "set daily_rate = " + dailyRate +
                                ", daily_rate_dog_size = '" + dogSize + "', " +
                                "serv_service_number = " + serviceNumber + ", " +
                                    "where daily_rate_number = " + drNumber;


            return HVK_SqlConnection.UpdateRow(cmd);
        }
        public bool Delete(int dailyNumber)
        {
            string cmd = @"Delete from hvk_daily_rate 
                                where daily_rate_number = " + dailyNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
