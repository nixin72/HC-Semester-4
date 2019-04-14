using HulkHvkBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKA03 {
    public partial class ManagePet : System.Web.UI.Page
    {

        Pet pet;
        bool isEmployee;


        protected void Page_PreRender(object sender, EventArgs e)
        {

            if (Session["UserType"] != null)
            {
                if (Session["OWNER_NUMBER"] != null)
                {
                    if (Session["PET_NUMBER"] != null)
                    {
                        setFieldsForOwnerPet();
                    }
                    else
                    {
                        btnRemovePet.Visible = false;
                        btnSave.Text = "Add New Pet";
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void setFieldsForOwnerPet()
        {
            pet = new Pet();
            pet = pet.getPet(Convert.ToInt32(Session["PET_NUMBER"]));

            txtName.Text = pet.name;
            txtBreed.Text = pet.breed;

            if (!DateTime.Equals(pet.birthdate, new DateTime()))
            {
                ddlYear.SelectedValue = pet.birthdate.Value.ToString("yyyy");
                String newDate = pet.birthdate.Value.ToString("%M");
                ddlMonth.SelectedIndex = Convert.ToInt32(newDate);
            }

            rblSexList.SelectedValue = pet.sex.ToString();
            chbFixed.Checked = pet._fixed;
            rblPetSizeList.SelectedValue = pet.size.ToString();

            setVaccinationFields(pet);

            txtPetNotes.Text = pet.special_notes;
            lblPageTitle.Text = pet.name + "'s information";
            btnSave.Text = "Update";
        }

        private void setVaccinationFields(Pet pet)
        {
            List<Vaccination> vaccinations = new List<Vaccination>();

            bool isEmployee = ((userType)Session["UserType"] == userType.Clerk);

            for (int i = 1; i <= 6; i++) {
                vaccinations.Add(pet.vaccinations.Find(v => v.number == i));
            }

            if (vaccinations[0] != null)
            {
                txtBordetella.Text = vaccinations[0].expiryDate.ToString("MM/dd/yyyy");
                if (isEmployee) { chbValBordetella.Checked = vaccinations[0].checkedStatus; }
            }

            if (vaccinations[1] != null)
            {
                txtDistemper.Text = vaccinations[1].expiryDate.ToString("MM/dd/yyyy");
                if (isEmployee) { chbValDistemper.Checked = vaccinations[1].checkedStatus; }
            }

            if (vaccinations[2] != null)
            {
                txtHepatitis.Text = vaccinations[2].expiryDate.ToString("MM/dd/yyyy");
                if (isEmployee) { chbValHepatitis.Checked = vaccinations[2].checkedStatus; }
            }

            if (vaccinations[3] != null)
            {
                txtParainfluenza.Text = vaccinations[3].expiryDate.ToString("MM/dd/yyyy");
                if (isEmployee) { chbValParainfluenza.Checked = vaccinations[3].checkedStatus; }
            }

            if (vaccinations[4] != null)
            {
                txtParovirus.Text = vaccinations[4].expiryDate.ToString("MM/dd/yyyy");
                if (isEmployee) { chbValParovirus.Checked = vaccinations[4].checkedStatus; }
            }

            if (vaccinations[5] != null)
            {
                txtRabies.Text = vaccinations[5].expiryDate.ToString("MM/dd/yyyy");
                if (isEmployee) { chbValRabies.Checked = vaccinations[5].checkedStatus; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserType"] != null)
                {
                    if (((userType)Session["UserType"] == userType.Clerk))
                    {
                        chbValBordetella.Visible = true;
                        chbValDistemper.Visible = true;
                        chbValHepatitis.Visible = true;
                        chbValParainfluenza.Visible = true;
                        chbValParovirus.Visible = true;
                        chbValRabies.Visible = true;
                    }
                    else
                    {
                        chbValBordetella.Visible = false;
                        chbValDistemper.Visible = false;
                        chbValHepatitis.Visible = false;
                        chbValParainfluenza.Visible = false;
                        chbValParovirus.Visible = false;
                        chbValRabies.Visible = false;
                    }

                    for (int x = DateTime.Now.Year - 17; x <= DateTime.Now.Year; x++)
                    {
                        ddlYear.Items.Add(new ListItem(x.ToString(), x.ToString()));
                    }
                    for (int x = 1; x < 13; x++)
                    {
                        ddlMonth.Items.Add(new ListItem(
                            new DateTime(DateTime.Now.Year, x, 1).ToString("MMM"), x.ToString()));
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }            
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(Page.IsValid)
            {
                savePet();
            }
            
        }

        private void savePet()
        {
            DateTime? birth = null;
            if (ddlYear.SelectedIndex != 0)
            {
                if (ddlMonth.SelectedIndex != 0)
                {
                    birth = new DateTime(Int16.Parse(ddlYear.SelectedValue), Int16.Parse(ddlMonth.SelectedValue), 1);
                }
                else
                {
                    birth = null;
                }
            }

            if (Session["PET_NUMBER"] == null)
            {
                Pet pet = new Pet();
                if (pet.AddPet(txtName.Text, (rblSexList.SelectedIndex == 0) ? 'M' : 'F', chbFixed.Checked, txtBreed.Text,
                                birth, Convert.ToInt32(Session["OWNER_NUMBER"]), rblPetSizeList.SelectedValue[0], txtPetNotes.Text)
                                != HulkHvkBLL.e.insertFail)
                {
                    addVaccinations();
                }
                else
                {
                    
                    lblCUDErrorORWarning.Text = "Error: We could not add your pet due to a serverside error <br /> we are currently working on a solution, please try again in 15 minutes";
                }

            }
            else
            {
                Pet tempPet = new Pet(Convert.ToInt32(Session["PET_NUMBER"]), txtName.Text, (rblSexList.SelectedIndex == 0) ? 'M' : 'F', chbFixed.Checked, txtBreed.Text,
                                      birth, Convert.ToInt32(Session["OWNER_NUMBER"]), 0, rblPetSizeList.SelectedValue[0], txtPetNotes.Text);
                if (tempPet.Update(Convert.ToInt32(Session["PET_NUMBER"]), tempPet.name, tempPet.sex, tempPet._fixed, tempPet.breed,
                               Convert.ToDateTime(tempPet.birthdate), tempPet.ownerNumber, Convert.ToChar(tempPet.size), tempPet.special_notes)
                               != HulkHvkBLL.e.updateFail)
                {
                    addVaccinations();
                }
                else
                {
                    lblCUDErrorORWarning.Text = "Error: We could not add your pet's vaccinations due to a serverside error <br /> we are currently working on a solution, please try again in 15 minutes";
                }
            }
        }

        public void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Page.IsValid && lblCUDErrorORWarning.Text.Equals(""))
                {
                    Session.Remove("PET_NUMBER");
                    if ((userType)Session["UserType"] == userType.Clerk)
                    {
                        Response.Redirect("~/ManageClientHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Home.aspx");
                    }
                    
                }
            }
        }

        private void addVaccinations()
        {

            List<DateTime> expiryDates = new List<DateTime>();
            expiryDates.Add((txtBordetella.Text != "") ? DateTime.Parse(txtBordetella.Text) : new DateTime(1000));
            expiryDates.Add((txtDistemper.Text != "") ? DateTime.Parse(txtDistemper.Text) : new DateTime(1000));
            expiryDates.Add((txtHepatitis.Text != "") ? DateTime.Parse(txtHepatitis.Text) : new DateTime(1000));
            expiryDates.Add((txtParainfluenza.Text != "") ? DateTime.Parse(txtParainfluenza.Text) : new DateTime(1000));
            expiryDates.Add((txtParovirus.Text != "") ? DateTime.Parse(txtParovirus.Text) : new DateTime(1000));
            expiryDates.Add((txtRabies.Text != "") ? DateTime.Parse(txtRabies.Text) : new DateTime(1000));

            List<CheckBox> vaccCheckBoxes = new List<CheckBox>();
            vaccCheckBoxes.Add(chbValBordetella);
            vaccCheckBoxes.Add(chbValDistemper);
            vaccCheckBoxes.Add(chbValHepatitis);
            vaccCheckBoxes.Add(chbValParainfluenza);
            vaccCheckBoxes.Add(chbValParovirus);
            vaccCheckBoxes.Add(chbValRabies);

            Vaccination vacc = new Vaccination();

            if (Session["PET_NUMBER"] != null)
            {
                Pet pet = new Pet();
                pet = pet.getPet(Convert.ToInt32(Session["PET_NUMBER"]));

                List<Vaccination> vaccinations = new List<Vaccination>();
                for (int i = 1; i <= 6; i++)
                {
                    vaccinations.Add(pet.vaccinations.Find(v => v.number == i));
                }

                for (int i = 0; i < 6; i++)
                {
                    if (!DateTime.Equals(expiryDates[i], new DateTime(1000)))
                    {
                        if (vaccinations[i] != null)
                            vacc.Update(expiryDates[i], i+1, Convert.ToInt32(Session["PET_NUMBER"]), vaccCheckBoxes[i].Checked);
                        else
                            vacc.Insert(expiryDates[i], i+1, Convert.ToInt32(Session["PET_NUMBER"]), vaccCheckBoxes[i].Checked);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (!DateTime.Equals(expiryDates[i], new DateTime(1000)))
                    {
                        vacc.Insert(expiryDates[i], i + 1, vaccCheckBoxes[i].Checked);
                    }
                }
            }

            }


        public void cusBordetella_Validate(object sender, ServerValidateEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBordetella.Text))
                e.IsValid = (DateTime.Parse(txtBordetella.Text) <= DateTime.Now.AddYears(5) 
                      && DateTime.Parse(txtBordetella.Text) >= DateTime.Now.AddYears(-5));
            else if(String.IsNullOrEmpty(txtBordetella.Text)) {
                e.IsValid = !(chbValBordetella.Checked);
            }
            else {
                e.IsValid = true;
            }
               
            
        }

        public void cusDistemper_Validate(object sender, ServerValidateEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDistemper.Text))
                e.IsValid = (DateTime.Parse(txtDistemper.Text) <= DateTime.Now.AddYears(5)
                      && DateTime.Parse(txtDistemper.Text) >= DateTime.Now.AddYears(-5));
            else if (String.IsNullOrEmpty(txtDistemper.Text))
            {
                e.IsValid = !(chbValDistemper.Checked);
            }
            else
                e.IsValid = true;
        }

        public void cusHepatitus_Validate(object sender, ServerValidateEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtHepatitis.Text))
                e.IsValid = (DateTime.Parse(txtHepatitis.Text) <= DateTime.Now.AddYears(5)
                      && DateTime.Parse(txtHepatitis.Text) >= DateTime.Now.AddYears(-5));
            else if (String.IsNullOrEmpty(txtHepatitis.Text))
            {
                e.IsValid = !(chbValHepatitis.Checked);
            }
            else
                e.IsValid = true;
        }

        public void cusParainfluenza_Validate(object sender, ServerValidateEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtParainfluenza.Text))
                e.IsValid = (DateTime.Parse(txtParainfluenza.Text) <= DateTime.Now.AddYears(5)
                      && DateTime.Parse(txtParainfluenza.Text) >= DateTime.Now.AddYears(-5));
            else if (String.IsNullOrEmpty(txtParainfluenza.Text))
            {
                e.IsValid = !(chbValParainfluenza.Checked);
            }
            else
                e.IsValid = true;
        }

        public void cusParovirus_Validate(object sender, ServerValidateEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtParovirus.Text))
                e.IsValid = (DateTime.Parse(txtParovirus.Text) <= DateTime.Now.AddYears(5)
                          && DateTime.Parse(txtParovirus.Text) >= DateTime.Now.AddYears(-5));
            else if (String.IsNullOrEmpty(txtParovirus.Text))
            {
                e.IsValid = !(chbValParovirus.Checked);
            }
            else
                e.IsValid = true;
        }

        public void cusRabies_Validate(object sender, ServerValidateEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRabies.Text))
                e.IsValid = (DateTime.Parse(txtRabies.Text) <= DateTime.Now.AddYears(5)
                      && DateTime.Parse(txtRabies.Text) >= DateTime.Now.AddYears(-5));
            else if (String.IsNullOrEmpty(txtRabies.Text))
            {
                e.IsValid = !(chbValRabies.Checked);
            }
            else
                e.IsValid = true;
        }


        public void cusBirth_Validate(object sender, ServerValidateEventArgs e)
        {
            if (ddlYear.SelectedIndex != 0 && ddlMonth.SelectedIndex != 0)
            {
                e.IsValid = (new DateTime(Convert.ToInt16(ddlYear.SelectedValue),
                                          Convert.ToInt16(ddlMonth.SelectedValue),
                                          DateTime.Now.Day) < DateTime.Now);
            }
            else if(ddlYear.SelectedIndex != 0 && ddlMonth.SelectedIndex == 0)
            {
                e.IsValid = (new DateTime(Convert.ToInt16(ddlYear.SelectedValue), 1,1) <= DateTime.Now);
            }
            else if(ddlYear.SelectedIndex == 0 && ddlMonth.SelectedIndex != 0)
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
            
        }

        protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = pet.birthdate.Value.AddYears(1);
            DateTime maxDate = DateTime.Now.AddYears(5);
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt) && dt <= maxDate && dt >= minDate);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("PET_NUMBER");

            if ((userType)Session["UserType"] == userType.Clerk)
            {
                Response.Redirect("~/ManageClientHome.aspx");
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void btnRemovePet_Click(object sender, EventArgs e)
        {
            Pet pet = new Pet();

            if (pet.removePet(Convert.ToInt32(Session["PET_NUMBER"])) != HulkHvkBLL.e.deleteFail)
            {
                Session.Remove("PET_NUMBER");
                if ((userType)Session["UserType"] == userType.Clerk)
                {
                    Response.Redirect("~/ManageClientHome.aspx");
                }
                else
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
            else
            {
                lblCUDErrorORWarning.Text = "Error: We could not add your pet due to a serverside error <br /> we are currently working on a solution, please try again in 15 minutes";
            }
        }
    }
}