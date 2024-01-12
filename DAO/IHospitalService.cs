using HMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAO

{
    public interface IHospitalService
    {
        
        Appointment getAppointmentById(int appointment_id);
        Appointment getAppointmentsForPatient(int patient_id);
        Appointment getAppointmentsForDoctor(int doctor_id);
        void scheduleAppointment(Appointment appointment);
        void updateAppointment(Appointment appointment);
        string cancelAppointment(int appointment_id);
    }
}
