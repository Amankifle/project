using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssignment
{
    internal class Rec_model
    {
        public int id { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String Dateofbirth { get; set; }
        public string Gender { get; set; }
        public String PhoneNo { get; set; }
        public int Experience { get; set; }
       
        public String Email { get; set; }
        public String username { get; set; }
        public String password { get; set; }


        public static List<Rec_model> p = new List<Rec_model>();
        public static List<Rec_model> getallrec()
        {

            List<Rec_model> rec = new List<Rec_model>();
            Sqlconnection.selectallrec(rec);
            return rec;

        }

        public void save()
        {
            //MessageBox.Show(this.object_name + " has been added successfully!!");
            p.Add(this);
            Sqlconnection.insertrecdata(this);

        }


    }
   
}
