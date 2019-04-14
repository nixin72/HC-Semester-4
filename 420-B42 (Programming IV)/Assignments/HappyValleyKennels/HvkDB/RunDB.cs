using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class RunDB
    {
        public DataTable GetFullRunInfo()
        {
            return HVK_SqlConnection.GetData("HVK_RUN");

        }
        public int Add(char size, char covered, char location, int status)
        {
            string cmdStr = "Insert into hvk_run (RUN_NUMBER, RUN_SIZE, RUN_COVERED, RUN_LOCATION," +
                                "RUN_STATUS)" +
                                " values (HVK_RUN_SEQ.NEXTVAL," + size + "," + covered + "," + location + "," + status + ")";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(int runNumber, char size, char covered, char location, int status)
        {
            string cmd = "Update hvk_run " +
                                "set run_size = '" + size +
                                "', run_covered = '" + covered +
                                "', run_location = '" + location +
                                "', run_status = " + status +
                                    "where run_number = " + runNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }
        public bool Delete(int runNumber)
        {
            string cmd = @"Delete from hvk_run 
                                where run_number = " + runNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
