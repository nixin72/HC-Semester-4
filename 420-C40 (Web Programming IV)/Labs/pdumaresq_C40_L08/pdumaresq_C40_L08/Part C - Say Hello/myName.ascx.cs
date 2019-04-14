using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part_C___Say_Hello {
    public partial class myName : System.Web.UI.UserControl {
        public String firstName { get; set; }

        public String lastName { get; set; }

        public int count { get; set; }

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnGreet_Click(object sender, EventArgs e) {
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            count = Convert.ToInt16(txtCount.Text);
        }
    }
}