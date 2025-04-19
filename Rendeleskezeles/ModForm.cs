using Hotcakes.CommerceDTO.v1.Client;
using Rendeleskezeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rendeleskezelo
{
    public partial class ModForm : Form
    {
        public ModForm(BindingSource source)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.orderDTOBindingSource.DataSource = source.Current;           
        }


        private bool ValidateForm()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(textBoxNev.Text))
                errors.AppendLine("A vevő neve kötelező.");

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || !IsValidEmail(textBoxEmail.Text))
                errors.AppendLine("Érvényes e-mail cím megadása kötelező.");

            if (dateTimePickerDatum.Value.Date > DateTime.Now.Date)
                errors.AppendLine("A rendelés dátuma nem lehet jövőbeli időpont.");

            if (comboBoxStatusz.SelectedIndex < 0)
                errors.AppendLine("Kérjük, válassz ki egy státuszt.");

            if (string.IsNullOrWhiteSpace(textBoxSzallítasiCim.Text))
                errors.AppendLine("A szállítási cím megadása kötelező.");

            if (!IsValidAddress(textBoxSzallítasiCim.Text))
            {
                errors.AppendLine("A szállítási cím nem megfelelő formátumú. Példa: 'Fővám tér 8, Budapest, Hungary, 1098'");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Hibás adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidAddress(string address)
        {
            var pattern = @"^[\p{L} ]+\s\d+,\s[\p{L} ]+,\s[\p{L} ]+,\s\d{4}$";
            return Regex.IsMatch(address, pattern);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public void PopulateStatusComboBox(List<string> items)
        {
            comboBoxStatusz.Items.Clear();
            comboBoxStatusz.Items.AddRange(items.ToArray());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ProductsForm prodForm = new ProductsForm(this.orderDTOBindingSource);
            if (prodForm.ShowDialog() == DialogResult.OK)
            {
                // Handle the case when the dialog result is OK
            }
            else
            {
                // Handle the case when the dialog result is not OK
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                UpdateOrderThroughApi();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private string GetStatusCodeFromComboBox(string statusName)
        {
            switch (statusName)
            {
                case "Received":
                    return "F37EC405-1EC6-4a91-9AC4-6836215FBBBC";
                case "Ready for Shipping":
                    return "0c6d4b57-3e46-4c20-9361-6b0e5827db5a";
                case "Complete":
                    return "09D7305D-BD95-48d2-A025-16ADC827582A";
                default:
                    return null;  // You could return an error message or a default code if necessary
            }
        }


        private void UpdateOrderThroughApi()
        {
            string url = "http://rendfejl10001.northeurope.cloudapp.azure.com:8080";
            string kulcs = "1-7d286e89-c54f-430f-906e-f4ec7847b883";
            string orderId = ((OrderDTO)orderDTOBindingSource.Current).bvin;

            Api proxy = new Api(url, kulcs);
            var response = proxy.OrdersFind(orderId);
            var order = response.Content;

            var nev = textBoxNev.Text.Split(' ').Select(x => x.Trim()).ToArray();
            order.BillingAddress.FirstName = nev[0];
            order.BillingAddress.LastName = nev[1];

            order.UserEmail = textBoxEmail.Text;
            order.StatusName = comboBoxStatusz.Text;
            order.StatusCode = GetStatusCodeFromComboBox(comboBoxStatusz.Text);

            order.TimeOfOrderUtc = dateTimePickerDatum.Value.ToUniversalTime();

            // Szállítási cím (parszolni kell a TextBoxból)
            var cim = textBoxSzallítasiCim.Text.Split(',').Select(x => x.Trim()).ToArray();
            if (cim.Length == 4)
            {
                order.ShippingAddress.Line1 = cim[0];
                order.ShippingAddress.City = cim[1];
                order.ShippingAddress.CountryName = cim[2];
                order.ShippingAddress.PostalCode = cim[3];
            }

            var updateResponse = proxy.OrdersUpdate(order);
            if (updateResponse.Errors == null || updateResponse.Errors.Count == 0)
            {
                MessageBox.Show("A rendelés sikeresen frissítve lett!");
            }
            else
            {
                string errorMessages = string.Join("\n", updateResponse.Errors);
                MessageBox.Show("Hiba történt a frissítés során: " + errorMessages);
            }

        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            ProductsForm prodForm = new ProductsForm(this.orderDTOBindingSource);
        }
    }
}
