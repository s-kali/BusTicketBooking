using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booking_Database
{
    public partial class adminpanel : Form
    {
        public adminpanel()
        {
            InitializeComponent();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            addticket addticket = new addticket();
            addticket.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            managepass managepass = new managepass();
            managepass.Show();
        }
    }
}
