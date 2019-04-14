using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdumaresq_B42_A01;

namespace pdumaresq_C40_A02 {
    public partial class Home : System.Web.UI.Page {
        List<Reservation> reservations = new List<Reservation>();
        List<Pet> petList = new List<Pet>();
        List<Owner> owners = new List<Owner>();

        IDictionary<char, String> petSizes = new Dictionary<char, String>();
        IDictionary<char, String> petSex = new Dictionary<char, String>();

        bool isEmployee;

        protected void Page_Load(object sender, EventArgs e) {
            petSizes['L'] = "Large";
            petSizes['M'] = "Medium";
            petSizes['S'] = "Small";
            petSex['M'] = "Male";
            petSex['F'] = "Female";

            petList.Add(new Pet(30, "Suki", 'F', false, null, new DateTime(), 0, 'L', null, 17));
            petList.Add(new Pet(31, "Sam", 'M', false, null, new DateTime(), 0, 'L', null, 17));
            petList.Add(new Pet(32, "Snoop Dogg", 'M', false, null, new DateTime(), 0, 'M', null, 17));

            owners.Add(new Owner(17, "Polly", "Morphek", null, null, null, null, "pmorphek@gmail.com", "8195575332", null, null, null, 1));
            owners[owners.IndexOf(owners.Find(o => o.number == 17))].pets = petList.FindAll(p => p.ownerNumber == 17);

            reservations.Add(new Reservation(633, new DateTime(2017, 01, 07), new DateTime(2017, 01, 09))); //32
            reservations.Add(new Reservation(704, new DateTime(2017, 01, 10), new DateTime(2017, 01, 12))); //32
            reservations.Add(new Reservation(717, new DateTime(2017, 04, 10), new DateTime(2017, 04, 25))); //32, 31, 30
            reservations.Add(new Reservation(603, new DateTime(2017, 03, 01), new DateTime(2017, 03, 07))); //32, 31
            reservations.Add(new Reservation(800, new DateTime(2017, 06, 20), new DateTime(2017, 06, 26))); //32, 31
            reservations.Add(new Reservation(146, new DateTime(2016, 12, 28), new DateTime(2017, 01, 01))); //32
            reservations.Add(new Reservation(145, new DateTime(2016, 12, 28), new DateTime(2017, 01, 01))); //31, 30
            reservations.Add(new Reservation(701, new DateTime(2017, 01, 10), new DateTime(2017, 01, 12))); //30

            owners[owners.IndexOf(owners.Find(o => o.number == 17))].reservations = reservations;

            isEmployee = (Session["isEmployee"] != null) ? (bool)Session["isEmployee"] : true;
            if (isEmployee) {
                homeLeftPanel.Visible = false;
                pnlClerk.Visible = true;

                thcCustomer.Visible = true;
                reservationsAndClerk.CssClass = "resAndClerk";

                foreach (var x in reservations) {
                    addReservations(x);
                }
            }
            else {
                homeLeftPanel.Visible = true;
                pnlClerk.Visible = false;

                foreach (var x in petList) {
                    insertPet(x);
                }

                foreach (var x in reservations) {
                    addReservations(x);
                }
            }
        }

        private void addReservations(Reservation res) {
            TableRow resData = new TableRow();

            if (isEmployee) {
                TableCell owner = new TableCell();
                Label ownerName = new Label();

                ownerName.Text = owners[owners.IndexOf(owners.Find(o => o.reservations.Any(r => r.number == res.number)))].ToString();
                
                owner.Controls.Add(ownerName);
                resData.Cells.Add(owner);
            }

            TableCell start = new TableCell();
            Label startDate = new Label();
            startDate.Text = res.sDate.ToString("MMM dd yyyy") + "<br />";
            LinkButton editPet = new LinkButton();
            editPet.Text = "Edit";
            editPet.PostBackUrl = "~/ManageReservations.aspx";

            start.Controls.Add(startDate);
            start.Controls.Add(editPet);

            TableCell sep = new TableCell();
            sep.Text = "---------";

            TableCell end = new TableCell();
            end.Text = res.eDate.ToString("MMM dd yyyy");

            TableCell pets = new TableCell();
            foreach (var x in petList) {
                LinkButton pet = new LinkButton();
                pet.PostBackUrl = "~/ManagePets.aspx";
                pet.Text = x.name + "<br />";

                pets.Controls.Add(pet);
            }

            resData.Cells.Add(start);
            resData.Cells.Add(sep);
            resData.Cells.Add(end);
            resData.Cells.Add(pets);
            tblReservations.Rows.Add(resData);

            TableRow div = new TableRow();
            TableCell divCell = new TableCell();
            divCell.Text = "";
            div.Cells.Add(divCell);
            tblReservations.Rows.Add(div);
        }

        public String checkVaccinations() {
            return "Up to date";
        }

        public void insertPet(Pet x) {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            Table table = new Table();
            table.CssClass = "petTable";

            TableRow nameRow = new TableRow();
            TableCell nameCell = new TableCell();
            Label editPet = new Label();
            editPet.Text = x.name;
            nameCell.Controls.Add(editPet);
            nameCell.CssClass = "petName";
            nameRow.Cells.Add(nameCell);
            
            TableRow sizeVacc = new TableRow();
            TableCell size = new TableCell();
            size.Text = "Size: " + petSizes[x.size];
            TableCell vacc = new TableCell();
            vacc.Text = "Vaccinations: " + checkVaccinations();
            sizeVacc.Cells.Add(size);
            sizeVacc.Cells.Add(vacc);

            TableRow gender = new TableRow();
            TableCell sex = new TableCell();
            sex.Text = "Sex: " + petSex[x.sex];
            gender.Cells.Add(sex);

            table.Rows.Add(nameRow);
            table.Rows.Add(sizeVacc);
            table.Rows.Add(gender);

            cell.Controls.Add(table);
            row.Cells.Add(cell);
            pnlPets.Controls.Add(row);

            Label lblLine = new Label();
            lblLine.Text = "<hr />";
            pnlPets.Controls.Add(lblLine);
        }
    }
}