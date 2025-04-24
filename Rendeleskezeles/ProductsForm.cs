using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Vml.Office;
using Hotcakes.CommerceDTO.v1;
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
        public ProductsForm(BindingSource bindingSource)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.orderDTOBindingSource.DataSource = bindingSource.Current;
            orderId = ((OrderDTO)bindingSource.Current).bvin;
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

            LoadOrders(proxy);

            productBindingSource.DataSource = response.Content.ToList();
            listBoxProducts.DataSource = productBindingSource;
            listBoxProducts.DisplayMember = "ProductName";
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxFilter.Text.ToLower();

            var allProducts = (List<ProductDTO>)productBindingSource.DataSource;

            var filtered = allProducts
            .Where(p => p.ProductName.ToLower().Contains(filterText))
            .ToList();

            listBoxProducts.DataSource = null;
            listBoxProducts.DataSource = filtered;
            listBoxProducts.DisplayMember = "ProductName";
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            UpdateOrder_Remove();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UpdateOrder_Add();
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

        private void UpdateOrder_Add()
        {
            Api proxy = ApiHivas();
            var response = proxy.OrdersFind(orderId);
            var originalOrder = response.Content;

            var selectedProduct = (ProductDTO)productBindingSource.Current;
            string productId = selectedProduct.Bvin;
            int quantity = (int)numericQuantity.Value;

            ApiResponse<ProductDTO> product = proxy.ProductsFind(productId);

            if (product.Content == null)
            {
                MessageBox.Show("Nem található termék azonosítóval: " + productId);
                return;
            }

            originalOrder.Items.Add(new LineItemDTO
            {
                ProductId = productId,
                Quantity = quantity,
                ProductShortDescription = product.Content.ShortDescription,
                ProductName = product.Content.ProductName,
                ProductSku = product.Content.Sku,
                BasePricePerItem = product.Content.ListPrice,
                LineTotal = product.Content.ListPrice * quantity
            });

            var deleteResponse = proxy.OrdersDelete(orderId);

            if (deleteResponse.Errors != null && deleteResponse.Errors.Count > 0)
            {
                MessageBox.Show("Nem sikerült törölni a rendelést: " + string.Join(", ", deleteResponse.Errors));
                return;
            }

            originalOrder.Bvin = null; // nullázzuk, hogy új rendelésként jöjjön létre
            ApiResponse<Hotcakes.CommerceDTO.v1.Orders.OrderDTO> createResponse = proxy.OrdersCreate(originalOrder);

            if (createResponse.Errors.Any())
            {
                MessageBox.Show("Hiba a rendelés újralétrehozásakor: " + string.Join(", ", createResponse.Errors));
            }
            else
            {
                orderId = createResponse.Content.Bvin;
                MessageBox.Show("Rendelés sikeresen frissítve új létrehozással: " + createResponse.Content.Bvin);
            }

            LoadOrders(proxy);

        }

        private void LoadOrders(Api proxy)
        {
            var order = proxy.OrdersFind(orderId);

            items = order.Content.Items.Select(item => item.ProductName).ToList();
            quantity = order.Content.Items.Select(item => item.Quantity).ToList();
            if (items != null)
            {
                listBoxOrdered.DataSource = items;
            }
        }

        private void UpdateOrder_Remove()
        {
            Api proxy = ApiHivas();
            var response = proxy.OrdersFind(orderId);
            var order = response.Content;

            string selectedProductName = listBoxOrdered.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedProductName))
            {
                MessageBox.Show("Nincs kiválasztva termék a rendelésből.");
                return;
            }

            // Betöltjük az összes terméket és megkeressük a nevet
            var allProducts = proxy.ProductsFindAll();
            var matchingProduct = allProducts.Content.FirstOrDefault(p => p.ProductName == selectedProductName);

            if (matchingProduct == null)
            {
                MessageBox.Show($"Nem található termék ilyen névvel: {selectedProductName}");
                return;
            }

            string productId = matchingProduct.Bvin;

            // Eltávolítjuk a megfelelő tételt a rendelésből
            var existingItem = order.Items.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem == null)
            {
                MessageBox.Show("A kiválasztott termék nem található ebben a rendelésben.");
                return;
            }

            order.Items.Remove(existingItem);

            var updateResponse = proxy.OrdersUpdate(order);
            if (updateResponse.Errors == null || updateResponse.Errors.Count == 0)
            {
                MessageBox.Show("Termék sikeresen eltávolítva a rendelésből!");
            }
            else
            {
                string errorMessages = string.Join("\n", updateResponse.Errors);
                MessageBox.Show("Hiba történt az eltávolítás során: " + errorMessages);
            }

            LoadOrders(proxy);
        }
    }
}
