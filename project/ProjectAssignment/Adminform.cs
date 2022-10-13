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
    public partial class Adminform : Form
    {
        public Adminform(string name)
        {
            InitializeComponent();
            label1.Text = name;
            Home d = new Home();
            openchildform(d);
            button8.BackColor = Color.SlateGray;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            adminForm2 adminForm2 = new adminForm2();
            openchildform(adminForm2);
            button1.BackColor = Color.SlateGray;
        }  
        private Form activeform = null;
        private void openchildform(Form childform)
        {
            button1.BackColor = Color.SteelBlue;
            button5.BackColor = Color.SteelBlue;
            button4.BackColor = Color.SteelBlue;
            button2.BackColor = Color.SteelBlue;
            button6.BackColor = Color.SteelBlue;
            button8.BackColor = Color.SteelBlue;
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock= DockStyle.Fill;
            mainpanel.Controls.Add(childform);
            mainpanel.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {           
            Labratory_data d = new Labratory_data();
            openchildform(d);
            button4.BackColor = Color.SlateGray;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            Recep_add s = new Recep_add();
            openchildform(s);
            button2.BackColor = Color.SlateGray;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Pharmacist_add d = new Pharmacist_add();
            openchildform(d);
            button5.BackColor = Color.SlateGray;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            
            Home d = new Home();
            openchildform(d);
            button8.BackColor = Color.SlateGray;
        }
    }
}
