using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssignment
{
    internal class Lab_model
    {
        public int id { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String Dateofbirth { get; set; }
        public String Gender { get; set; }
        public String PhoneNo { get; set; }
        public int Experience { get; set; }
        public String Specialisation { get; set; }
        public String Email { get; set; }
        public String user { get; set; }
        public String pass { get; set; }

        public static List<Lab_model> p = new List<Lab_model>();
        public static List<Lab_model> getallLab()
        {
            List<Lab_model> p = new List<Lab_model>();
            Sqlconnection.selectallLab(p);
            return p;
        }
    
        public void save()
        {
            //MessageBox.Show(this.object_name + " has been added successfully!!");
            p.Add(this);
            Sqlconnection.insertlabdata(this);

        }




    }
}
