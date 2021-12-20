<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="patientSignUp.aspx.cs" Inherits="HMS_Pro1.patientSignUp" %>
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
    
    
    
    
    
    
    <div>
        <form>
        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>First Name</label>
        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        </div>
        </div>
        </div>


        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Last Name</label>
        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        </div>
        </div>
        </div>

        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>ID</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        </div>
        </div>
            </div>


             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Age</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        </div>
            </div></div>

             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Gender</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <br />
            </div>
            </div>
        </div>

             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Phone</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <br />
            </div></div>

        </div>
             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Current Address</label>
        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        <br />
            </div>
            </div>
 
        </div>

             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Blood Type</label>
        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <br />
            </div></div>

        </div>
             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Patient Email</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox9" runat="server"></asp:TextBox>
        <br />
        <br />
            </div></div>
        </div>
             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Patient Password</label>
        <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server"></asp:TextBox>
        <br />
        <br />
            </div></div>
        </div>
        </form>
        <div class="form-group">
        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
        </div>
    </div>


</div>
</div>
</div>
</div>
</div>
</div>
</div>








</asp:Content>
