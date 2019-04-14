using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamHvkBLL {
    class Food {
        public int number { get; set; }
        public String brand { get; set; }
        public String variety { get; set; }
        public int frequency { get; set; }
        public String quantity { get; set; }

        //default
        public Food() {
            this.number = 0;
            this.brand = "";
            this.variety = "";
            this.frequency = 0;
            this.quantity = "";
        }

        //required
        public Food(int num, String brand) {
            this.number = num;
            this.brand = brand;
            this.variety = "";
            this.frequency = 0;
            this.quantity = "";
        }

        //allFood
        public Food(int num, String brand, String variety) {
            this.number = num;
            this.brand = brand;
            this.variety = variety;
            this.frequency = 0;
            this.quantity = "";
        }

        //reqAssc
        public Food(int num, String brand, String variety, int frequency) {
            this.number = num;
            this.brand = brand;
            this.variety = variety;
            this.frequency = frequency;
            this.quantity = "";
        }

        //allAssc
        public Food(int num, String brand, String variety, int frequency, String quantity) {
            this.number = num;
            this.brand = brand;
            this.variety = variety;
            this.frequency = frequency;
            this.quantity = quantity;
        }

        public int CompareTo(Food type2) {
            if (brand.Equals(type2.brand)) {
                return variety.CompareTo(type2.variety);
            }
            else {
                return brand.CompareTo(type2.brand);
            }
        }

        public override bool Equals(Object food) {
            if (food.GetType() == typeof(Food)) {
                Food food2 = (Food)food;
                return this.ToString().Equals(food2.ToString());
            }
            else
                return false;
        }

        public bool Equals(Food type2) {
            return this.ToString().Equals(type2.ToString());
        }

        public override String ToString() {
            return brand + " " + variety;
        }
    }
}
