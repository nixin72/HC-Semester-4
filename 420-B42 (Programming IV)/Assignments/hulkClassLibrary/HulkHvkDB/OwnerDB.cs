using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace HulkHvkDB {
    public class OwnerDB {
            public DataTable GetFullOwnerInfo()
            {
                // Original code
                //            dsHvkTableAdapters.HVK_OWNERTableAdapter adapter = new dsHvkTableAdapters.HVK_OWNERTableAdapter();
                //            adapter.ClearBeforeFill = true;
                //            return adapter.GetData();

                return HVK_SqlConnection.GetData("HVK_OWNER");

            }  // GetFullOwnerInfo

        public int Add(string first, string last, string street, string city,
            string province, string postal, string phone, string email, string emgFirst, string emgLast,
            string emgPhone, int vet)
        {
            string cmdStr = "Insert into hvk_owner (OWNER_NUMBER, OWNER_FIRST_NAME, OWNER_LAST_NAME,"+
                                "OWNER_STREET, OWNER_CITY, OWNER_PROVINCE, OWNER_POSTAL_CODE, OWNER_PHONE,"+
                                "OWNER_EMAIL, EMERGENCY_CONTACT_FIRST_NAME, EMERGENCY_CONTACT_LAST_NAME,"+
                                "EMERGENCY_CONTACT_PHONE, VET_VET_NUMBER)"+
                                " values (HVK_OWNER_SEQ.NEXTVAL,"+first+","+last+","+street+ ","+city+
                                ","+province+ ","+postal+ ","+phone+ ","+email+ ","+emgFirst+ ","+emgLast+
                                ","+emgPhone+ ","+vet+")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_owner_seq");
        }

        public bool Update(int ownerNumber, string first, string last, string street, string city, 
            string province, string postal, string phone, string email, string emgFirst, string emgLast,
            string emgPhone, int vet)
        {
            string cmd = @"Update hvk_owner 
                                set owner_first_name = :fName, 
                                owner_last_name = :lName,
                                owner_street = :street,
                                owner_city = :city,
                                owner_province = :province,
                                owner_postal_code = :postalCode,
                                owner_phone = :phone,
                                owner_email = :email,
                                emergency_contact_first_name = :eFName,
                                emergency_contact_last_name = :eLName,
                                emergency_contact_phone = :ePhone,
                                vet_vet_number = :vet
                                    where owner_number = :oNumber;";
            List<string> list = new List<string>();
            list.Add("oNumber~" + ownerNumber);
            list.Add("fName~"+first);
            list.Add("lName~" + last);
            list.Add("street~" + street);
            list.Add("city~" + city);
            list.Add("province~" + province);
            list.Add("postalCode~" + postal);
            list.Add("email~" + email);
            list.Add("eFName~" + emgFirst);
            list.Add("eLName~" + emgLast);
            list.Add("ePhone~" + emgPhone);
            list.Add("vet~" + vet);
            return HVK_SqlConnection.UpdateRow(cmd,list);
        }

    }
    }
