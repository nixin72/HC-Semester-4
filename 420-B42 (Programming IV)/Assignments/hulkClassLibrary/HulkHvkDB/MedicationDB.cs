using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class MedicationDB {
        public DataTable GetFullMedicationInfo() {
            //            dsHvkTableAdapters.HVK_MEDICATIONTableAdapter adapter = new dsHvkTableAdapters.HVK_MEDICATIONTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_MEDICATION");

        }
        public int Add(string name, string dosage, string instructions, DateTime endDate,
            int petResNumber)
        {
            string cmdStr = "Insert into hvk_medication (MEDICATION_NUMBER, MEDICATION_NAME, MEDICATION_DOSAGE," +
                                "MEDICATION_SPECIAL_INSTRUCT, MEDICATION_END_DATE, PR_PET_RES_NUMBER)" +
                                " values (HVK_MEDICATION_SEQ.NEXTVAL," + name + "," + dosage + "," + instructions + 
                                "," + endDate.ToShortDateString() + "," + petResNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_medication_seq");
        }

        public bool Update(int medNumber, string name, string dosage, string instructions, DateTime endDate,
            int petResNumber)
        {
            string cmd = @"Update hvk_medication 
                                set medication_name = :name, 
                                medication_dosage = :dosage,
                                medication_special_instruct = :instructions,
                                medication_end_date = :endDate,
                                pr_pet_res_number = :petResNumber
                                    where medication_number = :medNumber;";
            List<string> list = new List<string>();
            list.Add("medNumber~" + medNumber);
            list.Add("name~" + name);
            list.Add("dosage~" + dosage);
            list.Add("instructions~" + instructions);
            list.Add("endDate~" + endDate.ToShortDateString());
            list.Add("petResNumber~" + petResNumber);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
