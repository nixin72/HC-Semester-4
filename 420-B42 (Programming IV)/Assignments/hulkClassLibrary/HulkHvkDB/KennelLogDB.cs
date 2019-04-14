using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class KennelLogDB {
        public DataTable GetFullLogInfo() {
            //            dsHvkTableAdapters.HVK_KENNEL_LOGTableAdapter adapter = new dsHvkTableAdapters.HVK_KENNEL_LOGTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_KENNEL_LOG");

        }
        public int Add(DateTime date, int sequence, string notes, int petResNumber)
        {
            string cmdStr = "Insert into hvk_kennel_log (KENNEL_LOG_DATE,KENNEL_LOG_SEQUENCE_NUMBER," +
                                "KENNEL_LOG_NOTES, PR_PET_RES_NUMBER, KENNEL_LOG_VIDEO)" +
                                " values (" + date + "," + sequence + "," + notes + "," + petResNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"");
        }

        public bool Update(DateTime date, int sequence, string notes, int petResNumber)
        {
            string cmd = @"Update hvk_kennel_log 
                                set kennel_log_notes = :notes
                                    where kennel_log_date = :date and
                                        kennel_log_sequence_number = :sequence and
                                        pr_pet_res_number = :petResNumber;";
            List<string> list = new List<string>();
            list.Add("date~" + date);
            list.Add("sequence~" + sequence);
            list.Add("notes~" + notes);
            list.Add("petResNumber~" + petResNumber);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
