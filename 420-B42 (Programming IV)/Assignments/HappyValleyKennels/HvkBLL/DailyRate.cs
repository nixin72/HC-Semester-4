using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HulkHvkDB;

namespace HulkHvkBLL {
    public class DailyRate {
        public int number { get; set; }
        public float rate { get; set; }
        public char dogSize { get; set; }
        public int serviceNumber { get; set; }

        public DailyRate() {
            this.number = 0;
            this.rate = 0;
            this.dogSize = 's';
            this.serviceNumber = 0;
        }

        public DailyRate( int num, float rate ) {
            this.number = num;
            this.rate = rate;
            this.dogSize = 's';
            this.serviceNumber = 0;
        }

        public DailyRate( int num, float rate, char size, int servNum ) {
            this.number = num;
            this.rate = rate;
            this.dogSize = size;
            this.serviceNumber = servNum;
        }

        public List<DailyRate> GetFullRateInfo() {
            DailyRateDB rateDB = new DailyRateDB();
            DataTable table = rateDB.GetFullRateInfo();
            return GetDailyRates(table);
        }

        private List<DailyRate> GetDailyRates( DataTable data ) {
            List<DailyRate> rates = new List<DailyRate>();

            foreach ( DataRow row in data.Rows ) {
                try {
                    rates.Add(new DailyRate(
                        row.IsNull("DAILY_RATE_NUMBER") ? (int)row["DAILY_RATE_NUMBER"] : -1,
                        row.IsNull("DAILY_RATE") ? (float)row["DAILY_RATE"] : -1,
                        row.IsNull("DAILY_RATE_DOG_SIZE") ? (char)row["DAILY_RATE_DOG_SIZE"] : '~',
                        row.IsNull("SERV_SERVICE_NUMBER") ? (int)row["SERV_SERVICE_NUMBER"] : -1
                    ));
                } catch { }
            }

            return data != null ? rates : null;
        }

        public int compareTo( DailyRate rate2 ) {
            if ( rate > rate2.rate ) {
                return 1;
            } else if ( rate < rate2.rate ) {
                return -1;
            } else {
                return 0;
            }
        }

        public override bool Equals( Object rate2 ) {
            if ( rate2.GetType() == typeof(DailyRate) ) {
                DailyRate rateTest = (DailyRate)rate2;
                return ((this.dogSize == rateTest.dogSize)
                    && (this.rate == rateTest.rate));
            } else
                return false;
        }

        public String toString() {
            //TODO
            return "";
        }
    }
}
