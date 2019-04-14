using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class OwnerDB
    {
        public DataTable GetFullOwnerInfo()
        {
            return HVK_SqlConnection.GetData("HVK_OWNER");
        }

        public DataTable GetOwnerInfo(int ownerNumber)
        {
            return HVK_SqlConnection.GetData("HVK_OWNER", "Select * FROM HVK_OWNER WHERE HVK_OWNER.OWNER_NUMBER = " + ownerNumber);
        }

        public int Add(string first, string last, string street, string city,
            string province, string postal, string phone, string email, string emgFirst, string emgLast,
            string emgPhone)
        {
            string cmdStr = "Insert into hvk_owner (OWNER_NUMBER, OWNER_FIRST_NAME, OWNER_LAST_NAME," +
                                "OWNER_STREET, OWNER_CITY, OWNER_PROVINCE, OWNER_POSTAL_CODE, OWNER_PHONE," +
                                "OWNER_EMAIL, EMERGENCY_CONTACT_FIRST_NAME, EMERGENCY_CONTACT_LAST_NAME," +
                                "EMERGENCY_CONTACT_PHONE)" +
                                " values (HVK_OWNER_SEQ.NEXTVAL,'" + first +
                                "','" + last +
                                "','" + street +
                                "','" + city +
                                "','" + province +
                                "','" + postal +
                                "','" + phone +
                                "','" + email +
                                "','" + emgFirst +
                                "','" + emgLast +
                                "','" + emgPhone + "')";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(int ownerNumber, string first, string last, string street, string city,
            string province, string postal, string phone, string email, string emgFirst, string emgLast,
            string emgPhone)
        {
            string cmd = "Update hvk_owner set owner_first_name = '" + first +
                "', owner_last_name = '" + last
                + "', owner_street = '" + street +
                "', owner_city = '" + city +
                "', owner_province = '" + province +
                "', owner_postal_code = '" + postal +
                "', owner_phone = '" + phone +
                "', owner_email = '" + email +
                "', emergency_contact_first_name = '" + emgFirst +
                "', emergency_contact_last_name = '" + emgLast +
                "', emergency_contact_phone = '" + emgPhone +
                "' where owner_number = " + ownerNumber;


            return HVK_SqlConnection.UpdateRow(cmd);
        }

        public bool Delete(int ownerNumber)
        {
            string cmd = @"Delete from hvk_owner 
                                where owner_number = " + ownerNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
