using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace HulkHvkBLL {
    public class KennelLog {
        public DateTime logDate { get; set; }
        public int seqNum { get; set; }
        public String notes { get; set; }
        public byte video { get; set; }

        private List<PetReservation> pr;

        public List<PetReservation> petRes {
            get { return pr; }
            set { pr = value; }
        }

        public KennelLog() {
            this.logDate = new DateTime();
            this.seqNum = 0;
            this.notes = "";
            this.video = 0;
        }

        public KennelLog( DateTime logDate, int seqNum, String notes ) {
            this.logDate = logDate;
            this.seqNum = seqNum;
            this.notes = notes;
            this.video = 0;
        }

        public KennelLog( DateTime logDate, int seqNum, String notes, byte video ) {
            this.logDate = logDate;
            this.seqNum = seqNum;
            this.notes = notes;
            this.video = video;
        }

        public KennelLog( DateTime logDate, int seqNum, String notes, byte video, List<PetReservation> pR ) {
            this.logDate = logDate;
            this.seqNum = seqNum;
            this.notes = notes;
            this.video = video;
            this.petRes = pR;
        }

        public int compareTo( KennelLog log2 ) {
            return (logDate > log2.logDate) ? 1 : (logDate > log2.logDate) ? -1 : 0;
        }

        public bool equals( KennelLog log2 ) {
            return (logDate == log2.logDate && seqNum == log2.seqNum);
        }

        public List<KennelLog> ListLogs() {
            KennelLogDB logDB = new KennelLogDB();
            DataTable data = logDB.GetFullLogInfo();
            return GetLogs(data);
        }
        
        private List<KennelLog> GetLogs( DataTable data ) {
            List<KennelLog> list = new List<KennelLog>();
            foreach ( DataRow r in data.Rows ) {
                try {
                    list.Add(new KennelLog(
                        DateTime.Parse((string)r["KENNEL_LOG_DATE"]),
                        (int)r["KENNEL_LOG_SEQUENCE_NUMBER"],
                        (string)r["KENNEL_LOG_NOTES"]
                    ));
                } catch { }
            }

            return data != null ? list : null;
        }
    }
}
