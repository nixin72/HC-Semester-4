using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HulkHvkA03;

namespace HulkHvkA03
{
    public partial class ManagePets1 : System.Web.UI.Page {
        protected void Page_PreRender(object sender, EventArgs e) {
            if (Session["OWNER_NUMBER"] != null)
            {

            }
            else
            {
                Session["OWNER_NUMBER"] = 15;
            }
        }
        //Pet pet;
        //bool isEmployee;

        //protected void Page_PreRender(object sender, EventArgs e) {
        //    if (Session["pet"] != null) {
        //        txtName.Text = pet.name;
        //        txtBreed.Text = pet.breed;
        //        ddlYear.SelectedValue = pet.birthdate.Year.ToString();
        //        ddlMonth.SelectedValue = pet.birthdate.Month.ToString();
        //        rblSexList.SelectedValue = pet.sex.ToString();
        //        chbFixed.Checked = pet._fixed;
        //        rblPetSizeList.SelectedValue = pet.size.ToString();
                    
        //        Vaccination bord = pet.vaccinations.Find(v => v.number == 1) ?? new Vaccination(1, "Bordetella", false, new DateTime());
        //        if (bord.expiryDate == new DateTime()) { txtBordetella.Value = bord.expiryDate.ToString("MM/dd/yyyy"); }
        //        if (isEmployee) { chbValBordetella.Checked = bord.checkedStatus; }

        //        Vaccination dist = pet.vaccinations.Find(v => v.number == 2) ?? new Vaccination(2, "Distemper", false, new DateTime());
        //        if (dist.expiryDate == new DateTime()) { txtDistemper.Value = dist.expiryDate.ToString("MM/dd/yyyy"); }
        //        if (isEmployee) { chbValDistemper.Checked = dist.checkedStatus; }

        //        Vaccination hepa = pet.vaccinations.Find(v => v.number == 3) ?? new Vaccination(3, "Heptatitis", false, new DateTime());
        //        if (hepa.expiryDate == new DateTime()) { txtHepatitis.Value = hepa.expiryDate.ToString("MM/dd/yyyy"); }
        //        if (isEmployee) { chbValHepatitis.Checked = hepa.checkedStatus; }

        //        Vaccination para = pet.vaccinations.Find(v => v.number == 4) ?? new Vaccination(4, "Parainfluenza", false, new DateTime());
        //        if (para.expiryDate == new DateTime()) { txtParainfluenza.Value = para.expiryDate.ToString("MM/dd/yyyy"); }
        //        if (isEmployee) { chbValParainfluenza.Checked = para.checkedStatus; }

        //        Vaccination paro = pet.vaccinations.Find(v => v.number == 5) ?? new Vaccination(5, "Parovirus", false, new DateTime());
        //        if (paro.expiryDate == new DateTime()) { txtParovirus.Value = paro.expiryDate.ToString("MM/dd/yyyy"); }
        //        if (isEmployee) { chbValParovirus.Checked = paro.checkedStatus; }

        //        Vaccination rabi = pet.vaccinations.Find(v => v.number == 6) ?? new Vaccination(6, "Rabies", false, new DateTime());
        //        if (rabi.expiryDate == new DateTime()) { txtRabies.Value = rabi.expiryDate.ToString("MM/dd/yyyy"); }
        //        if (isEmployee) { chbValRabies.Checked = rabi.checkedStatus; }

        //        txtPetNotes.Text = pet.special_notes;
        //    }
        //    Session["pet"] = pet;
        //}

        //protected void Page_Load(object sender, EventArgs e) {
        //    isEmployee = (Session["isEmployee"] != null) ? (bool)Session["isEmployee"] : true;

        //    //Deciding what to show based on if employee
        //    if (isEmployee) {
        //        //Unfortunately wasn't worth it to get working...
        //        //Controls.OfType<CheckBox>().ToList().FindAll(c => c.CssClass == "Vaccinevalidator").ForEach(c => c.Visible = true);
        //        chbValBordetella.Visible = true;
        //        chbValDistemper.Visible = true;
        //        chbValHepatitis.Visible = true;
        //        chbValParainfluenza.Visible = true;
        //        chbValParovirus.Visible = true;
        //        chbValRabies.Visible = true;
        //    }
        //    else {
        //        chbValBordetella.Visible = false;
        //        chbValDistemper.Visible = false;
        //        chbValHepatitis.Visible = false;
        //        chbValParainfluenza.Visible = false;
        //        chbValParovirus.Visible = false;
        //        chbValRabies.Visible = false;
        //    }

        //    for (int x = DateTime.Now.Year - 17; x <= DateTime.Now.Year; x++) {
        //        ddlYear.Items.Add(new ListItem(x.ToString(), x.ToString()));
        //    }
        //    for (int x = 1; x < 13; x++) {
        //        ddlMonth.Items.Add(new ListItem(
        //            new DateTime(DateTime.Now.Year, x, 1).ToString("MMM"), x.ToString()));
        //    }

        //    //Loading the session or instantiating the globals
        //    if (Session["pet"] == null) {
        //        petList.Visible = false;
        //        pet = new Pet();
        //    }
        //    else {
        //        petList.Visible = true;
        //        pet = Session["pet"] as Pet;
        //    }
        //}

        //public void btnSave_Click(object sender, EventArgs e) {
        //    pet = new Pet(10, txtName.Text, (rblSexList.SelectedIndex == 0) ? 'm' : 'f', chbFixed.Checked, txtBreed.Text,
        //        new DateTime(ddlYear.SelectedIndex + DateTime.Now.Year - 17, ddlMonth.SelectedIndex + 1, 1), 0,
        //        rblPetSizeList.SelectedValue[0], txtPetNotes.Text, 17);

        //    pet.vaccinations = getVaccs();
        //}

        //private List<Vaccination> getVaccs() {
        //    List<Vaccination> vaccinations = new List<Vaccination>();
        //    vaccinations.Add(new Vaccination(1, "Bordetella", isEmployee
        //        ? chbValBordetella.Checked : false, txtBordetella.Value != "" 
        //        ? DateTime.Parse(txtBordetella.Value) : new DateTime(1)));

        //    vaccinations.Add(new Vaccination(2, "Distemper", isEmployee 
        //        ? chbValDistemper.Checked : false, txtDistemper.Value != ""
        //        ? DateTime.Parse(txtDistemper.Value) : new DateTime(1)));

        //    vaccinations.Add(new Vaccination(3, "Hepatitis", isEmployee 
        //        ? chbValHepatitis.Checked : false, txtHepatitis.Value != ""
        //        ? DateTime.Parse(txtHepatitis.Value) : new DateTime(1)));

        //    vaccinations.Add(new Vaccination(4, "Parainfluenza", isEmployee 
        //        ? chbValParainfluenza.Checked : false, txtParainfluenza.Value != ""
        //        ? DateTime.Parse(txtParainfluenza.Value) : new DateTime(1)));

        //    vaccinations.Add(new Vaccination(5, "Parovirus", isEmployee 
        //        ? chbValParovirus.Checked : false, txtParovirus.Value != ""
        //        ? DateTime.Parse(txtParovirus.Value) : new DateTime(1)));

        //    vaccinations.Add(new Vaccination(6, "Rabies", isEmployee 
        //        ? chbValRabies.Checked : false, txtRabies.Value != ""
        //        ? DateTime.Parse(txtRabies.Value) : new DateTime(1)));
            
        //    return vaccinations;
        //}

        //public void Page_LoadComplete(object sender, EventArgs e) {
        //    if (Page.IsPostBack) {
        //        if (Page.IsValid) {
        //            lblPageTitle.Text = pet.name + "'s information";
        //            petList.Visible = true;
        //            rdbAllPets.Items.Clear();
        //            rdbAllPets.Items.Add(pet.name);
        //            rdbAllPets.SelectedIndex = 0;

        //            btnSave.Text = "Update";
        //        }
        //    }
        

        //public void getRequest() {
        //    for (int x = DateTime.Now.Year - 17; x <= DateTime.Now.Year; x++) {
        //        ddlYear.Items.Add(x.ToString());
        //    }
        //    for (int x = 1; x < 13; x++) {
        //        ddlMonth.Items.Add(new ListItem(
        //            new DateTime(DateTime.Now.Year, x, 1).ToString("MMM"), x.ToString()));
        //    }

        //    petList.Visible = false;
        //    chbFixed.Checked = false;
        //    ddlYear.SelectedIndex = 0;
        //    ddlMonth.SelectedIndex = 0;
        //}

        //public void postBack() {
        //    if (Page.IsValid) {
        //        char sex = Request.Form[master + "rblSexList"][0];
        //        char size = Request.Form[master + "rblPetSizeList"][0]; ;
        //        bool fix = Request.Form[master + "rblSexList"] == "on";

        //        DateTime birth = new DateTime(1000);
        //        if (Request.Form[master + "ddlYear"] != "--Year--") {
        //            if (Request.Form[master + "ddlMonth"] != "--Month--") {
        //                birth = new DateTime(Int16.Parse(Request.Form[master + "ddlYear"]),
        //                    Int16.Parse(Request.Form[master + "ddlMonth"]), 1);
        //            }
        //            else {
        //                birth = new DateTime(Int16.Parse(Request.Form[master + "ddlYear"]), 1, 1);
        //            }
        //        }

        //        pet = new Pet(10, Request.Form[master + "txtName"], sex, fix, Request.Form[master + "txtBreed"],
        //            birth, 0, size, Request.Form[master + "txtPetNotes"], 17);

        //        DateTime bord = (txtBordetella.Value != "") ? DateTime.Parse(txtBordetella.Value) : new DateTime(1000);
        //        DateTime dist = (txtDistemper.Value != "") ? DateTime.Parse(txtDistemper.Value) : new DateTime(1000);
        //        DateTime hepa = (txtHepatitis.Value != "") ? DateTime.Parse(txtHepatitis.Value) : new DateTime(1000);
        //        DateTime para = (txtParainfluenza.Value != "") ? DateTime.Parse(txtParainfluenza.Value) : new DateTime(1000);
        //        DateTime paro = (txtParovirus.Value != "") ? DateTime.Parse(txtParovirus.Value) : new DateTime(1000);
        //        DateTime rabi = (txtRabies.Value != "") ? DateTime.Parse(txtRabies.Value) : new DateTime(1000);

        //        pet.vaccinations.Add(new Vaccination(1, "bordetella", bord));
        //        pet.vaccinations.Add(new Vaccination(1, "Distemper", dist));
        //        pet.vaccinations.Add(new Vaccination(1, "Hepatitis", hepa));
        //        pet.vaccinations.Add(new Vaccination(1, "Parainfluenza", para));
        //        pet.vaccinations.Add(new Vaccination(1, "Parovirus", paro));
        //        pet.vaccinations.Add(new Vaccination(1, "Rabies", rabi));
        //    }

        //}

        //private void loadFields() {
        //    txtName.Text = pet.name;
        //    txtBreed.Text = pet.breed;

        //    if (pet.birthdate.Ticks != 1000) {
        //        ddlYear.SelectedValue = pet.birthdate.Year.ToString();
        //        ddlMonth.SelectedValue = pet.birthdate.Month.ToString();
        //    }

        //    rblSexList.SelectedIndex = (pet.sex == 'm') ? 0 : 1;
        //    chbFixed.Checked = pet._fixed;
        //    rblPetSizeList.SelectedIndex = (pet.size == 's') ? 0
        //        : (pet.size == 'm') ? 1 : (pet.size == 'l') ? 2 : 0;
        //    txtPetNotes.Text = pet.special_notes;

        //    txtBordetella.Value = (pet.vaccinations[0].expiryDate.Ticks != 1000) ?
        //        pet.vaccinations[0].expiryDate.ToString("MM/DD/YYYY") : "";
        //    txtDistemper.Value = (pet.vaccinations[1].expiryDate.Ticks != 1000) ?
        //        pet.vaccinations[1].expiryDate.ToString("MM/DD/YYYY") : "";
        //    txtHepatitis.Value = (pet.vaccinations[2].expiryDate.Ticks != 1000) ?
        //        pet.vaccinations[2].expiryDate.ToString("MM/DD/YYYY") : "";
        //    txtParainfluenza.Value = (pet.vaccinations[3].expiryDate.Ticks != 1000) ?
        //        pet.vaccinations[3].expiryDate.ToString("MM/DD/YYYY") : "";
        //    txtParovirus.Value = (pet.vaccinations[4].expiryDate.Ticks != 1000) ?
        //        pet.vaccinations[4].expiryDate.ToString("MM/DD/YYYY") : "";
        //    txtRabies.Value = (pet.vaccinations[5].expiryDate.Ticks != 1000) ?
        //        pet.vaccinations[5].expiryDate.ToString("MM/DD/YYYY") : "";
        //}

        //public void cusBirth_Validate(object sender, ServerValidateEventArgs e) {
        //    e.IsValid = (new DateTime(Convert.ToInt16(ddlYear.SelectedValue), 
        //                              Convert.ToInt16(ddlMonth.SelectedValue), 
        //                              DateTime.Now.Day) < DateTime.Now);

        //}

        //protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args) {
        //    DateTime minDate = pet.birthdate.AddYears(1);
        //    DateTime maxDate = DateTime.Now.AddYears(5);
        //    DateTime dt;

        //    args.IsValid = (DateTime.TryParse(args.Value, out dt) && dt <= maxDate && dt >= minDate);
        //}
    //}
    }
}