using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HulkHVKA03 {
    public partial class DatePicker:System.Web.UI.UserControl {
        public String Text
        {
            get{ return txtCalendar.Text; }
            set { txtCalendar.Text = value; }
        }

        ValidateRequestMode val = ValidateRequestMode.Enabled;

        protected void Page_Load( object sender, EventArgs e ) {
            txtCalendar.Attributes.Add("readonly", "readonly");
            txtCalendar.Attributes.Add("placeholder", "Pick a Date");
            //Added programatically as it is the only way to allow postback, 
            //as well as to put a placeholder in an asp textbox
        }
    }
}