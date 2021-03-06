﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HawkeyehvkBLL;

namespace AYadollahibastani_C40A02
{
    public partial class Login : System.Web.UI.Page {

        Owner owner;
        protected void Page_Load(object sender, EventArgs e) {
        }
        private void invalidInfo() {
            txtPass.BorderColor = Color.DarkRed;
            txtPass.BorderWidth = Unit.Parse("2px");
            txtUsername.BorderColor = Color.DarkRed;
            txtUsername.BorderWidth = Unit.Parse("2px");
            lblErrors.Text = "&nbspInvalid Username or Password.&nbsp";
            lblErrors.BackColor = Color.DarkRed;
        }
        enum UserType {
            Clerk,
            Owner,
            NewOwner
        };
        private void setUserType(String type) {
            if (type.ToUpper()=="CLERK") {
                Session["UserType"] = UserType.Clerk;
            }
            else if(type.ToUpper() == "OWNER"){
                Session["UserType"] = UserType.Owner;
            }
            else
            {
                Session["UserType"] = UserType.NewOwner;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e) {
            string email = txtUsername.Text;
            string pass = txtPass.Text;
            if (email.ToUpper() == "REED@HVK.CA") {
                if (pass=="1234") {
                    //set session for clerk
                    setUserType("clerk");

                    Owner newOwner = new Owner();
                    newOwner.firstName = "Jim";
                    newOwner.lastName = "Reed";
                    newOwner.email = "Reed@hvk.ca";
                    newOwner.emergencyFirstName = "steve";
                    newOwner.emergencyLastName = "jobs";
                    newOwner.emergencyPhone = "4324554555";
                    newOwner.address.city = "Chelsea";
                    newOwner.address.province = "QC";
                    newOwner.address.street = "123 scott road";
                    newOwner.address.postalCode = "J9B 2P8";
                    newOwner.phoneNumber = "4385566065";
                    Session["owner"] = newOwner;
                    Session["PetID"] = null;
                    Session["SelectedPet"] = null;
                    // the sessions with objects are loaded from the master page used for application pages
                    Response.Redirect("home.aspx");
                }
                else {
                    //invalid info
                    invalidInfo();
                }
            }
            else {
                owner = Owner.getFullOwner(email);
                if (owner == null)
                {
                    invalidInfo();
                } else
                {
                    setUserType("owner");
                    Session["owner"] = owner;
                    Session["PetID"] = null;
                    Session["SelectedPet"] = null;
                    Response.Redirect("home.aspx");
                }
            }
           
        }

        protected void btnBookNow_Click(object sender, EventArgs e)
        {
            setUserType("NewOwner");
            Session["owner"] = null;
            Session["PetID"] = null;
            Server.Transfer("~/ManageCustomer.aspx");
        }
        
    }
    enum UserType
    {
        Clerk,
        Owner
    }
}