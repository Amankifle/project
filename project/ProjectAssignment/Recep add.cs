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
    public partial class Recep_add : Form
    {
        int Id; 
        public Recep_add()
        {
            InitializeComponent();

            txtconfirm.UseSystemPasswordChar = true;
            txtpass.UseSystemPasswordChar = true;
        }
        public void Passvalue(int id, String FN, String Ln, String Dofb, String g, String pho, int exp
            , String e, String un, String pass)
        {
            Id= id;
            txtFname.Text = FN;
            txtpass.Text = pass;
            txtLname.Text = Ln;
            txtPhoneNo.Text = pho;
            if (g == "Male")
                radioButtonMale.Checked = true;
            else
                radioButtonFemale.Checked = true;
            dateTimePicker1.Text = Dofb;
            txtemail.Text = e;
            textBox1.Text = exp.ToString();
            txtuser.Text = un;
            button1.Text = "Update";
            button2.Text = "Delete";
            button3.Visible = true;
        }
      
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked && txtconfirm != null && checkBox1.Checked && txtpass != null)
            {
                txtconfirm.UseSystemPasswordChar = false;
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtconfirm.UseSystemPasswordChar = true;
                txtpass.UseSystemPasswordChar = true;
            }
        }


        void clear()
        {
            txtFname.Clear();
            txtLname.Clear();
            txtemail.Clear();
            txtPhoneNo.Clear();
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            textBox1.Clear();
            txtpass.Clear();
            txtconfirm.Clear();
            txtuser.Clear();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button2.Text == "Clear")
            {
                clear();
            }
            else if (button2.Text == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this person", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Sqlconnection.deleterec(Id, "", "");
                    this.Close();
          
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Rec_model d = new Rec_model();
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
                MessageBox.Show("gender is required", "error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            if (regex1.IsMatch(txtPhoneNo.Text))
            {
                d.PhoneNo = txtPhoneNo.Text;

            }
            else
            {
                b = false;
                errorProvider3.SetError(txtPhoneNo, "Invalid phone number");

            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                b = false;
                errorProvider4.SetError(textBox1, " Experience is required");

            }
            else
            {

                errorProvider4.Clear();
                d.Experience = int.Parse(textBox1.Text);

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

            if (string.IsNullOrEmpty(txtuser.Text))
            {
                b = false;
                errorProvider6.SetError(txtuser, " user name is required");

            }
            else
            {
                errorProvider6.Clear();
                d.username = txtuser.Text;

            }


            if (string.IsNullOrEmpty(txtpass.Text))
            {
                b = false;
                errorProvider8.SetError(txtpass, " password is required");

            }
            else
            {
                errorProvider8.Clear();
                d.password = txtpass.Text;

            }
            if (string.IsNullOrEmpty(txtconfirm.Text))
            {
                b = false;
                errorProvider9.SetError(txtconfirm, " confirm password is required");

            }
            else
            {
                errorProvider9.Clear();

                if (txtconfirm.Text != txtpass.Text)
                {
                    MessageBox.Show("Passwords do not match please check again", "error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (b == true && txtconfirm.Text == txtpass.Text)

                {
                    d.Dateofbirth = dateTimePicker1.Text;
                    if (button1.Text == "Save")
                    {
                        d.save();
                        clear();
                    }
                    else if (button1.Text == "Update")
                    {
                        if (MessageBox.Show("Are you sure you want to update this person", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Sqlconnection.Updaterec(Id, d);

                            this.Close();
                        }
                    }


                    clear();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
