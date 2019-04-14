using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace Part_F___Accordion_Control {
    public partial class polka : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Button btn1 = new Button();
            btn1.Text = "A button";

            TextBox txt1 = new TextBox();


            CheckBox chb1 = new CheckBox();
            chb1.Text = "A checkbox";
            chb1.Checked = true;

            AccordionPane pnl1 = new AccordionPane();
            pnl1.ID = "Panel-1";
            pnl1.HeaderContainer.Controls.Add(new LiteralControl("Panel 1"));
            pnl1.ContentContainer.Controls.Add(new LiteralControl("This is the content for panel 1"));
            pnl1.ContentContainer.Controls.Add(btn1);

            AccordionPane pnl2 = new AccordionPane();
            pnl2.ID = "Panel-2";
            pnl2.HeaderContainer.Controls.Add(new LiteralControl("Panel 2"));
            pnl2.ContentContainer.Controls.Add(new LiteralControl("This is the content for panel 2"));
            pnl2.ContentContainer.Controls.Add(txt1);

            AccordionPane pnl3 = new AccordionPane();
            pnl3.ID = "Panel-3";
            pnl3.HeaderContainer.Controls.Add(new LiteralControl("Panel 3"));
            pnl3.ContentContainer.Controls.Add(new LiteralControl("This is the content for panel 3"));
            pnl3.ContentContainer.Controls.Add(chb1);

            accPanel2.Panes.Add(pnl1);
            accPanel2.Panes.Add(pnl2);
            accPanel2.Panes.Add(pnl3);

            accPanel2.SelectedIndex = 2;
        }
        
    }
}