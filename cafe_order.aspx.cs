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
    public partial class Cafe_Order : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT food_name,food_type,price FROM cafeteria", con);
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            con.Close();

        }
        protected void cheesecake()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = 'CheeseCake'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int price = Convert.ToInt32(dr1["price"]);
                int quantity = Convert.ToInt32(TextBox3.Text);
                int subtotal = quantity * price;
                Label5.Text = subtotal.ToString();
            }
        }
        protected void Daal()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = 'Daal'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int price = Convert.ToInt32(dr1["price"]);
                int quantity = Convert.ToInt32(TextBox4.Text);
                int subtotal = quantity * price;
                Label6.Text = subtotal.ToString();
            }
        }
        protected void IceCream()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = 'Ice-Cream'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int price = Convert.ToInt32(dr1["price"]);
                int quantity = Convert.ToInt32(TextBox5.Text);
                int subtotal = quantity * price;
                Label7.Text = subtotal.ToString();
            }
        }
        protected void Kheer()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = 'Kheer'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int price = Convert.ToInt32(dr1["price"]);
                int quantity = Convert.ToInt32(TextBox6.Text);
                int subtotal = quantity * price;
                Label8.Text = subtotal.ToString();
            }
        }
        protected void MexicanSoup()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = 'Mexican Soup'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int price = Convert.ToInt32(dr1["price"]);
                int quantity = Convert.ToInt32(TextBox7.Text);
                int subtotal = quantity * price;
                Label9.Text = subtotal.ToString();
            }
        }
        protected void Roti()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = 'Roti'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int price = Convert.ToInt32(dr1["price"]);
                int quantity = Convert.ToInt32(TextBox8.Text);
                int subtotal = quantity * price;
                Label10.Text = subtotal.ToString();
            }
        }

        protected void biryani()
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = 'biryani'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int price = Convert.ToInt32(dr1["price"]);
                int quantity = Convert.ToInt32(TextBox2.Text);
                int subtotal = quantity * price;
                Label4.Text = subtotal.ToString();
            }

        }
        protected void getStock(string foodName,int quantity)
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = '" + foodName + "'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int stock = Convert.ToInt32(dr1["amount_in_stock"]);
                updateStock(foodName, stock ,quantity);
            }
            con.Close();
        }
        protected void updateStock(string food_name, int stock,int quantity)
        {
            int amount_in_stock;
            amount_in_stock = stock - quantity;
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //string sql = "Update blood_bank set units_remaining = unit_remaining where blood_type = '" + TextBox2.Text + "' ";
            SqlCommand cmd0 = new SqlCommand("Update cafeteria set amount_in_stock = @amount_in_stock where food_name = '" + food_name + "' ", con);
            cmd0.Parameters.AddWithValue("@amount_in_stock", amount_in_stock);
            cmd0.ExecuteNonQuery();
            con.Close();
        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            biryani();
            cheesecake();
            Daal();
            IceCream();
            Kheer();
            MexicanSoup();
            Roti();
            Label11.Text = (Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text) + Convert.ToInt32(Label6.Text)+ Convert.ToInt32(Label7.Text)+ Convert.ToInt32(Label8.Text)+ Convert.ToInt32(Label9.Text)+ Convert.ToInt32(Label10.Text)).ToString(); 

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            getStock("Biryani", Convert.ToInt32(TextBox2.Text.Trim()));
            getStock("CheeseCake", Convert.ToInt32(TextBox3.Text.Trim()));
            getStock("Daal", Convert.ToInt32(TextBox4.Text.Trim()));
            getStock("Ice-Cream", Convert.ToInt32(TextBox5.Text.Trim()));
            getStock("Kheer", Convert.ToInt32(TextBox6.Text.Trim()));
            getStock("Mexican Soup", Convert.ToInt32(TextBox7.Text.Trim()));
            getStock("Roti", Convert.ToInt32(TextBox8.Text.Trim()));
            int totalPayment = Convert.ToInt32(Label11.Text);
            Session["totalPayment"] = totalPayment;
            Response.Redirect("Billing.aspx");
        }
    }
}