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
        Dictionary<int, string> Time_Slot_Data = new Dictionary<int, string>();
        string connectionStr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)                                                        //This is important otherwise the data will be bound to the dropdown list again and again
            {
                int count = 1;                                                      //This will be incremented to form the key for our (key,value) pairs
                Dictionary<int, string> doctors = new Dictionary<int, string>();
                try
                {
                    SqlConnection connection = new SqlConnection(connectionStr);
                    if (connection.State == ConnectionState.Closed)                 //Check if connection is open.
                        connection.Open();
                    count = Get_Doctors(doctors, connection, 1, count);             //Simply populating the dictionary with key:value pairs.
                    count = Get_Doctors(doctors, connection, 2, count);
                    count = Get_Doctors(doctors, connection, 3, count);
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
            Dictionary<string, DateTime> daysTimes = new Dictionary<string, DateTime>();    //We will use this to store the chosen doctors working days.
            DateTime doc_start_time = new DateTime();
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
                    doc_start_time = Convert.ToDateTime(dataReader["start_time"].ToString());
                }
                dataReader.Close();
                if (Check_Clashes(daysTimes, doc_id, connection))
                    Response.Write("<script>alert('Sorry Dr " + DropDownDoc.SelectedItem + " has no available slots at the moment, please select another doctor or try again later.');</script>");
                else
                {
                    Response.Write("<script>alert('Yay! Dr " + DropDownDoc.SelectedItem + " has some available slots.');</script>");
                    Time_Slots_Data(daysTimes, doc_start_time, connection, 1);
                    DropDownTime.DataTextField = "Value";                                       //Binding the dictionary to our Time dropdown list.
                    DropDownTime.DataValueField = "Key";
                    DropDownTime.DataSource = Time_Slot_Data;
                    DropDownTime.DataBind();
                }
                connection.Close();
            }
            catch (Exception excpt)
            {
                Response.Write("<script>alert('" + excpt.Message + "');</script>");
            }
        }
        protected void Time_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Time Slot Chosen: " + DropDownTime.SelectedItem + "💃');</script>");
        }
        protected bool Check_Clashes(Dictionary<string, DateTime> daysTimes, string id, SqlConnection connection)
        {
            bool clash;
            Dictionary<string, DateTime> daysTimes_copy = new Dictionary<string, DateTime>(daysTimes);
            List<string> clashDays = new List<string>();
            List<DateTime> clashTimes = new List<DateTime>();
            SqlCommand getClashes = new SqlCommand("SELECT end_time, appointment_day FROM appointments WHERE doctor_id = '" + id + "';", connection);
            SqlDataReader dataReader = getClashes.ExecuteReader();
            while (dataReader.Read())
            {
                clashDays.Add(dataReader["appointment_day"].ToString());
                clashTimes.Add(Convert.ToDateTime(dataReader["end_time"].ToString()));
            }
            if (dataReader.HasRows)                                                             //If dataReader returned rows(appointments) for the chosen doctor check for potential clashes.
            {
                for(int counter=0; counter<clashDays.Count; counter++)
                {
                    if (daysTimes_copy[clashDays[counter]] > clashTimes[counter])               //Potential time slot available for booking
                        daysTimes_copy[clashDays[counter]] = clashTimes[counter];
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
            dataReader.Close();
            return clash;
        }
        protected void Time_Slots_Data(Dictionary<string, DateTime> daysTimes, DateTime doc_start_time, SqlConnection connection, int flag_first)
        {
            List<string> available_days = new List<string>();
            List<DateTime> start_time = new List<DateTime>();
            List<DateTime> end_time = new List<DateTime>();
            if (flag_first == 1)                                                            //flag_first = 1-> This is the doctor's 1st appointment, otherwise previous appointments are present
            {
                for (int day_number =0; day_number < 3; day_number++)
                {
                    available_days.Add(daysTimes.ElementAt(day_number).Key);                             //Don't use [index] for assignment of list it doesn't work for some reason.
                    start_time.Add(doc_start_time);
                    end_time.Add(start_time[0].AddMinutes(15));
                    //each appointment is of 15 mins-> 3 hours = 12 - 1(first appointment done outside loop) => 11 appointments
                    for (int slots=1; slots<12; slots++)
                    {
                        available_days.Add(daysTimes.ElementAt(day_number).Key);
                        start_time.Add(end_time[slots-1]);
                        end_time.Add(start_time[slots].AddMinutes(15));
                    }
                }
                string data_string="";
                for(int counter=0; counter<(3*12); counter++)
                {
                    data_string = available_days[counter]+": "+ start_time[counter].ToString("hh:mm tt")+"-"+ end_time[counter].ToString("hh:mm tt");
                    Time_Slot_Data.Add(counter + 1, data_string);
                    data_string = "";
                }
            }
            else
            {
                Response.Write("<script>alert('Inside else?!?!');</script>");
                //well do it heres
            }
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