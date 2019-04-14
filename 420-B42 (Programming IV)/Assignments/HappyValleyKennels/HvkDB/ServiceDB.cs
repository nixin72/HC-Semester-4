using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HulkHvkDB
{
    public class ServiceDB
    {
        public DataTable GetFullServiceInfo()
        {
            return HVK_SqlConnection.GetData("HVK_SERVICE");

        }

        public DataTable GetFullPetReservationServiceInfo()
        {
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION_SERVICE");

        }
        public int Add(string serviceDesc)
        {
            string cmdStr = "Insert into hvk_service (SERVICE_NUMBER, SERVICE_DESCRIPTION)" +
                                " values (HVK_SERVICE_SEQ.NEXTVAL," + serviceDesc + ")";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(int serviceNumber, string serviceDesc)
        {
            string cmd = "Update hvk_service " +
                                "set service_description = '" + serviceDesc +
                                    "' where service_number = " + serviceNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }
        public bool DeleteService(int serviceNumber)
        {
            string cmd = @"Delete from hvk_service 
                                where service_number = " + serviceNumber;
            return HVK_SqlConnection.Delete(cmd);
        }

        /*
         * PET_RESERVATION_SERVICE
         */

        public int Add(int petResNumber, int serviceNumber)
        {
            string cmdStr = "Insert into hvk_pet_reservation_service (PR_PET_RES_NUMBER, SERV_SERVICE_NUMBER)" +
                                " values (" + petResNumber + ", " + serviceNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr);
        }

        public bool Update(int serviceFrequency, int petResNumber, int serviceNumber)
        {
            string cmd = "Update hvk_pet_reservation_service " +
                                "set service_frequency = " + serviceFrequency +
                                    "where pr_pet_res_number = " + petResNumber +
                                       " and serv_service_number = " + serviceNumber;

            return HVK_SqlConnection.UpdateRow(cmd);
        }
        public bool DeletePetReservation(int petResNumber)
        {
            string cmd = @"Delete from hvk_pet_reservation_service 
                                where pr_pet_res_number = " + petResNumber;
            return HVK_SqlConnection.Delete(cmd);
        }

        public bool DeleteServiceForPet(int petResNumber, int servNumber) {
            string query = @"
                DELETE FROM hvk_pet_reservation_service 
                WHERE pr_pet_res_number = " + petResNumber + 
                " AND serv_service_number = " + servNumber;
            return HVK_SqlConnection.Delete(query);
        }
    }
}
