using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresq_C40_A02 {
    public partial class PD_HVK : System.Web.UI.MasterPage {
        protected void Page_PreRender(object sender, EventArgs e) {
            //Change this to determine if the account is employee or customer
            //comment it out to allow the default.aspx page to determine based on the button clicked
            hdnIsEmployee.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e) {
            
        }
    }
}