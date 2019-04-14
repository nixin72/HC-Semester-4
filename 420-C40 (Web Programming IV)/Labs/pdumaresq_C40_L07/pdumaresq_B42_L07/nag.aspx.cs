using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresq_B42_L07 {
    public partial class nag : System.Web.UI.Page {
        int nagCount;

        protected void Page_Load(object sender, EventArgs e) {
            if (Request.Cookies["name"] == null) {
                nagCount = 0;
                if (Request.Cookies["nagCounter"] != null) {
                    nagCount = Int16.Parse(Request.Cookies["nagCounter"].Value);
                    nagCount++;

                    if (nagCount % 5 == 0) {
                        lblNag.Text = "You must register";
                    }
                }
            }

        }

        protected void btnResiter_Click(object sender, EventArgs e) {
            if (txtName.Text != "" && txtEmail.Text != "") {
                Response.Cookies.Remove("nagCounter");
                HttpCookie name = new HttpCookie("name", txtName.Text);
                HttpCookie email = new HttpCookie("email", txtEmail.Text);
                name.Expires = DateTime.Now.AddDays(14);
                email.Expires = DateTime.Now.AddDays(14);
                Response.Cookies.Add(name);
                Response.Cookies.Add(email);

                lblNag.Text = "Name: " + name.Value.ToString() + ". Email: " + email.Value.ToString();
            }
            else {
                Response.Cookies["nagCounter"].Value = nagCount.ToString();
            }

        }
    }
}