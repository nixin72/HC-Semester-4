using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresq_B42_L07 {
    public partial class undo2 : System.Web.UI.Page {
        ThePerson person;

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSend_Click(object sender, EventArgs e) {
            ThePerson person = new ThePerson(txtName.Text, txtPhone.Text, txtCity.Text);
            ViewState["person"] = person;
        }

        protected void btnUndo_Click(object sender, EventArgs e) {
            txtName.Text = person.name;
            txtPhone.Text = person.phone;
            txtCity.Text = person.city;
        }
    }
}