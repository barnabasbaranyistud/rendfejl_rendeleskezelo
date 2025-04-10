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
            dataGridView1 = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(723, 428);
            dataGridView1.TabIndex = 0;
            // 
            // buttonAddOrder
            // 
            buttonAddOrder.Location = new Point(31, 96);
            buttonAddOrder.Name = "buttonAddOrder";
            buttonAddOrder.Size = new Size(99, 23);
            buttonAddOrder.TabIndex = 1;
            buttonAddOrder.Text = "Új felvétel";
            buttonAddOrder.UseVisualStyleBackColor = true;
            // 
            // buttonModOrder
            // 
            buttonModOrder.Location = new Point(167, 96);
            buttonModOrder.Name = "buttonModOrder";
            buttonModOrder.Size = new Size(94, 23);
            buttonModOrder.TabIndex = 2;
            buttonModOrder.Text = "Módosítás";
            buttonModOrder.UseVisualStyleBackColor = true;
            // 
            // buttonDelOrder
            // 
            buttonDelOrder.Location = new Point(290, 96);
            buttonDelOrder.Name = "buttonDelOrder";
            buttonDelOrder.Size = new Size(94, 23);
            buttonDelOrder.TabIndex = 3;
            buttonDelOrder.Text = "Törlés";
            buttonDelOrder.UseVisualStyleBackColor = true;
            // 
            // buttonReload
            // 
            buttonReload.Location = new Point(421, 96);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(94, 23);
            buttonReload.TabIndex = 4;
            buttonReload.Text = "Frissítés";
            buttonReload.UseVisualStyleBackColor = true;
            // 
            // buttonSignOut
            // 
            buttonSignOut.Location = new Point(620, 96);
            buttonSignOut.Name = "buttonSignOut";
            buttonSignOut.Size = new Size(115, 23);
            buttonSignOut.TabIndex = 5;
            buttonSignOut.Text = "Kijelentekezés";
            buttonSignOut.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(486, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(184, 23);
            comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(122, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(248, 23);
            textBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 31);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 8;
            label1.Text = "Ügyfél keresés:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(421, 31);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 9;
            label2.Text = "Státusz:";
            // 
            // statusStrip
            // 
            statusStrip.Location = new Point(0, 586);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(774, 22);
            statusStrip.TabIndex = 10;
            statusStrip.Text = "statusStrip1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(774, 608);
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
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "Rendelések kezelése";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
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
