﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HawkeyehvkBLL;
namespace AYadollahibastani_C40A02
{
    public partial class owners : System.Web.UI.Page
    {
        Owner owner;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PetID"] = null;
            //Session["SelectedPet"] = null;
            editDisplay.Visible = false;
            viewPet.Visible = false;  
            gdOwner.GridLines = GridLines.None;
        
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            Application master = Master as Application;
            owner = master.owner;

        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
     
            Session["SelectedOwner"] = new Owner();
            Response.Redirect("manageCustomer.aspx"); 
        }

        protected void btnViewPet_Click(object sender, EventArgs e)
        {

            if (viewPet.Visible)
            {
                viewPet.Visible = false;
            }
            else
            {
                viewPet.Visible = true;
            }
        }


     
        protected void btnDetail_Click(object sender, EventArgs e)
        {
            editDisplay.Visible = true;
            viewPet.Visible = true;
        }

        protected void gdOwner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var ownerNum = Convert.ToInt16(e.CommandArgument);
            Owner newOwner = new Owner();
            newOwner = Owner.getOwner(ownerNum);
            Session["SelectedOwner"] = newOwner;
            viewPet.Visible = true; 
            editDisplay.Visible = true;

        }
        protected void btnBookNewReservation_Click(object sender, EventArgs e)
        {
            Session["selectedOwner"] = Owner.getFullOwner(txtEmail.Text);//using owner email get phone number
            Response.Redirect("manageReservation.aspx");
        }
    }
}