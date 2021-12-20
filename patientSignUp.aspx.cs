using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HMS_Pro1
{
   
    public partial class patientSignUp : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from patients where patient_id ='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        protected void insertpatient()
        {
            SqlConnection con = new SqlConnection(cs);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            string str = "INSERT INTO patients(patient_id,fname,lname,age,gender,phone,current_address,blood_type,patient_email,patient_password) VALUES(@patient_id,@fname,@lname,@age,@gender,@phone,@current_address,@blood_type,@patient_email,@patient_password)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@patient_id", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@fname", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@lname", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@age", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@gender", TextBox5.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@current_address", TextBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@blood_type", TextBox8.Text.Trim());
            cmd.Parameters.AddWithValue("@patient_email", TextBox9.Text.Trim());
            cmd.Parameters.AddWithValue("@patient_password", TextBox10.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {

                Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
            }
            else
            {
                insertpatient();
            }

        }
    }
}