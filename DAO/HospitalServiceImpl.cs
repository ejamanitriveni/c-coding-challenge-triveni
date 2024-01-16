using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Entity;
using HMS.Util;
using System.Data.SqlClient;
using HMS.Exceptions;
using System.Data.Common;

namespace HMS.DAO
{
    public class HospitalServiceimpl : IHospitalService
    {

        SqlConnection conn;
        SqlCommand cmd = null;

        public HospitalServiceDao()
        {
                cmd = new SqlCommand();
        }
       

        public Appointment getAppointmentById(int appointment_id)
        {
        try{
            Appointment appointment = null;

            using (SqlConnection connection = DBConnUtil.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE appointment_id = @appointment_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@appointment_id", appointment_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            appointment = new Appointment
                            {
                                appointment_id = (int)reader["appointment_id"],
                                patient_id = (int)reader["patient_id"],
                                doctor_id = (int)reader["doctor_id"],
                                appointment_date = Convert.ToDateTime(reader["appointment_date"]),
                                description = reader["description"].ToString()
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Appointment With id {appointment_id} not found.");
                        }
                    }
                }  
            }
            return appointment;
            }
            catch(Exception e)
            {
             Console.WriteLine(ex.Message);}
            

        }

        public Appointment getAppointmentsForPatient(int patient_id)
        {
            try{
            Appointment appointment = null;

            using (SqlConnection connection = DBConnUtil.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE patient_id = @patient_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@patient_id", patient_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            appointment = new Appointment
                            {
                                appointment_id = (int)reader["appointment_id"],
                                patient_id = (int)reader["patient_id"],
                                doctor_id = (int)reader["doctor_id"],
                                appointment_date = Convert.ToDateTime(reader["appointment_date"]),
                                description = reader["description"].ToString()
                            };
                        }
                        else
                        {
                        throw new PatientNotFoundException("Invalid patient Id");
                            
                        }
                    }
                }
            }
            return appointment;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);  }


        }

        public Appointment getAppointmentsForDoctor(int doctor_id)
        {
        try{
            Appointment appointment = null;

            using (SqlConnection connection = DBConnUtil.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE doctor_id = @doctor_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@doctor_id", doctor_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            appointment = new Appointment
                            {
                                appointment_id = (int)reader["appointment_id"],
                                patient_id = (int)reader["patient_id"],
                                doctor_id = (int)reader["doctor_id"],
                                appointment_date = Convert.ToDateTime(reader["appointment_date"]),
                                description = reader["description"].ToString()
                            };
                        }
                        else
                        {
                            Console.WriteLine($"Appointment With id {doctor_id} not found.");
                        }
                    }
                }
            }
            return appointment;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);  }


        }

        public void scheduleAppointment(Appointment appointment)
        {
        try{
            using (SqlConnection connection = DBConnUtil.GetConnection())
            {
                
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO Appointments (appointment_id, patient_id, doctor_id, appointment_date, description) VALUES (@appointment_id, @patient_id, @doctor_id, @appointment_date, @Description)";
                command.Parameters.AddWithValue("@appointment_id", appointment.appointment_id);
                command.Parameters.AddWithValue("@patient_id", appointment.patient_id);
                command.Parameters.AddWithValue("@doctor_id", appointment.doctor_id);
                command.Parameters.AddWithValue("@appointment_date", appointment.appointment_date);
                command.Parameters.AddWithValue("@Description", appointment.description);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);  }
        }

        public void updateAppointment(Appointment appointment)
        {
        try{
            using (SqlConnection connection = DBConnUtil.GetConnection())
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE Appointments SET patient_id = @patient_id, doctor_id = @doctor_id, appointment_date = @appointment_date, description = @description WHERE appointment_id = @appointment_id";
                command.Parameters.AddWithValue("@appointment_id", appointment.appointment_id);
                command.Parameters.AddWithValue("@patient_id", appointment.patient_id);
                command.Parameters.AddWithValue("@doctor_id", appointment.doctor_id);
                command.Parameters.AddWithValue("@appointment_date", appointment.appointment_date);
                command.Parameters.AddWithValue("@description", appointment.description);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);  }
        }

        public string cancelAppointment(int appointment_id)
        {
        try{
            string response = null;
            using (SqlConnection connection = DBConnUtil.GetConnection())
            {
                cmd = new SqlCommand();
                cmd.CommandText = ("DELETE FROM Appointments WHERE appointment_id = @appointment_id");
                cmd.Parameters.AddWithValue("@appointment_id", appointment_id);
                cmd.Connection = connection;
                connection.Open();
                int cancelAppointmentID = cmd.ExecuteNonQuery();
                if (cancelAppointmentID > 0)
                {
                    response = $"Data of Appointment having ID : {appointment_id} has been deleted succefully.";

                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
            return response;
        }
    }
    }

    catch (Exception ex) { Console.WriteLine(ex.Message);  }
}


