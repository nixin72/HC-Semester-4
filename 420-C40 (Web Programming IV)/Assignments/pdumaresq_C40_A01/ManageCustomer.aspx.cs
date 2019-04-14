using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdumaresq_B42_A01;

public partial class ManageCustomer : System.Web.UI.Page {
    Owner testOwner;
    protected void Page_Load(object sender, EventArgs e) {
        bool isEmployee = true;

        if (!isEmployee) {
            password.Visible = true;
            deleteCustomer.Visible = false;

            if (Request.HttpMethod == "GET") {
                testOwner = new Owner();
            }
            else if (Request.HttpMethod == "POST") {
                testOwner = new Owner(1, Request.Form["txtfname"], Request.Form["txtlname"],
                    Request.Form["txtStreet"], Request.Form["txtCity"], Request.Form["ddlProvince"],
                    Request.Form["txtPostal"], Request.Form["txtemail"], Request.Form["txtphone"],
                    Request.Form["txtEmgF"], Request.Form["txtEmgL"], Request.Form["txtEmgP"], 0);

                lblPageTitle.Text = "Your Information";
                btnSave.Text = "Update";
                lblChgPswrd.Text = "Change Password";
                lblOldPswrd.Text = "Old Password: ";
                lblNewPswrd.Text = "New Password: ";

                loadFields();
            }
        }
        else {
            password.Visible = false;
            if (IsPostBack) {
                testOwner = new Owner(1, Request.Form["txtfname"], Request.Form["txtlname"],
                   Request.Form["txtStreet"], Request.Form["txtCity"], Request.Form["ddlProvince"],
                   Request.Form["txtPostal"], Request.Form["txtemail"], Request.Form["txtphone"],
                   Request.Form["txtEmgF"], Request.Form["txtEmgL"], Request.Form["txtEmgP"], 0);

                lblPageTitle.Text = "Customer Information: " + testOwner.ToString();
                btnSave.Text = "Update";
                deleteCustomer.Visible = true;

                loadFields();
            }
            else {
                testOwner = new Owner();
                deleteCustomer.Visible = false;
            }               
        }
    }

    public void loadFields() {
        txtfname.Text = testOwner.first;
        txtlname.Text = testOwner.last;
        txtStreet.Text = testOwner.street;
        txtCity.Text = testOwner.city;
        ddlProvince.SelectedValue = testOwner.province;
        txtPostal.Text = testOwner.postal;
        txtemail.Text = testOwner.email;
        txtphone.Text = testOwner.phone;
        txtEmgF.Text = testOwner.emg_first;
        txtEmgL.Text = testOwner.emg_last;
        txtEmgP.Text = testOwner.emg_phone;
    }

    protected void btnSave_click(object sender, EventArgs e) {
        testOwner.first = txtfname.Text;
        testOwner.last = txtlname.Text;
        testOwner.street = txtStreet.Text;
        testOwner.city = txtCity.Text;
        testOwner.province = ddlProvince.SelectedValue;
        testOwner.email = txtemail.Text;
        testOwner.phone = txtphone.Text;
        testOwner.postal = txtPostal.Text;
        testOwner.emg_first = txtEmgF.Text;
        testOwner.emg_last = txtEmgL.Text;
        testOwner.emg_phone = txtEmgP.Text;
    }
}