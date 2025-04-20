using System.Drawing;
using System.Windows.Forms;

namespace Rendeleskezelo
{
    partial class ModForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNev = new System.Windows.Forms.TextBox();
            this.orderDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxSzallítasiCim = new System.Windows.Forms.TextBox();
            this.dateTimePickerDatum = new System.Windows.Forms.DateTimePicker();
            this.comboBoxStatusz = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelGrand = new System.Windows.Forms.Label();
            this.buttonProducts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Név:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "E-mail cím:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rendelés dátuma:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 267);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rendelés státusza:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 342);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Szállítási cím:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(52, 415);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Megrendelés összege:";
            // 
            // textBoxNev
            // 
            this.textBoxNev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNev.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "CustomerName", true));
            this.textBoxNev.Location = new System.Drawing.Point(296, 44);
            this.textBoxNev.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxNev.Name = "textBoxNev";
            this.textBoxNev.Size = new System.Drawing.Size(420, 31);
            this.textBoxNev.TabIndex = 9;
            // 
            // orderDTOBindingSource
            // 
            this.orderDTOBindingSource.DataSource = typeof(OrderDTO);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "Email", true));
            this.textBoxEmail.Location = new System.Drawing.Point(296, 117);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(420, 31);
            this.textBoxEmail.TabIndex = 10;
            // 
            // textBoxSzallítasiCim
            // 
            this.textBoxSzallítasiCim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSzallítasiCim.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "ShippingAddress", true));
            this.textBoxSzallítasiCim.Location = new System.Drawing.Point(296, 342);
            this.textBoxSzallítasiCim.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxSzallítasiCim.Name = "textBoxSzallítasiCim";
            this.textBoxSzallítasiCim.Size = new System.Drawing.Size(420, 31);
            this.textBoxSzallítasiCim.TabIndex = 11;
            // 
            // dateTimePickerDatum
            // 
            this.dateTimePickerDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDatum.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderDTOBindingSource, "OrderDate", true));
            this.dateTimePickerDatum.Location = new System.Drawing.Point(296, 185);
            this.dateTimePickerDatum.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimePickerDatum.Name = "dateTimePickerDatum";
            this.dateTimePickerDatum.Size = new System.Drawing.Size(420, 31);
            this.dateTimePickerDatum.TabIndex = 14;
            // 
            // comboBoxStatusz
            // 
            this.comboBoxStatusz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatusz.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "Status", true));
            this.comboBoxStatusz.FormattingEnabled = true;
            this.comboBoxStatusz.Location = new System.Drawing.Point(296, 262);
            this.comboBoxStatusz.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxStatusz.Name = "comboBoxStatusz";
            this.comboBoxStatusz.Size = new System.Drawing.Size(420, 33);
            this.comboBoxStatusz.TabIndex = 15;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(372, 492);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(174, 50);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Mégse";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(558, 492);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(162, 50);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Mentés";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelGrand
            // 
            this.labelGrand.AutoSize = true;
            this.labelGrand.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "OrderTotal", true));
            this.labelGrand.Location = new System.Drawing.Point(322, 415);
            this.labelGrand.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelGrand.Name = "labelGrand";
            this.labelGrand.Size = new System.Drawing.Size(31, 25);
            this.labelGrand.TabIndex = 18;
            this.labelGrand.Text = "Ft";
            // 
            // buttonProducts
            // 
            this.buttonProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonProducts.Location = new System.Drawing.Point(57, 492);
            this.buttonProducts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(140, 50);
            this.buttonProducts.TabIndex = 19;
            this.buttonProducts.Text = "Részletek";
            this.buttonProducts.UseVisualStyleBackColor = false;
            this.buttonProducts.Visible = false;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // ModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 567);
            this.Controls.Add(this.buttonProducts);
            this.Controls.Add(this.labelGrand);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxStatusz);
            this.Controls.Add(this.dateTimePickerDatum);
            this.Controls.Add(this.textBoxSzallítasiCim);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxNev);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ModForm";
            this.Text = "ModForm";
            ((System.ComponentModel.ISupportInitialize)(this.orderDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private TextBox textBoxNev;
        private TextBox textBoxEmail;
        private TextBox textBoxSzallítasiCim;
        private DateTimePicker dateTimePickerDatum;
        private ComboBox comboBoxStatusz;
        private Button buttonCancel;
        private Button buttonSave;
        private BindingSource orderDTOBindingSource;
        private Label labelGrand;
        private Button buttonProducts;
    }
}