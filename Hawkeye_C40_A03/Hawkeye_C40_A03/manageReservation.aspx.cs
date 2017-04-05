﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HawkeyehvkBLL;
namespace AYadollahibastani_C40A02
{
    public partial class manageReservation : System.Web.UI.Page
    {
        Owner newOwner = null ;
        enum UserType
        {
            Clerk,
            Owner
        };
        protected void Page_PreRender(object sender, EventArgs e)
        {
            newOwner = ((Application)Master).owner;
            Reservation resOnPage = new Reservation();
            //Switch To Clerk - Default : Customer
            if ((UserType)Session["UserType"] == UserType.Owner)
            {
                ddlChooseRun.Visible = false;
                lblChooseRun.Visible = false;
                if (Session["selectedReservation"] != null)
                {
                    bool resFound = false;
                    int resNum = Convert.ToInt32(Session["selectedReservation"]);
                    newOwner.reservationList.ForEach(delegate (Reservation res)
                    {
                        if (resNum == res.reservationNumber)
                        {
                            resOnPage = res;
                            resFound = true;
                        }
                    });
                    if (!resFound)
                    {
                        //Error, invalid reservation number passed....

                    }
                    else {
                        pageTitle.InnerText = "Editing Reservation";
                    }
                    loadData(resOnPage, ((Application)Master).owner);
                    
                }
                else {//new Reservation, owner
                    pageTitle.InnerText = "New Reservation";
                }
            }
            else {// clerk
                ddlChooseRun.Visible = true;
                lblChooseRun.Visible = true;
                if (Session["selectedReservation"] != null)// edit reservation / clerk
                {
                    Reservation curRes = new Reservation();
                    int resNum = Convert.ToInt32(Session["selectedReservation"]);
                    
                    List<Reservation> resList = Reservation.listReservations(Convert.ToInt32(Session["selectedOwner"]));

                    resList.ForEach(delegate (Reservation res) {
                        if (res.reservationNumber == resNum) {
                            curRes=res;
                        }
                    });
                    if (curRes != null)
                    {
                        
                        Owner own = curRes.owner;
                        loadData(curRes, own);
                        pageTitle.InnerText = "Editing Reservation for " + own.firstName + " " + own.lastName;
                    }
                    else {
                        //Error, invalid reservation number or owner number passed....

                    }
                    //pull res from DB
                }
                else { // new Reservation, clerk

                    Owner own = Owner.getOwner(Convert.ToInt32(Session["selectedOwner"]));
                    pageTitle.InnerText = "New Reservation for "+own.firstName+" "+own.lastName;

                }
            }
            if (!IsPostBack) {
                changeState(false);
            }
            
        }

  

        protected void changeState(Boolean State)
        {
            ((TextBox)UCstartDate.FindControl("txtDate")).Enabled = State;
            ((TextBox)UCendDate.FindControl("txtDate")).Enabled = State;
            reservationPanel.Enabled = State;
        }

        protected void loadData(Reservation reservationOnPage,Owner owner)
        {
            
                try
                {
                    ((TextBox)UCstartDate.FindControl("txtDate")).Text = reservationOnPage.startDate.ToShortDateString();
                    ((TextBox)UCendDate.FindControl("txtDate")).Text = reservationOnPage.endDate.ToShortDateString();
                List<Pet> petList = new List<Pet>();
                reservationOnPage.petReservationList.ForEach(delegate(PetReservation pres) {
                    petList.Add(pres.pet);
                });
                petList.ForEach(delegate(Pet pet) {
                    ddlPetsInRes.Items.Add(new ListItem(pet.name,pet.petNumber.ToString()));
                });
                bool inList;
                owner.petList.ForEach(delegate (Pet pet) {
                    inList = false;// check if pet is already listed in other ddl
                    petList.ForEach(delegate (Pet petInDdl) {
                        if (petInDdl.name == pet.name) {
                            inList = true;
                        }
                    });
                    if (!inList) {// if pet not already listed add the the other ddl
                        ddlAddPet.Items.Add(new ListItem(pet.name, pet.petNumber.ToString()));
                    }
                });

                // now populate the first pet reservations data
                reservationOnPage.petReservationList[0].serviceList.ForEach(delegate(ReservedService serv) {
                    if (serv.service.descripion == "Walk") {
                        chWalk.Checked = true;
                    }
                    else if (serv.service.descripion == "Playtime") {
                        chWalk.Checked = true;
                    }
                });
                }
                catch
                {
                    Console.Write("Error - Exception catched => load file => manage reservation ! ");
                }
            
        }//load info into fields 



        protected void btnEdit_Click1(object sender, EventArgs e)
        {
            changeState(true);
            btnBook.Text = "Save";
        }
    }

}