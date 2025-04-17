using Hotcakes.CommerceDTO.v1.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rendeleskezelo
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();


            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Egyszerű hitelesítés
            if (username == "a" && password == "a")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Hibás felhasználónév vagy jelszó!";
                lblError.Visible = true;
            }
        }
    }
}
