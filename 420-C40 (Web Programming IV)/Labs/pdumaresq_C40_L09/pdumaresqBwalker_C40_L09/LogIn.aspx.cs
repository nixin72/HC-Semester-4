using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresqBwalker_C40_L09 {
    public partial class LogIn : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Unnamed_ServerValidate(object source, ServerValidateEventArgs args) {
            if (birth.SelectedDate.CompareTo(DateTime.Now.AddYears(-18)) > 1) {
                cusBirth.IsValid = true;
            }
            else {
                cusBirth.IsValid = false;
            }
        }
    }
}