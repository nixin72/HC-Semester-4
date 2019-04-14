using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class KennelLogDB
    {
        public DataTable GetFullLogInfo()
        {
            return HVK_SqlConnection.GetData("HVK_KENNEL_LOG");

        }
        public int Add(DateTime date, int sequence, string notes, int petResNumber)
        {
            string cmdStr = "Insert into hvk_kennel_log (KENNEL_LOG_DATE,KENNEL_LOG_SEQUENCE_NUMBER," +
                                "KENNEL_LOG_NOTES, PR_PET_RES_NUMBER, KENNEL_LOG_VIDEO)" +
                                " values (" + date + "," + sequence + "," + notes + "," + petResNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(DateTime date, int sequence, string notes, int petResNumber)
        {
            string cmd = "Update hvk_kennel_log " +
                                "set kennel_log_notes = '" + notes +
                                    "' where kennel_log_date = to_date('" + date.ToString("yyyy/mm/dd") + "','yyyy/mm/dd')" +
                                        " and kennel_log_sequence_number = " + sequence +
                                       " and pr_pet_res_number = " + petResNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }
    }
}
