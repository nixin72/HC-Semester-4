using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB
{
    public class PetFoodDB
    {
        public DataTable GetFullPetFoodInfo()
        {
          return HVK_SqlConnection.GetData("HVK_PET_FOOD");

        }
        public int Add(int frequency, string quantity, int petResNumber, int foodNumber)
        {
            string cmdStr = "Insert into hvk_pet_food (PET_FOOD_FREQUENCY, PET_FOOD_QUANTITY," +
                                "PR_PET_RES_NUMBER, FOOD_FOOD_NUMBER)" +
                                " values (" + frequency + "," + quantity + "," + petResNumber + "," + foodNumber + ")";
            return HVK_SqlConnection.AddRow(cmdStr,"");
        }

        public bool Update(int frequency, string quantity, int petResNumber, int foodNumber)
        {
            string cmd = @"Update hvk_pet_food 
                                set pet_food_frequency = :frequency, 
                                pet_food_quantity = :quantity,
                                food_food_number = :foodNumber
                                    where pr_pet_res_number = :petResNumber;";
            List<string> list = new List<string>();
            list.Add("frequency~" + frequency);
            list.Add("quantity~" + quantity);
            list.Add("petResNumber~" + petResNumber);
            list.Add("foodNumber~" + foodNumber);
            return HVK_SqlConnection.UpdateRow(cmd, list);
        }
    }
}
