using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Exceptions
{

    class PatientNumberNotFoundException : Exception
    {
        public PatientNumberNotFoundException()
        {
        }

        public PatientNumberNotFoundException(string message) : base(message)
        {
        }

        
    }
}