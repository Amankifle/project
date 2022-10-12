using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssignment
{
    internal class PatientTest
    {
        public int id { get; set; }
        public string bloodtest { get; set; }
		public string cbc { get; set; }
		public string bun { get; set; }
		public string electrolyte { get; set; }
		public string cholestrol { get; set; }
		public string creatanine { get; set; }
		public string glucose { get; set; }
		public string uric { get; set; }
		public string medication { get; set; }
		public string diagnosis { get; set; }
        public string Symptom { get; set; } 
        public int pid { get; set; }
		public int tested { get; set; }
        public String dose { get; set; }
        public void set()
        {
            bloodtest = " ";
             cbc = " ";
         bun = " ";
       electrolyte = " ";
       cholestrol = " ";
         creatanine = " ";
       glucose = " ";
       uric = " ";
       medication = " ";
            dose = " ";
        }
        public bool AddPatientTest()
        {
            //insert to database 
            Boolean b = Sqlconnection.insertpatientTest(this);
            return b;
        }
    }
}
