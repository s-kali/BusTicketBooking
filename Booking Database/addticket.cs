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
    public partial class addticket : Form
    {
        string conString = @"Data Source=DESKTOP-MTPG2JV;Initial Catalog=Booking;Integrated Security=True";
        
        public addticket()
        {
            InitializeComponent();
            visualizetable();
        }
        void visualizetable()
        {
            using (SqlConnection sqlCon = new SqlConnection(conString))// datagridview doldurulması
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM ticket", sqlCon); // 3. SORGU
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.CommandText = "SELECT AVG(ticket_fee) FROM ticket";
                sqlCom.Connection = sqlCon;
                SqlCommand sqlCom1 = new SqlCommand();
                sqlCom1.CommandText = "SELECT MIN(ticket_fee) FROM ticket";
                sqlCom1.Connection = sqlCon; 
                SqlCommand sqlCom2 = new SqlCommand();
                sqlCom2.CommandText = "SELECT MAX(ticket_fee) FROM ticket";
                sqlCom2.Connection = sqlCon;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                Int32 count = (Int32)sqlCom.ExecuteScalar();
                txtavgfee.Text = count.ToString();
                Int32 count1 = (Int32)sqlCom1.ExecuteScalar();
                txtminfee.Text = count1.ToString();
                Int32 count2 = (Int32)sqlCom2.ExecuteScalar();
                txtmaxfee.Text = count2.ToString();

                dataGridView1.DataSource = dtbl;
                sqlCon.Close();
            }
        }
        private void txtTicketIDenter(object sender, EventArgs e)
        {
            if (txtTicketID.Text.Equals(@"ticket_id"))
            {
                txtTicketID.Text = "";
            }
        }

        private void txtTicketIDleave(object sender, EventArgs e)
        {
            if (txtTicketID.Text.Equals(""))
            {
                txtTicketID.Text = @"ticket_id";
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminpanel adminpanel = new adminpanel();
            adminpanel.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ticketinsertbtn_Click(object sender, EventArgs e)// Insert butonu çalışması
        {
            
            if (txtTicketID.Text == "" || txtTicketFrom.Text == "" ||
               txtTicketArrival.Text == "" || txtTicketTo.Text == "" ||
               txtTicketDeparture.Text == "" || txtTicketFee.Text == "")
            {
                MessageBox.Show("Please fill all spaces.!");
            }
            else
            {
                

                string ticket_Query = @"insert into ticket
                                    (ticket_id,ticket_date,ticket_from,ticket_to,ticket_fee,ticket_departure_time,ticket_arrive_time)
                                      VALUES(@ticket_id,@ticket_date,@ticket_from,@ticket_to,@ticket_fee,@ticket_departure_time,@ticket_arrive_time)";//4. SORGU

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = ticket_Query;
                    com.Parameters.AddWithValue("@ticket_id", Convert.ToInt32(txtTicketID.Text));
                    com.Parameters.AddWithValue("@ticket_date", dateTimePicker1.Value);
                    com.Parameters.AddWithValue("@ticket_from", txtTicketFrom.Text);
                    com.Parameters.AddWithValue("@ticket_to", txtTicketTo.Text);
                    com.Parameters.AddWithValue("@ticket_fee", Convert.ToInt32(txtTicketFee.Text));
                    com.Parameters.AddWithValue("@ticket_departure_time", txtTicketDeparture.Text);
                    com.Parameters.AddWithValue("@ticket_arrive_time", txtTicketArrival.Text);
                   
                    if(com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Ticket added succesfully!");
                    }
                    con.Close();
                }
                txtTicketArrival.Text = String.Empty;
                txtTicketID.Text = String.Empty;
                txtTicketDeparture.Text = String.Empty;
                txtTicketFee.Text = String.Empty;
                txtTicketFrom.Text = String.Empty;
                txtTicketTo.Text = String.Empty;
                dateTimePicker1.Value = new DateTime(2021, 1, 1);

            }
            visualizetable();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)// Textlerin doldurulması
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                txtTicketID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value);
                txtTicketFrom.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTicketTo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtTicketFee.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtTicketDeparture.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtTicketArrival.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void ticketdeletebtn_Click(object sender, EventArgs e)// silme butonu
        {
            if (txtTicketID.Text == "" || txtTicketFrom.Text == "" ||
                txtTicketArrival.Text == "" || txtTicketTo.Text == "" ||
                txtTicketDeparture.Text == "" || txtTicketFee.Text == "")
            {
                MessageBox.Show("Please fill all spaces.!");

            }
            else
            {
                string delete_Query = "DELETE FROM ticket WHERE ticket_id LIKE @ticket_id";//5. SORGU

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = delete_Query;
                    com.Parameters.AddWithValue("@ticket_id", Convert.ToInt32(txtTicketID.Text));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Ticket deleted succesfully!");
                    }
                    con.Close();
                }
                txtTicketArrival.Text = String.Empty;
                txtTicketID.Text = String.Empty;
                txtTicketDeparture.Text = String.Empty;
                txtTicketFee.Text = String.Empty;
                txtTicketFrom.Text = String.Empty;
                txtTicketTo.Text = String.Empty;
                dateTimePicker1.Value = new DateTime(2021, 1, 1);

            }
            visualizetable();
        }

        private void ticketupdatebtn_Click(object sender, EventArgs e)
        {
            if (txtTicketID.Text == "" || txtTicketFrom.Text == "" ||
                txtTicketArrival.Text == "" || txtTicketTo.Text == "" ||
                txtTicketDeparture.Text == "" || txtTicketFee.Text == "")
            {
                MessageBox.Show("Please fill all spaces.!");

            }
            else
            {
                string update_Query = "UPDATE ticket SET" +
                    " ticket_date = @ticket_date," +
                    " ticket_from = @ticket_from," +
                    " ticket_to = @ticket_to," +
                    " ticket_fee = @ticket_fee," +
                    " ticket_departure_time = @ticket_departure_time," +
                    " ticket_arrive_time = @ticket_arrive_time" +
                    " WHERE ticket_id = @ticket_id";// 6. SORGU

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = update_Query;
                    com.Parameters.AddWithValue("@ticket_id", Convert.ToInt32(txtTicketID.Text));
                    com.Parameters.AddWithValue("@ticket_date", dateTimePicker1.Value);
                    com.Parameters.AddWithValue("@ticket_from", txtTicketFrom.Text);
                    com.Parameters.AddWithValue("@ticket_to", txtTicketTo.Text);
                    com.Parameters.AddWithValue("@ticket_fee", Convert.ToInt32(txtTicketFee.Text));
                    com.Parameters.AddWithValue("@ticket_departure_time", txtTicketDeparture.Text);
                    com.Parameters.AddWithValue("@ticket_arrive_time", txtTicketArrival.Text);

                    if (com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Ticket updated succesfully!");
                    }
                    con.Close();
                }
                txtTicketArrival.Text = String.Empty;
                txtTicketID.Text = String.Empty;
                txtTicketDeparture.Text = String.Empty;
                txtTicketFee.Text = String.Empty;
                txtTicketFrom.Text = String.Empty;
                txtTicketTo.Text = String.Empty;
                dateTimePicker1.Value = new DateTime(2021, 1, 1);

            }
            visualizetable();
        }
    }
}
