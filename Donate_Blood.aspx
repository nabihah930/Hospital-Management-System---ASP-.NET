<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Donate_Blood.aspx.cs" Inherits="HMS_Pro1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <section>
        <img src="imgs/donate_blood.jpg" class="img-fluid" />
    </section>
    <div>
         Donor_ID:-
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
         <br />
         Blood_Type:-<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
         <br />
         Quantity:-&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
         <br />
          <asp:Button ID="Button1" runat="server" Text="Donate" OnClick="Button1_Click" />
         <br />
    </div>
       
</asp:Content>
