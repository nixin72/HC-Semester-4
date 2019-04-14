using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresq_B42_L07 {
    public partial class cookies : System.Web.UI.Page {
        int clickCounter;
        DateTime datetime;
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.Cookies["clickCount"] != null) {
                clickCounter = Int16.Parse(Request.Cookies["clickCount"].Value);
                datetime = Convert.ToDateTime(Request.Cookies["clickCount"].Value);
            }
            else {
                clickCounter = 0;
                datetime = DateTime.Now;
            }
        }

        protected void btnClickCounter_Click(object sender, EventArgs e) {
            clickCounter++;
            datetime = DateTime.Now;

            HttpCookie click = new HttpCookie("clickCount", clickCounter.ToString());
            HttpCookie date  = new HttpCookie("dateTime"  , datetime.ToString());

            click.Expires = DateTime.Now.AddDays(14);
            date.Expires  = DateTime.Now.AddDays(14);

            Response.Cookies.Add(click);
            Response.Cookies.Add(date);

            lblLabel.Text = "You clicked the button " + clickCounter + " times. The last time on " + datetime.ToString("dd-MM-yyyy") + ", " + datetime.ToString("hh:mm:ss");
        }

        protected void btnDateTimeLast_Click(object sender, EventArgs e) {
            clickCounter += 2;
            datetime = DateTime.Now;

            HttpCookie click = new HttpCookie("clickCount", clickCounter.ToString());
            HttpCookie date = new HttpCookie("dateTime", datetime.ToString());

            click.Expires = DateTime.Now.AddDays(14);
            date.Expires = DateTime.Now.AddDays(14);

            Response.Cookies.Add(click);
            Response.Cookies.Add(date);

            lblLabel.Text = "You clicked the button " + clickCounter + " times. The last time on " + datetime.ToString("dd-MM-yyyy") + ", " + datetime.ToString("hh:mm:ss");
        }
    }
}