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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void donateBlood(string bloodtype, int units)
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT units_remaining FROM blood_bank where blood_type = '" + bloodtype + "'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int unit_blood = Convert.ToInt32(dr1["units_remaining"]);
                int quantity = unit_blood + units;
                donationBlood(quantity);
            }
            con.Close();

        }
        protected void donationBlood(int unit_remaining)
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //string sql = "Update blood_bank set units_remaining = unit_remaining where blood_type = '" + TextBox2.Text + "' ";
            SqlCommand cmd0 = new SqlCommand("Update blood_bank set units_remaining = @unit_remaining where blood_type = '" + TextBox2.Text + "' ", con);
            cmd0.Parameters.AddWithValue("@unit_remaining", unit_remaining);
            cmd0.ExecuteNonQuery();
            con.Close();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                DateTime dt = DateTime.Now;
                string date_query = dt.ToString();
                string str = "INSERT INTO donations(donor_id, donation_date, blood_type) VALUES (@donor_id, @donation_date,@blood_type)";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@donor_id",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@donation_date", dt);
                cmd.Parameters.AddWithValue("@blood_type", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();             
                con.Close();
                if(TextBox2.Text == "A")
                {
                    donateBlood(TextBox2.Text, Convert.ToInt32(TextBox3.Text));
                }
                else if(TextBox2.Text == "B")
                {
                    donateBlood(TextBox2.Text, Convert.ToInt32(TextBox3.Text));


                }
                else if(TextBox2.Text == "AB")
                {
                    donateBlood(TextBox2.Text, Convert.ToInt32(TextBox3.Text));


                }
                else if(TextBox2.Text == "O")
                {
                    donateBlood(TextBox2.Text, Convert.ToInt32(TextBox3.Text));


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" +ex.Message+ "');</script>");
            }
            


        }
    }
}