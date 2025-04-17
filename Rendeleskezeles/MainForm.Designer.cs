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
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.buttonModOrder = new System.Windows.Forms.Button();
            this.buttonDelOrder = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.buttonSignOut = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(27, 119);
            this.dataGridViewOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 82;
            this.dataGridViewOrders.Size = new System.Drawing.Size(603, 302);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Location = new System.Drawing.Point(27, 83);
            this.buttonAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(85, 20);
            this.buttonAddOrder.TabIndex = 1;
            this.buttonAddOrder.Text = "Új felvétel";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            // 
            // buttonModOrder
            // 
            this.buttonModOrder.Location = new System.Drawing.Point(143, 83);
            this.buttonModOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonModOrder.Name = "buttonModOrder";
            this.buttonModOrder.Size = new System.Drawing.Size(81, 20);
            this.buttonModOrder.TabIndex = 2;
            this.buttonModOrder.Text = "Módosítás";
            this.buttonModOrder.UseVisualStyleBackColor = true;
            this.buttonModOrder.Click += new System.EventHandler(this.buttonModOrder_Click);
            // 
            // buttonDelOrder
            // 
            this.buttonDelOrder.Location = new System.Drawing.Point(249, 83);
            this.buttonDelOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelOrder.Name = "buttonDelOrder";
            this.buttonDelOrder.Size = new System.Drawing.Size(81, 20);
            this.buttonDelOrder.TabIndex = 3;
            this.buttonDelOrder.Text = "Törlés";
            this.buttonDelOrder.UseVisualStyleBackColor = true;
            // 
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(361, 83);
            this.buttonReload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(81, 20);
            this.buttonReload.TabIndex = 4;
            this.buttonReload.Text = "Frissítés";
            this.buttonReload.UseVisualStyleBackColor = true;
            // 
            // buttonSignOut
            // 
            this.buttonSignOut.Location = new System.Drawing.Point(531, 83);
            this.buttonSignOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSignOut.Name = "buttonSignOut";
            this.buttonSignOut.Size = new System.Drawing.Size(99, 20);
            this.buttonSignOut.TabIndex = 5;
            this.buttonSignOut.Text = "Kijelentekezés";
            this.buttonSignOut.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(417, 24);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 24);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ügyfél keresés:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Státusz:";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Location = new System.Drawing.Point(0, 440);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip.Size = new System.Drawing.Size(663, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(663, 462);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonSignOut);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.buttonDelOrder);
            this.Controls.Add(this.buttonModOrder);
            this.Controls.Add(this.buttonAddOrder);
            this.Controls.Add(this.dataGridViewOrders);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Rendelések kezelése";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
