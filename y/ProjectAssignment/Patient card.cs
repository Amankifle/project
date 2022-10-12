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
    public partial class Product_card : UserControl
    {
        public Product_card()
        {
            InitializeComponent();
        }
        private String _fname;

        public String Fname
        {
            get { return _fname; }
            set { _fname = value; labelFname.Text = value; }
        }

        private String _lname;

        public String Lname
        {
            get { return _lname; }
            set { _lname = value; labelLname.Text = value; }
        }

        private String _gender;

        public String Gender
        {
            get { return _gender; }
            set { _gender = value; labelGender.Text = value; }
        }

        private String _dateofbirth;

        public String Dateofbirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; labelDateoB.Text = value; }
        }

        private String _blood;

        public String Blood
        {
            get { return _blood; }
            set { _blood = value; labelBlood.Text = value; }
        }

        private String _phone;

        public String Phone
        {
            get { return _phone; }
            set { _phone = value; labelPhone.Text = value; }
        }
        private String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value; labelEmail.Text = value; }
        }


        private String _address;

        public String Address
        {
            get { return _address; }
            set { _address = value; labelAddress.Text = value; }
        }

        private void Product_card_Load(object sender, EventArgs e)
        {

        }

    }
}
