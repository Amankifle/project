using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }
        int s = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            s+=5;
            circularProgressBar1.Value = s;
            label2.Text=s.ToString()+"%";
            if (circularProgressBar1.Value == 100)
            {
                circularProgressBar1.Value = 0;
                timer1.Stop();
                circularProgressBar1.Visible = false;
                groupBox1.Visible = true;
                label2.Visible = false;

            }

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Boolean valid = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            if (textBox3.Text == "Username" && textBox3.ForeColor == Color.Gray)
            {
                valid = false;
                errorProvider1.SetError(textBox3, "user name is a Required field");
            }
            if (textBox2.Text == "Password" && textBox2.ForeColor == Color.Gray)
            {
                valid = false;
                errorProvider2.SetError(textBox2, "password is a Required field");
            }
            if (comboBox1.Text == "select role" )
            {
                valid = false;
                MessageBox.Show("Please choose a role", "error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (valid == true) {
                string username = textBox3.Text;
                string password = textBox2.Text;
                Boolean b = Sqlconnection.selectdoctor(username, password);
                Boolean R = Sqlconnection.selectreception(username, password);
                Boolean L = Sqlconnection.selectlaboratory(username, password);
                Boolean P = Sqlconnection.selectpharmacist(username, password);
                if (textBox2.Text == "admin" && textBox3.Text == "admin" && comboBox1.Text == "Admin")
                {
                    this.Hide();
                    Adminform adminform = new Adminform(textBox2.Text);
                    adminform.ShowDialog();
                    
                }
                else if (b && comboBox1.Text == "Doctor")
                {
                    this.Hide();
                    Doc d = new Doc(textBox3.Text, textBox2.Text);
                    d.Show();
                }
                else if (R && comboBox1.Text == "Reception")
                {
                    this.Hide();
                    reception d = new reception();
                    d.Show();
                }
                else if (L && comboBox1.Text == "Labratory")
                {
                    this.Hide();
                    Labratorist_main d = new Labratorist_main();
                    d.Show();
                }
                else if (P && comboBox1.Text == "Pharmacist")
                {
                    this.Hide();
                    Pharmacist_data d = new Pharmacist_data();
                    d.Show();
                } else
                    MessageBox.Show("No user  exist with the current role please check User name and Password!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Username")
                textBox3.Clear();
                textBox3.ForeColor = Color.Black;
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Username";

            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
                textBox2.Clear();
            textBox2.UseSystemPasswordChar = true;
            textBox2.ForeColor = Color.Black;
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = "Password";

            }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox3.ForeColor = Color.Gray;
            textBox3.Text = "Username";
            textBox2.ForeColor = Color.Gray;
            textBox2.UseSystemPasswordChar = false;
            textBox2.Text = "Password";

        }
        private void comboBox1_Leave_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "select role";
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked && textBox2.ForeColor == Color.Black)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else if (textBox2.ForeColor == Color.Black)
                textBox2.UseSystemPasswordChar = true;
        }

    }
}
