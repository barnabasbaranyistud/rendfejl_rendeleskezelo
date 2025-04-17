using System.Drawing;
using System.Windows.Forms;

namespace Rendeleskezelo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewOrders = new DataGridView();
            buttonAddOrder = new Button();
            buttonModOrder = new Button();
            buttonDelOrder = new Button();
            buttonReload = new Button();
            buttonSignOut = new Button();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            statusStrip = new StatusStrip();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.BackgroundColor = SystemColors.Window;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Location = new Point(22, 314);
            dataGridViewOrders.Margin = new Padding(6, 6, 6, 6);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersWidth = 82;
            dataGridViewOrders.Size = new Size(1343, 913);
            dataGridViewOrders.TabIndex = 0;
            // 
            // buttonAddOrder
            // 
            buttonAddOrder.Location = new Point(58, 205);
            buttonAddOrder.Margin = new Padding(6, 6, 6, 6);
            buttonAddOrder.Name = "buttonAddOrder";
            buttonAddOrder.Size = new Size(184, 49);
            buttonAddOrder.TabIndex = 1;
            buttonAddOrder.Text = "Új felvétel";
            buttonAddOrder.UseVisualStyleBackColor = true;
            // 
            // buttonModOrder
            // 
            buttonModOrder.Location = new Point(310, 205);
            buttonModOrder.Margin = new Padding(6, 6, 6, 6);
            buttonModOrder.Name = "buttonModOrder";
            buttonModOrder.Size = new Size(175, 49);
            buttonModOrder.TabIndex = 2;
            buttonModOrder.Text = "Módosítás";
            buttonModOrder.UseVisualStyleBackColor = true;
            buttonModOrder.Click += buttonModOrder_Click;
            // 
            // buttonDelOrder
            // 
            buttonDelOrder.Location = new Point(539, 205);
            buttonDelOrder.Margin = new Padding(6, 6, 6, 6);
            buttonDelOrder.Name = "buttonDelOrder";
            buttonDelOrder.Size = new Size(175, 49);
            buttonDelOrder.TabIndex = 3;
            buttonDelOrder.Text = "Törlés";
            buttonDelOrder.UseVisualStyleBackColor = true;
            // 
            // buttonReload
            // 
            buttonReload.Location = new Point(782, 205);
            buttonReload.Margin = new Padding(6, 6, 6, 6);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(175, 49);
            buttonReload.TabIndex = 4;
            buttonReload.Text = "Frissítés";
            buttonReload.UseVisualStyleBackColor = true;
            // 
            // buttonSignOut
            // 
            buttonSignOut.Location = new Point(1151, 205);
            buttonSignOut.Margin = new Padding(6, 6, 6, 6);
            buttonSignOut.Name = "buttonSignOut";
            buttonSignOut.Size = new Size(214, 49);
            buttonSignOut.TabIndex = 5;
            buttonSignOut.Text = "Kijelentekezés";
            buttonSignOut.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(903, 60);
            comboBox1.Margin = new Padding(6, 6, 6, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(338, 40);
            comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(227, 60);
            textBox1.Margin = new Padding(6, 6, 6, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(457, 39);
            textBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 66);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 32);
            label1.TabIndex = 8;
            label1.Text = "Ügyfél keresés:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(782, 66);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(94, 32);
            label2.TabIndex = 9;
            label2.Text = "Státusz:";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(32, 32);
            statusStrip.Location = new Point(0, 1275);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 26, 0);
            statusStrip.Size = new Size(1437, 22);
            statusStrip.TabIndex = 10;
            statusStrip.Text = "statusStrip1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1437, 1297);
            Controls.Add(statusStrip);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(buttonSignOut);
            Controls.Add(buttonReload);
            Controls.Add(buttonDelOrder);
            Controls.Add(buttonModOrder);
            Controls.Add(buttonAddOrder);
            Controls.Add(dataGridViewOrders);
            Margin = new Padding(6, 6, 6, 6);
            Name = "MainForm";
            Text = "Rendelések kezelése";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewOrders;
        private Button buttonAddOrder;
        private Button buttonModOrder;
        private Button buttonDelOrder;
        private Button buttonReload;
        private Button buttonSignOut;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private StatusStrip statusStrip;
    }
}
