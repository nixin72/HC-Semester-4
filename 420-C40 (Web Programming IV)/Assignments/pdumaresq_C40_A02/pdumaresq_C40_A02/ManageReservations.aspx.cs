using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdumaresq_B42_A01;

namespace pdumaresq_C40_A02 {
    public partial class ManageReservations : System.Web.UI.Page {
        Reservation res;
        Pet pet;
        PetReservation petRes;
        bool isEmployee;

        protected void Page_PreRender(object sender, EventArgs e) {
            if (Session["res"] != null) {
                txtStart.Value = res.sDate.ToString("MM/dd/yyyy");
                txtEnd.Value = res.eDate.ToString("MM/dd/yyyy");

                chbFoodTwice.Checked = petRes.food.frequency == 2;
                chbOwnFood.Checked = petRes.food.number == 13;
                 
                chlServices.Items[0].Selected = petRes.services.Any(s => s is Service ? s.number == 2 ? true : false : false);
                chlServices.Items[1].Selected = petRes.services.Any(s => s is Service ? s.number == 3 ? true : false : false);
                chlServices.Items[2].Selected = petRes.services.Any(s => s is Service ? s.number == 4 ? true : false : false);

                ddlFood.Value = petRes.food.ToString();
                ddlRun.SelectedValue = !isEmployee ? petRes.run.number.ToString() : null;

                lblPageTitle.Text = "Reservation for Philip: " + res.sDate.ToLongDateString() + " to " + res.eDate.ToLongDateString();
                btnCancelRes.Visible = true;
                btnMakeReservation.Text = "Update Information";
            }
            Session["res"] = res;
            Session["pet"] = pet;
            Session["pR"] = petRes;
        }

        protected void Page_Load(object sender, EventArgs e) {
            isEmployee = (Session["isEmployee"] != null) ? (bool)Session["isEmployee"] : true;

            //Deciding what to show based on if employee
            if (isEmployee) {
                pnlClerkRun.Visible = false;
                pnlSharing.Visible = true;
                lbtnViewVacc.Visible = false;
            }
            else {
                pnlClerkRun.Visible = true;
                pnlSharing.Visible = false;
                lbtnViewVacc.Visible = true;
            }

            //Loading the session or instantiating the globals
            if (Session["res"] == null) {
                res = new Reservation();
                pet = new Pet();
                petRes = new PetReservation();
                fillDropDowns();
            }
            else {
                res = Session["res"] as Reservation;
                pet = Session["pet"] as Pet;
                petRes = Session["pR"] as PetReservation;
            }
        }

        protected void btnMakeReservation_Click(object sender, EventArgs e) {
            res = new Reservation(10, DateTime.Parse(txtStart.Value), DateTime.Parse(txtEnd.Value));
            
            pet = new Pet();
            pet.name = "Sparly";

            Run run = new Run(ddlRun.SelectedIndex + 1, (pet.size == 's' ? 's' : 'l'));
            List<Discount> discounts = getDiscounts();
            List<Medication> meds = getMeds();
            List<Service> services = getServices();

            petRes = new PetReservation(10, 10, 10, 10, 10, run, findFood(ddlFood.Value), res, discounts, meds, services);
        }

        public void fillDropDowns() {
            for (int x = 1; x < 41; x++) {
                ddlRun.Items.Add(" " + x.ToString() + " ");
            }

            List<Food> foods = getFoods();

            for (int x = 0; x < foods.Count; x++)
                ddlFood.Items.Add(new ListItem(foods[x].ToString(), x.ToString()));
        }



        private Food findFood(String chosenFood) {
            foreach (Food food in getFoods()) {
                if (food.ToString() == chosenFood) {
                    food.frequency = chbFoodTwice.Checked ? 2 : 1;
                    return food;
                }
            }
            return new Food(13, "own food", null, chbFoodTwice.Checked ? 2 : 1);
        }

        private List<Discount> getDiscounts() {
            List<Discount> discounts = new List<Discount>();
            if (ddlSharing.SelectedIndex != 0)
                discounts.Add(new Discount(0, "Sharing run", 10, 't'));
            if (chbOwnFood.Checked)
                discounts.Add(new Discount(1, "Own Food", 7, 'b'));

            return discounts;
        }

        private List<Medication> getMeds() {
            List<Medication> meds = new List<Medication>();

            int num = 0;
            foreach (var li in chlMeds.Items) {
                meds.Add(new Medication(num, li.ToString()));
                num++;
            }

            return meds;
        }

        private List<Service> getServices() {
            List<Service> services = new List<Service>();

            int num = 2;
            foreach (ListItem x in chlServices.Items) {
                services.Add(x.Selected ? new Service(num, x.Text, 10) : null);
                num++;
            }

            return services;
        }

        private List<Food> getFoods() {
            List<Food> foods = new List<Food>();
            foods.Add(new Food(1, "Iams", "Mini Chunks"));
            foods.Add(new Food(2, "Iams", "Large dog"));
            foods.Add(new Food(3, "Iams", "Weight Control"));
            foods.Add(new Food(4, "Iams", "Beef and rice formula"));
            foods.Add(new Food(5, "President's choice", "Xtra Meaty Chicken and Rice"));
            foods.Add(new Food(6, "President's choice", "Xtra Meaty Lamb and Rice"));
            foods.Add(new Food(7, "Purina", "Dog Chow"));
            foods.Add(new Food(11, "Science Diet", "Allergy Formula"));
            foods.Add(new Food(14, "Pedigree", "Choice Cuts in Sauce Country Stew"));
            foods.Add(new Food(15, "Purina", "Moist Meaty Burger with Cheddar Cheese Burger with Cheddar Cheese"));

            return foods;
        }

        protected void cusStart_ServerValidate(object source, ServerValidateEventArgs args) {
            args.IsValid = cusDate_ServerValidate(txtStart.Value);
        }

        protected void cusEnd_ServerValidate(object source, ServerValidateEventArgs args) {
            args.IsValid = cusDate_ServerValidate(txtEnd.Value);
        }

        protected void compSEnd_ServerValidate(object source, ServerValidateEventArgs args) {
            args.IsValid = DateTime.Parse(txtStart.Value) < DateTime.Parse(txtEnd.Value);
        }

        protected bool cusDate_ServerValidate(String date) {
            try {
                DateTime testDate = DateTime.Parse(date);
                return true;
            }
            catch {
                return false;
            }
        }
    }

    //private List<Discount> postDiscounts() {
    //    List<Discount> discounts = new List<Discount>();
    //if (Request.Form[master + "ddlSharing"] != 0.ToString()) {
    //    discounts.Add(new Discount(0, "Sharing run", 10, 't'));
    //    ddlSharing.SelectedIndex = discounts[0].number;
    //}
    //if (Request.Form[master + "chbOwnFood"] == "on") {
    //    discounts.Add(new Discount(1, "Own Food", 7, 'b'));
    //    chbOwnFood.Checked = true;
    //}

    //    if (petRes.PRpetResNum != 0) {
    //        discounts.Add(new Discount(0, "Sharing run", 10, 't'));
    //        ddlSharing.SelectedIndex = discounts[0].number;
    //    }
    //    if (petRes.food.number == 13) {
    //        discounts.Add(new Discount(1, "Own Food", 7, 'b'));
    //        chbOwnFood.Checked = true;
    //    }

    //    return discounts;
    //}

    //private List<Service> postServices() {
    //    List<Service> services = new List<Service>();

    //    int num = 0;
    //    int ser = 0;
    //    foreach (ListItem x in chlServices.Items) {
    //if (Request.Form[master + "chlServices"] == "on") {
    //    chlServices.Items[num].Selected = true;

    //    ser++;
    //}
    //        if (((PetReservation)Session["pR"]).services.Count() != 0) {
    //            chlServices.Items[1].Selected = true;
    //            ser++;
    //        }

    //        num++;
    //    }

    //    return services;
    //}

    //private List<Medication> postMeds() {
    //    List<Medication> meds = new List<Medication>();

    //    int num = 0;
    //    foreach (ListItem x in chlMeds.Items) {
    //        if (Request.Form[master + "chlMeds"] == "on") {
    //            chlServices.Items[num].Selected = true;
    //        }
    //        num++;
    //    }

    //    return meds;
    //}

    //private void postPetReservation() {
    //    Run run = new Run(ddlRun.SelectedIndex + 1, (pet.size == 's' ? 's' : 'l'));
    //    List<Discount> discounts = postDiscounts();
    //    List<Medication> meds = postMeds();
    //    List<Service> services = postServices();

    //    petRes = new PetReservation(10, pet.number, res.number, 10, 10, run, new Food(), res, discounts, meds, services);
    //}
}