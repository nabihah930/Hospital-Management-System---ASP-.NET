<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cafe_Order.aspx.cs" Inherits="HMS_Pro1.Cafe_Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>

        <br />
        Biryani:-<br />

        Quantity:-
        <asp:TextBox ID="TextBox2" runat="server" Text="0"></asp:TextBox>
        <br />
        Subtotal:-
        <asp:Label ID="Label4" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        CheeseCake:-<br />
        Quantity:-
        <asp:TextBox ID="TextBox3" runat="server" Text="0"></asp:TextBox>
        <br />
        Subtotal:-
        <asp:Label ID="Label5" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        Daal:-<br />
        Quantity:-<asp:TextBox ID="TextBox4" runat="server" Text="0"></asp:TextBox>
        <br />
        Subtotal:-<asp:Label ID="Label6" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        Ice-Cream:-<br />
        Quantity:-<asp:TextBox ID="TextBox5" runat="server" Text="0"></asp:TextBox>
        <br />
        SubTotal:-<asp:Label ID="Label7" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        Kheer:-<br />
        Quantity:-<asp:TextBox ID="TextBox6" runat="server" Text="0"></asp:TextBox>
        <br />
        SubTotal:-<asp:Label ID="Label8" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        Mexican Soup:-<br />
        Quantity:-<asp:TextBox ID="TextBox7" runat="server" Text="0"></asp:TextBox>
        <br />
        SubTotal:-<asp:Label ID="Label9" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        Roti:-<br />
        Quantity:-
        <asp:TextBox ID="TextBox8" runat="server" Text="0"></asp:TextBox>
        <br />
        SubTotal:-<asp:Label ID="Label10" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        Total Payment:-<asp:Label ID="Label11" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="Place Order" OnClick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <asp:Button ID="Button3" runat="server" Text="Confirm Order" OnClick="Button3_Click" />
        <br />
        <br />
        
    </div>
</asp:Content>
