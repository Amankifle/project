using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAssignment
{
    internal  class Sqlconnection
    {
       static  SqlConnection con;
        public static void connection()
        {
            string cs = @"server =. ;database=Hospital_project;integrated security= true";
            con = new SqlConnection(cs);

            try
            {
                con.Open();
                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public static Boolean selectdoctor(string user, string pass)

        {
            Boolean b = false;
            try
            {
                connection();
                string sql = "select * from doctor";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    string username = res["username"].ToString();
                    string password = res["password"].ToString();
                    if (username == user && password == pass)
                    {

                        b = true;
                    }

                }
                con.Close();

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static Boolean selectreception(string user, string pass)

        {
            Boolean b = false;
            try
            {
                connection();
                string sql = "select * from reception";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    string username = res["username"].ToString();
                    string password = res["password"].ToString();
                    if (username == user && password == pass)
                    {

                        b = true;
                    }

                }
                con.Close();

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static Boolean selectpharmacist(string user, string pass)

        {
            Boolean b = false;
            try
            {
                connection();
                string sql = "select * from pharmacist";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    string username = res["username"].ToString();
                    string password = res["password"].ToString();
                    if (username == user && password == pass)
                    {

                        b = true;
                    }

                }
                con.Close();

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static Boolean selectlaboratory(string user, string pass)

        {
            Boolean b = false;
            try
            {
                connection();
                string sql = "select * from laboratory";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    string username = res["username"].ToString();
                    string password = res["password"].ToString();
                    if (username == user && password == pass)
                    {

                        b = true;
                    }

                }
                con.Close();

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static Boolean selectpatientTest(int id)
        {
            Boolean b = false;
            try
            {
                connection();
                string sql = "select * from Patienttest";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    int  pid = int.Parse(res["pid"].ToString());
                   
                    if (pid==id)
                    {
                        b = true;
                        return b;
                    }

                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return b;

        }

        public static int checkpatientTest(int id)
        {
            int b=0;
            try
            {
                connection();
                string sql = "select * from Patienttest";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    int pid = int.Parse(res["pid"].ToString());

                    if (pid == id)
                    {
                        return int.Parse(res["tested"].ToString());
                    }

                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return b;

        }


        public static void selectallrec(List<Rec_model> reclist)
        {
            try
            {
                connection();
                string sql = "select * from reception";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    Rec_model d = new Rec_model();
                    d.id = int.Parse(res["id"].ToString());
                    d.FName = res[1].ToString();
                    d.LName = res[2].ToString();
                    d.Dateofbirth = res[3].ToString();
                    d.Gender = res[4].ToString();
                    d.PhoneNo = res[5].ToString();
                    d.Email = res[6].ToString();
                    d.Experience = int.Parse(res[7].ToString());
                    d.username = res[8].ToString();
                    d.password = res[9].ToString();
                    reclist.Add(d);
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        } 
        public static void selectallphar(List<Pharmacist_add_model> phalist)
        {
            try
            {
                connection();
                string sql = "select * from pharmacist";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    Pharmacist_add_model d = new Pharmacist_add_model();
                    d.id = int.Parse(res["id"].ToString());
                    d.FName = res[1].ToString();
                    d.LName = res[2].ToString();
                    d.Dateofbirth = res[3].ToString();
                    d.Gender = res[4].ToString();
                    d.PhoneNo = res[5].ToString();
                    d.Email = res[6].ToString();
                    d.Experience = int.Parse(res[7].ToString());
                    d.user = res[8].ToString();
                    d.pass = res[9].ToString();

                    phalist.Add(d);
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void selectallLab(List<Lab_model> Lablist)
        {
            try
            {
                connection();
                string sql = "select * from laboratory";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();

                while (res.Read()) 
                {
                    Lab_model d = new Lab_model();
                    d.id = int.Parse(res["id"].ToString());
                    d.FName = res[1].ToString();
                    d.LName = res[2].ToString();
                    d.Dateofbirth = res[3].ToString();
                    d.Gender = res[4].ToString();
                    d.PhoneNo = res[5].ToString();
                    d.Email = res[6].ToString();
                    d.Experience = int.Parse(res[7].ToString());
                    d.Specialisation = res[8].ToString();
                    d.user = res[9].ToString();
                    d.pass = res[10].ToString();

                    Lablist.Add(d);
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void selectalldoctor(List<Doctorclass> doctorlist)
        {            
            
            try
            {
                connection();
                string sql = "select * from doctor";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
               
                while (res.Read())
                {
                    Doctorclass d = new Doctorclass();
                    d.id = int.Parse(res["id"].ToString());                   
                    d.FName = res[1].ToString();
                    d.LName = res[2].ToString();
                    d.Dateofbirth = res[3].ToString();
                    d.Gender = res[4].ToString();
                    d.PhoneNo = res[5].ToString();
                    d.Email= res[6].ToString();
                    d.Experience = int.Parse(res[7].ToString());
                    d.Specialisation = res[8].ToString();
                    d.user = res[9].ToString();
                    d.pass = res[10].ToString();
                    
                    doctorlist.Add(d);
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public static void selectallpatient(List<Patient_model> patientlist)
        {
            try
            {
                connection();
                string sql = "select * from Patient";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    Patient_model d = new Patient_model();
                    d.id =int.Parse(res["id"].ToString());
                    d.FName = res[1].ToString();
                    d.LName = res[2].ToString();
                    d.Dateofbirth = res[3].ToString();
                    d.Address = res[4].ToString();
                    d.Blood_Group = res[5].ToString();
                    d.Gender = res[6].ToString();
                    d.PhoneNo = res[7].ToString();
                    d.Email = res[8].ToString();
                    patientlist.Add(d);
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static Patient_model selectspecificpatient(int id)
        {
            Patient_model d =null;
            try
            {
                connection();
                string sql = "select * from Patient where id='"+id+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                res.Read();
                   d = new Patient_model();
                    d.id = int.Parse(res["id"].ToString());
                    d.FName = res[1].ToString();
                    d.LName = res[2].ToString();
                    d.Dateofbirth = res[3].ToString();
                    d.Address = res[4].ToString();
                    d.Blood_Group = res[5].ToString();
                    d.Gender = res[6].ToString();
                    d.PhoneNo = res[7].ToString();
                    d.Email = res[8].ToString();
                con.Close();
            }
            catch (Exception e)
            {
                return null;
                
            }
            return d;
        }








        public static Boolean insertpatientTest(PatientTest p)
        {
            string sql = "insert into Patienttest values(@bloodtest,@cbc,@bun," +
                "@electrolyte,@cholestrol,@creatanine,@glucose,@uric,@medication,@dose,@diagnosis,@Symptom,@pid,@tested)";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@bloodtest", p.bloodtest);
                cmd.Parameters.AddWithValue("@cbc", p.cbc);
                cmd.Parameters.AddWithValue("@bun", p.bun);
                cmd.Parameters.AddWithValue("@electrolyte", p.electrolyte);
                cmd.Parameters.AddWithValue("@cholestrol", p.cholestrol);
                cmd.Parameters.AddWithValue("@creatanine", p.creatanine);
                cmd.Parameters.AddWithValue("@glucose", p.glucose);
                cmd.Parameters.AddWithValue("@uric", p.uric);
                cmd.Parameters.AddWithValue("@medication", p.medication);
                cmd.Parameters.AddWithValue("@dose", p.dose);
                cmd.Parameters.AddWithValue("@diagnosis", p.diagnosis);
                cmd.Parameters.AddWithValue("@Symptom",p.Symptom);
                cmd.Parameters.AddWithValue("@pid", p.pid);
                cmd.Parameters.AddWithValue("@tested", p.tested);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Doctor test has been Registered Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                b = false;
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static PatientTest selectpatienttest( int id)
        {
            PatientTest p = new PatientTest();
            try
            {
                connection();
                string sql = "select * from Patienttest where pid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                res.Read();
                p.id = int.Parse(res["id"].ToString());
                p.bloodtest = res[1].ToString();
                p.cbc = res[2].ToString();
                p.bun = res[3].ToString();
                p.electrolyte = res[4].ToString();
                p.cholestrol = res[5].ToString();
                p.creatanine = res[6].ToString();
                p.glucose = res[7].ToString();
                p.uric = res[8].ToString();
                p.medication = res[9].ToString();
                p.dose =res[10].ToString();
                p.diagnosis = res[11].ToString();
                p.Symptom = res[12].ToString();
                p.pid = int.Parse(res[13].ToString());
                p.tested = int.Parse(res[14].ToString());

                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return p;
        }
        public static List<PatientTest> selectallpatienttest()
        {
            List<PatientTest> list = new List<PatientTest>();
            try
            {
                connection();
                string sql = "select * from Patienttest";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    PatientTest p = new PatientTest();
                    p.id = int.Parse(res["id"].ToString());
                    p.bloodtest = res[1].ToString();
                    p.cbc = res[2].ToString();
                    p.bun = res[3].ToString();
                    p.electrolyte = res[4].ToString();
                    p.cholestrol = res[5].ToString();
                    p.creatanine = res[6].ToString();
                    p.glucose = res[7].ToString();
                    p.uric = res[8].ToString();
                    p.medication = res[9].ToString();
                    p.dose = res[10].ToString();
                    p.diagnosis = res[11].ToString();
                    p.Symptom = res[12].ToString();
                    p.pid = int.Parse(res[13].ToString());
                    p.tested = int.Parse(res[14].ToString());
                    list.Add(p);
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return list;
        }
        public static Class2 selectpatienttestDoc(int id)
        {
            Class2 p = new Class2();
            SqlDataReader res = null;
            try
            {
                connection();
                string sql = "select id,bloodtest,cbc,bun,electrolyte,cholestrol,creatanine,glucose,uric from Patienttest where pid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                res = cmd.ExecuteReader();
                res.Read();
                p.id = int.Parse(res["id"].ToString());
                p.bloodtest = res[1].ToString();
                p.cbc = res[2].ToString();
                p.bun = res[3].ToString();
                p.electrolyte = res[4].ToString();
                p.cholestrol = res[5].ToString();
                p.creatanine = res[6].ToString();
                p.glucose = res[7].ToString();
                p.uric = res[8].ToString();
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return p;
        }
        public static Boolean updatetest(int id, string medication,string newdiagnosis,string dose)
        {
            Boolean b = false;
            try
            {
                connection();
                string sql = "update Patienttest set medication='" + medication + "',diagnosis='" + newdiagnosis + "',dose='" + dose + "' where pid ='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"patient result has been updated Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in updating");
            }
            return b;

        }
        public static Boolean updatetestResult(PatientTest p)
        {
            Boolean b = false;
            try
            {
                connection();
                string sql = "update Patienttest set bloodtest='" + p.bloodtest + "',cbc='" + p.cbc + "' " +
                    ",bun='" + p.bun + "' ,electrolyte='" + p.electrolyte + "' ,cholestrol='" + p.cholestrol + "' ,creatanine='" + p.creatanine + "',glucose='" + p.glucose + "' " +
                    ",uric='" + p.uric + "' ,tested='" + p.tested + "' where pid ='" + p.pid + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"patient result has been updated Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in updating");
            }
            return b;

        }

        public static void selectmedication(PatientTest d)
        {
            try
            {
                connection();
                string sql = "select * from patienttest where pid ='" + d.pid + "' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    d.medication = res[9].ToString();
                    d.dose = res[10].ToString().ToLower();
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }





        public static Boolean insertdoctor(Doctorclass doc)

        {
            string sql = "insert into doctor values(@FirstName,@LastName,@Dateofbirth,@Gender,@PhoneNo,@Email,@Experience,@Specialisation,@username,@password)";
            Boolean b = false;

            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", doc.FName);
                cmd.Parameters.AddWithValue("@LastName", doc.LName);
                cmd.Parameters.AddWithValue("@Dateofbirth", doc.Dateofbirth);
                cmd.Parameters.AddWithValue("@Gender", doc.Gender);
                cmd.Parameters.AddWithValue("@PhoneNo", doc.PhoneNo);
                cmd.Parameters.AddWithValue("@Email", doc.Email);
                cmd.Parameters.AddWithValue("@Specialisation", doc.Specialisation);
                cmd.Parameters.AddWithValue("@Experience", doc.Experience);
                cmd.Parameters.AddWithValue("@username", doc.user);
                cmd.Parameters.AddWithValue("@password", doc.pass);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Doctor {doc.FName + " " + doc.LName} has been Registered Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                b = false;
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static Boolean insertlabdata(Lab_model doc)

        {
            string sql = "insert into laboratory values(@FirstName,@LastName,@Dateofbirth,@Gender,@PhoneNo,@Email,@Experience,@Specialisation,@username,@password)";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", doc.FName);
                cmd.Parameters.AddWithValue("@LastName", doc.LName);
                cmd.Parameters.AddWithValue("@Dateofbirth", doc.Dateofbirth);
                cmd.Parameters.AddWithValue("@Gender", doc.Gender);
                cmd.Parameters.AddWithValue("@PhoneNo", doc.PhoneNo);
                cmd.Parameters.AddWithValue("@Email", doc.Email);
                cmd.Parameters.AddWithValue("@Specialisation", doc.Specialisation);
                cmd.Parameters.AddWithValue("@Experience", doc.Experience);
                cmd.Parameters.AddWithValue("@username", doc.user);
                cmd.Parameters.AddWithValue("@password", doc.pass);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    
                    MessageBox.Show($"laboratorist {doc.FName +" "+ doc.LName} has been Registered Successfully");
                    
                 
                    b = true;
                }
                con.Close();

            }
            catch (SqlException e)
            {
                b = false;
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static Boolean insertphardata(Pharmacist_add_model doc)

        {
            string sql = "insert into pharmacist values(@FirstName,@LastName,@Dateofbirth,@Gender,@PhoneNo,@Email,@Experience,@username,@password)";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", doc.FName);
                cmd.Parameters.AddWithValue("@LastName", doc.LName);
                cmd.Parameters.AddWithValue("@Dateofbirth", doc.Dateofbirth);
                cmd.Parameters.AddWithValue("@Gender", doc.Gender);
                cmd.Parameters.AddWithValue("@PhoneNo", doc.PhoneNo);
                cmd.Parameters.AddWithValue("@Email", doc.Email);
                cmd.Parameters.AddWithValue("@Experience", doc.Experience);
                cmd.Parameters.AddWithValue("@username", doc.user);
                cmd.Parameters.AddWithValue("@password", doc.pass);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {

                    MessageBox.Show($"Pharmacist {doc.FName +" "+ doc.LName} has been Registered Successfully");

                  
                    b = true;
                }
                con.Close();

            }
            catch (SqlException e)
            {
                b = false;
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static Boolean insertrecdata(Rec_model doc)

        {
            string sql = "insert into reception values(@FirstName,@LastName,@Dateofbirth,@Gender,@PhoneNo,@Email,@Experience,@username,@password)";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", doc.FName);
                cmd.Parameters.AddWithValue("@LastName", doc.LName);
                cmd.Parameters.AddWithValue("@Dateofbirth", doc.Dateofbirth);
                cmd.Parameters.AddWithValue("@Gender", doc.Gender);
                cmd.Parameters.AddWithValue("@PhoneNo", doc.PhoneNo);
                cmd.Parameters.AddWithValue("@Email", doc.Email);
                cmd.Parameters.AddWithValue("@Experience", doc.Experience);
                cmd.Parameters.AddWithValue("@username", doc.username);
                cmd.Parameters.AddWithValue("@password", doc.password);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {

                    MessageBox.Show($"receptionist {doc.FName +" "+ doc.LName} has been Registered Successfully");

                   
                    b = true;
                }

                con.Close();
            }
            catch (SqlException e)
            {
                b = false;
                MessageBox.Show(e.Message);
            }
            return b;

        }
        public static Boolean insertpatient(Patient_model doc)

        {
            int id = 0;
            string sql = "insert into patient values(@FirstName,@LastName,@Dateofbirth,@Address,@Blood_Group,@Gender,@PhoneNo,@Email)";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", doc.FName);
                cmd.Parameters.AddWithValue("@LastName", doc.LName);
                cmd.Parameters.AddWithValue("@Dateofbirth", doc.Dateofbirth);
                cmd.Parameters.AddWithValue("@Address", doc.Address);
                cmd.Parameters.AddWithValue("@Blood_Group", doc.Blood_Group);
                cmd.Parameters.AddWithValue("@Gender", doc.Gender);
                cmd.Parameters.AddWithValue("@PhoneNo", doc.PhoneNo);
                cmd.Parameters.AddWithValue("@Email", doc.Email);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    List<Patient_model> list = new List<Patient_model>();
                    selectallpatient(list);
                   for(int i = 1; i < list.Count; i++)
                    {
                        if (list[i].id > list[i - 1].id)
                        {
                            id = list[i].id;
                        }
                    }
                    MessageBox.Show($"Patient {doc.FName + " " + doc.LName} has been Registered Successfully \n your Patient id is: " + id);
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                b = false;
                MessageBox.Show(e.Message);
            }
            return b;

        }

        public static Boolean Updatedoctor(int id, Doctorclass d)
        {
            string sql = "update doctor set FirstName='" + d.FName + "',LastName='" + d.LName + "', DateofBirth='" + d.Dateofbirth + "', Gender='" + d.Gender + "', PhoneNo='" + d.PhoneNo + "', Email = '" + d.Email + "', Experience='" + d.Experience + "', Specialisation='" + d.Specialisation + "', username='" + d.user + "', password='" + d.pass + "'where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Doctor {d.FName + " " + d.LName} has been updated Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in updating");
            }
            return b;

        }
        public static Boolean UpdateLab(int id, Lab_model d)
        {
            string sql = "update laboratory set FirstName='" + d.FName + "',LastName='" + d.LName + "', DateofBirth='" + d.Dateofbirth + "', Gender='" + d.Gender + "', PhoneNo='" + d.PhoneNo + "', Email = '" + d.Email + "', Experience='" + d.Experience + "', Specialisation='" + d.Specialisation + "', username='" + d.user + "', password='" + d.pass + "'where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"laboratorist {d.FName + " " + d.LName} has been updated Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in updating");
            }
            return b;

        }
        public static Boolean Updaterec(int id, Rec_model d)
        {
            string sql = "update reception set FirstName='" + d.FName + "',LastName='" + d.LName + "', DateofBirth='" + d.Dateofbirth + "', Gender='" + d.Gender + "', PhoneNo='" + d.PhoneNo + "', Email = '" + d.Email + "', Experience='" + d.Experience + "', username='" + d.username + "', password='" + d.password + "'where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"reception {d.FName + " " + d.LName} has been updated Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in updating");
            }
            return b;

        }
        public static Boolean Updatepha(int id, Pharmacist_add_model d)
        {
            string sql = "update pharmacist set FirstName='" + d.FName + "',LastName='" + d.LName + "', DateofBirth='" + d.Dateofbirth + "', Gender='" + d.Gender + "', PhoneNo='" + d.PhoneNo + "', Email = '" + d.Email + "', Experience='" + d.Experience + "', username='" + d.user + "', password='" + d.pass + "'where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"pharmacist {d.FName + " " + d.LName} has been updated Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in updating");
            }
            return b;

        }
        public static Boolean Updatepat(int id, Patient_model d)
        {
            string sql = "update Patient set FirstName='" + d.FName + "',LastName='" + d.LName + "', DateofBirth='" + d.Dateofbirth + "', Gender='" + d.Gender + "', PhoneNo='" + d.PhoneNo + "', Address='" + d.Address + "', Email = '" + d.Email + "" +
                 "'where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"pharmacist {d.FName + " " + d.LName} has been updated Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in updating");
            }
            return b;

        }

        public static Boolean deletelab(int id, string Fname, string Lname)
        {
            string sql = "delete laboratory where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"laboratorist {Fname + " " + Lname} has been deleted Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in deleting");
            }
            return b;
        }
        public static Boolean deletedoc(int id, string Fname, string Lname)
        {
            string sql = "delete doctor where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"doctor {Fname + " " + Lname} has been deleted Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in deleting");
            }
            return b;
        }
        public static Boolean deleterec(int id, string Fname, string Lname)
        {
            string sql = "delete reception where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"reception {Fname + " " + Lname} has been deleted Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in deleting");
            }
            return b;
        }
         public static Boolean deletepha(int id,string Fname,string Lname)
        {
            string sql = "delete pharmacist where id='" + id + "'";
            Boolean b = false;
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand(sql, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"pharmacist {Fname + " " + Lname} has been deleted Successfully");
                    b = true;
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error in deleting");
            }
            return b;

        }
    }
}

