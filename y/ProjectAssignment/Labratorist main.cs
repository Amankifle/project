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
    public partial class Labratorist_main : Form
    {
        public Labratorist_main()
        {
            InitializeComponent();
        }

        private void Labratorist_main_Load(object sender, EventArgs e)
        {

        }

        private void addNewDiagnosisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtsearch.Visible = true;
            Boolean valid = true;
            errorProvider1.Clear();
            if (txtsearch.Text == "Enter id" && txtsearch.ForeColor == Color.Gray)
            {
                valid = false;
                errorProvider1.SetError(txtsearch, "patient id is a Required field");
            }
            else if (valid == true)
            {
                if (Sqlconnection.selectpatientTest(int.Parse(txtsearch.Text)))
                {
                    if (ActiveMdiChild != null)
                    {
                        ActiveMdiChild.Close();
                    }

                    Labratorist_Form form = new Labratorist_Form(int.Parse(txtsearch.Text));
                    form.MdiParent = this;
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Patient not found!!", "error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 d = new Form1();
            d.Show();
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text == "Enter id")
                txtsearch.Clear();
            txtsearch.ForeColor = Color.Black;
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                txtsearch.ForeColor = Color.Gray;
                txtsearch.Text = "Enter id";

            }
        }
        private void viewPatientNewDiagnosisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtsearch.Visible=false;
            Setting form = new Setting();
            form.pat();
            form.MdiParent = this;
            form.Show();
        }
    }
}
