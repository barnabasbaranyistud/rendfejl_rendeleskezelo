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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNev = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxSzallítasiCim = new System.Windows.Forms.TextBox();
            this.textBoxSzallitasiAr = new System.Windows.Forms.TextBox();
            this.textBoxMegrendelesAr = new System.Windows.Forms.TextBox();
            this.dateTimePickerDatum = new System.Windows.Forms.DateTimePicker();
            this.comboBoxStatusz = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.orderDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.orderDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Név:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "E-mail cím:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rendelés dátuma:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rendelés státusza:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Szállítási cím:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Szállítás ára:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Megrendelés összege:";
            // 
            // textBoxNev
            // 
            this.textBoxNev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNev.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "CustomerName", true));
            this.textBoxNev.Location = new System.Drawing.Point(148, 23);
            this.textBoxNev.Name = "textBoxNev";
            this.textBoxNev.Size = new System.Drawing.Size(212, 20);
            this.textBoxNev.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "Email", true));
            this.textBoxEmail.Location = new System.Drawing.Point(148, 61);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(212, 20);
            this.textBoxEmail.TabIndex = 10;
            // 
            // textBoxSzallítasiCim
            // 
            this.textBoxSzallítasiCim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSzallítasiCim.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "ShippingAddress", true));
            this.textBoxSzallítasiCim.Location = new System.Drawing.Point(148, 178);
            this.textBoxSzallítasiCim.Name = "textBoxSzallítasiCim";
            this.textBoxSzallítasiCim.Size = new System.Drawing.Size(212, 20);
            this.textBoxSzallítasiCim.TabIndex = 11;
            // 
            // textBoxSzallitasiAr
            // 
            this.textBoxSzallitasiAr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSzallitasiAr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "ShippingCost", true));
            this.textBoxSzallitasiAr.Location = new System.Drawing.Point(148, 219);
            this.textBoxSzallitasiAr.Name = "textBoxSzallitasiAr";
            this.textBoxSzallitasiAr.Size = new System.Drawing.Size(212, 20);
            this.textBoxSzallitasiAr.TabIndex = 12;
            // 
            // textBoxMegrendelesAr
            // 
            this.textBoxMegrendelesAr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMegrendelesAr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "OrderTotal", true));
            this.textBoxMegrendelesAr.Location = new System.Drawing.Point(148, 258);
            this.textBoxMegrendelesAr.Name = "textBoxMegrendelesAr";
            this.textBoxMegrendelesAr.Size = new System.Drawing.Size(212, 20);
            this.textBoxMegrendelesAr.TabIndex = 13;
            // 
            // dateTimePickerDatum
            // 
            this.dateTimePickerDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDatum.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderDTOBindingSource, "OrderDate", true));
            this.dateTimePickerDatum.Location = new System.Drawing.Point(148, 96);
            this.dateTimePickerDatum.Name = "dateTimePickerDatum";
            this.dateTimePickerDatum.Size = new System.Drawing.Size(212, 20);
            this.dateTimePickerDatum.TabIndex = 14;
            // 
            // comboBoxStatusz
            // 
            this.comboBoxStatusz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatusz.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderDTOBindingSource, "Status", true));
            this.comboBoxStatusz.FormattingEnabled = true;
            this.comboBoxStatusz.Location = new System.Drawing.Point(148, 136);
            this.comboBoxStatusz.Name = "comboBoxStatusz";
            this.comboBoxStatusz.Size = new System.Drawing.Size(212, 21);
            this.comboBoxStatusz.TabIndex = 15;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(186, 315);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 26);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Mégse";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(279, 315);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(81, 26);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Mentés";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // orderDTOBindingSource
            // 
            this.orderDTOBindingSource.DataSource = typeof(OrderDTO);
            // 
            // ModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 354);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxStatusz);
            this.Controls.Add(this.dateTimePickerDatum);
            this.Controls.Add(this.textBoxMegrendelesAr);
            this.Controls.Add(this.textBoxSzallitasiAr);
            this.Controls.Add(this.textBoxSzallítasiCim);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxNev);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private Label label6;
        private Label label7;
        private TextBox textBoxNev;
        private TextBox textBoxEmail;
        private TextBox textBoxSzallítasiCim;
        private TextBox textBoxSzallitasiAr;
        private TextBox textBoxMegrendelesAr;
        private DateTimePicker dateTimePickerDatum;
        private ComboBox comboBoxStatusz;
        private Button buttonCancel;
        private Button buttonSave;
        private BindingSource orderDTOBindingSource;
    }
}