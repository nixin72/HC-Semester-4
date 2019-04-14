using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresq_B42_L07 {
    public partial class undo : System.Web.UI.Page {
        String name;
        String phone;
        String city;

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSend_Click(object sender, EventArgs e) {
            ViewState["name"] = txtName.Text;
            ViewState["phone"] = txtPhone.Text;
            ViewState["city"] = txtCity.Text;
        }

        protected void btnUndo_Click(object sender, EventArgs e) {
            txtName.Text = ViewState["name"].ToString();
            txtPhone.Text = ViewState["phone"].ToString();
            txtCity.Text = ViewState["city"].ToString();
        }
    }
}