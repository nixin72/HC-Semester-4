using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartB {
    public partial class login : System.Web.UI.UserControl {
        public bool isSuccess { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            isSuccess = false;
            if (IsPostBack) {
                isSuccess = regUsername.IsValid && regPassword.IsValid;
            }
        }
    }
}