<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="HospitalManagementSys.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/homepage_style.css" rel="stylesheet" />
    <%--1st image section--%>
    <section>
       <img src="images/homepage_bkg7.jpg" id="homepageBG1" class="img-fluid"/>
    </section>
    <%--Creating content(in the form of a grid) which is sandwitched between the images--%>
    <section>
        <div class="container">
            <div class="row">
                <%--In Bootstrap a row can have upto 12 cols--%>
                <div class="col-12">
                    <center>
                        <h2>Services We Provide</h2>
                        <p><b>(Our Primary Features)</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <%--2nd row which will contain our features--%>
                <div class="col-md-4">                                                      <%--md= occupy 4 cols as long as device size > median device size--%>
                    <center>
                        <img id="iconPatient" src="icons/browse_icon.png" />
                        <h4>Browse Our Website</h4>
                        <p class="text-justify">Meet our highly qualified panel of doctors and browse through our departments to see what we have to offer.</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img id="iconPatient" src="icons/book_appointment_icon.png" />
                        <h4>Book an Appointment</h4>
                        <p class="text-justify">Book an appointment from the comfort of your home.</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img id="iconPatient" src="icons/donate_blood_icon.png" />
                        <h4>Donate Blood</h4>
                        <p class="text-justify">Be a hero and donate now!</p>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
        <img src="images/homepage_banner_bkg1.jpg" id="homepageBG1" class="img-fluid"/>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <%--In Bootstrap a row can have upto 12 cols--%>
                <div class="col-12">
                    <center>
                        <h2>Features For Doctors</h2>
                        <p><b>(Only for registered doctors of this hospital)</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <%--2nd row which will contain our features--%>
                <div class="col-md-4">                                                      <%--md= occupy 4 cols as long as device size > median device size--%>
                    <center>
                        <img id="iconDoctor" src="icons/view_schedule_icon.png" />
                        <h4>View Your Schedule</h4>
                        <p class="text-justify">A neat and tidy display of all your booked appointments.</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img id="iconDoctor" src="icons/donate_blood_icon.png" />
                        <h4>Donate Blood</h4>
                        <p class="text-justify">Doctor's too can arrange for a blood donation to save lifes.</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img id="iconDoctor" src="icons/cafeteria_icon.png" />
                        <h4>Cafeteria</h4>
                        <p class="text-justify">Place an order from the hospital's cafeteria which will be delivered right to you room.</p>
                    </center>
                </div>
                
            </div>
        </div>
    </section>
</asp:Content>
