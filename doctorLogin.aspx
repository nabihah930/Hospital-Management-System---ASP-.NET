<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="doctorLogin.aspx.cs" Inherits="HMS_Pro1.doctorLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
    <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
  
    <div class="row">
    <div class="col-md-6">
    <div class="form-group">
    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
    </div>
        </div>
            </div>
    <div class="row">
    <div class="col-md-6">
    <div class="form-group">
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="Message"></asp:Label>
    </div>
        </div>
            </div>
    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
    </div>
        </div>
            </div>
                </div>
                    </div>
                        </div>
                             </div>
     

</asp:Content>
