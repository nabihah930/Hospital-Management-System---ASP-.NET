<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Donate_Blood.aspx.cs" Inherits="HMS_Pro1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Donate Blood</h1>
    <div class="container-fluid">
    <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
  
    <div>
        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
         Donor_ID:-
         <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            </div>
            </div>
         <br />
        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
         Blood_Type:-<asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox>
            </div>
            </div>
            </div>
        <br/>
        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
         Quantity:-&nbsp; <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"></asp:TextBox>
            </div>
            </div>
            </div>
         <br />
          <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Donate" OnClick="Button1_Click" />
         <br />
    </div>
                         </div>
                      </div>
                   </div>
                </div>
             </div>
        </div>
        </div>
       
</asp:Content>
