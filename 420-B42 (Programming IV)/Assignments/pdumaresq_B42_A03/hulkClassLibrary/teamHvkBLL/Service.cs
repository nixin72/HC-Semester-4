using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace teamHvkBLL {
    public class Service {
        public int number { get; set; }
        public String desc { get; set; }

        public int frequency { get; set; }
        public int petResNumber { get; set; }

        public DailyRate rate { get; set; }

        public Service() {
            this.number = 0;
            this.desc = "";
            this.frequency = 0;
            this.petResNumber = 0;
            this.rate = new DailyRate();
        }

        public Service( int num, String desc, int pRNum ) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = pRNum;
            this.frequency = 0;
            this.rate = new DailyRate();
        }

        public Service( int num, String desc, int pRNum, int frequency ) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = pRNum;
            this.frequency = frequency;
            this.rate = new DailyRate();
        }

        public Service( int num, String desc, int pRNum, int frequency, DailyRate rate ) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = pRNum;
            this.frequency = frequency;
            this.rate = rate;
        }

        public bool Equal( Service ser ) {
            return this.desc == ser.desc && this.frequency == ser.frequency;
        }

        public int CompareTo( Service ser ) {
            return this.desc.CompareTo(ser.desc);
        }

        public List<Service> ListServices() {
            ServiceDB serDB = new ServiceDB();
            DataTable data = serDB.GetFullServiceInfo();
            DataTable data2 = serDB.GetFullPetReservationServiceInfo();
            return GetServices(data, data2);
        }

        private List<Service> GetServices( DataTable data, DataTable data2 ) {
            List<Service> list = new List<Service>();
            foreach ( DataRow r in data2.Rows ) {
                try {
                    DataRow r2 = null;
                    foreach ( DataRow rr in data.Rows ) {
                        if ( (int)rr["SERVICE_NUMBER"] == (int)r["SERV_SERVICE_NUMBER"] ) {
                            r2 = rr;
                        }
                    }
                    list.Add(new Service(
                        r.IsNull("SERV_SERVICE_NUMBER") ? (int)r["SERV_SERVICE_NUMBER"] : -1,
                        r.IsNull("SERVICE_DESCRIPTION") ? (string)r2["SERVICE_DESCRIPTION"] : "",
                        r.IsNull("PR_PET_RES_NUMBER") ? (int)r["PR_PET_RES_NUMBER"] : -1,
                        r.IsNull("SERVICE_FREQUENCY") ? (int)r["SERVICE_FREQUENCY"] : -1
                    ));
                } catch { }
            };

            return data != null ? list : null;
        }
    }
}
