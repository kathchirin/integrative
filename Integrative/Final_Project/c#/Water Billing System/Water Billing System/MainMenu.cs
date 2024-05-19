using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water_Billing_System
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        

        private void BtnBilling_Click(object sender, EventArgs e)
        {
            BillingForm bill = new BillingForm();
            this.Hide();
            bill.Show();
        }

       

        private void BtnClients_Click(object sender, EventArgs e)
        {
            ClientsForm client = new ClientsForm();
            this.Hide();
            client.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            logInForm cm = new logInForm();
            this.Hide();
            cm.Show();
        }

        private void BtnLogout_MouseLeave(object sender, EventArgs e)
        {
            BtnLogout.BackColor = Color.White;
        }

        private void BtnLogout_MouseMove(object sender, MouseEventArgs e)
        {
            BtnLogout.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Viewbilling vb = new Viewbilling();
            this.Hide();
            vb.Show();
        }
    }
}
