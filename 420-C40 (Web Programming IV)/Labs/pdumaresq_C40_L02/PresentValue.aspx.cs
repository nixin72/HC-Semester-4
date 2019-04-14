using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class images_Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            for (int x = 50 ; x <= 500 ; x+=50) {
                ddlInvest.Items.Add(x.ToString());
            }
        }  
    }

    public void btnClear_Click(object sender, EventArgs e) {
        ddlInvest.SelectedIndex = 0;
        txtInterest.Text = "";
        txtYears.Text = "";
    }

    public void btnCalc_Click(object sender, EventArgs e) {
        decimal interest = Convert.ToDecimal(txtInterest.Text) / 12 / 100;
        int months = Convert.ToInt16(txtYears.Text) * 12;
        int rate = Convert.ToInt16(ddlInvest.SelectedValue);

        lblFuture.Text = FutureValue(months, interest, rate).ToString("C2");
    }

    protected decimal FutureValue(int months, decimal interestRate, decimal monthlyInvestment) {
        decimal calcValue = 0;

        for (int i = 1; i <= months; i++) {
            calcValue = (calcValue + monthlyInvestment) * (1 + interestRate);
        }

        return calcValue;
    }
}