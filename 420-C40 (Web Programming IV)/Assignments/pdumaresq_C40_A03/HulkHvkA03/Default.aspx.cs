using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.ComponentModel;
using Oracle.ManagedDataAccess.Client;
using pdumaresq_B42_A01;

namespace HulkHvkA03
{
    public partial class Default : System.Web.UI.Page
    {
        string result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Page.Master.FindControl("nav").Visible = false;
            if (IsPostBack)
            {
                //check if session is not null
                if (result == "Email Does not exist." || result == "Incorrect Password or login.")
                {
                }
                else
                {
                    if (result == "employee")
                    {
                        Session["isEmployee"] = true;
                    }
                    else
                    {
                        Session["OwnerNum"] = result;
                        Session["isEmployee"] = false;
                        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        OracleConnection con = new OracleConnection(conString);
                        string cmdStr = "SELECT OWNER_NUMBER, OWNER_FIRST_NAME, OWNER_LAST_NAME, OWNER_STREET, OWNER_CITY, OWNER_PROVINCE,OWNER_POSTAL_CODE, OWNER_PHONE, OWNER_EMAIL, EMERGENCY_CONTACT_FIRST_NAME, EMERGENCY_CONTACT_LAST_NAME, EMERGENCY_CONTACT_PHONE, VET_VET_NUMBER FROM HVK_OWNER WHERE OWNER_NUMBER = :OWNER_NUMBER";
                        OracleCommand cmd = new OracleCommand(cmdStr, con);
                        cmd.Parameters.Add("OWNER_NUMBER", result);
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet("ownerDataSet");
                        da.Fill(ds, "HVK_OWNER");

                        Owner ownInfo = new Owner(Convert.ToInt32(ds.Tables[0].Rows[0]["OWNER_NUMBER"].ToString()),
                            ds.Tables[0].Rows[0]["OWNER_FIRST_NAME"].ToString(),
                            ds.Tables[0].Rows[0]["OWNER_LAST_NAME"].ToString(),
                            ds.Tables[0].Rows[0]["OWNER_STREET"].ToString(),
                            ds.Tables[0].Rows[0]["OWNER_CITY"].ToString(),
                            ds.Tables[0].Rows[0]["OWNER_PROVINCE"].ToString(),
                            ds.Tables[0].Rows[0]["OWNER_POSTAL_CODE"].ToString(),
                            ds.Tables[0].Rows[0]["OWNER_EMAIL"].ToString(),
                            ds.Tables[0].Rows[0]["OWNER_PHONE"].ToString(),
                            ds.Tables[0].Rows[0]["EMERGENCY_CONTACT_FIRST_NAME"].ToString(),
                            ds.Tables[0].Rows[0]["EMERGENCY_CONTACT_LAST_NAME"].ToString(),
                            ds.Tables[0].Rows[0]["EMERGENCY_CONTACT_PHONE"].ToString(),
                            Convert.ToInt32(ds.Tables[0].Rows[0]["VET_VET_NUMBER"].ToString()),
                            new List<Pet>());
                        Session["currentClient"] = ownInfo;
                    }
                    Response.Redirect("~/Home.aspx");
                }
            }
        }


        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            
            if (txtEmailOrPhone.Text == "reed@hvk.ca")
            {
                if (txtPassword.Text == "1234")
                {
                    result = "employee";
                }
                else
                {
                    result = "Incorrect Password or login.";
                }
            }
            else
            {
                result = "Email Does not exist.";
                DataView view = (DataView) dbOwner.Select(new DataSourceSelectArguments());
                DataTable dt = view.ToTable();
                foreach(DataRow row in dt.Rows)
                    if (row["OWNER_EMAIL"].ToString() == txtEmailOrPhone.Text)
                        result = row["OWNER_NUMBER"].ToString();
            }
        }
    }
}