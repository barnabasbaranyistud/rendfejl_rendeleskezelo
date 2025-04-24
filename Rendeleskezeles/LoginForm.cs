using Hotcakes.CommerceDTO.v1.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var loginSuccess = await LoginAsync(username, password);

            if (loginSuccess)
            {
                // Bejelentkezés sikeres, folytasd a munkát
                MessageBox.Show("Login successful!");
            }
            else
            {
                // Bejelentkezés nem sikerült
                MessageBox.Show("Login failed.");
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginRequest = new
            {
                Username = username,
                Password = password
            };

            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://rendfejl10001.northeurope.cloudapp.azure.com:8080/api/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<dynamic>(responseContent).Token;
                    // Token elmentése, például a felhasználó munkamenetéhez
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    return false;
                }
            }
        }

    }
}
