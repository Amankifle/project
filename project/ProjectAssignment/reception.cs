using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectAssignment
{
    public partial class reception : Form
    {
        int pid;
        public reception()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Add")
            {
                Patient_model d = new Patient_model();
                Boolean b = true;
                if (radioButtonMale.Checked)
                {

                    d.Gender = "Male";
                }
                else if (radioButtonFemale.Checked)
                {
                    d.Gender = "Female";
                }
                else
                {
                    b = false;
                    MessageBox.Show("Gender is required", "error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                Regex regex3 = new Regex(@"^[a-zA-Z]+$");
                if (regex3.IsMatch(txtFname.Text))
                {
                    errorProvider1.Clear();
                    d.FName = txtFname.Text;
                }
                else
                {
                    b = false;
                    errorProvider1.SetError(txtFname, "Name required");

                }
                if (regex3.IsMatch(txtLname.Text))
                {
                    errorProvider2.Clear();
                    d.LName = txtLname.Text;
                }
                else
                {
                    b = false;
                    errorProvider2.SetError(txtLname, "Last name required");

                }

                Regex regex1 = new Regex(@"^[0-9]+$");
                if (regex1.IsMatch(txtPhoneNo.Text) && txtPhoneNo.Text.Length != 11)
                {
                    d.PhoneNo = txtPhoneNo.Text;

                }
                else
                {
                    b = false;
                    errorProvider3.SetError(txtPhoneNo, "Invalid phone number");

                }
                if (string.IsNullOrEmpty(txtemail.Text))
                {
                    b = false;
                    errorProvider7.SetError(txtemail, " Email is required");

                }
                else
                {
                    errorProvider7.Clear();
                    d.Email = txtemail.Text;

                }
                if (string.IsNullOrEmpty(txtaddress.Text))
                {
                    b = false;
                    errorProvider8.SetError(txtaddress, " Address is required");

                }
                else
                {
                    errorProvider8.Clear();
                    d.Address = txtaddress.Text;

                }
                if (b == true)
                {
                    d.Blood_Group = comboBox1.Text;
                    d.Dateofbirth = dateTimePicker1.Text;
                    if (MessageBox.Show("Are you sure you want to add this person", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (d.AddPatient())
                        {
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("There was an error in adding Patient!!", "error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else if (button1.Text == "update")
                {
                    if (MessageBox.Show("Are you sure you want to update this person", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Patient_model p = new Patient_model();
                        p.FName= txtFname.Text;
                        p.Address= txtaddress.Text;
                        p.Email= txtemail.Text;
                         p.LName= txtLname.Text;
                        p.PhoneNo= txtPhoneNo.Text ;
                        if (radioButtonMale.Checked == true)
                            p.Gender = "Male";
                        else
                            p.Gender = "Female";
                        p.Blood_Group= comboBox1.Text;
                        p.Dateofbirth= dateTimePicker1.Text;
                        Sqlconnection.Updatepat(pid, p);
                    }
                }
            }
        }
        private void clear()
        {
            txtFname.Clear();
            txtLname.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            txtPhoneNo.Clear();
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked=false;
            comboBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text== "Clear")
            clear();
            else if(button2.Text== "cancel")
            {
                Patient_model p = Sqlconnection.selectspecificpatient(pid);
                txtFname.Text = p.FName;
                txtaddress.Text = p.Address;
                txtemail.Text = p.Email;
                txtLname.Text = p.LName;
                txtPhoneNo.Text = p.PhoneNo;
                if (p.Gender == "Male")
                    radioButtonMale.Checked = true;
                else
                    radioButtonFemale.Checked = true;
                comboBox1.Text = p.Blood_Group;
                dateTimePicker1.Text = p.Dateofbirth;
                pid = p.id;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void reception_Load(object sender, EventArgs e)
        {

        }

        private void metroSetDefaultButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button1.Text = "Add";
            button2.Text = "Clear";
            panel1.Visible = true;
            clear();
        }

        private void metroSetDefaultButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            dataGridView1.DataSource = Patient_model.getallPatient();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter patient First name")
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Enter patient First name";
            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex regex1 = new Regex(@"^[a-z]+$");
            if (textBox1.Text == "Enter patient First name")
            {
                errorProvider9.SetError(textBox1, "Invalid  patient name");
            }
            else if (regex1.IsMatch(textBox1.Text))
            {
              
                List<Patient_model> p2=new List<Patient_model>();
                List<Patient_model> p = Patient_model.getallPatient();
                foreach(Patient_model model in p)
                {
                    if (model.FName==textBox1.Text)
                    {
                        p2.Add(model);
                    }
                }
                if(p2.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = p2;
                }
                else
                {
                    MessageBox.Show("no person found with that name");
                }
            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
        }

        int x;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            x = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[x];
            panel2.Visible = false;
            panel1.Visible = true;
            button1.Text = "update";
            button2.Text = "cancel";
            Patient_model p = Sqlconnection.selectspecificpatient(int.Parse(row.Cells[0].Value.ToString()));
            txtFname.Text = p.FName;
            txtaddress.Text = p.Address;
            txtemail.Text = p.Email;
            txtLname.Text = p.LName;
            txtPhoneNo.Text = p.PhoneNo;
            if (p.Gender == "Male")
                radioButtonMale.Checked = true;
            else
                radioButtonFemale.Checked = true;
            comboBox1.Text = p.Blood_Group;
            dateTimePicker1.Text = p.Dateofbirth;
            pid = p.id;
        }
    }
}
