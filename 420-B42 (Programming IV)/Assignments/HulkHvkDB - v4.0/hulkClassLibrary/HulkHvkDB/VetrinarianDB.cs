using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class VetrinarianDB {
        public DataTable GetFullVetInfo() {
            //            dsHvkTableAdapters.HVK_VETERINARIANTableAdapter adapter = new dsHvkTableAdapters.HVK_VETERINARIANTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_VETERINARIAN");

        }
        public int Add(string name, string phone, string street, string city, string province, string postal)
        {
            string cmdStr = "Insert into hvk_veterinarian (VET_NUMBER, VET_NAME, VET_PHONE, VET_STREET," +
                                "VET_CITY, VET_PROVINCE, VET_POSTAL_CODE)" +
                                " values (HVK_VETERINARIAN_SEQ.NEXTVAL," + name + "," + phone + "," + street + "," + city +
                                "," + province + "," + postal + "," + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_veterinarian_seq");
        }

        public bool Update(int vetNumber, string name, string phone, string street, string city, 
            string province, string postal)
        {
            string cmd = @"Update hvk_veterinarian 
                                set vet_name = :name, 
                                vet_phone = :phone,
                                vet_street = :street,
                                vet_city = :city,
                                vet_province = :province,
                                vet_postal_code = :postal
                                    where vet_number = :vetNumber;";
            List<string> list = new List<string>();
            list.Add("vetNumber~" + vetNumber);
            list.Add("name~" + name);
            list.Add("phone~" + phone);
            list.Add("street~" + street);
            list.Add("city~" + city);
            list.Add("province~" + province);
            list.Add("postal~" + postal);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
