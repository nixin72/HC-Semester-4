using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace HulkHvkBLL {
    public class Service {
        public int number { get; set; }
        public String desc { get; set; }
        public int petResNumber { get; set; }
        public DailyRate rate { get; set; }

        public Service() {
            this.number = 0;
            this.desc = "";
            this.petResNumber = 0;
            this.rate = new DailyRate();
        }

        public Service( int num, String desc ) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = 0;
            this.rate = new DailyRate();
        }

        public Service( int num, String desc, int pRNum ) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = pRNum;
            this.rate = new DailyRate();
        }

        public Service( int num, String desc, int pRNum, DailyRate rate ) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = pRNum;
            this.rate = rate;
        }

        public bool Equal( Service ser ) {
            return this.desc == ser.desc && this.number == ser.number;
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

        public List<Service> ListBasicService() {
            ServiceDB serDB = new ServiceDB();
            DataTable data = serDB.GetFullServiceInfo();
            return GetBasicServices(data);
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
                        r["SERV_SERVICE_NUMBER"] != DBNull.Value ? (int)r["SERV_SERVICE_NUMBER"] : -1,
                        r2["SERVICE_DESCRIPTION"] != DBNull.Value ? (string)r2["SERVICE_DESCRIPTION"] : "",
                        r["PR_PET_RES_NUMBER"] != DBNull.Value ? (int)r["PR_PET_RES_NUMBER"] : -1
                    ));
                } catch { }
            };

            return data != null ? list : null;
        }

        public e Add( int petResNum, int serviceNumber ) {
            e errCode = e.success;
            ServiceDB serDB = new ServiceDB();
            if (serDB.Add(petResNum, serviceNumber) != 0) {
                errCode = e.insertFail;
            }
            return errCode;
        }

        public e Update( int petResNum, int serviceNumber ) {
            e errCode = e.success;
            ServiceDB serDB = new ServiceDB();
            if (serDB.Add(petResNum, serviceNumber) < 0) {
                errCode = e.insertFail;
            }
            return errCode;
        }

        public e Delete( int petResNum ) {
            e errCode = e.success;
            ServiceDB serDB = new ServiceDB();
            if ( !serDB.DeletePetReservation(petResNum) ) {
                errCode = e.insertFail;
            }

            return errCode;
        }

        public e DeleteServ(int petResNum, int servNum) {
            e errCode = e.success;
            ServiceDB serDB = new ServiceDB();
            if ( !serDB.DeleteServiceForPet(petResNum, servNum) ) {
                errCode = e.insertFail;
            }

            return errCode;
        }

        private List<Service> GetBasicServices( DataTable data ) {
            List<Service> list = new List<Service>();
            foreach ( DataRow r in data.Rows ) {
                try {
                    list.Add(new Service(
                        Convert.ToInt16(r[0]),
                        r[1].ToString()
                    ));
                } catch { }
            };

            return data != null ? list : null;
        }
    }
}
