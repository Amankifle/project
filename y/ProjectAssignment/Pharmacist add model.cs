using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssignment
{
    internal class Pharmacist_add_model
    {
        public int id { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String Dateofbirth { get; set; }
        public string Gender { get; set; }
        public String PhoneNo { get; set; }
        public int Experience { get; set; }
        public String Email { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        

        public static List<Pharmacist_add_model> p = new List<Pharmacist_add_model>();
        public static List<Pharmacist_add_model> getallPha()
        {
            List<Pharmacist_add_model> phar = new List<Pharmacist_add_model>();
            Sqlconnection.selectallphar(phar);
            return phar;
        }
        public void save()
        {
            //MessageBox.Show(this.object_name + " has been added successfully!!");
            p.Add(this);
            Sqlconnection.insertphardata(this);

        }


    }
}
