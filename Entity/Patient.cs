using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class Patient
    {
        public int patient_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
        public string contact_number { get; set; }
        public string address { get; set; }

        // Default constructor
        public Patient() { }
        // Parameterized constructor
        public Patient(int patient_id, string first_name, string last_name, DateTime date_of_birth, string gender, string contact_number, string address)
        {
            this.patient_id = patient_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.date_of_birth = date_of_birth;
            this.gender = gender;
            this.contact_number = contact_number;
            this.address = address;
        }


    }
}
