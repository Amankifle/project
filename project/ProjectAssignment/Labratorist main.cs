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
            addNewDiagnosisToolStripMenuItem_Click(sender, e);
        }
  
        private void addNewDiagnosisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }

            Labratorist_Form form = new Labratorist_Form();
            form.MdiParent = this;
            form.Show();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 d = new Form1();
            d.Show();
        }

   
        private void viewPatientNewDiagnosisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            View_All_Data form = new View_All_Data();
            form.pat();
            form.MdiParent = this;
            form.Show();
        }
    }
}
