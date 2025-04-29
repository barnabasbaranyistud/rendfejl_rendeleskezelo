using Hotcakes.CommerceDTO.v1.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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

            string correctUsername = ConfigurationManager.AppSettings["Username"];
            string correctPassword = ConfigurationManager.AppSettings["Password"];

            if (username == correctUsername && password == correctPassword)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblError.Text = "Hibás név vagy jelszó.";
                lblError.Visible = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
}
}
