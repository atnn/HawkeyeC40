﻿using Hvk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AYadollahibastani_C40A02
{
    public partial class Login : System.Web.UI.Page {
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
            Owner
        };
        private void setUserType(String type) {
            if (type.ToUpper()=="CLERK") {
                Session["UserType"] = UserType.Clerk;
            }
            else {
                Session["UserType"] = UserType.Owner;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e) {
            string email = txtUsername.Text;
            string pass = txtPass.Text;
            if (email.ToUpper() == "REED@HVK.CA") {
                if (pass=="1234") {
                    //set session for clerk
                    setUserType("clerk");
                    // the sessions with objects are loaded from the master page used for application pages
                    Response.Redirect("home.aspx");
                }
                else {
                    //invalid info
                    invalidInfo();
                }
            }
            else {
                DataSourceSelectArguments args = new DataSourceSelectArguments();
                DataView view = (DataView)dsOwnerEmails.Select(args);
                DataTable dt = view.ToTable();
                int columnNumber = 0;
                bool isTrue = false;
                // checks all emails in database for the entered email
                for (int i = 0; i < dt.Rows.Count; i++) {
                    if (email == (dt.Rows[i][columnNumber].ToString())) {
                        isTrue = true;
                    }
                }
                if (isTrue) {
                    //set sessions for that owner
                    setUserType("owner");
                    // the sessions with objects are loaded from the master page used for application pages
                    Response.Redirect("home.aspx");
                }
                else {
                    //invalid info
                    invalidInfo();
                }
            }
        }
    }
}