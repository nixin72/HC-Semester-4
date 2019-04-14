using HulkHvkBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HVKA03 {

    public enum viewingMode { insert, update, findOwner, delete }

    public partial class ManageReservation:System.Web.UI.Page {
        bool isChanged;
        viewingMode state;
        bool isEmployee;
        List<String> Errors = new List<String>();

        protected void Page_PreRender( object sender, EventArgs e ) {
            Errors.ForEach(err => {
                errMsgs.Text += err + "<br />";
            });
            Errors = new List<String>();
            isEmployee = (Session["UserType"] != null) ? (userType)Session["UserType"] == userType.Clerk : true;
            Reservation res = new Reservation();
            if ( Session["RESERVATION_NUMBER"] == null ) {
                if ( isEmployee ? Session["OWNER_NUMBER"] == null : Session["OWNER"] == null ) {
                    state = viewingMode.findOwner;
                    loadOwners();
                } else {
                    if ( isEmployee ) {
                        loadJustPets();
                        state = viewingMode.insert;
                        
                    } else {
                        loadJustPets();
                        state = viewingMode.insert;
                    }
                }
            } else {
                if ( res.ListReservations().Any(r => r.number == Convert.ToInt16(Session["RESERVATION_NUMBER"])) ) {
                    loadFullLists();
                    state = viewingMode.update;
                } else {
                    Response.Redirect("~/Home.aspx");
                }

            }

            switch ( state ) {
                case viewingMode.findOwner: {
                    pets.Visible = false;
                    startEndInfo.Visible = false;
                    btnCancelRes.Visible = false;
                    btnMakeReservation.Visible = false;
                    btnStartReservation.Visible = false;
                    btnUpdateReservation.Visible = false;
                }
                break;
                case viewingMode.insert: {
                    pickOwner.Visible = false;
                    btnMakeReservation.Visible = true;
                    btnUpdateReservation.Visible = false;
                    pets.Visible = true;
                    startEndInfo.Visible = true;
                }
                break;
                case viewingMode.update: {
                    pickOwner.Visible = false;
                    btnMakeReservation.Visible = false;
                    btnUpdateReservation.Visible = true;
                    pets.Visible = true;
                    startEndInfo.Visible = true;
                    btnCancelRes.Visible = true;
                }
                break;
            }
        }

        private void loadOwners() {
            Owner own = new Owner();
            own.ListOwners().ForEach(o => {
                ListItem temp = new ListItem(o.ToString(), o.number.ToString());
                ddlPickOwner.Items.Add(temp);
            });
        }

        private void loadJustPets() {
            ddlPickOwner.Visible = false;
            Pet p = new Pet();
            List<Pet> pets = p.listPets(isEmployee ? Convert.ToInt16(Session["OWNER_NUMBER"]) : ((Owner)Session["OWNER"]).number);
            testNewFill(pets);
        }

        private void loadFullLists() {
            int resNum = Convert.ToInt16(Session["RESERVATION_NUMBER"]);

            Reservation res = new Reservation();
            Reservation r = res.ListReservations().Find(rr => rr.number == resNum);
            Pet p = new Pet();
            Service ser = new Service();
            PetReservation pr = new PetReservation();

            List<Pet> pets = p.listPets(Convert.ToInt16(r.ownerNumber));
            testSerNewFill(pets, r, pr.ListPetReservations(), ser.ListServices());

            txtStartDate.Text = r.sDate.ToString("MMM/dd/yyyy");
            txtEndDate.Text = r.eDate.ToString("MMM/dd/yyyy");
            ddlPickOwner.Visible = false;
        }

        private void testNewFill( List<Pet> pets ) {
            Service sers = new Service();
            Table petTable = new Table();
            TableRow allPetsRow = new TableRow();
            TableCell aPet = new TableCell();

            int currPet = 0;
            pets.ForEach(p => {

                switch ( currPet ) {
                    case 0: {
                        pet1.Visible = true;
                        pet1.PetName = p.name;
                        pet1.Included = true;
                        pet1.Walking = false;
                        pet1.Playtime = false;
                    }
                    break;
                    case 1: {
                        pet2.Visible = true;
                        pet2.PetName = p.name;
                        pet2.Included = true;
                        pet2.Walking = false;
                        pet2.Playtime = false;
                    }
                    break;
                    case 2: {
                        pet3.Visible = true;
                        pet3.PetName = p.name;
                        pet3.Included = true;
                        pet3.Walking = false;
                        pet3.Playtime = false;
                    }
                    break;
                    case 3: {
                        pet4.Visible = true;
                        pet4.PetName = p.name;
                        pet4.Included = true;
                        pet4.Walking = false;
                        pet4.Playtime = false;
                    }
                    break;
                }
                currPet++;
            });
        }

        private void testSerNewFill( List<Pet> _pets, Reservation _res, List<PetReservation> _petRes, List<Service> _ser ) {
            List<PetReservation> petRes = _petRes.FindAll(rr => rr.reservationNum == _res.number);

            Service sers = new Service();
            List<Service> basicServices = sers.ListBasicService().FindAll(s => s.number != 1);

            int currPet = 0;
            _pets.ForEach(p => {
                PetReservation thisPetRes = petRes.Find(pr => pr.petNum == p.number);
                List<Service> thisSerList = thisPetRes != null ? _ser.FindAll(prs => prs.petResNumber == thisPetRes.petResNum) : null;
                thisSerList = thisSerList != null ? thisSerList.Count < 2 ? null : thisSerList : null;
                switch ( currPet ) {
                    case 0: {
                        pet1.Visible = true;
                        pet1.PetName = p.name;
                        pet1.Included = thisPetRes != null;
                        pet1.Walking = thisSerList == null ? false : thisSerList.Any(s => s.number == 2);
                        pet1.Playtime = thisSerList == null ? false : thisSerList.Any(s => s.number == 5);
                    }
                    break;
                    case 1: {
                        pet2.Visible = true;
                        pet2.PetName = p.name;
                        pet2.Included = thisPetRes != null;
                        pet2.Walking = thisSerList == null ? false : thisSerList.Any(s => s.number == 2);
                        pet2.Playtime = thisSerList == null ? false : thisSerList.Any(s => s.number == 5);
                    }
                    break;
                    case 2: {
                        pet3.Visible = true;
                        pet3.PetName = p.name;
                        pet3.Included = thisPetRes != null;
                        pet3.Walking = thisSerList == null ? false : thisSerList.Any(s => s.number == 2);
                        pet3.Playtime = thisSerList == null ? false : thisSerList.Any(s => s.number == 5);
                    }
                    break;
                    case 3: {
                        pet4.Visible = true;
                        pet4.PetName = p.name;
                        pet4.Included = thisPetRes != null;
                        pet4.Walking = thisSerList == null ? false : thisSerList.Any(s => s.number == 2);
                        pet4.Playtime = thisSerList == null ? false : thisSerList.Any(s => s.number == 5);
                    }
                    break;
                }
                currPet++;
            });
        }

        /*
        private void FillPets( List<Pet> _pets, Reservation _res, List<PetReservation> _petRes, List<Service> _ser ) {
            List<PetReservation> petRes = _petRes.FindAll(rr => rr.reservationNum == _res.number);

            Service sers = new Service();
            List<Service> basicServices = sers.ListBasicService().FindAll(s => s.number != 1);

            Table petTable = new Table();
            TableRow allPetsRow = new TableRow();
            TableCell aPet = new TableCell();
            int z = 0;
            _pets.ForEach(p => {
                PetReservation thisPetRes = petRes.Find(pr => pr.petNum == p.number);
                List<Service> thisSerList = thisPetRes != null ? _ser.FindAll(prs => prs.petResNumber == thisPetRes.petResNum) : null;

                Table pet = new Table();

                TableRow top = new TableRow();
                TableCell petName = new TableCell();
                Label lblPetName = new Label();
                lblPetName.Text = p.name;
                lblPetName.CssClass = "petName";

                CheckBox include = new CheckBox();
                include.ID = "chb" + p.number.ToString();
                include.AutoPostBack = false;
                include.CausesValidation = false;
                include.Checked = thisPetRes != null;
                include.Text = "Include";

                petName.Controls.Add(lblPetName);
                petName.Controls.Add(include);

                top.Cells.Add(petName);

                TableRow bottom = new TableRow();
                bottom.ID = "btm" + p.number.ToString();

                TableCell services = new TableCell();
                CheckBoxList cblServices = new CheckBoxList();
                cblServices.ID = "cbl" + p.number.ToString();

                for ( int q = 0 ; q < basicServices.Count ; q++ ) {
                    cblServices.Items.Add(basicServices[q].desc);
                    cblServices.Items[0].Selected = false;
                    if ( thisSerList != null ) {
                        if ( thisSerList.Find(s => s.number == basicServices[q].number) != null ) {
                            cblServices.Items[0].Selected = true;

                        }
                    }
                }

                if ( isEmployee ) {
                    CheckBoxList cblVaccinations = new CheckBoxList();
                    cblVaccinations.ID = "cblVacc" + p.number;
                    p.AddVaccinations();
                    p.vaccinations.ForEach(v => {
                        cblVaccinations.Items.Add(new ListItem(v.name + v.expiryDate, v.number.ToString()));
                    });

                    services.Controls.Add(cblVaccinations);
                }

                services.Controls.Add(cblServices);

                bottom.Cells.Add(services);

                pet.Rows.Add(top);
                pet.Rows.Add(bottom);

                aPet.Controls.Add(pet);
                allPetsRow.Cells.Add(aPet);
                z++;
            });

            petTable.Rows.Add(allPetsRow);
            allPets.Controls.Add(petTable);
        }
        */

        protected void ddlPickOwner_SelectedIndexChanged( object sender, EventArgs e ) {
            pickOwner.Controls.Clear();
            Session["OWNER_NUMBER"] = ddlPickOwner.SelectedValue;
            Pet p = new Pet();
            testNewFill(p.listPets(Convert.ToInt16(Session["OWNER_NUMBER"])));
            isChanged = true;
            Session["UserType"] = userType.Clerk;
            state = viewingMode.insert;
        }

        protected void btnMakeReservation_Click( object sender, EventArgs e ) {
            Pet p = new Pet();
            Service s = new Service();
            PetReservation pr = new PetReservation();
            Reservation r = new Reservation();
            List<Pet> pets = p.listPets(((userType)Session["UserType"] == userType.Clerk) ? Convert.ToInt16(Session["OWNER_NUMBER"]) : ((Owner)Session["OWNER"]).number);

            int resNumber = 0;
            int currPet = 0;
            for ( int x = 0 ; x < 4 ; x++ ) {
                
                switch ( currPet ) {
                    case 0: {
                        Pet p2 = pets.Find(pp => pp.name == pet1.PetName && pp.ownerNumber == (((userType)Session["UserType"] == userType.Clerk) ? Convert.ToInt16(Session["OWNER_NUMBER"]) : ((Owner)Session["OWNER"]).number));
                        if ( p2 != null ) {
                            resNumber = r.AddReservation(p2.number, DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text))[1];
                            if ( resNumber < 0 )
                                break;
                            int petResNum = pr.Add(p2.number, resNumber)[1];
                            s.Add(petResNum, 1);
                            if ( pet1.Walking )
                                s.Add(petResNum, 2);
                            if ( pet1.Playtime )
                                s.Add(petResNum, 5);
                        }
                    }
                    break;
                    case 1: {
                        Pet p2 = pets.Find(pp => pp.name == pet2.PetName && pp.ownerNumber == (((userType)Session["UserType"] == userType.Clerk) ? Convert.ToInt16(Session["OWNER_NUMBER"]) : ((Owner)Session["OWNER"]).number));
                        try {
                            if ( pet2.Included ) {
                                if ( p2 != null ) {
                                    int petResNum = pr.Add(p2.number, resNumber)[1];
                                    s.Add(petResNum, 1);
                                    if ( pet2.Walking )
                                        s.Add(petResNum, 2);
                                    if ( pet2.Playtime )
                                        s.Add(petResNum, 5);
                                }
                            }
                        } catch {
                            Errors.Add("Your second pet could not be added to the reservation.");
                        }
                    }
                    break;
                    case 2: {
                        Pet p2 = pets.Find(pp => pp.name == pet3.PetName && pp.ownerNumber == (((userType)Session["UserType"] == userType.Clerk) ? Convert.ToInt16(Session["OWNER_NUMBER"]) : ((Owner)Session["OWNER"]).number));
                        try {
                            if ( pet3.Included ) {
                                if ( p2 != null ) {
                                    int petResNum = pr.Add(p2.number, resNumber)[1];
                                    s.Add(petResNum, 1);
                                    if ( pet3.Walking )
                                        s.Add(petResNum, 2);
                                    if ( pet3.Playtime )
                                        s.Add(petResNum, 5);
                                }
                            }
                        } catch {
                            Errors.Add("Your third pet could not be added to the reservation.");
                        }
                    }
                    break;
                    case 3: {
                        Pet p2 = pets.Find(pp => pp.name == pet4.PetName && pp.ownerNumber == (((userType)Session["UserType"] == userType.Clerk) ? Convert.ToInt16(Session["OWNER_NUMBER"]) : ((Owner)Session["OWNER"]).number));
                        try {
                            if ( pet4.Included ) {
                                if ( p2 != null ) {
                                    int petResNum = pr.Add(p2.number, resNumber)[1];
                                    s.Add(petResNum, 1);
                                    if ( pet4.Walking )
                                        s.Add(petResNum, 2);
                                    if ( pet4.Playtime )
                                        s.Add(petResNum, 5);
                                }
                            }
                        } catch {
                            Errors.Add("Your fourth pet could not be added to the reservation.");
                        }
                    }
                    break;
                }

                


                currPet++;
            }
            if ( resNumber > 0 ) {
                Session["RESERVATION_NUMBER"] = resNumber;
                state = viewingMode.update;
            } else {
                Errors.Add("The reservation could not be added.");
                state = viewingMode.insert;
            }
        }

        protected void btnUpdateReservation_Click( object sender, EventArgs e ) {
            Pet p = new Pet();
            Service s = new Service();
            PetReservation pr = new PetReservation();
            Reservation r = new Reservation();

            int resNumber = Convert.ToInt16(Session["RESERVATION_NUMBER"]);

            Reservation curr = r.ListReservations().Find(rr => rr.number == resNumber);
            List<Pet> pets = p.listPets((int)curr.ownerNumber);

            List<PetReservation> petRes = pr.ListPetReservations().FindAll(pr2 => pr2.reservationNum == resNumber);
            List<Service> prs = s.ListServices().FindAll(ss => petRes.Any(pr2 => pr2.petResNum == s.petResNumber));
            r.ChangeReservation(curr.number, DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text));

            int currPet = 0;
            for ( int x = 0 ; x < pets.Count ; x++ ) {
                PetReservation thisPetRes = petRes.Find(pr2 => pr2.petNum == pets[x].number);
                List<Service> thisSerList = thisPetRes != null ? s.ListServices().FindAll(prs2 => prs2.petResNumber == thisPetRes.petResNum) : null;

                switch ( currPet ) {
                    case 0: {
                        Pet p2 = pets.Find(pp => pp.name == pet1.PetName && pp.ownerNumber == curr.ownerNumber);
                        if ( p2 != null ) {
                            if ( thisPetRes != null ) {
                                if ( pet1.Included == false ) {
                                    pr.RemovePetFromRes(p2.number, resNumber);
                                } else {
                                    if ( thisSerList.Any(q => q.number == 2) ) {
                                        if ( !pet1.Walking )
                                            s.DeleteServ(thisPetRes.petResNum, 2);
                                    } else {
                                        if ( pet1.Walking )
                                            s.Add(thisPetRes.petResNum, 2);
                                    }

                                    if ( thisSerList.Any(q => q.number == 5) ) {
                                        if ( !pet1.Playtime )
                                            s.DeleteServ(thisPetRes.petResNum, 5);
                                    } else {
                                        if ( pet1.Playtime )
                                            s.Add(thisPetRes.petResNum, 5);
                                    }
                                }
                            } else {
                                if ( pet1.Included ) {
                                    int petResNum = pr.Add(p2.number, resNumber)[1];
                                    s.Add(petResNum, 1);
                                    if ( pet1.Walking )
                                        s.Add(petResNum, 2);
                                    if ( pet1.Playtime )
                                        s.Add(petResNum, 5);
                                }

                            }
                        }

                    }
                    break;
                    case 1: {
                        Pet p2 = pets.Find(pp => pp.name == pet2.PetName && pp.ownerNumber == curr.ownerNumber);
                        if ( p2 != null ) {
                            if ( thisPetRes != null ) {
                                if ( pet2.Included == false ) {
                                    pr.RemovePetFromRes(p2.number, resNumber);
                                } else {
                                    if ( thisSerList.Any(q => q.number == 2) ) {
                                        if ( !pet2.Walking )
                                            s.DeleteServ(thisPetRes.petResNum, 2);
                                    } else {
                                        if ( pet2.Walking )
                                            s.Add(thisPetRes.petResNum, 2);
                                    }

                                    if ( thisSerList.Any(q => q.number == 5) ) {
                                        if ( !pet2.Playtime )
                                            s.DeleteServ(thisPetRes.petResNum, 5);
                                    } else {
                                        if ( pet2.Playtime )
                                            s.Add(thisPetRes.petResNum, 5);
                                    }
                                }
                            } else {
                                int petResNum = pr.Add(p2.number, resNumber)[1];
                                s.Add(petResNum, 1);
                                if ( pet2.Walking )
                                    s.Add(petResNum, 2);
                                if ( pet2.Playtime )
                                    s.Add(petResNum, 5);
                            }
                        }

                    }
                    break;
                    case 2: {
                        Pet p2 = pets.Find(pp => pp.name == pet3.PetName && pp.ownerNumber == curr.ownerNumber);
                        if ( p2 != null ) {
                            if ( thisPetRes != null ) {
                                if ( pet3.Included == false ) {
                                    pr.RemovePetFromRes(p2.number, resNumber);
                                } else {
                                    if ( thisSerList.Any(q => q.number == 2) ) {
                                        if ( !pet3.Walking )
                                            s.DeleteServ(thisPetRes.petResNum, 2);
                                    } else {
                                        if ( pet3.Walking )
                                            s.Add(thisPetRes.petResNum, 2);
                                    }

                                    if ( thisSerList.Any(q => q.number == 5) ) {
                                        if ( !pet3.Playtime )
                                            s.DeleteServ(thisPetRes.petResNum, 5);
                                    } else {
                                        if ( pet3.Playtime )
                                            s.Add(thisPetRes.petResNum, 5);
                                    }
                                }
                            } else {
                                int petResNum = pr.Add(p2.number, resNumber)[1];
                                s.Add(petResNum, 1);
                                if ( pet3.Walking )
                                    s.Add(petResNum, 2);
                                if ( pet3.Playtime )
                                    s.Add(petResNum, 5);
                            }
                        }


                    }
                    break;
                    case 3: {
                        Pet p2 = pets.Find(pp => pp.name == pet4.PetName && pp.ownerNumber == curr.ownerNumber);
                        if ( p2 != null ) {
                            if ( thisPetRes != null ) {
                                if ( pet4.Included == false ) {
                                    pr.RemovePetFromRes(p2.number, resNumber);
                                } else {
                                    if ( thisSerList.Any(q => q.number == 2) ) {
                                        if ( !pet4.Walking )
                                            s.DeleteServ(thisPetRes.petResNum, 2);
                                    } else {
                                        if ( pet4.Walking )
                                            s.Add(thisPetRes.petResNum, 2);
                                    }

                                    if ( thisSerList.Any(q => q.number == 5) ) {
                                        if ( !pet4.Playtime )
                                            s.DeleteServ(thisPetRes.petResNum, 5);
                                    } else {
                                        if ( pet4.Playtime )
                                            s.Add(thisPetRes.petResNum, 5);
                                    }
                                }
                            } else {
                                int petResNum = pr.Add(p2.number, resNumber)[1];
                                s.Add(petResNum, 1);
                                if ( pet4.Walking )
                                    s.Add(petResNum, 2);
                                if ( pet4.Playtime )
                                    s.Add(petResNum, 5);
                            }
                        }

                    }
                    break;
                }

                if ( resNumber < 0 ) {
                    Errors.Add("The reservation could not be added.");
                    break;
                }
                currPet++;
            }
        }

        protected void btnDeleteReservation_Click( object sender, EventArgs e ) {
            Reservation res = new Reservation();
            PetReservation petRes = new PetReservation();
            int resNumber = Convert.ToInt16(Session["RESERVATION_NUMBER"]);

            int succ = res.CancelReservation(resNumber);
            if ( succ > 0 ) {
                Response.Redirect("~/Home.aspx");
            }
        }
    }
}