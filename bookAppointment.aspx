<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookAppointment.aspx.cs" Inherits="HospitalManagementSys.bookAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
          <%--mx-auto simply moves the division to the center--%>
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
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Doctor's Name"></asp:TextBox>
                        </div>
                        <label>Time Slot</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Available Time Slot"></asp:TextBox>
                        </div>
                        <label>Room Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Available Room for Appointment"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                         <center>
                             <div class="form-group">
                                <asp:Button class="btn btn-success btn-lg btn-block" ID="Button1" runat="server" Text="Book Appointment" />
                             </div>
                             <br>
                             <div class="form-group">
                                <input class="btn btn-danger btn-block btn-lg" id="Button2" type="button" value="Clear Form" />
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
