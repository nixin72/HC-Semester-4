using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdumaresq_B42_A01;


public partial class ManageReservation : System.Web.UI.Page {
    Reservation res;
    Pet pet;
    PetReservation petRes;
    List<Food> foods = new List<Food>();

    protected void Page_Load(object sender, EventArgs e) {
        bool isEmployee = false;

        if (!isEmployee) {
            pnlClerkRun.Visible = false;
            pnlSharing.Visible = true;
            lbtnViewVacc.Visible = false;

            if (!IsPostBack) {
                getRequest();
            }
            else {
                postback();
            }
        }
        else {
            pnlClerkRun.Visible = true;
            pnlSharing.Visible = false;
            lbtnViewVacc.Visible = true;

            if (!IsPostBack) {
                getRequest();
            }
            else {
                postback();
            }
        }
    }

    public void getRequest() {
        for (int x = DateTime.Now.Year; x < DateTime.Now.Year + 2; x++) {
            ddlStartYear.Items.Add(x.ToString());
            ddlEndYear.Items.Add(x.ToString());
        }
        for (int x = 1; x < 13; x++) {
            ddlStartMonth.Items.Add(new ListItem(
                new DateTime(DateTime.Now.Year, x, 1).ToString("MMM"), x.ToString()));
            ddlEndMonth.Items.Add(new ListItem(
                new DateTime(DateTime.Now.Year, x, 1).ToString("MMM"), x.ToString()));
        }
        for (int x = 1; x < DateTime.DaysInMonth(ddlStartYear.SelectedIndex + DateTime.Now.Year,
            ddlStartMonth.SelectedIndex + 1); x++) {
            ddlStartDay.Items.Add(x.ToString());
            ddlEndDay.Items.Add(x.ToString());
        }
        for (int x = 1; x < 41; x++) {
            ddlRun.Items.Add(" " + x.ToString() + " ");
        }

        addFood();
    }

    private void addFood() {
        foods.Add(new Food(1, "food1", "variety1"));
        foods.Add(new Food(2, "food2", "variety2"));
        foods.Add(new Food(3, "food3", "variety3"));
        foods.Add(new Food(4, "food4", "variety4"));

        for (int x = 0; x < foods.Count; x++)
            ddlFood.Items.Add(new ListItem(foods[x].ToString(), x.ToString()));
    }

    protected void btnMakeReservation_Click(object sender, EventArgs e) {
        DateTime start = new DateTime(ddlStartYear.SelectedIndex + DateTime.Now.Year,
            Int16.Parse(ddlStartMonth.SelectedValue), Int16.Parse(ddlStartDay.SelectedValue));
        DateTime end = new DateTime(ddlEndYear.SelectedIndex + DateTime.Now.Year,
            Int16.Parse(ddlEndMonth.SelectedValue), Int16.Parse(ddlEndDay.SelectedValue));

        res = new Reservation(10, start, end);
        pet = new Pet();
        pet.name = "Sparly";
        Run run = new Run(ddlRun.SelectedIndex + 1, (pet.size == 's' ? 's' : 'l'));
        //txtStartDate.Text = ddlFood.SelectedIndex.ToString();
        //Food food = new Food(ddlFood.SelectedIndex, foods[ddlFood.SelectedIndex+1].brand, 
        //  foods[ddlFood.SelectedIndex+1].variety, chbFoodTwice.Checked ? 2 : 1);
        List<Discount> discounts = getDiscounts();
        List<Medication> meds = getMeds();
        List<KennelLog> logs = new List<KennelLog>(); //stupid me...
        List<Service> services = getServices();

        petRes = new PetReservation(10, 10, 10, 10, 10, run, new Food(), res, discounts, meds, logs, services);
    }

    public void postback() {
        postReservation();
        postPet();
        postPetReservation();

        lblPageTitle.Text = "Reservation for Philip: " + res.sDate.ToLongDateString() + " to " + res.eDate.ToLongDateString();
        btnCancelRes.Visible = true;
        btnMakeReservation.Text = "Update Information";
    }

    private void postReservation() {
        res = new Reservation(10,
            new DateTime(Int16.Parse(Request.Form["ddlStartYear"]),
            Int16.Parse(Request.Form["ddlStartMonth"]), Int16.Parse(Request.Form["ddlStartDay"])),
            new DateTime(Int16.Parse(Request.Form["ddlEndYear"]),
            Int16.Parse(Request.Form["ddlEndMonth"]), Int16.Parse(Request.Form["ddlEndDay"])));
    }

    private void postPet() {
        pet = new Pet();
        pet.name = "Sparly";
    }

    private void postPetReservation() {
        Run run = new Run(ddlRun.SelectedIndex + 1, (pet.size == 's' ? 's' : 'l'));
        //txtStartDate.Text = ddlFood.SelectedIndex.ToString();
        //Food food = new Food(ddlFood.SelectedIndex, foods[ddlFood.SelectedIndex+1].brand, 
        //  foods[ddlFood.SelectedIndex+1].variety, chbFoodTwice.Checked ? 2 : 1);
        List<Discount> discounts = postDiscounts();
        List<Medication> meds = postMeds();
        List<KennelLog> logs = new List<KennelLog>(); //stupid me...
        List<Service> services = postServices();

        petRes = new PetReservation(10, pet.number, res.number, 10, 10, run, new Food(), res, discounts, meds, logs, services);
    }

    private List<Discount> getDiscounts() {
        List<Discount> discounts = new List<Discount>();
        if (ddlSharing.SelectedIndex != 0)
            discounts.Add(new Discount(0, "Sharing run", 10, 't'));
        if (chbOwnFood.Checked)
            discounts.Add(new Discount(1, "Own Food", 7, 'b'));

        return discounts;
    }

    private List<Discount> postDiscounts() {
        List<Discount> discounts = new List<Discount>();
        if (Request.Form["ddlSharing"] != 0.ToString()) {
            discounts.Add(new Discount(0, "Sharing run", 10, 't'));
            ddlSharing.SelectedIndex = discounts[0].number;
        }
        if (Request.Form["chbOwnFood"] == "on") {
            discounts.Add(new Discount(1, "Own Food", 7, 'b'));
            chbOwnFood.Checked = true;
        }            

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

    private List<Medication> postMeds() {
        List<Medication> meds = new List<Medication>();

        int num = 0;
        foreach (ListItem x in chlMeds.Items) {
            if (Request.Form["chlMeds"] == "on") {
                chlServices.Items[num].Selected = true;
            }
            num++;
        }

        return meds;
    }

    private List<Service> getServices() {
        List<Service> services = new List<Service>();

        int num = 0;
        foreach (ListItem x in chlServices.Items) {
            services.Add(new Service(num, x.Text, 10));
            num++;
        }
        return services;
    }

    private List<Service> postServices() {
        List<Service> services = new List<Service>();

        int num = 0;
        int ser = 0;
        foreach (ListItem x in chlServices.Items) {
            if (Request.Form["chlServices"] == "on") {
                chlServices.Items[num].Selected = true;
                
                ser++;
            }
            num++;
        }

        return services;
    }

    /*
    public void insertPet(Pet pet) {
        pets.InnerHtml += ""
            + "<div class='pet'>"
                + "<h2>" + pet.name + "</h2>"
                    + "<div class='top'>"
                        + "<div class='left res' style='text-align: left'>"
                            + "<label>Prefered Food</label>"
                            + "<br />"
                            + "<select id = 'ddlFood' runat= 'server' >"
                       
                            + "</ select >"
                            + "< br />< br />"
                            + "< asp:CheckBox runat='server' ID='chbFoodTwice' Text=' Twice a day &ensp; +$3.00/Day' />"
                            + "< br />"
                            + "< asp:CheckBox runat = 'server' ID='chbOwnFood' Text=' I will bring my own food' />"
                            + "< br />< br />"
                            + "< label > Share run with:</label><br />"
                            + "<select>"
                                + "<option>No other pets</option>"
                            + "</select>"

                        + "</div>"
                        + "<div class='middle res'>"
                            + "Medical information:<br /><br />"
                            + vaccinationsUpToDate() + "<br /><br />"
                            + "Add a medication<br />"
                            + medications() + "<br />"
                        + "</div>"
                        + "<div class='right res'>"
                            + "<label>Services: </label>"
                            + "<asp:CheckBoxList runat = 'server' >"
                                + "< asp:ListItem>Walk</asp:ListItem>"
                                + "<asp:ListItem>Grooming</asp:ListItem>"
                                + "<asp:ListItem>Playtime</asp:ListItem>"
                            + "</asp:CheckBoxList>"
                            + "<br />"
                            + "<div class='clerkVisible'>"
                                + "<label>Selected run:</label><br />"
                                + "<asp:TextBox runat = 'server' ID='run' ></asp:TextBox>"
                                + "<br />"
                                + "<asp:LinkButton runat ='server' ID='pickRun'>Pick Run</asp:LinkButton>"
                            + "</div>"
                        + "</div>"
                        + "<br />"
                    + "</div>"
                    + "<br />"
                    + "<div class='bottom' style='text-align: left;'>"
                        + "notes:<br />"
                        + "<asp:TextBox ID = 'txtPet1Notes' TextMode='multiline' Columns='70' Rows='5' runat='server'></asp:TextBox>"
                    + "</div>"
                + "</div>"
            ;
    }
    */
}