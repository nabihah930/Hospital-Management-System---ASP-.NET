<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookAppointment.aspx.cs" Inherits="HospitalManagementSys.bookAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
          <%--<asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Doctor's Name"></asp:TextBox>--%>
         <div class="col-md-8 mx-auto">
             <%--card: bootstrap class which has a body, title or button--%>
            <div class="card">
               <div class="card-body">
                   <%--We are going to create multiple rows inside of our card--%>
                  <div class="row">
                     <div class="col">
                        <center>
                            <img width="150px" src="icons/book_appointment_icon.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h2>Book an Appointment</h2>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>                                        <%--Adds a horizontal rule a.k.a a horizontal line--%>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Doctor's Name</label>
                        <div class="form-group">                    <%--form-group: simply a bootstrap class to add some additional styling to the interface--%>
                           <%--<asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Doctor's Name"></asp:TextBox>--%>
                           <asp:DropDownList CssClass="form-control" ID="DropDownDoc" runat="server" AutoPostBack="True" OnSelectedIndexChanged = "OnSelectedIndexChanged">
                               <asp:ListItem Text="Select Doctor" Value="Select"/>
                           </asp:DropDownList>
                        </div>
                        <label>Time Slot</label>
                        <div class="form-group">
                           <%--<asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Available Time Slot"></asp:TextBox>--%>
                            <asp:DropDownList CssClass="form-control" ID="DropDownTime" runat="server" AutoPostBack="True" OnSelectedIndexChanged = "Time_OnSelectedIndexChanged">
                                <asp:ListItem Text="Select Time Slot" Value="Select"/>
                            </asp:DropDownList>
                        </div>
                        <label>Room Number</label>
                        <div class="form-group">
                            <asp:DropDownList CssClass="form-control" ID="DropDownRoom" runat="server" AutoPostBack="True" OnSelectedIndexChanged = "Room_OnSelectedIndexChanged">
                                <asp:ListItem Text="Select Appointment Room" Value="Select"/>
                            </asp:DropDownList>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                         <center>
                             <div class="form-group">
                                <asp:Button class="btn btn-success btn-lg w-100" ID="Button1" runat="server" Text="Book Appointment" OnClick="Button1_Click" />
                             </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
            <br><a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      </div>
   </div>
</asp:Content>
