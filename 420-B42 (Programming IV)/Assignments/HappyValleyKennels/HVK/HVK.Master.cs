using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HulkHvkBLL;

namespace HVKA03
{

    public partial class HVK : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] != null)
            {
                if ((userType)Session["UserType"] == userType.Clerk)
                {
                    navCustomer.Visible = false;
                }
            }
        }
        
    }
}