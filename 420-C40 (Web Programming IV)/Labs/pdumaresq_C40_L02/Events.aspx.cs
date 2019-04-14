using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (IsPostBack) {
            int guests = Convert.ToInt16(Request.Form["txtGuests"]);
            String tmp = Convert.ToString(Request.Form["ddlFood"]);
            int cost = Convert.ToInt16(tmp.Substring(tmp.IndexOf("$")+1, tmp.IndexOf(" ")+1));
            bool music = Request.Form["chbDJ"] == "on" || Request.Form["chbLive"] == "on";
            bool bar = Request.Form["chbOpenBar"] == "on";

            heading.InnerText = Request.Form["txtEvent"];
            lblCostGuests.Text = guests.ToString();
            lblCostFood.Text = cost.ToString();
            lblCostBar.Text = (bar) ? "Yes" : "No";
            lblCostMusic.Text = (Request.Form["chbDJ"] == "on") ?
                ((Request.Form["chbLive"] == "on") ? "Mixed" : "DJ")
                : (Request.Form["chbLive"] == "on") ? "Live" : "none";

            lblTotalBar.Text = calculateBar(bar, guests).ToString("C2");
            lblTotalMusic.Text = calculateMusic(music).ToString("C2");
            lblTotalsFood.Text = calculateFood(guests, cost).ToString("C2");
            lblTotalCost.Text = totalCost(guests, cost, music, bar).ToString("C2");

            result.ID = "";
        }
    }

    public int calculateFood(int guests, int cost) {
        return guests * cost;
    }

    public int calculateMusic(bool music) {
        return (music) ? 500 : 0;
    }

    public int calculateBar(bool bar, int guests) {
        return (bar) ? guests * 30 : 0;
    }

    public int totalCost(int guests, int cost, bool music, bool bar) {
        return calculateBar(bar, guests)
            + calculateFood(guests, cost)
            + calculateMusic(music);
    }

    public void btnCalc_Click(object sender, EventArgs e) {
        int guests = Convert.ToInt16(txtGuests.Text);
        int cost = Convert.ToInt16(ddlFood.SelectedValue);
        bool music = chbDJ.Checked || chbLive.Checked;
        bool bar = chbLive.Checked;
    }
}