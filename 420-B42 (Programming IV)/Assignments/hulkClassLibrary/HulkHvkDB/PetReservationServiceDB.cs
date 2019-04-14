using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB
{
    public class PetReservationServiceDB
    {
        public DataTable GetFullPetReservationServiceInfo()
        {
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION_SERVICE");
        }
        public int Add(int serviceFrequency, int petResNumber, int serviceNumber)
        {
            string cmdStr = "Insert into hvk_pet_reservation_service (SERVICE_FREQUENCY, PR_PET_RES_NUMBER," + 
                                " SERV_SERVICE_NUMBER)" +
                                " values (" + serviceFrequency +
                                ", " + petResNumber + ", " + serviceNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"");
        }

        public bool Update(int serviceFrequency, int petResNumber, int serviceNumber)
        {
            string cmd = @"Update hvk_pet_reservation_service 
                                set service_frequency = :serviceFrequency                                
                                    where pr_pet_res_number = :petResNumber and
                                        serv_service_number = :serviceNumber";
            List<string> list = new List<string>();
            list.Add("serviceFrequency~" + serviceFrequency);
            list.Add("petResNumber~" + petResNumber);
            list.Add("serviceNumber~" + serviceNumber);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
        public bool Delete(int petResNumber)
        {
            string cmd = @"Delete from hvk_pet_reservation_service 
                                where pr_pet_res_number = " + petResNumber;
            return HVK_SqlConnection.Delete(cmd);
        }
    }
}
