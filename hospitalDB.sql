
CREATE DATABASE hospital_management;

  use hospital_management;

  CREATE TABLE bill (
    invoice_num VARCHAR(5) PRIMARY KEY,
    user_id VARCHAR(5),                          
    total_payment FLOAT                
  );
  ALTER TABLE bill DROP FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE RESTRICT ON UPDATE CASCADE;CREATE DATABASE hospital_management;
  use hospital_management;

  CREATE TABLE blood_bank (
    blood_type VARCHAR(3) PRIMARY KEY,
    units_remaining INT,
  );
  CREATE TABLE departments (
    dept_id VARCHAR(5) PRIMARY KEY,
    dept_name VARCHAR(25) NOT NULL,
    dept_number VARCHAR(11) NOT NULL,
    dept_email VARCHAR(50) NOT NULL
  );
  CREATE TABLE working_days (
    working_days_code VARCHAR(5) PRIMARY KEY,
    day_one VARCHAR(15) NOT NULL,
    day_two VARCHAR(15) NOT NULL,
    day_three VARCHAR(15) NOT NULL,
  );
  CREATE TABLE shifts (
    shift_num VARCHAR(5) PRIMARY KEY,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    working_days_code VARCHAR(5)                 --FK to working_days table
  );
  ALTER TABLE shifts ADD FOREIGN KEY (working_days_code) REFERENCES working_days(working_days_code) ON DELETE CASCADE ON UPDATE CASCADE;

  CREATE TABLE patients (
    patient_id VARCHAR(5) PRIMARY KEY,
    fname VARCHAR(25) NOT NULL,
    lname VARCHAR(25) NOT NULL,
    age INT NOT NULL,
    gender VARCHAR(10) NOT NULL,
    phone VARCHAR(11) NOT NULL,
    current_address VARCHAR(50) NOT NULL,
    blood_type VARCHAR(3) NOT NULL,              --FK to blood_bank table? No
    patient_email VARCHAR(50) NOT NULL,
    patient_password VARCHAR(50) UNIQUE NOT NULL
  );
  CREATE TABLE doctors (
    doctor_id VARCHAR(5) PRIMARY KEY,
    fname VARCHAR(25) NOT NULL,
    lname VARCHAR(25) NOT NULL,
    gender VARCHAR(10) NOT NULL,
    dept_id VARCHAR(5) NOT NULL,                 --FK to departments table
    shift_num VARCHAR(5) NOT NULL,               --FK to shifts table
    charges INT NOT NULL,
    dr_email VARCHAR(50) NOT NULL,
    dr_password VARCHAR(50) UNIQUE NOT NULL
  );
  ALTER TABLE doctors ADD FOREIGN KEY (dept_id) REFERENCES departments(dept_id) ON DELETE CASCADE ON UPDATE CASCADE;
  ALTER TABLE doctors ADD FOREIGN KEY (shift_num) REFERENCES shifts(shift_num) ON DELETE CASCADE ON UPDATE CASCADE;

  CREATE TABLE nurses (
    nurse_id VARCHAR(5) PRIMARY KEY,
    fname VARCHAR(25) NOT NULL,
    lname VARCHAR(25) NOT NULL,
    gender VARCHAR(10) NOT NULL,
    dept_id VARCHAR(5) NOT NULL,                 --FK to dpartments table
    shift_num VARCHAR(5) NOT NULL,               --FK to shifts table
    charges INT NOT NULL,
    nurse_email VARCHAR(50) NOT NULL,
    nurse_password VARCHAR(50) UNIQUE NOT NULL
  );
  ALTER TABLE nurses ADD FOREIGN KEY (dept_id) REFERENCES departments(dept_id) ON DELETE CASCADE ON UPDATE CASCADE;
  ALTER TABLE nurses ADD FOREIGN KEY (shift_num) REFERENCES shifts(shift_num) ON DELETE CASCADE ON UPDATE CASCADE;

  CREATE TABLE users (
    user_id VARCHAR(5) PRIMARY KEY,              --Do NOT add FK to nurses, doctors and patients table
    user_email VARCHAR(50) NOT NULL,
    user_password VARCHAR(50) UNIQUE NOT NULL,
    user_date TIMESTAMP
  );
  
  CREATE TABLE appointment_info (
    appointment_type VARCHAR(5) PRIMARY KEY,
    appointment_name VARCHAR(25) NOT NULL,
    duration TIME,
    charges INT NOT NULL
  );
  CREATE TABLE rooms (
    room_id VARCHAR(5) PRIMARY KEY,
    room_type VARCHAR(25) NOT NULL,
    charges INT NOT NULL
  );
  CREATE TABLE appointments (
    appointment_num VARCHAR(5) PRIMARY KEY,
    appointment_type VARCHAR(5) NOT NULL,        --FK to appointment_info table
    patient_id VARCHAR(5) NOT NULL,              --FK to patients table
    doctor_id VARCHAR(5) NOT NULL,               --FK to doctors table
    nurse_id VARCHAR(5),                         --FK to nurses table
    room_id VARCHAR(5) NOT NULL,                 --FK to rooms table
    start_time TIME NOT NULL,
    end_time TIME,                      --DERIVED from appointment_info.duration + appointments.start_time
    app_date DATE NOT NULL,
    charges INT                         --DERIVED from appointment_info.charges + rooms.charges + nurses.charges + doctors.charges
  );
  ALTER TABLE appointments ADD FOREIGN KEY (appointment_num) REFERENCES appointment_info(appointment_type) ON DELETE RESTRICT ON UPDATE RESTRICT;
  ALTER TABLE appointments ADD FOREIGN KEY (patient_id) REFERENCES patients(patient_id) ON DELETE CASCADE ON UPDATE CASCADE;
  ALTER TABLE appointments ADD FOREIGN KEY (nurse_id) REFERENCES nurses(nurse_id) ON DELETE RESTRICT ON UPDATE CASCADE;
  ALTER TABLE appointments ADD FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id) ON DELETE RESTRICT ON UPDATE CASCADE;
  ALTER TABLE appointments ADD FOREIGN KEY (room_id) REFERENCES rooms(room_id) ON DELETE RESTRICT ON UPDATE CASCADE;

  ALTER TABLE `appointments` CHANGE `app_date` `app_day` VARCHAR(25) NOT NULL;


  CREATE TABLE donations (
    donor_id VARCHAR(5),                         --FK to users table
    donation_date TIMESTAMP,
    blood_type VARCHAR(3) NOT NULL,              --FK to blood_bank table
    PRIMARY KEY (donor_id, donation_date)
  );
  ALTER TABLE donations ADD FOREIGN KEY (donor_id) REFERENCES users(user_id) ON DELETE CASCADE ON UPDATE CASCADE;
  ALTER TABLE donations ADD FOREIGN KEY (blood_type) REFERENCES blood_bank(blood_type) ON DELETE RESTRICT ON UPDATE RESTRICT;

  CREATE TABLE cafeteria (
    food_name VARCHAR(25) PRIMARY KEY,
    food_type VARCHAR(25) NOT NULL,
    amount_in_stock INT,
    price FLOAT 
  );
  CREATE TABLE cafe_order (
    order_id VARCHAR(5) PRIMARY KEY,
    ordered_by VARCHAR(5) NOT NULL,              --X--(Remove)FK to doctors/nurses table
    to_room VARCHAR(5),                          --FK to rooms table
    order_time TIMESTAMP,
    charges FLOAT                       --DERIVED from cafeteria.price x order_info.qty
  );
  Ispe bola tha errors arahay hain tou change and add users
( ALTER TABLE cafe_order ADD FOREIGN KEY (ordered_by) REFERENCES doctors(doctor_id) ON DELETE CASCADE ON UPDATE CASCADE;
  ALTER TABLE cafe_order ADD FOREIGN KEY (ordered_by) REFERENCES nurses(nurse_id) ON DELETE CASCADE ON UPDATE CASCADE;) ) => ALTER TABLE cafe_order ADD FOREIGN KEY (ordered_by) REFERENCES users(user_id) ON DELETE CASCADE ON UPDATE CASCADE;

  ALTER TABLE cafe_order ADD FOREIGN KEY (to_room) REFERENCES rooms(room_id) ON DELETE RESTRICT ON UPDATE CASCADE;

  CREATE TABLE order_info (
    order_id VARCHAR(5),                         --FK to cafe_order table
    food_name VARCHAR(25),                       --FK to cafeteria table
    qty INT,
    PRIMARY KEY (order_id,food_name)
  );
  ALTER TABLE order_info ADD FOREIGN KEY (order_id) REFERENCES cafe_order(order_id) ON DELETE CASCADE ON UPDATE CASCADE;
  ALTER TABLE order_info ADD FOREIGN KEY (food_name) REFERENCES cafeteria(food_name) ON DELETE CASCADE ON UPDATE CASCADE;

  CREATE TABLE test (
    test_name VARCHAR(25) PRIMARY KEY,
    lab_num VARCHAR(5),                          --FK to rooms table
    charges FLOAT
  );
  ALTER TABLE test ADD FOREIGN KEY (lab_num) REFERENCES rooms(room_id) ON DELETE RESTRICT ON UPDATE CASCADE;

  CREATE TABLE test_ordered (
    test_id VARCHAR(5) PRIMARY KEY,
    test_name VARCHAR(25),                       --FK to tests table
    charges FLOAT,                      --DERIVED from test.charges
    patient_id VARCHAR(5),                       --FK to patients table
    doctor_reffered VARCHAR(5),                  --FK to doctors table
    scheduled_date DATETIME,
  );
  ALTER TABLE test_ordered ADD FOREIGN KEY (test_name) REFERENCES tests(test_name) ON DELETE RESTRICT ON UPDATE CASCADE;
  ALTER TABLE test_ordered ADD FOREIGN KEY (patient_id) REFERENCES patients(patient_id) ON DELETE CASCADE ON UPDATE CASCADE;
  ALTER TABLE test_ordered ADD FOREIGN KEY (doctor_reffered) REFERENCES doctors(doctor_id) ON DELETE RESTRICT ON UPDATE CASCADE;
  
  CREATE TABLE admittance (
    patient_id VARCHAR(5),                       --FK to patients table
    date_admitted DATETIME,
    date_discharged DATETIME,
    room_num VARCHAR(5),                         --FK to rooms table
    charges FLOAT,                     --DERIVED from (self.date_discharged - self.date_admitted) x rooms.charges
    PRIMARY KEY (patient_id,date_admitted)
  );
  ALTER TABLE admittance ADD FOREIGN KEY (patient_id) REFERENCES patients(patient_id) ON DELETE CASCADE ON UPDATE CASCADE;
  ALTER TABLE admittance ADD FOREIGN KEY (room_num) REFERENCES rooms(room_id) ON DELETE RESTRICT ON UPDATE CASCADE;
  
  CREATE TABLE bill (
    invoice_num VARCHAR(5) PRIMARY KEY,
    user_id VARCHAR(5),                          
    total_payment FLOAT                
  );
  ALTER TABLE bill DROP FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE RESTRICT ON UPDATE CASCADE;
