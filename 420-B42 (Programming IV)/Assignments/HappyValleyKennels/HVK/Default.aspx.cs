using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using HulkHvkBLL;

namespace HVKA03 {
    //public Data data = new Data();
    
    public enum userType { Clerk, Customer };

    public partial class Default:System.Web.UI.Page {
        string result;
        protected void Page_Load( object sender, EventArgs e ) {
 
        }

        protected void Page_PreRender( object sender, EventArgs e ) {
            Page.Master.FindControl("nav").Visible = false;
            if ( IsPostBack ) {
                //check if session is not null
                if ( result == "Incorrect Password."||result == "Invalid Email." ) {
                    lblErrors.Text = result;
                } else {
                    if ( result == "employee" ) {
                        Session["UserType"] = userType.Clerk;
                    } else {
                        Session["UserType"] = userType.Customer;
                        Owner ownerObj = new Owner();                        
                        Owner ownInfo = ownerObj.GetOwner(Convert.ToInt32(result));
                        Session["OWNER"] = ownInfo;
                    }
                    Response.Redirect("~/Home.aspx");
                }
            }
            else {
                Session["OWNER"] = null;
                Session["UserType"] = null;
            }
        }

        protected void btnLogIn_Click( object sender, EventArgs e ) {
            if ( txtEmailOrPhone.Text == "reed@hvk.ca" ) {
                if ( txtPassword.Text == "1234" ) {
                    result = "employee";
                } else {
                    result = "Incorrect Password.";
                }
            } else {
                result = "Invalid Email.";
                Owner own = new Owner();
                DataView view = (DataView)dbOwner.Select(new DataSourceSelectArguments());
                DataTable dt = view.ToTable();
                foreach ( DataRow row in dt.Rows )
                    if ( row["OWNER_EMAIL"].ToString() == txtEmailOrPhone.Text ) {
                        result = row["OWNER_NUMBER"].ToString();
                        Session["OWNER_NUMBER"] = result;
                        break;
                    }
            }
        }

        protected void lbtnNotRegistered_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManageCustomer.aspx");
        }
    }
}