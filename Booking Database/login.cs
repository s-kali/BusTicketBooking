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
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public login()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=DESKTOP-MTPG2JV;Initial Catalog=Booking;Integrated Security=True";
        }
        private void txtUserEnter(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(@"Username"))
            {
                txtUsername.Text = "";
            }
        }

        private void txtUserLeave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(""))
            {
                txtUsername.Text = @"Username";
            }
        }

        private void txtPassEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals("Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                txtPassword.Text = "Password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int x = -1;
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from AUTH"; // 1. SORGU
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (txtUsername.Text.Equals(dr["username"].ToString()) && txtPassword.Text.Equals(dr["password"].ToString()))
                    {
                        if (dr["AUTH_type"].ToString() == "admin")
                        {
                            MessageBox.Show("Admin Login Success", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            x = 1;                        
                        }

                        else if (dr["AUTH_type"].ToString() == "user")
                        {
                            MessageBox.Show("User Login Succes", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            x = 2;
                        }
                        else
                        {
                            x = 0;
                        }
                    }
                    if (x == 0)
                    {
                        MessageBox.Show("Username or Password is incorrect.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else if(x == 1)
                    {
                        this.Hide();
                        adminpanel adminpanel = new adminpanel();
                        adminpanel.Show();
                        break;
                    }
                    else if(x == 2)
                    {
                        this.Hide();
                        userpanel userpanel = new userpanel(txtUsername.Text);
                        userpanel.Show();
                        break;
                    }
                    

                }
                con.Close();
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            signup signup = new signup();
            signup.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
