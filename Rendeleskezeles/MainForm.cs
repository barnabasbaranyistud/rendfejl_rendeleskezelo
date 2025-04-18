using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            PopulateStatusComboBoxFromApi();
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
            string selectedStatus = comboBoxStatus.SelectedItem?.ToString().Trim().ToLower() ?? "";

            var filteredOrders = response.Content
                    .Where(order => !string.IsNullOrEmpty(order.StatusName) &&
                                    (string.IsNullOrEmpty(filterCustomerName) ||
                                     (order.BillingAddress.FirstName + " " + order.BillingAddress.LastName).ToLower().Contains(filterCustomerName)) &&
                                    (string.IsNullOrEmpty(selectedStatus) ||
                                     order.StatusName.ToLower().Contains(selectedStatus)))
                    .Select(order => new OrderDTO(order))  // Map to custom DTO
                    .ToList();

            orderDTOBindingSource.DataSource = filteredOrders;
        }

        private void PopulateStatusComboBoxFromApi()
        {
            Api proxy = ApiHivas();
            var response = proxy.OrdersFindAll();

            if (response != null && response.Content != null)
            {
                var statuses = response.Content
                    .Where(order => !string.IsNullOrEmpty(order.StatusName))
                    .Select(order => order.StatusName)
                    .Distinct()
                    .ToList();

                comboBoxStatus.Items.Clear();

                foreach (var status in statuses)
                {
                    comboBoxStatus.Items.Add(status);
                }

            }
            else
            {
                MessageBox.Show("Failed to load statuses from the API.");
            }
        }


        private void buttonModOrder_Click(object sender, EventArgs e)
        {
            ModForm modForm = new ModForm(this.orderDTOBindingSource);
            modForm.ShowDialog();
        }

        private void textBoxCustomerName_TextChanged(object sender, EventArgs e)
        {
            BetoltesRendelesek();
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BetoltesRendelesek();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxStatus.SelectedIndex = -1;
            textBoxCustomerName.Clear();
            BetoltesRendelesek();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            BetoltesRendelesek();
        }

        private void buttonDelOrder_Click(object sender, EventArgs e)
        {
            // Ellenőrzés, hogy van-e aktuálisan kiválasztott rendelés
            if (orderDTOBindingSource.Current is OrderDTO selectedOrder)
            {
                string orderId = selectedOrder.bvin;

                Api proxy = ApiHivas();

                ApiResponse<bool> response = proxy.OrdersDelete(orderId);

                if (response.Content == true && response.Errors.Count == 0)
                {
                    MessageBox.Show("A rendelés sikeresen törölve lett.", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hiba történt a törlés során:\n" + string.Join("\n", response.Errors), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva rendelés törléshez.", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            BetoltesRendelesek();
        }
    }
}
