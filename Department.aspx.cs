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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            cardio();
            ortho();
            hema();         
        }
        protected void cardio()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM departments where dept_id = 'CDP01'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                Label1.Text = dr1["dept_number"].ToString();
                Label2.Text = dr1["dept_email"].ToString();
            }
        }
        protected void ortho()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM departments where dept_id = 'ODP01'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                Label3.Text = dr1["dept_number"].ToString();
                Label4.Text = dr1["dept_email"].ToString();
            }
        }
        protected void hema()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM departments where dept_id = 'HDP01'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                Label5.Text = dr1["dept_number"].ToString();
                Label6.Text = dr1["dept_email"].ToString();
            }
        }

    }
}