using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Water_Billing_System
{
    public partial class logInForm : Form
    {
        public logInForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
                bool checker = database.VerifyAccount(TbxUsername.Text, TbxPassword.Text);

                if (checker)
                {
                    MainMenu main = new MainMenu();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("INCORRECT PASSWORD OR USERNAME.");
                }
        }

        private void TbxUsername_Click(object sender, EventArgs e)
        {
            TbxUsername.SelectAll();
        }

        private void TbxPassword_Click(object sender, EventArgs e)
        {
            TbxPassword.SelectAll();
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            BtnLogin.BackColor = Color.White;
        }

        private void BtnLogin_MouseMove(object sender, MouseEventArgs e)
        {
            BtnLogin.BackColor = Color.LimeGreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
