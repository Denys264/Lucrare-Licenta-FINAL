namespace Gestiune_Bar_proiect_LICENTA
{
    partial class AdaugaProdusGestiune
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdaugaProdusGestiune));
            Inapoi = new Button();
            ButonAdauga = new Button();
            label1 = new Label();
            NumeProdus = new TextBox();
            label2 = new Label();
            PretProdus = new TextBox();
            label3 = new Label();
            CantitateIncepere = new TextBox();
            label4 = new Label();
            CantitateMinima = new TextBox();
            label5 = new Label();
            label6 = new Label();
            Unitate = new ComboBox();
            SuspendLayout();
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(472, 388);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 8;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            Inapoi.Click += Inapoi_Click;
            // 
            // ButonAdauga
            // 
            ButonAdauga.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButonAdauga.Location = new Point(12, 388);
            ButonAdauga.Name = "ButonAdauga";
            ButonAdauga.Size = new Size(305, 50);
            ButonAdauga.TabIndex = 18;
            ButonAdauga.Text = "Adaugati Produsul";
            ButonAdauga.UseVisualStyleBackColor = true;
            ButonAdauga.Click += ButonAdauga_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(91, 9);
            label1.Name = "label1";
            label1.Size = new Size(587, 43);
            label1.TabIndex = 19;
            label1.Text = "Adaugati un Produs in Gestiune";
            // 
            // NumeProdus
            // 
            NumeProdus.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumeProdus.Location = new Point(22, 131);
            NumeProdus.Name = "NumeProdus";
            NumeProdus.Size = new Size(251, 30);
            NumeProdus.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(197, 78);
            label2.TabIndex = 20;
            label2.Text = "Nume Produs*:";
            // 
            // PretProdus
            // 
            PretProdus.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PretProdus.Location = new Point(22, 241);
            PretProdus.Name = "PretProdus";
            PretProdus.Size = new Size(251, 30);
            PretProdus.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 190);
            label3.Name = "label3";
            label3.Size = new Size(96, 78);
            label3.TabIndex = 22;
            label3.Text = "Pret*:";
            // 
            // CantitateIncepere
            // 
            CantitateIncepere.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CantitateIncepere.Location = new Point(369, 134);
            CantitateIncepere.Name = "CantitateIncepere";
            CantitateIncepere.Size = new Size(251, 30);
            CantitateIncepere.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(359, 83);
            label4.Name = "label4";
            label4.Size = new Size(276, 78);
            label4.TabIndex = 24;
            label4.Text = "Cantitate de incepere*:";
            // 
            // CantitateMinima
            // 
            CantitateMinima.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CantitateMinima.Location = new Point(369, 244);
            CantitateMinima.Name = "CantitateMinima";
            CantitateMinima.Size = new Size(251, 30);
            CantitateMinima.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(359, 193);
            label5.Name = "label5";
            label5.Size = new Size(235, 78);
            label5.TabIndex = 26;
            label5.Text = "Cantitate Minima*:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(12, 274);
            label6.Name = "label6";
            label6.Size = new Size(131, 78);
            label6.TabIndex = 28;
            label6.Text = "Unitate*:";
            // 
            // Unitate
            // 
            Unitate.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Unitate.FormattingEnabled = true;
            Unitate.Items.AddRange(new object[] { "50ml", "buc" });
            Unitate.Location = new Point(134, 293);
            Unitate.Name = "Unitate";
            Unitate.Size = new Size(151, 30);
            Unitate.TabIndex = 29;
            // 
            // AdaugaProdusGestiune
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(Unitate);
            Controls.Add(label6);
            Controls.Add(CantitateMinima);
            Controls.Add(label5);
            Controls.Add(CantitateIncepere);
            Controls.Add(label4);
            Controls.Add(PretProdus);
            Controls.Add(label3);
            Controls.Add(NumeProdus);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ButonAdauga);
            Controls.Add(Inapoi);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdaugaProdusGestiune";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adaugati un Produs in Gestiune";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Inapoi;
        private Button ButonAdauga;
        private Label label1;
        private TextBox NumeProdus;
        private Label label2;
        private TextBox PretProdus;
        private Label label3;
        private TextBox CantitateIncepere;
        private Label label4;
        private TextBox CantitateMinima;
        private Label label5;
        private Label label6;
        private ComboBox Unitate;
    }
}