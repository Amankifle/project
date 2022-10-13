using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssignment
{
    internal class Patient_model
    {
        public int id { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String PhoneNo { get; set; }
        public String Gender { get; set; }
        public String Dateofbirth { get; set; }
        public String Address { get; set; }
        public String Blood_Group { get; set; }
        public String Email { get; set; }

        private static List<Patient_model> patient = new List<Patient_model>();
        public static List<Patient_model> getallPatient()
        {
            List<Patient_model> patient = new List<Patient_model>();
            Sqlconnection.selectallpatient(patient);
            return patient;
        }
        public bool AddPatient()
        {
            
            //insert to database 
            patient.Add(this);
            Boolean b=Sqlconnection.insertpatient(this);
            return b;
        }
    }
}
