using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class ServiceDB {
        public DataTable GetFullServiceInfo() {
            //            dsHvkTableAdapters.HVK_SERVICETableAdapter adapter = new dsHvkTableAdapters.HVK_SERVICETableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_SERVICE");

        }

        public DataTable GetFullPetReservationServiceInfo() {
            //            dsHvkTableAdapters.HVK_PET_RESERVATION_SERVICETableAdapter adapter = new dsHvkTableAdapters.HVK_PET_RESERVATION_SERVICETableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_PET_RESERVATION_SERVICE");

        }
        public int Add(string serviceDesc)
        {
            string cmdStr = "Insert into hvk_service (SERVICE_NUMBER, SERVICE_DESCRIPTION)" +
                                " values (HVK_SERVICE_SEQ.NEXTVAL," + serviceDesc + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_service_seq");
        }

        public bool Update(int serviceNumber, string serviceDesc)
        {
            string cmd = @"Update hvk_service 
                                set service_description = :serviceDesc
                                    where service_number = :serviceNumber";
            List<string> list = new List<string>();
            list.Add("serviceNumber~" + serviceNumber);
            list.Add("serviceDesc~" + serviceDesc);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
