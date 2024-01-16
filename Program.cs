using HMS.DAO;
using HMS.Entity;
using System.Collections.Generic;
using System;
using System.Net.NetworkInformation;

class Program
{
    static void Main()
    {
        try{

        IHospitalService hospitalService = new HospitalServiceimpl();

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1.. Get appointment by ID");
            Console.WriteLine("2. Get appointments for patient");
            Console.WriteLine("3. Get appointments for doctor");
            Console.WriteLine("4. Schedule appointment");
            Console.WriteLine("5. Update appointment");
            Console.WriteLine("6. Cancel appointment");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice 1-6: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                

                case "1":
                    try{
                    Console.Write("Enter appointment ID: ");
                    if (int.TryParse(Console.ReadLine(), out int appointment_id))
                    {
                        Appointment appointment = hospitalService.getAppointmentById(appointment_id);
                        PrintAppointment(appointment);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for appointment ID.");
                    }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message);  }
                    break;

                case "2":
                    try{
                    Console.Write("Enter patient ID: ");
                    if (int.TryParse(Console.ReadLine(), out int appointmentsForPatientId))
                    {
                        Appointment appointment0 = hospitalService.getAppointmentsForPatient(appointmentsForPatientId);
                        PrintAppointment(appointment0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for patient ID.");
                    }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message);  }
                    break;

                case "3":
                    try{
                    Console.Write("Enter doctor ID: ");
                    if (int.TryParse(Console.ReadLine(), out int appointmentsForDoctorId))
                    {
                        Appointment appointment1 = hospitalService.getAppointmentsForDoctor(appointmentsForDoctorId);
                        PrintAppointment(appointment1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for doctor ID.");
                    }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message);  }
                    break;

                case "4":
                    try{
                        
                    Appointment newAppointment = ReadAppointmentDetailsFromUser();
                    hospitalService.scheduleAppointment(newAppointment);
                    Console.WriteLine("Appointment scheduled successfully.");
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message);  }
                    break;

                case "5":
                    try{
                    Console.Write("Enter appointment ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateAppointmentId))
                    {

                        Appointment existingAppointment = hospitalService.getAppointmentById(updateAppointmentId);
                        if (existingAppointment != null)
                        {
                            Appointment updatedAppointment = ReadAppointmentDetailsFromUser();
                            updatedAppointment.appointment_id = existingAppointment.appointment_id;
                            hospitalService.updateAppointment(updatedAppointment);
                            Console.WriteLine("Appointment updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Appointment with ID {updateAppointmentId} not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for appointment ID.");
                    }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message);  }
                    break;

                case "6":
                 try  {
                    Console.Write("Enter appointment ID to delete: ");
                    int deleteAppointmentId = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    string updateAppointmentRes = hospitalService.cancelAppointment(deleteAppointmentId);
                    if (updateAppointmentRes != null)
                    {
                        Console.WriteLine(updateAppointmentRes);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for Appointment ID.");
                    }
                 }
                    catch (Exception ex) { Console.WriteLine(ex.Message);  }
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }}
        catch (Exception ex) { Console.WriteLine(ex.Message);  }
    }
        


    static void PrintAppointment(Appointment appointment)
    {
        try{
        if (appointment != null)
        {
            Console.WriteLine($"Appointment ID: {appointment.appointment_id}");
            Console.WriteLine($"Patient ID: {appointment.patient_id}");
            Console.WriteLine($"Doctor ID: {appointment.doctor_id}");
            Console.WriteLine($"Appointment Date: {appointment.appointment_date}");
            Console.WriteLine($"Description: {appointment.description}");
        }
        else
        {
            Console.WriteLine("Appointment not found.");
        }
    }}
    catch (Exception ex) { Console.WriteLine(ex.Message);  }


    static Appointment ReadAppointmentDetailsFromUser()
    {
        try{
        Appointment appointment = new Appointment();

        Console.Write("Enter Appointment ID: ");
        if (int.TryParse(Console.ReadLine(), out int appointmentId))
        {
            appointment.appointment_id = appointmentId;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for Patient ID.");
        }

        Console.Write("Enter Patient ID: ");
        if (int.TryParse(Console.ReadLine(), out int patientId))
        {
            appointment.patient_id = patientId;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for Patient ID.");
        }

        Console.Write("Enter Doctor ID: ");
        if (int.TryParse(Console.ReadLine(), out int doctor_id))
        {
            appointment.doctor_id = doctor_id;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for Doctor ID.");
        }

        Console.Write("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime appointment_date))
        {
            appointment.appointment_date = appointment_date;
        }
        else
        {
            Console.WriteLine("Invalid date format. Setting Appointment Date to default.");
        }

        Console.Write("Enter Description: ");
        appointment.description = Console.ReadLine();

        return appointment;
    }}
    catch (Exception ex) { Console.WriteLine(ex.Message);  }
}
