using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Vml.Office;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.CommerceDTO.v1.Orders;
using System;
using System.Collections.Generic;
using System.IO;
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
            List<string> itemsFromComboBox = new List<string>();
            foreach (var item in comboBoxStatus.Items)
            {
                itemsFromComboBox.Add(item.ToString());
            }
            modForm.PopulateStatusComboBox(itemsFromComboBox);
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
        private void ImportOrdersFromExcel()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var path = ofd.FileName;

                using (var workbook = new XLWorkbook(path))
                {
                    var worksheet = workbook.Worksheets.First();
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // első sor fejléc
                    Api proxy = ApiHivas();

                    foreach (var row in rows)
                    {
                        string firstName = row.Cell(1).GetString();
                        string lastName = row.Cell(2).GetString();
                        string email = row.Cell(3).GetString();
                        string city = row.Cell(4).GetString();
                        string line1 = row.Cell(5).GetString();
                        string postalCode = row.Cell(6).GetString();
                        string[] productIds = row.Cell(7).GetString().Split(',');
                        string[] quantities = row.Cell(8).GetString().Split(',');

                        if (productIds.Length != quantities.Length)
                        {
                            MessageBox.Show("A termékazonosítók és mennyiségek száma nem egyezik meg.");
                            continue;
                        }

                        var items = new List<LineItemDTO>();

                        for (int i = 0; i < productIds.Length; i++)
                        {
                            string productId = productIds[i].Trim();
                            if (!int.TryParse(quantities[i].Trim(), out int quantity))
                            {
                                MessageBox.Show($"Érvénytelen mennyiség: {quantities[i]}");
                                continue;
                            }

                            ApiResponse<ProductDTO> product = proxy.ProductsFind(productId);

                            if (product.Content == null)
                            {
                                MessageBox.Show($"Nem található termék azonosítóval: {productId}");
                                continue;
                            }

                            items.Add(new LineItemDTO
                            {
                                ProductId = productId,
                                Quantity = quantity,
                                ProductShortDescription = product.Content.ShortDescription,
                                ProductName = product.Content.ProductName,
                                ProductSku = product.Content.Sku,
                                BasePricePerItem = product.Content.ListPrice,
                                LineTotal = product.Content.ListPrice * quantity,
                            });
                        }

                        var order = new Hotcakes.CommerceDTO.v1.Orders.OrderDTO
                        {
                            BillingAddress = new AddressDTO
                            {
                                AddressType = AddressTypesDTO.Billing,
                                FirstName = firstName,
                                LastName = lastName,
                                City = city,
                                Line1 = line1,
                                PostalCode = postalCode,
                                CountryBvin = "ACF84F60-6B00-4131-A5BE-FA202F1EB569", // HUN
                            },
                            ShippingAddress = new AddressDTO
                            {
                                AddressType = AddressTypesDTO.Shipping,
                                FirstName = firstName,
                                LastName = lastName,
                                City = city,
                                Line1 = line1,
                                PostalCode = postalCode,
                                CountryBvin = "ACF84F60-6B00-4131-A5BE-FA202F1EB569",
                            },
                            UserEmail = email,
                            UserID = "1",
                            StatusCode = "F37EC405-1EC6-4a91-9AC4-6836215FBBBC",
                            StatusName = "Received",
                            IsPlaced = true,
                            PaymentStatus = OrderPaymentStatusDTO.Unpaid,
                            ShippingStatus = OrderShippingStatusDTO.Unshipped,
                            ShippingMethodId = "cb834316-87ea-4808-855d-ea56235fad69",
                            ShippingMethodDisplayName = "Flat rate per order",
                            ShippingProviderId = "301AA2B8-F43C-42fe-B77E-A7E1CB1DD40E",

                            Items = items
                        };

                        ApiResponse<Hotcakes.CommerceDTO.v1.Orders.OrderDTO> response = proxy.OrdersCreate(order);

                        if (response.Errors.Any())
                        {
                            MessageBox.Show("Hiba a rendelés létrehozásakor: " + string.Join(", ", response.Errors));
                        }
                        else
                        {                            
                            MessageBox.Show("Sikeres rendelés: " + response.Content.Bvin);
                        }
                    }
                }
            }
            BetoltesRendelesek();
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            ImportOrdersFromExcel();
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
