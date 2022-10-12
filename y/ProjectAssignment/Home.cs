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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
            
        }
        private void panel5_Click(object sender, EventArgs e)
        {
            List<Doctorclass> text = Doctorclass.getallDoctor();

            if (text.Count > 0)
            {
                Setting s = new Setting();
                s.doctor();
                s.Show();
            }
            else
            {
                MessageBox.Show("Doctor list is empty!!");
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
           
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            List<Rec_model> text = Rec_model.getallrec();
            if (text.Count > 0)
            {
                
                Setting s = new Setting();
                s.rec();
                s.Show();
            }
            else
            {
                MessageBox.Show("Reception   list is empty!!");
            }
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            List<Lab_model> text = Lab_model.getallLab();
            if (text.Count > 0)
            {
                
                Setting s = new Setting();
                s.lab();
                s.Show();
            }
            else
            {
                MessageBox.Show("Labratory  list is empty!!");
            }
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            List<Pharmacist_add_model> text = Pharmacist_add_model.getallPha();
            if (text.Count > 0)
            {
                
                Setting s = new Setting();
                s.phar();
                s.Show();
            }
            else
            {
                MessageBox.Show("Pharmacist list is empty!!");
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            noDoc.Text=Doctorclass.getallDoctor().Count().ToString();
            noLab.Text = Lab_model.getallLab().Count().ToString();
            noRec.Text = Rec_model.getallrec().Count().ToString();
            nopha.Text = Pharmacist_add_model.getallPha().Count().ToString();
        }
    }
}
