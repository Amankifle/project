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
    public partial class Labratorist_Form : Form
    {
        int pid;
        public Labratorist_Form(int id)
        {
            InitializeComponent();
            pid= id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();

        }

      private void button1_Click(object sender, EventArgs e)
       {
            PatientTest p=new PatientTest();
            Boolean b = true;
            if (comboBox2.Text != "Not required" && string.IsNullOrEmpty(comboBox2.Text) )
            {
                b = false;
                MessageBox.Show(" Blood test is required");

            }
            else if (comboBox2.Text == "Not required")
                p.bloodtest = " ";
            else
            {
                p.bloodtest = comboBox2.Text;

            }

            if (txtbun.Text != "Not required"&& string.IsNullOrEmpty(txtbun.Text))
            {
                b = false;
                errorProvider4.SetError(txtbun, " bun test is required");

            }
            else if (txtbun.Text == "Not required")
                p.bun = " ";
            else
            {
                errorProvider4.Clear();
                p.bun = txtbun.Text;

            }

            if (txtcbc.Text != "Not required" && string.IsNullOrEmpty(txtcbc.Text))
            {
                b = false;
                errorProvider5.SetError(txtbun, " cbc test is required");

            }
            else if (txtcbc.Text == "Not required")
                p.cbc = " ";
            else
            {
                errorProvider5.Clear();
                p.cbc = txtcbc.Text;

            }
            if (txtcholestrol.Text != "Not required" && string.IsNullOrEmpty(txtcholestrol.Text))
            {
                b = false;
                errorProvider6.SetError(txtcholestrol, " cholestrol test is required");

            }
            else if (txtcholestrol.Text == "Not required")
                p.cholestrol = " ";
            else
            {
                errorProvider6.Clear();
                p.cholestrol = txtcholestrol.Text;

            }
            if (txtcreate.Text != "Not required" && string.IsNullOrEmpty(txtcreate.Text))
            {
                b = false;
                errorProvider7.SetError(txtcreate, " creatinine test is required");

            }
            else if (txtcreate.Text == "Not required")
                p.creatanine = " ";
            else
            {
                errorProvider7.Clear();
                p.creatanine = txtcreate.Text;

            }
            if (txtelectrolyte.Text != "Not required" && string.IsNullOrEmpty(txtelectrolyte.Text))
            {
                b = false;
                errorProvider8.SetError(txtelectrolyte, " Electrolyte test is required");

            }
            else if (txtelectrolyte.Text == "Not required")
                p.electrolyte = " ";
            else
            {
                errorProvider8.Clear();
                p.electrolyte = txtelectrolyte.Text;

            }
            if (txtglucose.Text != "Not required" && string.IsNullOrEmpty(txtglucose.Text))
            {
                b = false;
                errorProvider9.SetError(txtglucose, " Glucose test is required");

            }
            else if (txtglucose.Text == "Not required")
                p.glucose = " ";
            else
            {
                errorProvider9.Clear();
                p.glucose = txtglucose.Text;

            }
            if (txturic.Text != "Not required" && string.IsNullOrEmpty(txturic.Text))
            {
                b = false;
                errorProvider1.SetError(txturic, " uric test is required");

            }
            else if (txturic.Text == "Not required")
                p.uric = " ";
            else
            {
                errorProvider1.Clear();
                p.uric = txturic.Text;

            }
            if (b == true)
            {
                p.pid = pid;
                if (p.tested == 1)
                {
                    p.tested = 1;
                    if (MessageBox.Show("This patient test was submitted already!!\n Are you sure you want to submit again. ", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Sqlconnection.updatetestResult(p);
                    }
                }
                this.Close();  
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Labratorist_Form_Load(object sender, EventArgs e)
        {
            PatientTest p = Sqlconnection.selectpatienttest(pid);
            if (p.bloodtest == " ")
            {
                comboBox2.Text = "Not required";
                comboBox2.Enabled = false;
            }
            if (p.cbc == " ")
            {
                txtcbc.Text = "Not required";
                txtcbc.Enabled = false;
            }
            if (p.creatanine == " ")
            {
                txtcreate.Text = "Not required";
                txtcreate.Enabled = false;
            }
            if (p.bun == " ")
            {
                txtbun.Text = "Not required";
                txtbun.Enabled = false;
            }
            if (p.cholestrol == " ")
            {
                txtcholestrol.Text = "Not required";
                txtcholestrol.Enabled = false;
            }
            if (p.uric == " ")
            {
                txturic.Text = "Not required";
                txturic.Enabled = false;
            }
            if (p.electrolyte == " ")
            {
                txtelectrolyte.Text = "Not required";
                txtelectrolyte.Enabled = false;
            }
            if (p.glucose == " ")
            {
                txtglucose.Text = "Not required";
                txtglucose.Enabled = false;
            }
        }

        
    }
}
