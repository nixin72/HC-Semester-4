using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HulkHvkA03;
using pdumaresq_B42_A01;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace HulkHvkA03
{
    public partial class Home : System.Web.UI.Page
    {
        //    List<Reservation> reservations = new List<Reservation>();
        //    List<Pet> petList = new List<Pet>();
        //    List<Owner> owners = new List<Owner>();
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection con;

        IDictionary<char, String> petSizes = new Dictionary<char, String>();
        IDictionary<char, String> petSex = new Dictionary<char, String>();

        bool isEmployee;
        Owner client;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(conString);
            petSizes['L'] = "Large";
            petSizes['M'] = "Medium";
            petSizes['S'] = "Small";
            petSex['M'] = "Male";
            petSex['F'] = "Female";

            isEmployee = (Session["isEmployee"] != null) ? (bool)Session["isEmployee"] : true;
            if (isEmployee)
            {
                homeLeftPanel.Visible = false;
                pnlClerk.Visible = true;

                thcCustomer.Visible = true;
                reservationsAndClerk.CssClass = "resAndClerk";

                //foreach (var x in reservations) {
                //    addReservations(x);
                //}
            }
            else
            {
                client = (Owner)Session["currentClient"];
                homeLeftPanel.Visible = true;
                pnlClerk.Visible = false;

                lblCusFname.Text = "First name: " + client.first;
                lblCusLname.Text = "Last name: " + client.last;

                string cmdStrPet = "SELECT PET_NUMBER, PET_NAME, PET_GENDER, PET_FIXED FROM HVK_PET WHERE OWN_OWNER_NUMBER = :OWNER_NUMBER";
                OracleCommand cmdPet = new OracleCommand(cmdStrPet, con);
                cmdPet.Parameters.Add("OWNER_NUMBER", client.number);
                OracleDataAdapter daPet = new OracleDataAdapter(cmdPet);
                daPet.SelectCommand = cmdPet;
                DataSet dsPet = new DataSet("OwnerPetDataSet");
                daPet.Fill(dsPet, "HVK_PET");


                Pet varPet;
                bool fix = false;
                for (int i = 0; i < dsPet.Tables[0].Rows.Count; i++)
                {
                    if (dsPet.Tables[0].Rows[i]["PET_FIXED"].ToString() == "T") {
                        fix = true;
                    }
                    varPet = new Pet(Convert.ToInt32(dsPet.Tables[0].Rows[i]["PET_NUMBER"]), dsPet.Tables[0].Rows[i]["PET_NAME"].ToString(), Convert.ToChar(dsPet.Tables[0].Rows[i]["PET_GENDER"]), fix);
                    insertPet(varPet);
                }

                //string cmdStrRes = "SELECT DISTINCT r.RESERVATION_NUMBER, r.reservation_start_date, r.reservation_end_date FROM hvk_reservation r LEFT JOIN hvk_pet_reservation pr  ON pr.res_reservation_number = r.reservation_number LEFT JOIN hvk_pet p  ON pr.pet_pet_number = p.pet_number WHERE p.own_owner_number = &own_number; ";
                //OracleCommand cmdRes = new OracleCommand(cmdStrRes, con);
                //cmdRes.Parameters.Add("OWNER_NUMBER", client.number);
                //OracleDataAdapter daRes = new OracleDataAdapter(cmdRes);
                //daRes.SelectCommand = cmdRes;
                //DataSet dsRes = new DataSet("ReservationDataSet");
                //daPet.Fill(dsRes, "HVK_Reservation");
                //Reservation varRes;
                //for (int i = 0; i < dsRes.Tables[0].Rows.Count; i++)
                //{
                //    varRes = new Reservation(Convert.ToInt32(dsRes.Tables[0].Rows[i]["RESERVATION_NUMBER"])
                //        , Convert.ToDateTime(dsRes.Tables[0].Rows[i]["reservation_start_date"])
                //        , Convert.ToDateTime(dsRes.Tables[0].Rows[i]["reservation_end_date"]));
                //    addReservations(varRes);
                //}
            }
        }



            //        private void addReservations(Reservation res)
            //        {
            //            TableRow resData = new TableRow();

            //            if (isEmployee)
            //            {
            //                //TableCell owner = new TableCell();
            //                //Label ownerName = new Label();

            //                //ownerName.Text = owners[owners.IndexOf(owners.Find(o => o.reservations.Any(r => r.number == res.number)))].ToString();

            //                //owner.Controls.Add(ownerName);
            //                //resData.Cells.Add(owner);
            //            }

            //            TableCell start = new TableCell();
            //            Label startDate = new Label();
            //            startDate.Text = res.sDate.ToString("MMM dd yyyy") + "<br />";
            //            LinkButton editPet = new LinkButton();
            //            editPet.Text = "Edit";
            //            editPet.PostBackUrl = "~/ManageReservations.aspx";

            //            start.Controls.Add(startDate);
            //            start.Controls.Add(editPet);

            //            TableCell sep = new TableCell();
            //            sep.Text = "---------";

            //            TableCell end = new TableCell();
            //            end.Text = res.eDate.ToString("MMM dd yyyy");

            //            TableCell pets = new TableCell();


            //            string cmdStrResPet = "SELECT FROM HVK_PET_RESERVATION WHERE RES_RESERVATION_NUMBER = :RESERVATION_NUMBER";
            //            OracleCommand cmdResPet = new OracleCommand(cmdStrResPet, con);
            //            cmdResPet.Parameters.Add("OWNER_NUMBER", client.number);
            //            OracleDataAdapter daResPet = new OracleDataAdapter(cmdResPet);
            //            daResPet.SelectCommand = cmdResPet;
            //            DataSet dsResPet = new DataSet("OwnerPetDataSet");
            //            daResPet.Fill(dsResPet, "HVK_PET_RESERVATION");

            //            foreach (var x in petList)
            //            {
            //                LinkButton pet = new LinkButton();
            //                pet.PostBackUrl = "~/ManagePets.aspx";
            //                pet.Text = x.name + "<br />";

            //                pets.Controls.Add(pet);
            //            }

            //            resData.Cells.Add(start);
            //            resData.Cells.Add(sep);
            //            resData.Cells.Add(end);
            //            resData.Cells.Add(pets);
            //            tblReservations.Rows.Add(resData);

            //            TableRow div = new TableRow();
            //            TableCell divCell = new TableCell();
            //            divCell.Text = "";
            //            div.Cells.Add(divCell);
            //            tblReservations.Rows.Add(div);
            //        }

            //        public String checkVaccinations()
            //        {
            //            return "Up to date";
            //        }

        public void insertPet(Pet x)
        {
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
            sex.Text = "Sex: " + petSex[x.sex];
            gender.Cells.Add(sex);

            table.Rows.Add(nameRow);
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
