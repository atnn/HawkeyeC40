﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="AYadollahibastani_C40A02.homePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="row">
            <asp:Panel ID="searchPanel" runat="server">
                <div class="form-inline search ">
                    <div class="form-group">
                    </div>
                    <div class="form-group ">
                        <input type="text" class="form-control" id="txtSearchPhone" placeholder="Phone Number " />
                        Or
    <input type="text" class="form-control" id="txtSearchEmail" placeholder="CustomerEmail" />
                        <asp:Button ID="btnSearch" CausesValidation="false" runat="server" Text="Search" CssClass="btn btn-primary" />
                        <br />

                    </div>

                </div>
            </asp:Panel>
        </div>

        <h3>Reservations</h3>
        <table class="table table-responsive">
            <thead>
                <tr>
                    <th>Select
                    </th>
                    <th>Pet Names
                    </th>
                    <th>Time in 
                    </th>
                    <th>Time out
                    </th>
                    <th>Vaccine Valid
                    </th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:CheckBox ID="chReservationSelect" runat="server" OnCheckedChanged="chReservationSelect_CheckedChanged" AutoPostBack="true" />
                    </td>
                    <td>
                        <asp:Label ID="lblPetNames" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStartTime" runat="server" Text="Time In"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEndTime" runat="server" Text="Time Out"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </td>
                    <td>

                        <asp:LinkButton ID="lbtnEdit" href="manageReservation.aspx" CssClass="btn btn-secondary" runat="server">Edit</asp:LinkButton>
                        <asp:Button ID="btnCancelReservation" runat="server" Text="Cancel" CausesValidation="false" CssClass="btn btn-danger" />

                    </td>
                    <td>
                        <asp:Button ID="btnMoreInfo" runat="server" Text="More Info" CausesValidation="false" CssClass="btn btn-primary" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox3" runat="server" />
                    </td>
                    <td>[CONTENT]
                    </td>
                    <td>[CONTENT]
                    </td>
                    <td>[CONTENT]
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox4" runat="server" />
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" href="" CssClass="btn btn-secondary" runat="server">Edit</asp:LinkButton>
                        <asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="false" CssClass="btn btn-danger" />

                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="More Info" CausesValidation="false" CssClass="btn btn-primary" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <div class="row ">
        <div class="container whiteBackground">

            <asp:Panel ID="customerPanel" runat="server">
                <div class="clientDisplay">
                    <div class="col-sm-6">
                        <h4>Notifications</h4>
                        <br />
                        <br />
                        <%--                        Content Goes Here--%>
                        <br />
                        <br />
                    </div>
                    <div class="col-sm-6">
                        <h4>Kennel Log</h4>
                        <br />
                        <br />
                        <%--                        Content Goes Here--%>
                        <br />
                        <br />
                    </div>

                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="clerkPanel">
                <div class="form-group">
                    <h4 class="subtitle">Reservation Details</h4>
                    <div class="row">
                        <div class="col-sm-6">
                            <label class="label-control col-sm-4">
                                Start Date
                            </label>
                            <input name="startDate" runat="server" id="txtStartDate" class="form-control datepicker" />
                            <div class="error_msg label-control col-sm-6 oneSixity">
                                &nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="valRequired" runat="server" ControlToValidate="txtStartDate" Display="Dynamic" ErrorMessage="Please select a start date "></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <label class="label-control col-sm-4">
                                End Date
                            </label>
                            <input name="endDate" runat="server" id="txtEndDate" class="form-control datepicker" />
                            <div class="error_msg label-control col-sm-6 oneSixity">
                                &nbsp;&nbsp;&nbsp;
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEndDate" ErrorMessage="Please select an end date"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="valEndDate" runat="server" ErrorMessage="Your end must be after your start date" ControlToValidate="txtEndDate"></asp:CustomValidator>
                            </div>

                        </div>
                        <div class="col-sm-6 center">
                            <br />

                            <br />
                            <label id="lblChooseRun" runat="server" class="label-control col-sm-4">Assigned Run</label>
                            <asp:DropDownList ID="ddlChooseRun" runat="server" CssClass="form-control short"></asp:DropDownList>


                            <div class="error_msg label-control col-sm-6 oneSixity">
                                &nbsp;&nbsp;&nbsp;
                           <asp:CustomValidator ID="valPetExists" runat="server" ErrorMessage="Pet is already on reservation list ! "></asp:CustomValidator>
                            </div>
                        </div>
                        <br />
                        <div class="col-sm-6 center">
                            <label id="lblCurrentPet" runat="server" class="label-control col-sm-4">Current Pets</label>
                            <asp:ListBox ID="lbCurrentPets" runat="server" AutoPostBack="true"></asp:ListBox>
                        </div>
                    </div>
                    <br />
                    <h4 class="subtitle">Pet Services -
                        <asp:Label ID="lblSelectedPet" runat="server" Text="[Pet's Name]"></asp:Label></h4>
                    <div class="row">
                        <div class="col-md-6 ">
                            <label class="label-control col-sm-4">Services</label>
                            <!-- To be recieve from DB -->
                            <div class="col-sm-8 center push-left">
                                <div class="col-sm-6">
                                    <asp:CheckBox ID="chWalk" runat="server" Text="Daily Walk" CssClass="" /><br />
                                    <asp:CheckBox ID="chPalytime" runat="server" Text="Daily Playtime" CssClass="" /><br />
                                    <asp:CheckBox ID="chGrooming" runat="server" Text="Grooming" CssClass="" /><br />
                                    <asp:TextBox ID="txtGrooming" TextMode="Number" runat="server" min="0" max="2" step="1" CssClass="form-control  col-sm-8" Text="0" />
                                    <asp:RequiredFieldValidator ID="valReqGrooming" runat="server" ControlToValidate="txtGrooming" ErrorMessage="Please enter frequency for grooming"> <span class="glyphicon glyphicon-exclamation-sign red"></span></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="label-control col-sm-4">Medication</label>
                            <asp:TextBox placeholder="Your pet's medication" ID="txtMedication" runat="server" CssClass="form-control col-md-4"></asp:TextBox>
                            <asp:CustomValidator ID="valMedication" runat="server" ErrorMessage="Please Complete your medication information" ControlToValidate="txtMedication"> <span class="glyphicon glyphicon-exclamation-sign red"></span></asp:CustomValidator>

                            <asp:RegularExpressionValidator ID="valMedExpress" runat="server" ErrorMessage="Please enter a valid medication" ControlToValidate="txtMedication" ValidationExpression="^[a-zA-Z0-9]+$"><span class="glyphicon glyphicon-exclamation-sign red"></span></asp:RegularExpressionValidator>
                            <label class="label-control col-sm-4">Dosage</label>
                            <asp:TextBox ID="txtMedDosage" runat="server" CssClass="form-control col-md-6"></asp:TextBox>

                            <label class="label-control col-sm-4">Expiry Date</label>
                            <input name="medicationEndDate" id="txtMedicationEndDate" runat="server" class="form-control datepicker" />

                            <label class="label-control col-sm-4">Medication Note</label>
                            <textarea id="txtMedicationNote" runat="server" cols="20" rows="2" class=" form-control"></textarea>
                            <div class="right">
                                <asp:HyperLink ID="btnAddMedic" runat="server">Add Medication + </asp:HyperLink>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="label-control col-sm-4">Choose Your Food</label>
                            <asp:DropDownList ID="ddlFood" runat="server" CssClass="form-control"></asp:DropDownList>
                            <label class="label-control col-sm-4">Frequency</label>
                            <asp:RadioButtonList ID="rdOnce" runat="server">
                                <asp:ListItem Value="once"></asp:ListItem>
                                <asp:ListItem Value="twice"></asp:ListItem>
                            </asp:RadioButtonList>
                            <label class="label-control col-sm-4">Food Quantity</label>
                            <asp:TextBox ID="txtFoodQuantity" runat="server" CssClass="form-control short col-md-6"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label class="label-control col-sm-4">Reservation Note</label>
                            <textarea id="txtResNote" runat="server" cols="20" rows="2" class=" form-control"></textarea>
                        </div>
                        <br />
                    </div>



                </div>
            </asp:Panel>

        </div>
    </div>

</asp:Content>