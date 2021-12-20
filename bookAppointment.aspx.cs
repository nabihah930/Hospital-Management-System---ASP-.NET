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
        static string doc_ID = "", dept_ID = "";
        static int total_cost = 0;
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
            int cost = 0;
            Dictionary<string, DateTime> daysTimes = new Dictionary<string, DateTime>();    //We will use this to store the chosen doctors working days.
            DateTime doc_start_time = new DateTime();
            try
            {
                SqlConnection connection = new SqlConnection(connectionStr);
                if (connection.State == ConnectionState.Closed)                             //Check if connection is open.
                    connection.Open();
                doc_ID = Get_Doc_ID(DropDownDoc.SelectedItem.Text, connection);
                doc_id = doc_ID;
                SqlCommand getTimings = new SqlCommand("SELECT doctors.charges, working_days.day_one, working_days.day_two, working_days.day_three, shifts.start_time, shifts.end_time FROM shifts INNER JOIN working_days ON working_days.working_days_code = shifts.working_days_code INNER JOIN doctors ON doctors.shift_num = shifts.shift_num WHERE doctor_id='" + doc_ID + "';", connection);
                SqlDataReader dataReader = getTimings.ExecuteReader();
                while (dataReader.Read())
                {
                    cost = Convert.ToInt32(dataReader["charges"].ToString());
                    daysTimes.Add(dataReader["day_one"].ToString(), Convert.ToDateTime(dataReader["end_time"].ToString()));
                    daysTimes.Add(dataReader["day_two"].ToString(), Convert.ToDateTime(dataReader["end_time"].ToString()));
                    daysTimes.Add(dataReader["day_three"].ToString(), Convert.ToDateTime(dataReader["end_time"].ToString()));
                    doc_start_time = Convert.ToDateTime(dataReader["start_time"].ToString());
                }
                dataReader.Close();
                total_cost = total_cost + cost + 50;
                int check_answer = Check_Clashes(daysTimes, doc_id, connection);
                bool available = Convert.ToBoolean(check_answer);
                if (!available)
                    Response.Write("<script>alert('Sorry Dr " + DropDownDoc.SelectedItem + " has no available slots at the moment, please select another doctor or try again later.');</script>");
                else
                {
                    if (check_answer == 1)                                                      //Meaning no previous appointments at all.
                    {
                        Response.Write("<script>alert('Yay! Dr " + DropDownDoc.SelectedItem + " has all available slots.');</script>");
                        Time_Slots_Data(daysTimes, doc_start_time, connection, 1);
                        DropDownTime.DataTextField = "Value";                                       //Binding the dictionary to our Time dropdown list.
                        DropDownTime.DataValueField = "Key";
                        DropDownTime.DataSource = Time_Slot_Data;
                        DropDownTime.DataBind();
                    }
                    else if (check_answer == 2)
                    {
                        Response.Write("<script>alert('Yay! Dr " + DropDownDoc.SelectedItem + " has some available slots.');</script>");
                        Time_Slots_Data(daysTimes, doc_start_time, connection, 2);
                        DropDownTime.DataTextField = "Value";                                       //Binding the dictionary to our Time dropdown list.
                        DropDownTime.DataValueField = "Key";
                        DropDownTime.DataSource = Time_Slot_Data;
                        DropDownTime.DataBind();
                    }
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
            try
            {
                SqlConnection connection = new SqlConnection(connectionStr);
                if (connection.State == ConnectionState.Closed)                             //Check if connection is open.
                    connection.Open();
                dept_ID = Get_Doc_Dept(connection);
                Dictionary<int, string> Room_Info = new Dictionary<int, string>();
                string roomDescrp = "";
                //string dept_initial = dept_ID.Substring(0);
                List<string> roomID = new List<string>();
                List<string> roomType = new List<string>();
                List<int> roomCharges = new List<int>();
                List<int> roomCapacity = new List<int>();
                List<int> roomSpots = new List<int>();
                //Response.Write("<script>alert('Time Slot Chosen: " + DropDownTime.SelectedItem + "💃 with Doctor: " + DropDownDoc.SelectedItem + "');</script>");
                SqlCommand getRooms = new SqlCommand("SELECT room_id, room_type, charges, capacity, available_spots FROM rooms WHERE room_id LIKE '" + dept_ID[0] + "%';", connection);
                Response.Write("<script>alert('dept_ID[0]:" + dept_ID[0] + "');</script>");
                SqlDataReader dataReader = getRooms.ExecuteReader();
                while (dataReader.Read())
                {
                    roomID.Add(dataReader["room_id"].ToString());
                    roomType.Add(dataReader["room_type"].ToString());
                    roomCharges.Add(Convert.ToInt32(dataReader["charges"].ToString()));
                    roomCapacity.Add(Convert.ToInt32(dataReader["capacity"].ToString()));
                    roomSpots.Add(Convert.ToInt32(dataReader["available_spots"].ToString()));
                }
                dataReader.Close();
                int roomsFull = 0;
                for(int counter=0; counter<roomID.Count; counter++)
                {
                    if (roomSpots[counter] != 0)
                    {
                        Response.Write("<script>alert('roomID:" + roomID[counter] + " roomSpots: " + roomSpots[counter] + "');</script>");
                        roomDescrp = roomType[counter] + ": Remaining Capacity: " + roomSpots[counter]+" (" + roomCharges[counter] + "Rs)";
                        Room_Info.Add(roomCharges[counter], roomDescrp);
                    }
                    else
                        roomsFull++;
                }
                if (roomsFull == 3)
                    Response.Write("<script>alert('Sorry there are no beds available for for this department at the moment. Please try again later.');</script>");
                DropDownRoom.DataTextField = "Value";                            //Binding the dictionary to our dropdown list.
                DropDownRoom.DataValueField = "Key";
                DropDownRoom.DataSource = Room_Info;
                DropDownRoom.DataBind();
            }
            catch (Exception excpt)
            {
                Response.Write("<script>alert('" + excpt.Message + "');</script>");
            }
        }
        protected int Check_Clashes(Dictionary<string, DateTime> daysTimes, string id, SqlConnection connection)
        {
            int clash;
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
                    clash = 0;
                else
                    clash = 2;
            }
            else                                                                            //No rows returned means that this doctor has no previous appointments therefore can have no clashes. 
                clash = 1;
            dataReader.Close();
            return clash;
        }
        protected void Time_Slots_Data(Dictionary<string, DateTime> daysTimes, DateTime doc_start_time, SqlConnection connection, int flag_first)
        {
            string data_string = "";
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
                for(int counter=0; counter<(3*12); counter++)
                {
                    data_string = available_days[counter]+": "+ start_time[counter].ToString("hh:mm tt")+"-"+ end_time[counter].ToString("hh:mm tt");
                    Time_Slot_Data.Add(counter + 1, data_string);
                    data_string = "";
                }
            }
            else                                                                                        //Doctor has some previous appointments.
            {
                List<string> occupied_days = new List<string>();
                List<DateTime> available_start_time = new List<DateTime>();
                List<DateTime> available_end_time = new List<DateTime>();
                Response.Write("<script>alert('Inside else?!?!');</script>");
                SqlCommand getAppointments = new SqlCommand("SELECT start_time, end_time, appointment_day FROM appointments WHERE doctor_id = '" + doc_ID + "';", connection);
                SqlDataReader dataReader = getAppointments.ExecuteReader();
                while (dataReader.Read())
                {
                    start_time.Add(Convert.ToDateTime(dataReader["start_time"].ToString()));
                    end_time.Add(Convert.ToDateTime(dataReader["end_time"].ToString()));
                    occupied_days.Add(dataReader["appointment_day"].ToString());
                }
                dataReader.Close();
                if (start_time.Count == 1)                                                              //Doctor has only one prior appointment.
                {
                    if(start_time[0] == doc_start_time)                                                 //Appointment at the start of a day
                    {
                        available_start_time.Add(doc_start_time.AddMinutes(15));
                        available_end_time.Add(available_start_time[0].AddMinutes(15));
                        available_days.Add(occupied_days[0]);
                        //Since only 1 appointment at the begining, we have to create 11 slots for this day.
                        for (int slots=1; slots<11; slots++)
                        {
                            available_start_time.Add(available_end_time[slots-1]);
                            available_end_time.Add(available_start_time[slots].AddMinutes(15));
                            available_days.Add(occupied_days[0]);
                        }
                        //Now creating slots for the remaining days i.e the 2 days leftover.
                        for(int day_number=0; day_number<3; day_number++)
                        {
                            if (daysTimes.ElementAt(day_number).Key == occupied_days[0])
                                continue;
                            else
                            {
                                available_days.Add(daysTimes.ElementAt(day_number).Key);
                                available_start_time.Add(doc_start_time);
                                available_end_time.Add(doc_start_time.AddMinutes(15));
                                for (int slots=1; slots<12; slots++)
                                {
                                    available_days.Add(daysTimes.ElementAt(day_number).Key);
                                    available_start_time.Add(available_end_time[slots - 1]);
                                    available_end_time.Add(available_start_time[slots].AddMinutes(15));
                                }
                            }
                        }
                    }
                    else if (end_time[0] == daysTimes.ElementAt(0).Value)                               //Appointment at the end of a day
                    {
                        //Creating slots for the remaining days.
                        for(int day_number = 0; day_number < 3; day_number++)
                        {
                            if (daysTimes.ElementAt(day_number).Key == occupied_days[0])
                                continue;
                            else
                            {
                                available_days.Add(daysTimes.ElementAt(day_number).Key);
                                available_start_time.Add(doc_start_time);
                                available_end_time.Add(doc_start_time.AddMinutes(15));
                                for(int slots=1; slots<12; slots++)
                                {
                                    available_days.Add(daysTimes.ElementAt(day_number).Key);
                                    available_start_time.Add(available_end_time[slots - 1]);
                                    available_end_time.Add(available_start_time[slots].AddMinutes(15));
                                }
                            }
                        }
                        //Creating remaining slots for current day
                        available_start_time.Add(doc_start_time);
                        available_end_time.Add(doc_start_time.AddMinutes(15));
                        available_days.Add(occupied_days[0]);
                        for (int slots=1; slots<11; slots++)
                        {
                            available_start_time.Add(available_end_time[slots - 1]);
                            available_end_time.Add(available_start_time[slots].AddMinutes(15));
                            available_days.Add(occupied_days[0]);
                        }
                    }
                    else                                                                                //Appointment in the middle of a day
                    {
                        available_start_time.Add(doc_start_time);
                        available_end_time.Add(doc_start_time.AddMinutes(15));
                        available_days.Add(occupied_days[0]);
                        int counter = 1;
                        //Creating slots for right and left portions of the day.
                        while (!available_start_time.Contains(start_time[0]))
                        {
                            available_start_time.Add(available_end_time[counter - 1]);
                            available_end_time.Add(available_start_time[counter].AddMinutes(15));
                            available_days.Add(occupied_days[0]);
                            counter++;
                        }
                        available_start_time.Add(end_time[0]);
                        available_end_time.Add(available_start_time[counter].AddMinutes(15));
                        available_days.Add(occupied_days[0]);
                        counter++;
                        while (!available_end_time.Contains(daysTimes.ElementAt(0).Value))
                        {
                            available_start_time.Add(available_end_time[counter - 1]);
                            available_end_time.Add(available_start_time[counter].AddMinutes(15));
                            available_days.Add(occupied_days[0]);
                            counter++;
                        }
                        //Creating slots for the remaining days
                        for (int day_number = 0; day_number < 3; day_number++)
                        {
                            if (daysTimes.ElementAt(day_number).Key == occupied_days[0])
                                continue;
                            else
                            {
                                available_days.Add(daysTimes.ElementAt(day_number).Key);
                                available_start_time.Add(doc_start_time);
                                available_end_time.Add(doc_start_time.AddMinutes(15));
                                for (int slots = 1; slots < 12; slots++)
                                {
                                    available_days.Add(daysTimes.ElementAt(day_number).Key);
                                    available_start_time.Add(available_end_time[slots - 1]);
                                    available_end_time.Add(available_start_time[slots].AddMinutes(15));
                                }
                            }
                        }
                    }
                    //Making the dictionary we will bind to the Time Dropdown List.
                    for (int counter = 0; counter < (3*12)-1; counter++)
                    {
                        data_string = available_days[counter] + ": " + available_start_time[counter].ToString("hh:mm tt") + "-" + available_end_time[counter].ToString("hh:mm tt");
                        Time_Slot_Data.Add(counter + 1, data_string);
                        data_string = "";
                    }
                }
                else                                                                        //Doctor has multiple prior appointments
                {
                    List<double> slot_difference = new List<double>();
                    List<int> index_breaks = new List<int>();                               //To store starting index of each new day
                    index_breaks.Add(0);
                    for(int days=1; days<occupied_days.Count; days++)
                    {
                        if (occupied_days[days] != occupied_days[days - 1])
                            index_breaks.Add(days);
                    }
                    //For each day we must check: (1) start time of 1st appointment, (2) end time of last appointment & (3) any skipped slots in b/w via difference
                    for(int days=0; days<index_breaks.Count; days++)
                    {
                        if (start_time[0] != doc_start_time)
                        {
                            //(1) checking start_time to see if any slots available before
                            available_start_time.Add(doc_start_time);
                            available_end_time.Add(doc_start_time.AddMinutes(15));
                            available_days.Add(occupied_days[index_breaks[days]]);
                            TimeSpan diff = doc_start_time.Subtract(start_time[0]);
                            double available_time = diff.TotalMinutes;
                            double available_slots = available_time / 15;
                            for (int slots = 1; slots < available_slots; slots++)
                            {
                                available_start_time.Add(available_end_time[slots - 1]);
                                available_end_time.Add(available_start_time[slots].AddMinutes(15));
                                available_days.Add(occupied_days[index_breaks[days]]);
                            }
                        }
                        if (end_time[end_time.Count - 1] != daysTimes.ElementAt(0).Value)
                        {
                            //(2) checking end_time to see if any slots available after
                            available_start_time.Add(end_time[end_time.Count - 1]);
                            available_end_time.Add(end_time[end_time.Count - 1].AddMinutes(15));
                            available_days.Add(occupied_days[occupied_days.Count - 1]);
                            TimeSpan diff = daysTimes.ElementAt(0).Value.Subtract(end_time[end_time.Count - 1]);
                            double available_slots = (diff.TotalMinutes) / 15;
                            for (int slots = available_start_time.Count; slots < available_start_time.Count + available_slots; slots++)
                            {
                                available_start_time.Add(available_end_time[slots - 1]);
                                available_end_time.Add(available_start_time[slots].AddMinutes(15));
                                available_days.Add(occupied_days[index_breaks[days]]);
                            }
                        }
                        //(3) checking any slots that may be missing b/w appointments
                        for (int slots = 1; slots < start_time.Count; slots++)
                        {
                            TimeSpan diff = start_time[slots].Subtract(end_time[slots - 1]);
                            double available_slots = (diff.TotalMinutes) / 15;
                            for (int counter = available_start_time.Count; counter < available_start_time.Count + available_slots; counter++)
                            {
                                available_start_time.Add(available_end_time[counter - 1]);
                                available_end_time.Add(available_start_time[counter].AddMinutes(15));
                                available_days.Add(occupied_days[index_breaks[days]]);
                            }
                        }
                    }
                    //Making the dictionary we will bind to the Time Dropdown List.
                    for (int counter = 0; counter < available_start_time.Count; counter++)
                    {
                        data_string = available_days[counter] + ": " + available_start_time[counter].ToString("hh:mm tt") + "-" + available_end_time[counter].ToString("hh:mm tt");
                        Time_Slot_Data.Add(counter + 1, data_string);
                        data_string = "";
                    }
                }
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
        protected string Get_Doc_Dept(SqlConnection connection)
        {
            string id = "";
            SqlCommand getID = new SqlCommand("SELECT department_id FROM doctors WHERE doctor_id = '" + doc_ID + "';", connection);
            SqlDataReader dataReader = getID.ExecuteReader();
            while (dataReader.Read())
            {
                id = dataReader["department_id"].ToString();
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