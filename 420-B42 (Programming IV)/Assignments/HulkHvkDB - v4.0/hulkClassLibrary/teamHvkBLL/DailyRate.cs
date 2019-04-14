using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;

namespace teamHvkBLL {
    class DailyRate {
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

        public DailyRate(int num, float rate) {
            this.number = num;
            this.rate = rate;
            this.dogSize = 's';
            this.serviceNumber = 0;
        }

        public DailyRate(int num, float rate, char size, int servNum) {
            this.number = num;
            this.rate = rate;
            this.dogSize = size;
            this.serviceNumber = servNum;
        }

        public List<DailyRate> GetFullRateInfo() {
            DailyRateDB rateDB = new DailyRateDB();
            dsHvk.HVK_DAILY_RATEDataTable table = new dsHvk.HVK_DAILY_RATEDataTable();
            return GetDailyRates(table);
        }

        public List<DailyRate> GetDailyRates(dsHvk.HVK_DAILY_RATEDataTable table) {
            List<DailyRate> rates = new List<DailyRate>();
            if (table != null) {
                foreach (var row in table.ToList().FindAll(r => r != null)) {
                    try {
                        rates.Add(new DailyRate(row.DAILY_RATE_NUMBER, row.DAILY_RATE,
                            row.DAILY_RATE_DOG_SIZE.ElementAt(0), row.SERV_SERVICE_NUMBER));
                    }
                    catch {
                        Console.WriteLine("");
                    }
                }
            }
            else {
                rates = null;
            }
            return rates;
        }

        public int compareTo(DailyRate rate2) {
            if (rate > rate2.rate) {
                return 1;
            }
            else if (rate < rate2.rate) {
                return -1;
            }
            else {
                return 0;
            }
        }

        public override bool Equals(Object rate2) {
            if (rate2.GetType() == typeof(DailyRate)) {
                DailyRate rateTest = (DailyRate)rate2;
                return ((this.dogSize == rateTest.dogSize)
                    && (this.rate == rateTest.rate));
            }
            else
                return false;
        }

        public String toString() {
            //TODO
            return "";
        }
    }
}
