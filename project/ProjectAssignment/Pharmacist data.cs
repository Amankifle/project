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
    public partial class Pharmacist_data : Form
    {
        public Pharmacist_data()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtsearch.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PatientTest d = new PatientTest();
            Boolean b = true;
            if (string.IsNullOrEmpty(txtsearch.Text))
            {
                b = false;
                errorProvider1.SetError(txtsearch, " Field is required ");
            }
            if (b == true)
            {
                try
                {
                    errorProvider1.Clear();
                    d.pid = int.Parse(txtsearch.Text);
                    if (Sqlconnection.selectpatientTest(d.pid))
                    {
                        Sqlconnection.selectmedication(d);
                        MessageBox.Show("Patients new medication ordered by doctor is: " + d.medication + "\n with a dose of: " + d.dose + ".");
                    }
                    else
                    {
                        MessageBox.Show("Doctor hasn't ordered any medication.");
                    }
                }catch(Exception e3)
                {
                    MessageBox.Show("Please enter id properly!!");
                }
            }
            else if(b==false)
            {
                MessageBox.Show("Patient doesn't exits");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();

        }

   
    }
}
