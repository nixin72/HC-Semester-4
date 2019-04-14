using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartB {
    public partial class checkLogin : System.Web.UI.Page {
        protected void Page_PreRender(object sender, EventArgs e) {
            authorized.Text = login.isSuccess ? "You are authorized" : "You are not authorized";
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}