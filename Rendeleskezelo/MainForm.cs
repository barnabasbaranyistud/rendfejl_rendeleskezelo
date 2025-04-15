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

        }

        private void LoadData()
        {
            
        }   
    }
}
