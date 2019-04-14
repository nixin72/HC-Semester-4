using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class RunDB {
        public DataTable GetFullRunInfo() {
            //            dsHvkTableAdapters.HVK_RUNTableAdapter adapter = new dsHvkTableAdapters.HVK_RUNTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_RUN");

        }
        public int Add(char size, char covered, char location, int status)
        {
            string cmdStr = "Insert into hvk_run (RUN_NUMBER, RUN_SIZE, RUN_COVERED, RUN_LOCATION," +
                                "RUN_STATUS)" +
                                " values (HVK_RUN_SEQ.NEXTVAL," + size + "," + covered + "," + location + "," + status + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_run_seq");
        }

        public bool Update(int runNumber, char size, char covered, char location, int status)
        {
            string cmd = @"Update hvk_run 
                                set run_size = :size, 
                                run_covered = :covered,
                                run_location = :location,
                                run_status = :status
                                    where run_number = :runNumber;";
            List<string> list = new List<string>();
            list.Add("runNumber~" + runNumber);
            list.Add("size~" + size);
            list.Add("covered~" + covered);
            list.Add("location~" + location);
            list.Add("status~" + status);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
