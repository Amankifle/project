using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssignment
{
    internal class Doctorclass
    {
        public int id { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String Dateofbirth { get; set; }
        public string Gender { get; set; }
        public String PhoneNo { get; set; }
        public int Experience { get; set; }
        public String Specialisation { get; set; }
        public String Email { get; set; }
        public String user { get; set; }
        public String pass { get; set; }

        public  Doctorclass()
        {
            
        }
        private static List<Doctorclass> Doctors = new List<Doctorclass>();
        public static List<Doctorclass> getallDoctor()
        {
            List<Doctorclass> Doctors = new List<Doctorclass>();
            Sqlconnection.selectalldoctor(Doctors);
            return Doctors;
        }
        public void AddDoctor()
        {
            //insert to database 
            Doctors.Add(this);
            Sqlconnection.insertdoctor(this);
        }
        //private static void AddDoctortolist()
        //{

        //    Doctors=Sqlconnection.selectalldoctor();
        //}

  
    }
}
