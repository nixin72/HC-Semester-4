using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace HulkHvkBLL {
    public class Discount {
        public int number { get; set; }
        public String desc { get; set; }
        public float per { get; set; }
        public char type { get; set; }
        public int petReeservationNumber { get; set; }

        public Discount() {
            this.number = 0;
            this.desc = "";
            this.per = 0;
            this.type = 't';
        }

        public Discount( int num, String desc, float per, char type ) {
            this.number = num;
            this.desc = desc;
            this.per = per;
            this.type = type;
            this.petReeservationNumber = 0;
        }

        public Discount( int num, String desc, float per, char type, int petResNum ) {
            this.number = num;
            this.desc = desc;
            this.per = per;
            this.type = type;
            this.petReeservationNumber = petResNum;
        }

        public List<Discount> GetFullDiscountInfo() {
            DiscountDB disDB = new DiscountDB();
            DataTable table = disDB.GetFullPetReservationDiscountInfo();
            return GetDiscountInfo(table);
        }

        private List<Discount> GetDiscountInfo( DataTable data ) {
            List<Discount> discount = new List<Discount>();

            foreach ( DataRow row in data.Rows ) {
                try {
                    discount.Add(new Discount(
                        row.IsNull("DISCOUNT_NUMBER") ? (int)row["DISCOUNT_NUMBER"] : -1,
                        row.IsNull("DISCOUNT_DESCRIPTION") ? (string)row["DISCOUNT_DESCRIPTION"] : "",
                        row.IsNull("DISCOUNT_PERCENTAGE") ? (float)row["DISCOUNT_PERCENTAGE"] : -1,
                        row.IsNull("DISCOUNT_TYPE") ? (char)row["DISCOUNT_TYPE"] : '~',
                        row.IsNull("PR_PET_RES_NUMBER") ? (int)row["PR_PET_RES_NUMBER"] : -1
                    ));
                } catch { }
            }
            return data != null ? discount : null;
        }

        public e removeDiscount(int resNumber) {
            e errCode = e.success;
            DiscountDB serDB = new DiscountDB();
            if ( !serDB.DeleteResDis(resNumber) ) {
                errCode = e.insertFail;
            }

            return errCode;
        }
    }
}
;