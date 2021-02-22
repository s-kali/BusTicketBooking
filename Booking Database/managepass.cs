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
    public partial class managepass : Form
    {
        string conString = @"Data Source=DESKTOP-MTPG2JV;Initial Catalog=Booking;Integrated Security=True";
        public managepass()
        {
            InitializeComponent();
            visualizetable();
        }
        void visualizetable()
        {
            using (SqlConnection sqlCon = new SqlConnection(conString))// datagridview doldurulması
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM passenger", sqlCon);// 7. SORGU
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.CommandText = "SELECT COUNT(passenger_id) FROM passenger";
                sqlCom.Connection = sqlCon;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                Int32 count = (Int32)sqlCom.ExecuteScalar();
                txtpassenger.Text = count.ToString();

                dataGridView1.DataSource = dtbl;
                sqlCon.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminpanel adminpanel = new adminpanel();
            adminpanel.Show();
        }

        private void ticketupdatebtn_Click(object sender, EventArgs e)
        {
            if (txtpassAdress.Text == "" || txtpassID.Text == "" ||
                txtpassMail.Text == "" || txtpassName.Text == "" ||
                txtpassPhone.Text == "" || txtpassGender.Text == "")
            {
                MessageBox.Show("Please fill all spaces.!");

            }
            else
            {
                string update_Query = "UPDATE passenger SET" +
                    " passenger_name = @passenger_name," +
                    " passenger_add= @passenger_add," +
                    " passenger_mail= @passenger_mail," +
                    " passenger_phone= @passenger_phone," +
                    " passenger_gender= @passenger_gender" +
                    " where passenger_id= @passenger_id";// 8. SORGU

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = update_Query;
                    com.Parameters.AddWithValue("@passenger_id", txtpassID.Text);
                    com.Parameters.AddWithValue("@passenger_name", txtpassName.Text);
                    com.Parameters.AddWithValue("@passenger_add", txtpassAdress.Text);
                    com.Parameters.AddWithValue("@passenger_mail", txtpassMail.Text);
                    com.Parameters.AddWithValue("@passenger_phone", txtpassPhone.Text);
                    com.Parameters.AddWithValue("@passenger_gender", txtpassGender.Text);


                    if (com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Passenger updated succesfully!");
                    }
                    con.Close();
                }
                txtpassName.Text = String.Empty;
                txtpassID.Text = String.Empty;
                txtpassAdress.Text = String.Empty;
                txtpassGender.Text = String.Empty;
                txtpassMail.Text = String.Empty;
                txtpassPhone.Text = String.Empty;
            }

                visualizetable();
        }

        private void ticketdeletebtn_Click(object sender, EventArgs e)
        {
            if (txtpassID.Text == "" )
            {
                MessageBox.Show("Please fill id.!");

            }
            else
            {
                string delete_Query = "DELETE FROM passenger WHERE passenger_id LIKE @passenger_id";// 9. SORGU

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = delete_Query;
                    com.Parameters.AddWithValue("@passenger_id", Convert.ToInt32(txtpassID.Text));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Passenger deleted succesfully!");
                    }
                    con.Close();
                }
                txtpassName.Text = String.Empty;
                txtpassID.Text = String.Empty;
                txtpassAdress.Text = String.Empty;
                txtpassGender.Text = String.Empty;
                txtpassMail.Text = String.Empty;
                txtpassPhone.Text = String.Empty;

            }

            visualizetable();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentRow.Index != -1)
            {
                txtpassID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtpassName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtpassAdress.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtpassMail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtpassPhone.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtpassGender.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
        }
    }
}
