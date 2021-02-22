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
    public partial class userpanel : Form
    {
        string conString = @"Data Source=DESKTOP-MTPG2JV;Initial Catalog=Booking;Integrated Security=True";
        public userpanel(string username)
        {
            InitializeComponent();
            bunifuMaterialTextbox1.Text = username;
        }

        void goback()
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            goback();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAdressbox.Text == "" || txtmailbox.Text == "" ||
                txtnamebox.Text == "" || txtphonebox.Text == "" ||
                txtmailbox.Text == ""
                )
            {
                MessageBox.Show("Please enter passenger informations.! ");
            }
            else
            {
                string click_Query = @"insert into passenger
                                    (passenger_id,passenger_name,passenger_add,passenger_mail,passenger_phone,passenger_gender)
                                      VALUES((select login_id from AUTH where username = @username),@passenger_name,@passenger_add,@passenger_mail,@passenger_phone,@passenger_gender)";
                string seat_Query = @"insert into seat
                                    (seat_id,seat_num,seat_type,seat_ticket_id)
                                      VALUES((select passenger_seat_id from passenger where passenger_id = (select login_id from AUTH where username = @username)),@seat_num,@seat_type,
                                        (select ticket_id from ticket where ticket_date = @ticket_date and ticket_from = @ticket_from and ticket_to = @ticket_to and ticket_departure_time = @ticket_departure_time))";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand();// passenger ekleme
                    com.Connection = con;
                    com.CommandText = click_Query;
                    com.Parameters.AddWithValue("@username", bunifuMaterialTextbox1.Text);
                    com.Parameters.AddWithValue("@passenger_name", txtnamebox.Text);
                    com.Parameters.AddWithValue("@passenger_add", txtAdressbox.Text);
                    com.Parameters.AddWithValue("@passenger_mail", txtmailbox.Text);
                    com.Parameters.AddWithValue("@passenger_phone", txtphonebox.Text);
                    com.Parameters.AddWithValue("@passenger_gender", combogenderbox.SelectedItem.ToString());
                    SqlCommand com2 = new SqlCommand();// seat ekleme
                    com2.Connection = con;
                    com2.CommandText = seat_Query;
                    com2.Parameters.AddWithValue("@username", bunifuMaterialTextbox1.Text);
                    com2.Parameters.AddWithValue("@seat_num", seatnumber().ToString());
                    com2.Parameters.AddWithValue("@seat_type", combotypebox.SelectedItem.ToString()); // selection için kontrol seat_type
                    com2.Parameters.AddWithValue("@ticket_date", dateTimePicker1.Value);
                    com2.Parameters.AddWithValue("@ticket_from", combofrombox.SelectedItem.ToString());
                    com2.Parameters.AddWithValue("@ticket_to", combotobox.SelectedItem.ToString());
                    com2.Parameters.AddWithValue("@ticket_departure_time", combodeparturebox.SelectedItem.ToString());
                    
                    if (com.ExecuteNonQuery() > 0 && com2.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Passenger added succesfully!");
                    }
                    con.Close();
                }
            }
        }
        void showfee()
        {
            string Query = "select ticket_fee from ticket where ticket_date = @ticket_date and ticket_from = @ticket_from and ticket_to = @ticket_to and ticket_departure_time = @ticket_departure_time";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = Query;
                com.Parameters.AddWithValue("@ticket_date", dateTimePicker1.Value);
                com.Parameters.AddWithValue("@ticket_from", combofrombox.SelectedItem.ToString());
                com.Parameters.AddWithValue("@ticket_to", combotobox.SelectedItem.ToString());
                com.Parameters.AddWithValue("@ticket_departure_time", combodeparturebox.SelectedItem.ToString());
                SqlDataReader sqlReader = com.ExecuteReader();
                while(sqlReader.Read())
                {
                    txtFeebox.Text = sqlReader["ticket_fee"].ToString();
                }

            }
        }
        void seat_type()// combobox seat_type kontrolu
        {
            string Query = "select seat_type from seat";
            using(SqlConnection con = new SqlConnection(conString))
            {
                int tek = 0;
                int cift = 0;
                con.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = Query;
                SqlDataReader dr = com.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            if(dr["seat_type"].ToString() == "Çift")
                            {
                            cift++;
                            }
                            else if(dr["seat_type"].ToString() == "Tek")
                            {
                            tek++;
                            }
                        }
                    }
                if(tek >= 10)
                {
                    combotypebox.Items.Remove("Çift");
                }
                if(cift >= 20)
                {
                    combotypebox.Items.Remove("Tek");
                }
                con.Close();
            }
        }

        int seatnumber()// random seat number oluşturucu
        {
            string seat_Query = "select seat_num from seat";
            using (SqlConnection con = new SqlConnection(conString))
            {
                Random rnd = new Random();
                int num = rnd.Next(1,30);
                con.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = seat_Query;
                SqlDataReader dr = com.ExecuteReader(); 
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            if(Convert.ToInt32(dr["seat_num"])==num)
                            {
                                num = rnd.Next(1,30);
                            }
                        }
                    }
                con.Close();
                return num;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            seat_type();// tarih degistikten sonra tickete özel seat durumu
            using (SqlConnection sqlCon = new SqlConnection(conString))// combobox doldurulması
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM ticket WHERE ticket_date = @ticket_date", sqlCon);
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@ticket_date",dateTimePicker1.Value);
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while(sqlReader.Read())// ticket_id yi kullanarak combobox'dan girilmiş froma göre to eklenecek.!
                {
                    combofrombox.Items.Add(sqlReader["ticket_from"].ToString());
                    combotobox.Items.Add(sqlReader["ticket_to"].ToString());
                    combodeparturebox.Items.Add(sqlReader["ticket_departure_time"].ToString());
                }
                sqlCon.Close();
            }
        }

        private void txtnamebox_Enter(object sender, EventArgs e)
        {
            if (txtnamebox.Text.Equals(@"passenger_name"))
            {
                txtnamebox.Text = "";
            }
        }

        private void txtnamebox_Leave(object sender, EventArgs e)
        {
            if (txtnamebox.Text.Equals(""))
            {
                txtnamebox.Text = @"passenger_name";
            }
        }

        private void txtmailbox_Enter(object sender, EventArgs e)
        {
            if (txtmailbox.Text.Equals(@"passenger_mail"))
            {
                txtmailbox.Text = "";
            }
        }

        private void txtmailbox_Leave(object sender, EventArgs e)
        {
            if (txtmailbox.Text.Equals(""))
            {
                txtmailbox.Text = @"passenger_mail";
            }
        }

        private void txtphonebox_Enter(object sender, EventArgs e)
        {
            if (txtphonebox.Text.Equals(@"passenger_phone"))
            {
                txtphonebox.Text = "";
            }
        }

        private void txtphonebox_Leave(object sender, EventArgs e)
        {
            if(txtphonebox.Text.Equals(""))
            {
                txtphonebox.Text = @"passenger_phone";
            }
        }

        private void txtAdressbox_Enter(object sender, EventArgs e)
        {
            if(txtAdressbox.Text.Equals(@"passenger_add"))
            {
                txtAdressbox.Text = "";
            }
        }

        private void txtAdressbox_Leave(object sender, EventArgs e)
        {
            if(txtAdressbox.Text.Equals(""))
            {
                txtAdressbox.Text = @"passenger_add";
            }
        }

        private void combodeparturebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showfee();
        }
    }
}
