using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Others : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void cal1_SelectionChanged(object sender, EventArgs e) {
        String d1 = cal1.SelectedDate.ToString("D");
        lblCal1.Text = d1;

        if (cal2.SelectedDate != DateTime.MinValue) {
            String d2 = cal2.SelectedDate.ToString("D");
            lblDays.Text = calcDays(d1, d2);
            lblSecs.Text = calcSecs(d1, d2);
        }
    }

    protected void cal2_SelectionChanged(object sender, EventArgs e) {
        String d1 = cal2.SelectedDate.ToString("D");
        lblCal2.Text = d1;

        if (cal1.SelectedDate != DateTime.MinValue) {
            String d2 = cal1.SelectedDate.ToString("D");
            lblDays.Text = calcDays(d1, d2);
            lblSecs.Text = calcSecs(d1, d2);
        }
    }

    protected String calcDays(String date1, String date2) {
        TimeSpan ts = Convert.ToDateTime(date1) - Convert.ToDateTime(date2);
        return ts.TotalDays.ToString();
    }

    protected String calcSecs(String d1, String d2) {
        TimeSpan ts = Convert.ToDateTime(d1) - Convert.ToDateTime(d2);
        return ts.TotalSeconds.ToString();
    }
}