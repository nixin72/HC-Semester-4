using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresq_C40_A02 {
    public partial class Default : System.Web.UI.Page {
        bool isEmployee;

        protected void Page_PreRender(object sender, EventArgs e) {
            if (IsPostBack) {
                Session["isEmployee"] = isEmployee;
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e) {
            isEmployee = false;
        }

        protected void lbtnSignUp_Click(object sender, EventArgs e) {
            isEmployee = true;
        }
    }
}