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

        protected int foodOrder(string foodname, string quan)
        {
            SqlConnection con = new SqlConnection(cs);
            con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM cafeteria where food_name = '" + foodname + "'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int price = Convert.ToInt32(dr1["price"]);
                int quantity = Convert.ToInt32(quan);
                int subtotal = quantity * price;
                Label12.Text = subtotal.ToString();
            }
            return Convert.ToInt32(Label12.Text);
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
            int f1 = foodOrder("Biryani", TextBox2.Text);
            Label4.Text = f1.ToString();
            int f2 = foodOrder("CheeseCake", TextBox3.Text);
            Label5.Text = f2.ToString();
            int f3 = foodOrder("Daal",TextBox4.Text);
            Label6.Text = f3.ToString();
            int f4= foodOrder("Ice-Cream",TextBox9.Text);
            Label7.Text = f4.ToString();
            int f5 = foodOrder("Kheer", TextBox6.Text);
            Label8.Text = f5.ToString();
            int f6= foodOrder("Mexican Soup", TextBox7.Text);
            Label9.Text = f6.ToString();
            int f7= foodOrder("Roti", TextBox8.Text);
            Label10.Text = f7.ToString();
            Label11.Text = (Convert.ToInt32(Label4.Text) + Convert.ToInt32(Label5.Text) + Convert.ToInt32(Label6.Text) + Convert.ToInt32(Label7.Text) + Convert.ToInt32(Label8.Text) + Convert.ToInt32(Label9.Text) + Convert.ToInt32(Label10.Text)).ToString();
            //Label11.Text = (Convert.ToInt32(f1) + Convert.ToInt32(f2) + Convert.ToInt32(f3) + Convert.ToInt32(f4) + Convert.ToInt32(f5) + Convert.ToInt32(f6) + Convert.ToInt32(f7)).ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            getStock("Biryani", Convert.ToInt32(TextBox2.Text.Trim()));
            getStock("CheeseCake", Convert.ToInt32(TextBox3.Text.Trim()));
            getStock("Daal", Convert.ToInt32(TextBox4.Text.Trim()));
            getStock("Ice-Cream", Convert.ToInt32(TextBox9.Text.Trim()));
            getStock("Kheer", Convert.ToInt32(TextBox6.Text.Trim()));
            getStock("Mexican Soup", Convert.ToInt32(TextBox7.Text.Trim()));
            getStock("Roti", Convert.ToInt32(TextBox8.Text.Trim()));
            int totalPayment = Convert.ToInt32(Label11.Text);
            Session["totalPayment"] = totalPayment;
            Response.Redirect("Billing.aspx");
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {
        }

    }
}