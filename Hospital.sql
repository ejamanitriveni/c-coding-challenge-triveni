CREATE DATABASE HospitalManagementSystem;

USE HospitalManagementSystem;

-- creating tables
--patients

CREATE TABLE Patients ( 
patient_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
date_of_birth DATE,
gender VARCHAR(10),
contact_number VARCHAR(15),
address VARCHAR(100) );


--Doctors
CREATE TABLE Doctors (
doctor_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
specialization VARCHAR(100),
contact_number VARCHAR(15) );

--Appointments table
CREATE TABLE Appointments (
appointment_id INT PRIMARY KEY,
patient_id INT, doctor_id INT,
appointment_date DATETIME,
description TEXT,
FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) on delete set null,
FOREIGN KEY (doctor_id) REFERENCES Doctors(doctor_id) on delete set null);



-- inserting data
INSERT INTO Patients (patient_id, first_name, last_name, date_of_birth, gender, contact_number, address)
VALUES
(1, 'John', 'Doe', '1990-05-15', 'Male', '123-456-7890', '123 Main St, Cityville, State'),
(2, 'Jane', 'Smith', '1985-08-22', 'Female', '987-654-3210', '456 Oak St, Townsville, State'),
(3, 'Mike', 'Johnson', '1978-12-10', 'Male', '555-123-4567', '789 Pine St, Villagetown, State'),
(4, 'Emily', 'Williams', '1995-04-03', 'Female', '111-222-3333', '321 Elm St, Hamletville, State'),
(5, 'Chris', 'Anderson', '1982-09-18', 'Male', '777-888-9999', '555 Birch St, Suburbia, State'),
(6, 'Sophia', 'Brown', '1998-07-25', 'Female', '444-555-6666', '987 Maple St, Countryside, State'),
(7, 'David', 'Miller', '1970-03-08', 'Male', '999-000-1111', '654 Pineapple St, Beachtown, State'),
(8, 'Olivia', 'Jones', '1989-11-30', 'Female', '222-333-4444', '876 Apple St, Mountainville, State'),
(9, 'Brian', 'Taylor', '1993-06-12', 'Male', '666-777-8888', '234 Cherry St, Riverside, State'),
(10, 'Mia', 'White', '1980-01-20', 'Female', '333-444-5555', '789 Grape St, Hillside, State');


INSERT INTO Doctors (doctor_id, first_name, last_name, specialization, contact_number)
VALUES
(1, 'Dr. Robert', 'Smith', 'Cardiologist', '123-456-7890'),
(2, 'Dr. Sarah', 'Johnson', 'Orthopedic Surgeon', '987-654-3210'),
(3, 'Dr. Michael', 'Williams', 'Pediatrician', '555-123-4567'),
(4, 'Dr. Emily', 'Brown', 'Dermatologist', '111-222-3333'),
(5, 'Dr. Christopher', 'Anderson', 'Oncologist', '777-888-9999'),
(6, 'Dr. Sophia', 'Miller', 'Neurologist', '444-555-6666'),
(7, 'Dr. David', 'Davis', 'Gastroenterologist', '999-000-1111'),
(8, 'Dr. Olivia', 'Taylor', 'Endocrinologist', '222-333-4444'),
(9, 'Dr. Brian', 'Jones', 'Psychiatrist', '666-777-8888'),
(10, 'Dr. Mia', 'White', 'Rheumatologist', '333-444-5555');



INSERT INTO Appointments (appointment_id, patient_id, doctor_id, appointment_date, description)
VALUES
(1, 1, 1, '2023-01-10 09:00:00', 'Routine checkup'),
(2, 2, 3, '2023-02-15 14:30:00', 'Follow-up for previous surgery'),
(3, 3, 5, '2023-03-20 11:45:00', 'Vaccination for child'),
(4, 4, 2, '2023-04-05 10:15:00', 'Skin condition consultation'),
(5, 5, 6, '2023-05-12 13:00:00', 'Cancer treatment discussion'),
(6, 6, 4, '2023-06-18 15:30:00', 'Neurological examination'),
(7, 7, 7, '2023-07-25 08:45:00', 'Digestive issues consultation'),
(8, 8, 9, '2023-08-30 16:15:00', 'Hormone level check'),
(9, 9, 8, '2023-09-10 12:30:00', 'Psychiatric evaluation'),
(10, 10, 10, '2023-10-22 09:30:00', 'Arthritis treatment plan');




select * from Appointments;