using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HulkHvkBLL;

namespace HVKA03 {
    
    public partial class ManageCustomer:System.Web.UI.Page {
        private Owner client;
        private int ownerNumber;
        protected void Page_Load( object sender, EventArgs e ) {
            if ( !IsPostBack ) {
                
            }
        }  // Page_Load


        private void DisplayCustomer(Owner Client)
        {
            txtFName.Text = Client.first;
            txtlname.Text = Client.last;
            txtemail.Text = Client.email;
            txtphone.Text = PhoneFormat(Client.phone);
            txtStreet.Text = Client.street;
            txtCity.Text = Client.city;
            ddlProvince.SelectedValue = (Client.province == "QC") ? "Quebec" : "Ontario";
            txtPostal.Text = PostalCodeFormat(Client.postal);
            txtEmgF.Text = Client.emg_first;
            txtEmgL.Text = Client.emg_last;
            txtEmgP.Text = PhoneFormat(Client.emg_phone);
        }

        protected void Page_PreRender( object sender, EventArgs e )
     {

         if (Session["UserType"] == null)
         { // New customer
             lblPageTitle.Text = "Welcome to Happy Valley Kennels!";
                btnDeleteCustomer.Visible = false;
            }
         else if ((userType) Session["UserType"] == userType.Customer)
         { // Customer editing account
             client = (Owner) Session["OWNER"];
             lblPageTitle.Text = "Information for " + client.first + " " + client.last;
             DisplayCustomer(client);
                btnDeleteCustomer.Visible = false;
            }
         else if ((userType) Session["UserType"] == userType.Clerk && Session["OWNER_NUMBER"] == null)
         { // Clerk creating new customer
                
                lblPageTitle.Text = "Creating a new customer";
                btnDeleteCustomer.Visible = false;
            }
         else
         { // Clerk editing existing customer
                client = new Owner();
                ownerNumber = Convert.ToInt32(Session["OWNER_NUMBER"]);
                client = client.GetOwner(ownerNumber);
                lblPageTitle.Text = "Editing " + client.first + " " + client.last;
                DisplayCustomer(client);
            }

//         if (Session["OWNER_NUMBER"] == null)
//         {
//             btnSave.Text = "Create User";
//             Session["UserType"] = userType.Customer;
//
//         }
//         else
//         {
//             if (Session["UserType"] == null)
//                 Response.Redirect("Default.aspx");
//             if ((userType) Session["UserType"] == userType.Clerk)
//             {
//                 ownerNumber = Convert.ToInt32(Session["OWNER_NUMBER"]);
//                 client = new Owner();
//                 client = client.GetOwner(ownerNumber);
//
//                 txtFName.Text = client.first;
//                 txtlname.Text = client.last;
//                 txtemail.Text = client.email;
//                 txtphone.Text = PhoneFormat(client.phone);
//                 txtStreet.Text = client.street;
//                 txtCity.Text = client.city;
//                 ddlProvince.SelectedValue = (client.province == "QC") ? "Quebec" : "Ontario";
//                 txtPostal.Text = PostalCodeFormat(client.postal);
//                 txtEmgF.Text = client.emg_first;
//                 txtEmgL.Text = client.emg_last;
//                 txtEmgP.Text = PhoneFormat(client.emg_phone);
//                 lblPageTitle.Text = "Editing " + client.first + " " + client.last;
//
//             }
//             else
//             {
//                 ownerNumber = Convert.ToInt32(Session["OWNER_NUMBER"]);
//                 client = new Owner();
//                 client = client.GetOwner(ownerNumber);
//                 btnDeleteCustomer.Visible = false;
//                 txtFName.Text = client.first;
//                 txtlname.Text = client.last;
//                 txtemail.Text = client.email;
//                 txtphone.Text = PhoneFormat(client.phone);
//                 txtStreet.Text = client.street;
//                 txtCity.Text = client.city;
//                 ddlProvince.SelectedValue = (client.province == "QC") ? "Quebec" : "Ontario";
//                 txtPostal.Text = PostalCodeFormat(client.postal);
//                 txtEmgF.Text = client.emg_first;
//                 txtEmgL.Text = client.emg_last;
//                 txtEmgP.Text = PhoneFormat(client.emg_phone);
//                 lblPageTitle.Text = "Information for " + client.first + " " + client.last;
//                }
//         }
     } // Page_PreRender

        private string PostalCodeFormat(string postal)
        {
            string result = "";

            if (postal != "")
            {
                result = postal.Substring(0, 3).ToUpper() + " ";
                result += postal.Substring(3).ToUpper();
            }
            return result;
        } // PostalCodeFormat

        private string PhoneFormat(string phone)
        {
            string result = "";

            if (phone != "")
            {
                result += "(" + phone.Substring(0, 3) + ") ";
                result += phone.Substring(3, 3) + "-";
                result += phone.Substring(6);
            }

            return result;
        } // PhoneFormat
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session["UserType"] == null)
            { // New customer
                Response.Redirect("~/Default.aspx");
            }
            else if ((userType)Session["UserType"] == userType.Customer)
            { // Customer editing account
                Response.Redirect("~/Home.aspx");
            }
            else 
            { // Clerk creating new customer
                if ((bool)Session["ManageClient"])
                    Response.Redirect("~/ManageClientHome.aspx");
                else
                    Response.Redirect("~/Home.aspx");
            }
            
        }  // btnCancel_Click


        private Owner GetCustomer()
        {
            Owner owner = new Owner();
            owner.first = txtFName.Text;
            owner.last = txtlname.Text;
            owner.phone = PhoneClean(txtphone.Text);
            owner.province = (ddlProvince.SelectedValue == "Quebec") ? "QC" : "ON";
            owner.city = txtCity.Text;
            owner.email = txtemail.Text;
            owner.street = txtStreet.Text;
            owner.postal = PostalCodeClean(txtPostal.Text);
            owner.emg_first = txtEmgF.Text;
            owner.emg_last = txtEmgL.Text;
            owner.emg_phone = PhoneClean(txtEmgP.Text);
            return owner;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["UserType"] == null)
            { // New customer
                client = GetCustomer();
                client.Add();
                Session["UserType"] = userType.Customer;
                Session["OWNER"] = client;
                Response.Redirect("~/Home.aspx");
            }
            else if ((userType)Session["UserType"] == userType.Customer)
            { // Customer editing account
                client = GetCustomer();
                client.number = (int) Session["OWNER_NUMBER"];
                client.Update();
                Session["OWNER"] = client;
                Response.Redirect("~/Home.aspx");
            }
            else if ((userType) Session["UserType"] == userType.Clerk && Session["OWNER_NUMBER"] == null)
            {
                // Clerk creating new customer
                client = GetCustomer();
                client.Add();
                Session["OWNER_NUMBER"] = client.number;
                if ((bool) Session["ManageClient"])
                    Response.Redirect("~/ManageClientHome.aspx");
                else
                    Response.Redirect("~/Home.aspx");
            }
            else
            { // Clerk editing existing customer
                client = GetCustomer();
                client.number = Convert.ToInt32(Session["OWNER_NUMBER"]);
                client.Update();
                if ((bool)Session["ManageClient"])
                    Response.Redirect("~/ManageClientHome.aspx");
                else
                    Response.Redirect("~/Home.aspx");
            }

        }
        
        private string PhoneClean(string phone)
        {
            Regex rgx = new Regex("[^0-9]");
            phone = rgx.Replace(phone, "");
            return phone;
        }

        private string PostalCodeClean(string postal)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            postal = rgx.Replace(postal, "").ToUpper();
            return postal;
        }

        protected void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            Owner owner = new Owner();
            owner.number = Convert.ToInt32(Session["OWNER_NUMBER"]);
            owner.Delete();
            Response.Redirect("~/Home.aspx");
        }
    }
}