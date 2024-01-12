﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class Doctor
    {
        private int doctor_id { get; set; }

        private string first_name { get; set; }
        private string last_name { get; set; }
        private string specialization {  get; set; }
        private string contact_number { get; set; }

        // Default constructor
        public Doctor() { }

        // Parameterized constructor
        public Doctor(int doctor_id, string first_name, string last_name, string specialization, string contact_number)
        {
            this.doctor_id = doctor_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.specialization = specialization;
            this.contact_number = contact_number;
        }
       
    }
}
