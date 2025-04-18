using Rendeleskezeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            // Ez a form saját BindingSource-ja, amit a designer használ (szintén orderDTOBindingSource a neve itt is)
            this.orderDTOBindingSource.DataSource = source;
        }

        private void ModForm_Load(object sender, EventArgs e)
        {

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
    }
}
