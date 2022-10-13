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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }
        public void doctor()
        {
            label2.Text = "Doctor list";
            List<Doctorclass> text = Doctorclass.getallDoctor();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = text;
        }
        public void lab()
        {
            label2.Text = "Labratorist list";
            List<Lab_model> text = Lab_model.getallLab();   
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = text;
        }
        public void labTestResult(int id)
        {
            label2.Text = "Labratory Result";
            Class2 o = Sqlconnection.selectpatienttestDoc(id);
            List<Class2> text = new List<Class2>();
            text.Add(o);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = text;
        }
        public void phar()
        {
            label2.Text = "Pharmacist list";
            List<Pharmacist_add_model> text = Pharmacist_add_model.getallPha();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = text;
        }
        public void rec()
        {
            label2.Text = "receptionist list";
            List<Rec_model> text = Rec_model.getallrec();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = text;
        }
        public void pat()
        {
            label2.Text = "patient result";
            List<PatientTest> text = Sqlconnection.selectallpatienttest();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = text;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        int x;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                x = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[x];
                if (label2.Text == "Doctor list")
                {
                    adminForm2 doc = new adminForm2();
                    doc.Passvalue(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()
                        , row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), int.Parse(row.Cells[6].Value.ToString())
                        , row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString()
                                   , row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString());
                    doc.Show();
                }
                else if (label2.Text == "Labratorist list")
                {
                    Labratory_data lab = new Labratory_data();
                    lab.Passvalue(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()
                        , row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), int.Parse(row.Cells[6].Value.ToString())
                        , row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString()
                                   , row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString());
                    lab.Show();
                }
                else if (label2.Text == "Pharmacist list")
                {
                    Pharmacist_add pha = new Pharmacist_add();
                    pha.Passvalue(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()
                        , row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), int.Parse(row.Cells[6].Value.ToString())
                        , row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString()
                                   , row.Cells[9].Value.ToString());
                    pha.Show();
                }
                else if (label2.Text == "receptionist list")
                {
                    Recep_add rec = new Recep_add();
                    rec.Passvalue(int.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()
                        , row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), int.Parse(row.Cells[6].Value.ToString())
                        , row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString()
                                   , row.Cells[9].Value.ToString());
                    rec.Show();
                }
            }catch(Exception e2)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
