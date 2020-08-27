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
/*Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\oepdatabase.mdf;Integrated Security=True;Connect Timeout=30*/
namespace blood_donation
{
    public partial class view : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        public view()
        {
            InitializeComponent();
        }

        private void view_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\oepdatabase.mdf;Integrated Security=True;Connect Timeout=30";
            BindGrid();
        }
        private void BindGrid()
        {
            string q = "select * from donar";
            try
            {
                cmd = new SqlCommand(q, cn);
                cn.Open();
                adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cn.Close();
                dataGridView1.DataSource = dt;
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            string q = "select * from donar order by d_bg";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void btnpincode_Click(object sender, EventArgs e)
        {
            string q = "select * from donar order by d_pin";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            add a = new add();
            a.Show();
        }

        private void all_Click(object sender, EventArgs e)
        {
            string q = "select * from donar";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select * from donar where d_gender='male'";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string q = "select * from donar where d_gender='female'";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string q = "select d_bg,count(*) from donar group by d_bg";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string q = "select d_pin,count(*) from donar group by d_pin";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string q = "select d_gender,count(*) from donar group by d_gender";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string q = "select count(*) as Total from donar";
            cmd = new SqlCommand(q, cn);
            cn.Open();
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
