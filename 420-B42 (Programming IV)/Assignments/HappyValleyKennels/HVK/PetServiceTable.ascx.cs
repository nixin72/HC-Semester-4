using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVK {
    public enum userType { Clerk, Customer };
    public partial class PetServiceTable:System.Web.UI.UserControl {
        public bool Included {
            get { return chbInclude.Checked; }
            set { chbInclude.Checked = value; }
        }

        public bool Walking {
            get { return cblServices.Items[0].Selected; }
            set { cblServices.Items[0].Selected = value; }
        }

        public bool Playtime {
            get { return cblServices.Items[1].Selected; }
            set { cblServices.Items[1].Selected = value; }
        }

        public String PetName {
            get { return lblPetName.Text; }
            set { lblPetName.Text = value; }
        }

        ValidateRequestMode val = ValidateRequestMode.Enabled;

        protected void Page_Load( object sender, EventArgs e ) {
            
            try {
                if ( (userType)Session["UserType"] == userType.Clerk ) {
                    cblVaccines.Visible = true;
                } else
                    cblVaccines.Visible = false;
            }
            catch {
                cblVaccines.Visible = false;
            }
        }
    }
}