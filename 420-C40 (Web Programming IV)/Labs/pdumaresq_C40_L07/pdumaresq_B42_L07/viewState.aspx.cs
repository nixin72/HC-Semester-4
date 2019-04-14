using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresq_B42_L07 {
    public partial class viewState : System.Web.UI.Page {
        int clickCounter;
        DateTime datetime;

        protected void Page_Load(object sender, EventArgs e) {
            if (ViewState["clickCounter"] != null) {
                clickCounter = (int)(ViewState["clickCounter"]);
                datetime = (DateTime)(ViewState["dateTime"]);
            }
            else {
                clickCounter = 0;
                datetime = DateTime.Now;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e) {
            ViewState["clickCounter"] = clickCounter;
            ViewState["dateTime"] = datetime;
        }

        protected void btnClickCounter_Click(object sender, EventArgs e) {
            clickCounter++;
            datetime = DateTime.Now;
            lblLabel.Text = "You clicked the button " + clickCounter + " times. The last time on " + datetime.ToString("dd-MM-yyyy") + ", " + datetime.ToString("hh:mm:ss");
        }

        protected void btnDateTimeLast_Click(object sender, EventArgs e) {
            clickCounter += 2;
            datetime = DateTime.Now;
            lblLabel.Text = "You clicked the button " + clickCounter + " times. The last time on " + datetime.ToString("dd-MM-yyyy") + ", " + datetime.ToString("hh:mm:ss");
        }
    }
}