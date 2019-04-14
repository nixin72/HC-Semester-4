using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using HulkHvkBLL;

namespace HVKA03 {
    public partial class Home:System.Web.UI.Page {

        //    List<Reservation> reservations = new List<Reservation>();
        //    List<Pet> petList = new List<Pet>();
        //    List<Owner> owners = new List<Owner>();
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection con;

        IDictionary<char, String> petSizes = new Dictionary<char, String>();
        IDictionary<char, String> petSex = new Dictionary<char, String>();

        bool isEmployee;
        Owner client;

        protected void Page_Load( object sender, EventArgs e ) {
            Session["ManageClient"] = false;
            Session.Remove("PET_NUMBER");
            Reservation resObj = new Reservation();
            Owner ownerObj = new Owner();
            List<Reservation> resList = null;
            List<Owner> ownerList = null;
            con = new OracleConnection(conString);
            petSizes['L'] = "Large";
            petSizes['M'] = "Medium";
            petSizes['S'] = "Small";
            petSex['M'] = "Male";
            petSex['F'] = "Female";

            isEmployee = (Session["UserType"] != null) ? (userType)Session["UserType"] == userType.Clerk : true;

            if ( isEmployee ) {
                homeLeftPanel.Visible = false;
                pnlOwnList.Visible = true;

                thcCustomer.Visible = true;
                reservationsAndClerk.CssClass = "resAndClerk";

                resList = resObj.ListReservations();
                ownerList = ownerObj.ListOwners();

                for ( int i = 0 ; i < ownerList.Count ; i++ ) {
                    insertClient(ownerList[i]);
                }
                //gvReservations.Visible = false;
                //cusResTable.Visible = true;
            } else {
                client = (Owner)Session["OWNER"];
                //homeLeftPanel.Visible = true;
                //pnlClerk.Visible = false;

                editCusLink.Command += new CommandEventHandler(editOwn_OnClick);
                lblCusFname.Text = "First name: " + client.first;
                lblCusLname.Text = "Last name: " + client.last;

                Pet petobj = new Pet();
                List<Pet> petList = petobj.listPets(client.number);

                for ( int i = 0 ; i < petList.Count ; i++ ) {
                    insertPet(petList[i]);
                }                
                resList = resObj.ListReservations(client.number);

                Button btnAddPet = new Button();
                btnAddPet.Text = "Add a Pet";
                pnlPets.Controls.Add(btnAddPet);
                btnAddPet.ID = "btnAddPet";
                btnAddPet.Command += new CommandEventHandler(btnAddPet_Click);

            }

            if ( !IsPostBack ) {
                Session["RESERVATION_NUMBER"] = null;
            }

            for ( int i = 0 ; i < resList.Count ; i++ ) {
                addReservations(resList[i]);
            }
        }



        private void addReservations( Reservation res ) {
            TableRow resData = new TableRow();

            if ( isEmployee ) {

                Owner ownerObj = new Owner();
                Owner client = ownerObj.GetOwner(Convert.ToInt32(res.ownerNumber));
                if (client == null)
                    client = new Owner();
                TableCell owner = new TableCell();
                Label ownerName = new Label();
                ownerName.Text = client.first + " " + client.last;
                owner.Controls.Add(ownerName);
                resData.Cells.Add(owner);
            }

            TableCell start = new TableCell();
            Label startDate = new Label();
            startDate.Text = res.sDate.ToString("MMM dd yyyy") + "<br />";

            start.Controls.Add(startDate);

            TableCell sep = new TableCell();
            sep.Text = "---------";

            TableCell end = new TableCell();
            end.Text = res.eDate.ToString("MMM dd yyyy");

            TableCell pets = new TableCell();

            //-------------------------------------------- can be replased with 2 linse using the db layer if you can get a list of pet object by res ID---------//
            string cmdStrResPet = "SELECT p.PET_NUMBER, p.PET_NAME FROM HVK_PET_RESERVATION pr JOIN HVK_PET p ON p.PET_NUMBER = pr.PET_PET_NUMBER WHERE pr.RES_RESERVATION_NUMBER = :RESERVATION_NUMBER";
            OracleCommand cmdResPet = new OracleCommand(cmdStrResPet, con);
            cmdResPet.Parameters.Add("RESERVATION_NUMBER", res.number);
            OracleDataAdapter daResPet = new OracleDataAdapter(cmdResPet);
            daResPet.SelectCommand = cmdResPet;
            DataSet dsResPet = new DataSet("OwnerPetDataSet");
            daResPet.Fill(dsResPet, "HVK_PET_RESERVATION");

            //----------------------------------------------------------------------------------------------------------------------------------------------


            for ( int i = 0 ; i < dsResPet.Tables[0].Rows.Count ; i++ ) {
                Label pet = new Label();
                pet.Text = dsResPet.Tables[0].Rows[i]["PET_NAME"] + "<br />";
                pets.Controls.Add(pet);
            }


            TableCell editCell = new TableCell();
            LinkButton editRes = new LinkButton();
            editRes.Text = "Edit";
            editRes.ID = "Edit" + res.number;
            editRes.CssClass = "editLink";
            editRes.Command += new CommandEventHandler(editRes_OnClick);
            editCell.Controls.Add(editRes);

            resData.Cells.Add(start);
            resData.Cells.Add(sep);
            resData.Cells.Add(end);
            resData.Cells.Add(pets);
            resData.Cells.Add(editCell);
            tblReservations.Rows.Add(resData);
        }

        public String checkVaccinations() {
            return "Up to date";
        }

        public void insertPet( Pet x ) {
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

            TableRow gender = new TableRow();
            TableCell sex = new TableCell();
            sex.Text = "<b>Sex:</b> " + petSex[x.sex];
            if ( x.breed != "" ) {
                TableCell breed = new TableCell();
                breed.Text = "<b>Breed:</b> " + x.breed;
                gender.Cells.Add(breed);
            }
            gender.Cells.Add(sex);

            TableRow vac = new TableRow();
            TableCell vacCell = new TableCell();
            vacCell.Text = "<b>Vaccinations:</b> " + checkVaccinations();
            vac.Cells.Add(vacCell);

            TableRow edit = new TableRow();
            TableCell editCell = new TableCell();
            LinkButton btnEdit = new LinkButton();
            btnEdit.Text = "Edit";
            btnEdit.CssClass = "editLink";
            btnEdit.ID = "UsePet" + x.number;
            btnEdit.Click += new EventHandler(editPet_OnClick);
            editCell.Controls.Add(btnEdit);

            edit.Cells.Add(editCell);

            table.Rows.Add(nameRow);
            table.Rows.Add(gender);
            table.Rows.Add(vac);
            table.Rows.Add(edit);

            cell.Controls.Add(table);
            row.Cells.Add(cell);
            pnlPets.Controls.Add(row);

            Label lblLine = new Label();
            lblLine.Text = "<hr />";
            pnlPets.Controls.Add(lblLine);
        }


        protected void insertClient( Owner own ) {
            TableRow ownData = new TableRow();
            
                TableCell owner = new TableCell();
                LinkButton ownerName = new LinkButton();
                ownerName.Text = own.first + " " + own.last;
                ownerName.ID = "Own" + own.number;
                ownerName.CssClass = "editLink";
                ownerName.Command += new CommandEventHandler(viewOwn_OnClick);
//                ownerName.PostBackUrl = "~/ManageCustomer.aspx";    ////////////////////////////////////////////////
                owner.Controls.Add(ownerName);
                ownData.Cells.Add(owner);

            TableCell email = new TableCell();
            Label lblEmail = new Label();
            lblEmail.Text = own.email;
            email.Controls.Add(lblEmail);
            ownData.Cells.Add(email);

            TableCell street = new TableCell();
            Label lblstreet = new Label();
            lblstreet.Text = own.street;
            street.Controls.Add(lblstreet);

            Pet petobj = new Pet();
            List<Pet> petList = petobj.listPets(own.number);

            TableCell pets = new TableCell();
            Label lblPets = new Label();
            lblPets.Text = Convert.ToString(petList.Count);
            pets.Controls.Add(lblPets);

            ownData.Cells.Add(owner);
            ownData.Cells.Add(email);
            ownData.Cells.Add(street);
            ownData.Cells.Add(pets);
            tblClients.Rows.Add(ownData);
        }


        protected void editPet_OnClick( object sender, EventArgs _args ) {
            String btnId = (((LinkButton)sender).ID);
            Session["PET_NUMBER"] = btnId.Substring(6, btnId.Length - 6);
            Session["OWNER_NUMBER"] = client.number;
            Response.Redirect("~/ManagePet.aspx");
        }
        protected void editRes_OnClick( object sender, EventArgs _args ) {
            String btnId = (((LinkButton)sender).ID);
            int resNumber = Convert.ToInt16(btnId.Substring(4));
            Session["RESERVATION_NUMBER"] = resNumber;
            Response.Redirect("~/ManageReservation.aspx");
        }
        protected void editOwn_OnClick( object sender, EventArgs _args ) {
            String btnId = (((LinkButton)sender).ID);
            Session["OWNER_NUMBER"] = btnId.Substring(3, btnId.Length - 3);
            Response.Redirect("~/ManageCustomer.aspx");
        }

        protected void viewOwn_OnClick(object sender, EventArgs _args)
        {
            String btnId = (((LinkButton)sender).ID);
            Session["MANAGE_NUMBER"] = btnId.Substring(3, btnId.Length - 3);
            Response.Redirect("~/ManageClientHome.aspx");
        }

        protected void btnNewRes_Click( object sender, EventArgs e ) {
            Session.Remove("RESERVATION_NUMBER");
            Session.Remove("OWNER_NUMBER");
            Response.Redirect("~/ManageReservation.aspx");
        }

        protected void btnNewClient_Click(object sender, EventArgs e)
        {
            Session.Remove("RESERVATION_NUMBER");
            Session.Remove("OWNER_NUMBER");
            Response.Redirect("~/ManageCustomer.aspx");
        }

        protected void btnAddPet_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManagePet.aspx");
        }

        protected void editCusLink_Click(object sender, EventArgs e)
        {
            String btnId = (((LinkButton)sender).ID);
            Session["OWNER_NUMBER"] = client.number;
            Response.Redirect("~/ManageCustomer.aspx");
        }
    }

}