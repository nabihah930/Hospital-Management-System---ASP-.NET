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
 
        
            
        <label>First Name</label>
            <div class="form-group">
        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
        
        </div>
        </div>
        
        <div class="col-md-6">
        <div class="form-group">
        <label>Last Name</label>
        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="last name"></asp:TextBox>
        
        </div>
        </div>
        </div>

        <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>ID</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox3" runat="server"></asp:TextBox>
      
        </div>
          </div>


        <div class="col-md-6">
        
        <label>Age</label>
            <div class="form-group">
        <asp:TextBox  CssClass="form-control" ID="TextBox4" runat="server"></asp:TextBox>

            </div>
         </div>
         </div>

             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Gender</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox5" runat="server"></asp:TextBox>
       
            </div>
        </div>

         
        <div class="col-md-6">
        <div class="form-group">
        <label>Phone</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox6" runat="server"></asp:TextBox>
       </div>

        </div>
             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Current Address</label>
        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server"  TextMode="MultiLine" Rows="1"></asp:TextBox>
        
            </div>
         </div>
                <div class="col-md-6">
        <div class="form-group">
        <label>Blood Group</label>
        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server"></asp:TextBox>
     
          </div>
</div>
        </div>
             <div class="row">
        <div class="col-md-6">
        <div class="form-group">
        <label>Patient Email</label>
        <asp:TextBox  CssClass="form-control" ID="TextBox9" runat="server"></asp:TextBox>
    </div>
        </div>
             
        <div class="col-md-6">
        <div class="form-group">
        <label>Patient Password</label>
        <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server"></asp:TextBox>

            </div>
            </div>
        </div>
        <center>
        <div class="form-group">
        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up"  />
    </center> 
       </div>
    </div>


</div>
             <a href="homepage.aspx"><< Back to Home</a><br><br>
</div>
</div>
</div>








</asp:Content>
