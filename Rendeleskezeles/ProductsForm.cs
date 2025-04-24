using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rendeleskezeles
{
    public partial class ProductsForm : Form
    {
        List<string> items = new List<string>();
        List<int> quantity = new List<int>();
        string orderId = string.Empty;
        string productId = string.Empty;
        public ProductsForm(BindingSource bindingSource)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.orderDTOBindingSource.DataSource = bindingSource.Current;
            
        }



        private static Api ApiHivas()
        {
            string url = "http://rendfejl10001.northeurope.cloudapp.azure.com:8080";
            string kulcs = "1-7d286e89-c54f-430f-906e-f4ec7847b883"; // <-- Ide tedd a saját API kulcsodat
            Api proxy = new Api(url, kulcs);
            return proxy;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            Api proxy = ApiHivas();

            var response = proxy.ProductsFindAll();

            orderId = ((OrderDTO)orderDTOBindingSource.Current).bvin;

            var order = proxy.OrdersFind(orderId);

            items = order.Content.Items.Select(item => item.ProductName).ToList();
            quantity = order.Content.Items.Select(item => item.Quantity).ToList();
            if (items != null)
            {
                listBoxOrdered.DataSource = items;
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = textBoxFilter.Text.ToLower();

            Api proxy = ApiHivas();

            var response = proxy.ProductsFindAll();

            var filtered = response.Content
                .Select(product => product.ProductName)
                .Where(o => o.ToLower().Contains(filter))
                .ToArray();

            listBoxProducts.Items.Clear();
            listBoxProducts.Items.AddRange(filtered);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void listBoxOrdered_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxOrdered.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < quantity.Count)
            {
                labelQuantity.Text = $"Mennyiség: {quantity[selectedIndex]}";
            }
            else
            {
                labelQuantity.Text = "";
            }
        }

        private void UpdateOrderThroughApi()
        {
            Api proxy = ApiHivas();
            var response = proxy.OrdersFind(orderId);
            var order = response.Content;

            var items = new List<LineItemDTO>();

            order.Items = items;


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
    }
}
