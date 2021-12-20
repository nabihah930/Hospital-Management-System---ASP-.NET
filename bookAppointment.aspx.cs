using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HospitalManagementSys
{
    public partial class bookAppointment : System.Web.UI.Page
    {
        static string doc_ID = "";
        string connectionStr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)                                                        //This is important otherwise the data will be bound to the dropdown list again and again
            {
                int count = 1;                                                      //This will be incremented to form the key for our (key,value) pairs
                Dictionary<int, string> doctors = new Dictionary<int, string>();
                //List<string> all_docs = new List<string>();
                try
                {
                    SqlConnection connection = new SqlConnection(connectionStr);
                    if (connection.State == ConnectionState.Closed)                 //Check if connection is open.
                        connection.Open();
                    count = Get_Doctors(doctors, connection, 1, count);             //Simply populating the dictionary with key:value pairs.
                    count = Get_Doctors(doctors, connection, 2, count);
                    count = Get_Doctors(doctors, connection, 3, count);
                    //Response.Write("<script>alert('" + count + "');</script>");
                    DropDownDoc.DataTextField = "Value";                            //Binding the dictionary to our dropdown list.
                    DropDownDoc.DataValueField = "Key";
                    DropDownDoc.DataSource = doctors;
                    DropDownDoc.DataBind();
                    connection.Close();

                }
                catch (Exception excpt)
                {
                    Response.Write("<script>alert('" + excpt.Message + "');</script>");
                }
            }
        }

        protected int Get_Doctors(Dictionary<int, string> names, SqlConnection connection, int doc_type, int count)
        {
            string fullName = "";
            if (doc_type == 1)                                                      //1->Cardiologists
            {
                SqlCommand getName = new SqlCommand("SELECT fname, lname FROM doctors WHERE department_id='CDP01'", connection);
                SqlDataReader dataReader = getName.ExecuteReader();
                while (dataReader.Read())
                {
                    fullName = dataReader["fname"].ToString() + " " + dataReader["lname"].ToString() + "(Cardiologist)";
                    names.Add(count,fullName);
                    //Response.Write("<script>alert('" + count + "');</script>");
                    count++;
                    fullName = "";
                }
                dataReader.Close();
            }
            else if (doc_type == 2)                                                 //2->Orthopedics
            {
                SqlCommand getName = new SqlCommand("SELECT fname, lname FROM doctors WHERE department_id='ODP01'", connection);
                SqlDataReader dataReader = getName.ExecuteReader();
                while (dataReader.Read())
                {
                    fullName = dataReader["fname"].ToString() + " " + dataReader["lname"].ToString() + "(Orthopedist)";
                    names.Add(count,fullName);
                    //Response.Write("<script>alert('" + count + "');</script>");
                    count++;
                    fullName = "";
                }
                dataReader.Close();
            }
            else                                                                    //3->Hematologists
            {
                SqlCommand getName = new SqlCommand("SELECT fname, lname FROM doctors WHERE department_id='HDP01'", connection);
                SqlDataReader dataReader = getName.ExecuteReader();
                while (dataReader.Read())
                {
                    fullName = dataReader["fname"].ToString() + " " + dataReader["lname"].ToString() + "(Hematologist)";
                    names.Add(count, fullName);
                    //Response.Write("<script>alert('" + count + "');</script>");
                    count++;
                    fullName = "";
                }
                dataReader.Close();
            }
            return count;
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string doc_id = "";
            //Dictionary<string, string> daysTimes = new Dictionary<string, string>();        //We will use this to store the chosen doctors working days.
            Dictionary<string, DateTime> daysTimes = new Dictionary<string, DateTime>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionStr);
                if (connection.State == ConnectionState.Closed)                             //Check if connection is open.
                    connection.Open();
                doc_ID = Get_Doc_ID(DropDownDoc.SelectedItem.Text, connection);
                doc_id = doc_ID;
                SqlCommand getTimings = new SqlCommand("SELECT working_days.day_one, working_days.day_two, working_days.day_three, shifts.start_time, shifts.end_time FROM shifts INNER JOIN working_days ON working_days.working_days_code = shifts.working_days_code INNER JOIN doctors ON doctors.shift_num = shifts.shift_num WHERE doctor_id='" + doc_ID + "';", connection);
                SqlDataReader dataReader = getTimings.ExecuteReader();
                while (dataReader.Read())
                {
                    daysTimes.Add(dataReader["day_one"].ToString(), Convert.ToDateTime(dataReader["end_time"].ToString()));
                    daysTimes.Add(dataReader["day_two"].ToString(), Convert.ToDateTime(dataReader["end_time"].ToString()));
                    daysTimes.Add(dataReader["day_three"].ToString(), Convert.ToDateTime(dataReader["end_time"].ToString()));
                }
                dataReader.Close();
                //Response.Write("<script>alert('Key: " + daysTimes.ElementAt(0).Key + " Value: " + daysTimes.ElementAt(0).Value + "');</script>");
                if (Check_Clashes(daysTimes, doc_ID, connection))
                {
                    Response.Write("<script>alert('Sorry Dr " + DropDownDoc.SelectedItem + " has no available slots at the moment, please select another doctor or try again later.');</script>");
                    }
                else
                {
                    Response.Write("<script>alert('Yay! Dr " + DropDownDoc.SelectedItem + " has some available slots.');</script>");
                }
                connection.Close();
            }
            catch (Exception excpt)
            {
                Response.Write("<script>alert('" + excpt.Message + "');</script>");
            }
        }
        protected bool Check_Clashes(Dictionary<string, DateTime> daysTimes, string id, SqlConnection connection)
        {
            bool clash = false;
            Dictionary<string, DateTime> daysTimes_copy = new Dictionary<string, DateTime>(daysTimes);
            //Dictionary<string, string> clashDaysTimes = new Dictionary<string, string>();
            List<string> clashDays = new List<string>();
            List<DateTime> clashTimes = new List<DateTime>();
            SqlCommand getClashes = new SqlCommand("SELECT end_time, appointment_day FROM appointments WHERE doctor_id = '" + id + "';", connection);
            SqlDataReader dataReader = getClashes.ExecuteReader();
            while (dataReader.Read())
            {
                clashDays.Add(dataReader["appointment_day"].ToString());
                clashTimes.Add(Convert.ToDateTime(dataReader["end_time"].ToString()));
                //clashDaysTimes.Add(dataReader["appointment_day"].ToString(), dataReader["end_time"].ToString());
            }
            if (dataReader.HasRows)                                                             //If dataReader returned rows(appointments) for the chosen doctor check for potential clashes.
            {
                for(int counter=0; counter<clashDays.Count; counter++)
                {
                    if (daysTimes_copy[clashDays[counter]] > clashTimes[counter])               //Potential time slot available for booking
                    {
                        daysTimes_copy[clashDays[counter]] = clashTimes[counter];
                        //Response.Write("<script>alert('daysTimes_copy[clashDays[counter]]: " + daysTimes_copy[clashDays[counter]] + " clashTimes[counter]: " + clashTimes[counter] + "');</script>");
                    }
                }
                //Checking if any of our end_times have changed if not then no available slots left for this doctor.
                int flag_days = 0;
                for (int counter=0; counter<daysTimes.Count; counter++)
                {
                    if (daysTimes.ElementAt(counter).Value == daysTimes_copy.ElementAt(counter).Value)
                        flag_days++;
                }
                if (flag_days == daysTimes.Count)
                    clash = true;
                else
                    clash = false;
            }
            else                                                                            //No rows returned means that this doctor has no previous appointments therefore can have no clashes. 
                clash = false;
            return clash;
        }
        protected void Time_Slots_Data()
        {

        }
        protected void Add_Appointment()
        {
            //should be called in Button1_Click() method.
        }
        protected string Get_Doc_ID(string full_name, SqlConnection connection)
        {
            string id = "";
            string[] name = full_name.Split(null);
            name[1] = name[1].Substring(0, name[1].IndexOf("("));                           //Extracting only the last name from the string.
            SqlCommand getID = new SqlCommand("SELECT doctor_id FROM doctors WHERE fname = '" + name[0] + "' AND lname = '" + name[1] + "';", connection);
            SqlDataReader dataReader = getID.ExecuteReader();
            while (dataReader.Read())
            {
                id = dataReader["doctor_id"].ToString();
            }
            dataReader.Close();
            return id;
        }
        protected void Button1_Click(object sender, EventArgs e)                            //Book Appointment button is clicked.
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionStr);
                if (connection.State == ConnectionState.Closed)                 //Check if connection is open.
                    connection.Open();
                Response.Write("<script>alert('Successfully Connected to the DB');</script>");
                connection.Close();
            }
            catch(Exception excpt)
            {
                Response.Write("<script>alert('"+ excpt.Message +"');</script>");
            }
        }
    }
}