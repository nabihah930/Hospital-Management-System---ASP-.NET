<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="HMS_Pro1.WebForm2" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <section>
        <img src="imgs/departs.jpg" class="img-fluid" style="max-width:100%"/>
    </section>
    <div style ="font-size: 10pt;font-family: Verdana, Geneva, Arial, Helvetica, sans-serif;color: black;line-height: 14pt;padding-left: 5pt;padding-right: 5pt;padding-top: 5pt;">
        <div id="dept_cardio">
            <h2 style="font-family: verdana; text-align: center">Cardiology</h2>
            <p style="font-family: Arial, Helvetica, sans-serif">Newlife Hospital is the private sector institute for Cardio Vascular diseases in Karachi, Pakistan. Newlife Heart and Vascular center provides the most advanced and comprehesnive care for cardiac, vascular and pulmonary problems in Pakistan.We provide you with
		       specialized and affordable cardiac care to patients. Cardiology is one of the most important component of medicine. Well trained cardiology consultants provide cardiac facilities to patients who are admitted in other medical and surgical disciplines.Check the information about the best cardiologists.</p>
            <a href="cardiology.aspx" target="#" style ="font-size: 15px"><strong>Click Here</strong></a>
            <h5 style ="font-size: 13px">Contact No:- 
                <asp:Label ID="Label1" runat="server" Text="-"></asp:Label>
            </h5>
            <h5 style ="font-size: 13px">Email Address:- 
                <asp:Label ID="Label2" runat="server" Text="-"></asp:Label>
            </h5>
        </div>
        <div id="dept_ortho">
            <h2 style="font-family: verdana; text-align:center">Orthopedic</h2>
            <p style="font-family: Arial, Helvetica, sans-serif">Orthopedic is the branch of surgery concerned with conditions involving the musculoskeletal system. We have provided comprehensive
		       care for all skeleton conditions. Our surgeons, well known on both national and international level,devotedly and skillfully diagnose and treat incoming trauma cases
               and chronic musculoskeletal diseases. It also coordinates the management and rehabilition of patients after injury.
               A physiotherapist with special training in orthopedic rehabilition has been dedicated to patients postoperative rehabilition.Check the information about the best orthopedics.</p>
            <a href="orthopedic.aspx" target="#" style ="font-size: 15px"><strong>Click Here</strong></a>
            <h5 style ="font-size: 13px">Contact No:-
                <asp:Label ID="Label3" runat="server" Text="-"></asp:Label>
            </h5>
            <h5 style ="font-size: 13px">Email Address:-&nbsp;
                <asp:Label ID="Label4" runat="server" Text="-"></asp:Label>
            </h5>
        </div>
        <div id="dept_hema">
            <h2 style="font-family: verdana; text-align: center">Hematology</h2>
            <p style="font-family: Arial, Helvetica, sans-serif" >Hematology department offers a full battery of routine and special hematology tests, Body fluid routine analysis including cerebrospinal fluid
		       ,routine and special coagulation profile,bone marrow biopsies and complete set of Immunohisochemical analysis for accurate
		       and final diagnosis of Hematological malignancies.It comprises of experienced surgeons and has modern art equipments.Check the information about the best orthopedics.</p>
             <a href="hematology.aspx" target="#" style ="font-size: 15px"><strong>Click Here</strong></a>
            <h5 style ="font-size: 13px">Contact No:-
                <asp:Label ID="Label5" runat="server" Text="-"></asp:Label>
            </h5>
            <h5 style ="font-size: 13px">Email Address:-&nbsp;
                <asp:Label ID="Label6" runat="server" Text="-"></asp:Label>
            </h5>
        </div>
       
    </div>
</asp:Content>
