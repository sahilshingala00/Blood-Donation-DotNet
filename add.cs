using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace blood_donation
{
    public partial class add : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        string gender;
        public add()
        {
            InitializeComponent();
        }

        private void add_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\oepdatabase.mdf;Integrated Security=True;Connect Timeout=30";
                
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string mobile = txtMobile.Text;
            string email = txtEmail.Text;
            int pin =Convert.ToInt32(txtPin.Text);
            int age = Convert.ToInt32(txtAge.Text);
            string bloodGroup = cmbBG.Text;
            if(rbMale.Checked)
            {
                gender = "Male";
            }
            else if(rbFemale.Checked)
            {
                gender = "Female";
            }
            string q = "insert into donar(d_name,d_email,d_mobile,d_pin,d_age,d_gender,d_bg) values('"+name+"','"+email+"',"+mobile+","+pin+","+age+",'"+gender+"','"+bloodGroup+"')";
            try
            {
                cn.Open();
                cmd = new SqlCommand(q, cn);
                int count = cmd.ExecuteNonQuery();
                if (count == 1)
                {
                    MessageBox.Show("Added successfully");
                    cn.Close();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
