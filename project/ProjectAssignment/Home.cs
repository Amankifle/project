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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        // Opens datagridview for doctor
        private void panel5_Click(object sender, EventArgs e)
        {
            List<Doctorclass> text = Doctorclass.getallDoctor();

            if (text.Count > 0)
            {
                View_All_Data s = new View_All_Data();// Has datagridview
                s.doctor();// gets all 
                s.Show();
            }
            else
            {
                MessageBox.Show("Doctor list is empty!!");
            }
        }




        // Opens datagridview for receptionist
        private void panel7_Click(object sender, EventArgs e)
        {
            List<Rec_model> text = Rec_model.getallrec();
            if (text.Count > 0)
            {
                
                View_All_Data s = new View_All_Data();
                s.rec();
                s.Show();// gets all 
            }
            else
            {
                MessageBox.Show("Reception   list is empty!!");
            }
        }
        // Opens datagridview for labratorist
        private void panel6_Click(object sender, EventArgs e)
        {
            List<Lab_model> text = Lab_model.getallLab();
            if (text.Count > 0)
            {
                
                View_All_Data s = new View_All_Data();
                s.lab();
                s.Show();// gets all 
            }
            else
            {
                MessageBox.Show("Labratory  list is empty!!");
            }
        }
        // Opens datagridview for pharmacist
        private void panel1_Click(object sender, EventArgs e)
        {
            List<Pharmacist_add_model> text = Pharmacist_add_model.getallPha();
            if (text.Count > 0)
            {
                
                View_All_Data s = new View_All_Data();
                s.phar();
                s.Show();// gets all 
            }
            else
            {
                MessageBox.Show("Pharmacist list is empty!!");
            }
        }
        // Counts how many employee are there and assign them to label
        private void Home_Load(object sender, EventArgs e)
        {
            noDoc.Text=Doctorclass.getallDoctor().Count().ToString();
            noLab.Text = Lab_model.getallLab().Count().ToString();
            noRec.Text = Rec_model.getallrec().Count().ToString();
            nopha.Text = Pharmacist_add_model.getallPha().Count().ToString();
        }
    }
}
