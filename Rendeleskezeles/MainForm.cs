using ClosedXML.Excel;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.CommerceDTO.v1.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Rendeleskezelo
{
    public partial class MainForm : Form
    {
        List<string> items = new List<string>();
        List<int> quantities = new List<int>();
        string orderId = string.Empty;
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dataGridViewOrders.DataSource = orderDTOBindingSource;
            BetoltesRendelesek();
            PopulateStatusComboBoxFromApi();
            orderId = ((OrderDTO)orderDTOBindingSource.Current).bvin;
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

            BindingList<OrderDTO> filteredOrders = new BindingList<OrderDTO>(
                response.Content
                    .Where(order => !string.IsNullOrEmpty(order.StatusName) &&
                                    (string.IsNullOrEmpty(filterCustomerName) ||
                                     (order.BillingAddress.FirstName + " " + order.BillingAddress.LastName).ToLower().Contains(filterCustomerName)) &&
                                    (string.IsNullOrEmpty(selectedStatus) ||
                                     order.StatusName.ToLower().Contains(selectedStatus)))
                    .Select(order => new OrderDTO(order))  // Map to custom DTO
                    .ToList()
            );

            orderDTOBindingSource.DataSource = filteredOrders;
            LoadOrders(proxy);

        }

        private void ShowStatusMessage(string message)
        {
            toolStripStatusLabel1.Text = message;
            statusStrip.Refresh();
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
            if (modForm.ShowDialog() == DialogResult.OK)
            {
                ShowStatusMessage("Rendelés módosítva.");
            }
            BetoltesRendelesek();
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
            ShowStatusMessage("Rendelések betöltve");
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            BetoltesRendelesek();
            ShowStatusMessage("Rendelések betöltve.");
        }

        private void buttonDelOrder_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Biztosan törölni szeretné a rendelést?", "Törlés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            // Ellenőrzés, hogy van-e aktuálisan kiválasztott rendelés
            if (orderDTOBindingSource.Current is OrderDTO selectedOrder)
            {
                string orderId = selectedOrder.bvin;

                Api proxy = ApiHivas();

                ApiResponse<bool> response = proxy.OrdersDelete(orderId);

                if (response.Content == true && response.Errors.Count == 0)
                {
                    ShowStatusMessage("A rendelés sikeresen törölve lett.");
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
                                ProductId = productId.ToUpper(),
                                Quantity = quantity,
                                ProductShortDescription = product.Content.ShortDescription,
                                ProductName = product.Content.ProductName,
                                ProductSku = product.Content.Sku,
                                BasePricePerItem = product.Content.SitePrice,
                                LineTotal = product.Content.SitePrice * quantity,
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
                                CountryBvin = "acf84f60-6b00-4131-a5be-fa202f1eb569", // HUN
                                CountryName = "Hungary",
                            },
                            ShippingAddress = new AddressDTO
                            {
                                AddressType = AddressTypesDTO.Shipping,
                                FirstName = firstName,
                                LastName = lastName,
                                City = city,
                                Line1 = line1,
                                PostalCode = postalCode,
                                CountryBvin = "acf84f60-6b00-4131-a5be-fa202f1eb569",
                                CountryName = "Hungary",
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
                            ShowStatusMessage("Sikeres rendelés létrehozás: " + response.Content.Bvin);
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

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void dataGridViewOrders_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewOrders.Columns[e.ColumnIndex].DataPropertyName;
            var direction = ListSortDirection.Ascending;

            // Optional: toggle direction if already sorted
            if (orderDTOBindingSource.Sort == $"{columnName} ASC")
                direction = ListSortDirection.Descending;

            orderDTOBindingSource.Sort = $"{columnName} {(direction == ListSortDirection.Ascending ? "ASC" : "DESC")}";
        }

        private void buttonMinta_Click(object sender, EventArgs e)
        {
            GenerateExampleExcel();
        }

        public void GenerateExampleExcel()
        {
            // Open the SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set the file filter for Excel files
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                // Set the default file name
                saveFileDialog.FileName = "OrderExample.xlsx";

                // Show the dialog and check if the user selected a file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Create a new workbook
                    using (var workbook = new XLWorkbook())
                    {
                        // Add a worksheet to the workbook
                        var worksheet = workbook.AddWorksheet("OrderExample");

                        // Add the header row
                        worksheet.Cell(1, 1).Value = "FirstName";
                        worksheet.Cell(1, 2).Value = "LastName";
                        worksheet.Cell(1, 3).Value = "Email";
                        worksheet.Cell(1, 4).Value = "City";
                        worksheet.Cell(1, 5).Value = "Line1";
                        worksheet.Cell(1, 6).Value = "PostalCode";
                        worksheet.Cell(1, 7).Value = "ProductId";
                        worksheet.Cell(1, 8).Value = "Quantity";

                        // Add the example data
                        worksheet.Cell(2, 1).Value = "bbb";
                        worksheet.Cell(2, 2).Value = "bbb";
                        worksheet.Cell(2, 3).Value = "bb@email.com";
                        worksheet.Cell(2, 4).Value = "Domsod";
                        worksheet.Cell(2, 5).Value = "Kozepso ut 2";
                        worksheet.Cell(2, 6).Value = "2344";
                        worksheet.Cell(2, 7).Value = "C279C8B7-574B-4ABF-BD41-9A27DFBD4D34,C279C8B7-574B-4ABF-BD41-9A27DFBD4D34";
                        worksheet.Cell(2, 8).Value = "2,1";

                        // Save the workbook to the selected file path
                        workbook.SaveAs(saveFileDialog.FileName);

                        // Optionally show a message to the user that the file is saved
                        MessageBox.Show($"Excel file saved at: {saveFileDialog.FileName}");
                    }
                }
            }
        }

        private void listBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxProducts.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < quantities.Count)
            {
                labelQuantity.Text = $"Mennyiség: {quantities[selectedIndex]}";
            }
            else
            {
                labelQuantity.Text = "";
            }
        }

        private void LoadOrders(Api proxy)
        {
            orderId = ((OrderDTO)orderDTOBindingSource.Current).bvin;
            var order = proxy.OrdersFind(orderId);

            items = order.Content.Items.Select(item => item.ProductName).ToList();
            quantities = order.Content.Items.Select(item => item.Quantity).ToList();
            if (items != null)
            {
                listBoxProducts.DataSource = items;
            }
        }

        private void dataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            Api proxy = ApiHivas();
            LoadOrders(proxy);
        }
    }
}
