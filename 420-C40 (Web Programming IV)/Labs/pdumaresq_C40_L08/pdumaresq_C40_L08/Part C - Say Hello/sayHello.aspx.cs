using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part_C___Say_Hello {
    public partial class sayHello : System.Web.UI.Page {
        protected void Page_PreRender(object sender, EventArgs e) {
            for (int x = 0; x < myName.count; x++) {
                lblGreeting.Text += myName.firstName + " " + myName.lastName + "<br />";
            }
        }
    }
}