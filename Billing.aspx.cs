using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HMS_Pro1
{
    public partial class Billing : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string data;
            data = (string)Session["totalPayment"];
            int totalPayment;
            totalPayment = Convert.ToInt32(data);

            string room_no;
            room_no = (string)Session["Room_No"];

            string ordered_by;
            ordered_by = (string)Session["ordered_by"];

            Random rand = new Random();
            int num = rand.Next(9);

            SqlConnection con = new SqlConnection(cs);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            string str = "INSERT INTO order_cafe(order_id, ordered_by, to_room, order_time, charges) VALUES (@order_id, @ordered_by,@to_room,@order_time,@charges)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@order_id", "OR" + num);
            cmd.Parameters.AddWithValue("@ordered_by", ordered_by);
            cmd.Parameters.AddWithValue("@to_room",room_no);
            cmd.Parameters.AddWithValue("@order_time", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@charges",totalPayment);
            cmd.ExecuteNonQuery();
            con.Close();



        }
    }
}