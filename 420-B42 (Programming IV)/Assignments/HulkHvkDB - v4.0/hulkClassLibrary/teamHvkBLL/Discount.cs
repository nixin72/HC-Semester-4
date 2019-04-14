using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;

namespace teamHvkBLL {
    class Discount {
        public int number { get; set; }
        public String desc { get; set; }
        public float per { get; set; }
        public char type { get; set; }

        public Discount() {
            this.number = 0;
            this.desc = "";
            this.per = 0;
            this.type = 't';
        }

        public Discount(int num, String desc, float per, char type) {
            this.number = num;
            this.desc = desc;
            this.per = per;
            this.type = type;
        }

        public List<Discount> GetFullDiscountInfo() {
            DiscountDB disDB = new DiscountDB();
            dsHvk.HVK_DISCOUNTDataTable table = disDB.GetFullDiscountInfo();
            return GetDiscountInfo(table);
        }

        public List<Discount> GetDiscountInfo(dsHvk.HVK_DISCOUNTDataTable data) {
            List<Discount> discount = new List<Discount>();
            if (data != null) {
                foreach (var row in data.ToList().FindAll(r => r != null)) {
                    try {
                        discount.Add(new Discount(row.DISCOUNT_NUMBER, row.DISCOUNT_DESCRIPTION,
                            row.DISCOUNT_PERCENTAGE, row.DISCOUNT_TYPE.ElementAt(0))
                        );
                    }
                    catch {
                        Console.WriteLine("");
                    }
                }
            }
            else {
                discount = null;
            }

            return discount;
        }


    }
}
