using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CongNgheNet;
using System.Data.SqlClient;
using System.Configuration;
namespace CongNgheNet
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DangNhap_Click(object sender, EventArgs e)
        {
            connect.Open();
            string tk = UserName.Text;  
            string mk = Password.Text;
            string sql = "select * from User_ where username = '" + tk + "' and pass = '" + mk + "'";
            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {
                MessageBox.Show("Đăng nhập thành công");
                Main f = new Main();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
            connect.Close();
        }
    }
}
