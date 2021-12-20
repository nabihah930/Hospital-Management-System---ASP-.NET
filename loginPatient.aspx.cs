using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HMS_Pro1
{
    public partial class loginPatient : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void checkEmailPassword()
        {
            string email;
            string password;
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM patients", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                email = dr1["patient_email"].ToString();
                password = dr1["patient_password"].ToString();
                if(email == TextBox1.Text && password == TextBox2.Text)
                {
                    Label3.Text = "Successful Login";
                    break;
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            checkEmailPassword();
        }
    }
}