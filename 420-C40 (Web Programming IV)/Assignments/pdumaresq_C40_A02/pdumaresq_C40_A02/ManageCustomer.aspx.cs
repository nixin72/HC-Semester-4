using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdumaresq_B42_A01;

namespace pdumaresq_C40_A02 {
    public partial class ManagePets : System.Web.UI.Page {
        Owner testOwner;
        bool isEmployee; //str.Visible

        protected void Page_PreRender(object sender, EventArgs e) {
            if (Session["owner"] != null) {
                txtfname.Text = testOwner.first;
                txtlname.Text = testOwner.last;
                txtemail.Text = testOwner.email;
                txtphone.Text = testOwner.phone;
                txtStreet.Text = testOwner.street;
                txtCity.Text = testOwner.city;
                ddlProvince.SelectedValue = testOwner.province;
                txtPostal.Text = testOwner.postal;
                txtEmgF.Text = testOwner.emg_first;
                txtEmgL.Text = testOwner.emg_last;
                txtEmgP.Text = testOwner.emg_phone;
            }
            Session["owner"] = testOwner;
        }

        protected void Page_Load(object sender, EventArgs e) {
            isEmployee = (Session["isEmployee"] != null) ? (bool)Session["isEmployee"] : false;

            //Deciding what to do based on if employee
            if (isEmployee) {
                pnlSetPassword.Visible = false;
                pnlChangePassword.Visible = false;
                deleteCustomer.Visible = true;
            }
            else {
                deleteCustomer.Visible = false;
                pnlChangePassword.Visible = Session["owner"] == null;
                pnlSetPassword.Visible = Session["owner"] != null;
            }

            //Loading the session or instantiating the globals
            if (Session["owner"] == null) {
                testOwner = new Owner();
            }
            else {
                testOwner = Session["owner"] as Owner;
            }
        }

        protected void btnSave_click(object sender, EventArgs e) {
            testOwner = new Owner(1, txtfname.Text, txtlname.Text, 
                txtStreet.Text, txtCity.Text, ddlProvince.SelectedValue, 
                txtPostal.Text, txtemail.Text, txtphone.Text, 
                txtEmgF.Text, txtEmgL.Text, txtEmgP.Text, 0);
        }

        protected void cusEmail_ServerValidate(object source, ServerValidateEventArgs args) {
            if (!isEmployee) {
                RequiredFieldValidator reqEmail = new RequiredFieldValidator();
                reqEmail.ErrorMessage = "Please enter an email";
                reqEmail.ControlToValidate = "txtemail";
                reqEmail.Display = ValidatorDisplay.None;
                reqEmail.Text = "*";
            }            
        }

        //public void loadFields() {
        //    txtfname.Text = testOwner.first;
        //    txtlname.Text = testOwner.last;
        //    txtStreet.Text = testOwner.street;
        //    txtCity.Text = testOwner.city;
        //    ddlProvince.SelectedValue = testOwner.province;
        //    txtPostal.Text = testOwner.postal;
        //    txtemail.Text = testOwner.email;
        //    txtphone.Text = testOwner.phone;
        //    txtEmgF.Text = testOwner.emg_first;
        //    txtEmgL.Text = testOwner.emg_last;
        //    txtEmgP.Text = testOwner.emg_phone;
        //}
    }
}