<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userSignup.aspx.cs" Inherits="HMS_Pro1.userSignup" %>
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
                        <center>
                           <img width="100px" src="images/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Sign Up</h4>
                           
                           <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your status"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Last Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Last Name"></asp:TextBox>
                        </div>
                     </div>
                      <div class="row">
                     <div class="col-md-6">
                        <label>Age</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Age"></asp:TextBox>
                        </div>
                     </div>
                          <div class="col-md-6">
                        <label>Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Contact Number"></asp:TextBox>
                        </div>
                     </div>
                          <div class="col-md-6">
                        <label>Blood Type</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Blood Type"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Gender</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Gender"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>State</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              
                              <asp:ListItem Text="Balochistan" Value="Balochistan" />
                              <asp:ListItem Text="Khyber Pakhtunkhwa" Value="Khyber Pakhtunkhwa" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                               <asp:ListItem Text="Sindh" Value="Sindh" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pincode</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                     <div class="row">
                         <div class="col">
                         <center>
                           <span class="badge badge-pill badge-info">Login Credentials</span>
                        </center>
                     </div>
                  </div>
                    <div class="row">
                     <div class="col-md-6">
                        <label>User Id</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="User Id"> </asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                
                  
                  <div class="row">
                     <div class="col-6 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
         
      </div>
   </div>

   </asp:Content>




