using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB {
    public class FoodDB {
        public DataTable GetFullFoodInfo() {
            //            dsHvkTableAdapters.HVK_FOODTableAdapter adapter = new dsHvkTableAdapters.HVK_FOODTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_FOOD");

        }

        public DataTable GetFullPetFoodInfo() {
            //            dsHvkTableAdapters.HVK_PET_FOODTableAdapter adapter = new dsHvkTableAdapters.HVK_PET_FOODTableAdapter();
            //            adapter.ClearBeforeFill = true;
            //            return adapter.GetData();
            return HVK_SqlConnection.GetData("HVK_PET_FOOD");
        }
        public int Add(string brand, string variety)
        {
            string cmdStr = "Insert into hvk_food (FOOD_NUMBER, FOOD_BRAND, FOOD_VARIETY)" +
                                " values (HVK_FOOD_SEQ.NEXTVAL," + brand + "," + variety + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"hvk_food_seq");
        }

        public bool Update(int foodNumber, string brand, string variety)
        {
            string cmd = @"Update hvk_food 
                                set food_brand = :brand, 
                                food_variety = :variety
                                    where food_number = :foodNumber;";
            List<string> list = new List<string>();
            list.Add("foodNumber~" + foodNumber);
            list.Add("brand~" + brand);
            list.Add("variety~" + variety);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
