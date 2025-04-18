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
            PopulateStatusComboBox(source);
        }


        private bool ValidateForm()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(textBoxNev.Text))
                errors.AppendLine("A vevő neve kötelező.");

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || !IsValidEmail(textBoxEmail.Text))
                errors.AppendLine("Érvényes e-mail cím megadása kötelező.");

            if (dateTimePickerDatum.Value > DateTime.Now)
                errors.AppendLine("A rendelés dátuma nem lehet jövőbeli időpont.");

            if (comboBoxStatusz.SelectedIndex < 0)
                errors.AppendLine("Kérjük, válassz ki egy státuszt.");

            if (string.IsNullOrWhiteSpace(textBoxSzallítasiCim.Text))
                errors.AppendLine("A szállítási cím megadása kötelező.");

            if (!IsValidAddress(textBoxSzallítasiCim.Text))
            {
                errors.AppendLine("A szállítási cím nem megfelelő formátumú. Példa: 'Fővám tér 8, Budapest, Hungary, 1098'");
            }

            if (!decimal.TryParse(textBoxSzallitasiAr.Text, out decimal shippingCost) || shippingCost < 0)
                errors.AppendLine("A szállítási költség csak pozitív szám lehet.");

            if (!decimal.TryParse(textBoxMegrendelesAr.Text, out decimal orderTotal) || orderTotal < 0)
                errors.AppendLine("A rendelés végösszege csak pozitív szám lehet.");

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

        private void PopulateStatusComboBox(BindingSource source)
        {
            var statuses = new HashSet<string>();

            foreach (var item in source.List)
            {
                if (item is OrderDTO order && !string.IsNullOrWhiteSpace(order.Status))
                {
                    statuses.Add(order.Status);
                }
            }

            comboBoxStatusz.Items.Clear();
            comboBoxStatusz.Items.AddRange(statuses.ToArray());
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
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
