namespace Rendeleskezelo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            BetoltesRendelesek();
        }


        private static Api ApiHivas()
        {
            string url = "http://rendfejl10001.northeurope.cloudapp.azure.com:8080/DesktopModules/Hotcakes/API/rest/v1";
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

            dataGridViewOrders.DataSource = response.Content;
        }
    }
}
