using Hotcakes.CommerceDTO.v1.Client;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Rendeleskezelo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dataGridViewOrders.DataSource = orderDTOBindingSource;
            BetoltesRendelesek();
        }



        private static Api ApiHivas()
        {
            string url = "http://rendfejl10001.northeurope.cloudapp.azure.com:8080";
            string kulcs = "1-7d286e89-c54f-430f-906e-f4ec7847b883"; // <-- Ide tedd a saját API kulcsodat
            Api proxy = new Api(url, kulcs);
            return proxy;
        }

        private void BetoltesRendelesek()
        {
            Api proxy = ApiHivas();

            var response = proxy.OrdersFindAll();

            if (response == null || response.Content == null || response.Content.Count == 0)
            {
                MessageBox.Show("Nem sikerült lekérni a rendeléseket vagy nincs adat.");
                return;
            }

            string filterCustomerName = textBoxCustomerName.Text.Trim().ToLower();

            var filteredOrders = response.Content
            .Where(order => !string.IsNullOrEmpty(order.StatusName) &&
                    (string.IsNullOrEmpty(filterCustomerName) ||
                     (order.BillingAddress.FirstName + " " + order.BillingAddress.LastName).ToLower().Contains(filterCustomerName)))
            .Select(order => new OrderDTO(order))  // Map to custom DTO
            .ToList();

            orderDTOBindingSource.DataSource = filteredOrders;
        }

        private void buttonModOrder_Click(object sender, EventArgs e)
        {
            ModForm modForm = new ModForm();
            if (modForm.ShowDialog() == DialogResult.OK)
            {
                // Handle the case when the dialog result is OK
            }
            else
            {
                // Handle the case when the dialog result is not OK
            }
        }

        private void textBoxCustomerName_TextChanged(object sender, EventArgs e)
        {
            BetoltesRendelesek();
        }
    }
}
