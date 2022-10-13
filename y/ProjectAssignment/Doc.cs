using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAssignment
{
    public partial class Doc : Form
    {
        public Doc(String user,string pass)
        {
            InitializeComponent();
            List<Doctorclass> d = new List<Doctorclass>();
            Sqlconnection.selectalldoctor(d);
            foreach (Doctorclass doctor in d)
            {
                if (doctor.user == user && doctor.pass == pass)
                {
                    label7.Text = doctor.FName;
                    label7.Text += " ";
                    label7.Text += doctor.LName;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Boolean b = true;
            PatientTest p = new PatientTest();
            if (string.IsNullOrEmpty(txtdiagnosis.Text))
            {
                b = false;
                errorProvider1.SetError(txtdiagnosis, "Invalid diagnosis");
            }
            else
            {
                errorProvider1.Clear();
                p.diagnosis = txtdiagnosis.Text;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                b = false;
                errorProvider3.SetError(textBox3, "Invalid dose");
            }
            else
            {
                errorProvider3.Clear();
                p.dose = textBox3.Text;
            }
            if (string.IsNullOrEmpty(txtmedication.Text))
            {
                b = false;
                errorProvider2.SetError(txtmedication, "Invalid medication");
            }
            else
            {
                errorProvider2.Clear();
                p.medication = txtmedication.Text;
            }
            if (b == true)
            {
                if (MessageBox.Show("Are you sure you want to update this info", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Sqlconnection.updatetest(int.Parse(txtsearch.Text), txtmedication.Text, txtdiagnosis.Text, textBox3.Text);
                    clear();
                    txtsearch.Clear();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtdiagnosis.Clear();
            txtmedication.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            product_card1.Visible = false;
            if (txtsearch.Text == "")
            {
                MessageBox.Show("please enter patient id. ");
            }
            else
            {
                try
                {
                    Patient_model p = Sqlconnection.selectspecificpatient(int.Parse(txtsearch.Text));
                    if (p == null)
                    {
                        MessageBox.Show("Patient not found.");
                    }
                    else
                    {
                        txtsearch.Enabled = false;
                        button6.Visible = true;
                        product_card1.Fname = p.FName;
                        product_card1.Lname = p.LName;
                        product_card1.Dateofbirth = p.Dateofbirth;
                        product_card1.Gender = p.Gender;
                        product_card1.Phone = p.PhoneNo;
                        product_card1.Email = p.Email;
                        product_card1.Blood = p.Blood_Group;
                        product_card1.Address = p.Address;
                        product_card1.Visible = true;
                        Boolean g = Sqlconnection.selectpatientTest(int.Parse(txtsearch.Text));
                        if (g == true)
                        {
                            int test = Sqlconnection.checkpatientTest(int.Parse(txtsearch.Text));
                            if(test == 0)
                            {
                                MessageBox.Show("Test result of this patient is not ready");
                            }else if(test == 1)
                            {
                                panel1.Visible = true;
                                button7.Visible = true;
                                
                            }
                        }
                        else if(g==false)
                        {
                            panel2.Visible = true;
                        }
                    }
                }catch(Exception e3)
                {
                    MessageBox.Show("Enter a valid id");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PatientTest p = new PatientTest();
            Boolean b = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                b = false;
                errorProvider1.SetError(textBox1, " Field is required ");

            }
            else
            {
                errorProvider1.Clear();
                p.Symptom=textBox1.Text;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                b = false;
                errorProvider1.SetError(textBox2, " Field is required ");

            }
            else
            {
                errorProvider2.Clear();
                p.diagnosis = textBox2.Text;
            }
            if (b == true) {
                p.set();
                p.pid = int.Parse(txtsearch.Text.ToString());
                p.tested = 0;
                if (checkedListBox1.CheckedItems.Count != 0)
                {
                    List<string> s = new List<string>();
                    for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                    {
                        s.Add(checkedListBox1.CheckedItems[x].ToString());
                    }
                    for (int i = 0; i < s.Count; i++)
                    {
                        if (s[i]== "bloodtest ")
                        {
                           
                            p.bloodtest = "*";
                        }
                        if (s[i] == "cbc ")
                        {
                            p.cbc = "*";

                        }
                        if (s[i] == "bun ")
                        {
                            p.bun = "*";

                        }
                        if (s[i] == "electrolyte ")
                        {
                            p.electrolyte = "*";

                        }

                        if (s[i] == "cholestrol ")
                        {
                            p.cholestrol = "*";
                        }

                        if (s[i] == "creatanine ")
                        {
                            p.creatanine = "*";
                        }

                        if (s[i] == "glucose ")
                        {

                            p.glucose = "*";
                        }
                        if (s[i] == "uric ")
                        {
                            p.uric = "*";
                        }

                    }
                    p.AddPatientTest();
                    clear();
                    txtsearch.Clear();
                }
            }
        }
       private void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            txtsearch.Enabled = true;
            product_card1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            txtsearch.Clear();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Setting s = new Setting();
            s.labTestResult(int.Parse(txtsearch.Text.ToString()));
            s.Show(); 
        }

        private void Doc_Load(object sender, EventArgs e)
        {
           
        }
    }
}
