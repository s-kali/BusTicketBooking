using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Booking_Database
{
    public partial class signup : Form
    {
        string connectionString = @"Data Source=DESKTOP-MTPG2JV;Initial Catalog=Booking;Integrated Security=True";
        public signup()
        {
            InitializeComponent();
        }

        private void txtUserSignEnter(object sender, EventArgs e)//Farklı secenege gecince sifirlama
        {
            if (txtUserSign.Text.Equals(@"Username"))
            {
                txtUserSign.Text = "";
            }
        }

        private void txtUserSignLeave(object sender, EventArgs e)
        {
            if (txtUserSign.Text.Equals(""))
            {
                txtUserSign.Text = @"Username";
            }
        }

        private void txtPassSignEnter(object sender, EventArgs e)
        {
            if(txtPassSign.Text.Equals("Password"))
            {
                txtPassSign.Text = "";
            }
        }

        private void txtPassSignLeave(object sender, EventArgs e)
        {
            if(txtPassSign.Text.Equals(""))
            {
                txtPassSign.Text = "Password";
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UserAdd",con); // 2. SORGU INSERT INTO AUTH(username,password,AUTH_type) VALUES(@username, @password, 'user')
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@username", txtUserSign.Text.Trim());
                com.Parameters.AddWithValue("@password", txtPassSign.Text.Trim());
                com.ExecuteNonQuery();
                MessageBox.Show("Success");
                con.Close();
                goback();
            }
        }

        void goback()
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            goback();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
