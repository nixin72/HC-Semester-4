using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pdumaresq_C40_L081 {
    public partial class ListPicker2 : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnAddAll_Click(object sender, EventArgs e) {
            if (lstAvailable.Items.Count != 0) {
                lstSelected.SelectedIndex = -1;
                foreach (ListItem li in lstAvailable.Items) {
                    AddItem(li, lstSelected);
                }
                lstAvailable.Items.Clear();
            }
            else {
                cusAvailableEmpty.IsValid = false;
            }

            
        }

        protected void btnAddOne_Click(object sender, EventArgs e) {
            if (lstAvailable.SelectedIndex >= 0) {
                ListItem li = lstAvailable.SelectedItem;

                AddItem(li, lstSelected);

                lstAvailable.Items.Remove(li);
                lstAvailable.SelectedIndex = -1;
            }
        }

        protected void btnBackOne_Click(object sender, EventArgs e) {
            if (lstSelected.SelectedIndex >= 0) {
                ListItem li = lstSelected.SelectedItem;

                AddItem(li, lstAvailable);
                lstSelected.Items.Remove(li);
                lstSelected.SelectedIndex = -1;
            }
        }

        protected void btnBackAll_Click(object sender, EventArgs e) {
            if (lstSelected.Items.Count != 0) {
                lstAvailable.SelectedIndex = -1;
                foreach (ListItem li in lstSelected.Items) {
                    AddItem(li, lstAvailable);
                }
                lstSelected.Items.Clear();
            }
            else {
                cusSelectedEmpty.IsValid = false;
            }
            
        }

        protected void AddItem(ListItem li, ListBox lbx) {
            if (lbx == lstSelected) {
                lstAvailable.SelectedIndex = -1;
                lstSelected.Items.Add(li);
            }
            else {
                lstSelected.SelectedIndex = -1;
                lstAvailable.Items.Add(li);
            }
        }
    }
}
