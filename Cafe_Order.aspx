<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cafe_Order.aspx.cs" Inherits="HMS_Pro1.Cafe_Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
            </center>

    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
    <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">                      
    <div>

        <br />
        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        Biryani:-<br />

        Quantity:-
        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Text ="0"></asp:TextBox>
        <br />
        Subtotal:-
        <asp:Label ID="Label4" runat="server" Text="-"></asp:Label>
</div>
            </div>
            </div>

        <br />
        <br />


        <div class="row">
        <div class="col-md-6">
        <div class="form-group">


        CheeseCake:-<br />
        Quantity:-
        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged" Text="0"></asp:TextBox>
        <br />
        Subtotal:-
        <asp:Label ID="Label5" runat="server" Text="-"></asp:Label>
        </div>
            </div>
            </div>
        <br />
        <br />

        <div class="row">
        <div class="col-md-6">
        <div class="form-group">

        Daal:-<br />
        Quantity:-<asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged" Text="0"></asp:TextBox>
        <br />
        Subtotal:-<asp:Label ID="Label6" runat="server" Text="-"></asp:Label>
        </div>
            </div>
            </div>
        <br />
        <br />
        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        Ice-Cream:-<br />
        Quantity:-<asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" Text="0"></asp:TextBox>
        <br />
        SubTotal:-<asp:Label ID="Label7" runat="server" Text="-"></asp:Label>
</div>
            </div>
            </div>
        <br />
        <br />
        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        Kheer:-<br />
        Quantity:-<asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" OnTextChanged="TextBox6_TextChanged" Text="0"></asp:TextBox>
        <br />
        SubTotal:-<asp:Label ID="Label8" runat="server" Text="-"></asp:Label>
            </div>
            </div>
            </div>
        <br />
        <br />

        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        Mexican Soup:-<br />
        Quantity:-<asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" OnTextChanged="TextBox7_TextChanged" Text="0"></asp:TextBox>
        <br />
        SubTotal:-<asp:Label ID="Label9" runat="server" Text="-"></asp:Label>
            </div>
            </div>
            </div>
        <br />
        <br />
        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        Roti:-<br />
        Quantity:-
        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" OnTextChanged="TextBox8_TextChanged" Text="0"></asp:TextBox>
        <br />
        SubTotal:-<asp:Label ID="Label10" runat="server" Text="-"></asp:Label>
            </div>
            </div>
            </div>
        <br />
        <br />
        Total Payment:-<asp:Label ID="Label11" runat="server" Text="-"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;<asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server" Text="Place Order" OnClick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button3" runat="server" Text="Confirm Order" OnClick="Button3_Click" />
        <br />
        <br />
        </div>
                         </div>
                      </div>
                   </div>
                </div>
             </div>
        </div>
        </div>
  
                      
        <asp:Label ID="Label12" runat="server" Text="-"></asp:Label>

</asp:Content>


