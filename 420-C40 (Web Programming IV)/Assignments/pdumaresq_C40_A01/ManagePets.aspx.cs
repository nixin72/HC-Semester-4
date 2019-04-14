using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdumaresq_B42_A01;


public partial class ManagePets : System.Web.UI.Page {
    Pet pet;

    protected void Page_Load(object sender, EventArgs e) {
        bool isEmployee = true;
        if (!isEmployee) {
            if (!IsPostBack) {

                getRequest();
            }
            else {
                postBack();
            }
        }
        else {
            if (!IsPostBack) {
                getRequest();
            }
            else {
                postBack();
            }
        }
    }

    public void getRequest() {
        for (int x = DateTime.Now.Year - 17; x <= DateTime.Now.Year; x++) {
            ddlYear.Items.Add(x.ToString());
        }
        for (int x = 1; x < 13; x++) {
            ddlMonth.Items.Add(new ListItem(
                new DateTime(DateTime.Now.Year, x, 1).ToString("MMM"), x.ToString()));
        }

        petList.Visible = false;
        chbFixed.Checked = false;
        ddlYear.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;
        rblSexList.SelectedIndex = 0;
        rblPetSizeList.SelectedIndex = 0;
    }

    public void postBack() {
        char sex = Request.Form["rblSexList"][0];
        bool fix  = Request.Form["rblSexList"] == "on" ;
        char size = Request.Form["rblPetSizeList"][0];
        DateTime birth = new DateTime(Int16.Parse(Request.Form["ddlYear"]), 
            Int16.Parse(Request.Form["ddlMonth"]), 1);

        pet = new Pet(10, Request.Form["txtName"], sex, fix, Request.Form["txtBreed"],
            birth, 0, size, Request.Form["txtPetNotes"]);

        lblPageTitle.Text = pet.name + "'s information";
        petList.Visible = true;
        rdbAllPets.Items.Clear();
        rdbAllPets.Items.Add(pet.name);
        rdbAllPets.SelectedIndex = 0;

        btnSave.Text = "Update";
        loadFields();
    }

    public void btnSave_Click(object sender, EventArgs e) {       
        pet = new Pet(10, txtName.Text, (rblSexList.SelectedIndex == 0) ? 'm' : 'f', chbFixed.Checked, txtBreed.Text,
            new DateTime(ddlYear.SelectedIndex + DateTime.Now.Year - 17, ddlMonth.SelectedIndex + 1, 1), 0,
            rblPetSizeList.SelectedValue[0], txtPetNotes.Text);
    }
    
    private void loadFields() {
        txtName.Text = pet.name;
        txtBreed.Text = pet.breed;
        ddlYear.SelectedValue = pet.birthdate.Year.ToString();
        ddlMonth.SelectedValue = pet.birthdate.Month.ToString();

        rblSexList.SelectedIndex = (pet.sex == 'm') ? 0 : 1;
        chbFixed.Checked = pet._fixed;
        rblPetSizeList.SelectedIndex = (pet.size == 's') ? 0
            : (pet.size == 'm') ? 1 : (pet.size == 'l') ? 2 : 0;
        txtPetNotes.Text = pet.special_notes;
    }

    /*
    public void Img_Click(object sender, EventArgs e)
    {
        ImageButton btnSender = (ImageButton)sender;
        btnSender.Visible = false;

        switch (btnSender.ID)
        {
            case "btnBordetella":
                calBordetella.Visible = true;
                break;
            case "btnDistemper":
                calDistemper.Visible = true;
                break;
            case "btnHepatitis":
                calHepatitis.Visible = true;
                break;
            case "btnParvovirus":
                calParvovirus.Visible = true;
                break;
            case "btnParainfluenza":
                calParainfluenza.Visible = true;
                break;
            case "btnRabies":
                calRabies.Visible = true;
                break;
            default: return;
        }
    }

    public void Cal_Click(object sender, EventArgs e)
    {
        Calendar calSender = (Calendar)sender;
        calSender.Visible = false;

        switch (calSender.ID)
        {
            case "calBordertella":
                btnBordetella.Visible = true;
                txtBordetella.Text = calSender.SelectedDate.ToShortDateString();
                break;
            case "calDistemper":
                btnDistemper.Visible = true;
                txtDistemper.Text = calSender.SelectedDate.ToShortDateString();
                break;
            case "calHepatitis":
                btnHepatitis.Visible = true;
                txtHepatitis.Text = calSender.SelectedDate.ToShortDateString();
                break;
            case "calParvovirus":
                btnParvovirus.Visible = true;
                txtParvovirus.Text = calSender.SelectedDate.ToShortDateString();
                break;
            case "calParainfluenza":
                btnParainfluenza.Visible = true;
                txtParainfluenza.Text = calSender.SelectedDate.ToShortDateString();
                break;
            case "calRabies":
                btnRabies.Visible = true;
                txtRabies.Text = calSender.SelectedDate.ToShortDateString();
                break;
            default:
                txtBordetella.Text = "Not working";
                return;
        }
    }*/
}