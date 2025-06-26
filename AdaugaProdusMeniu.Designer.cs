namespace Gestiune_Bar_proiect_LICENTA
{
    partial class AdaugaProdusMeniu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdaugaProdusMeniu));
            label1 = new Label();
            Categorie = new ComboBox();
            label6 = new Label();
            Produs = new ComboBox();
            label2 = new Label();
            Inapoi = new Button();
            ButonAdauga = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(57, 21);
            label1.Name = "label1";
            label1.Size = new Size(542, 43);
            label1.TabIndex = 0;
            label1.Text = "Adaugati un Produs in Meniu";
            // 
            // Categorie
            // 
            Categorie.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Categorie.FormattingEnabled = true;
            Categorie.Items.AddRange(new object[] { "50ml", "buc" });
            Categorie.Location = new Point(242, 110);
            Categorie.Name = "Categorie";
            Categorie.Size = new Size(263, 30);
            Categorie.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(1, 93);
            label6.Name = "label6";
            label6.Size = new Size(251, 78);
            label6.TabIndex = 30;
            label6.Text = "Numele Categoriei*:";
            // 
            // Produs
            // 
            Produs.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Produs.FormattingEnabled = true;
            Produs.Items.AddRange(new object[] { "50ml", "buc" });
            Produs.Location = new Point(242, 171);
            Produs.Name = "Produs";
            Produs.Size = new Size(263, 30);
            Produs.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1, 154);
            label2.Name = "label2";
            label2.Size = new Size(256, 78);
            label2.TabIndex = 32;
            label2.Text = "Numele Produsului*:";
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(350, 289);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 34;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            // 
            // ButonAdauga
            // 
            ButonAdauga.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButonAdauga.Location = new Point(12, 289);
            ButonAdauga.Name = "ButonAdauga";
            ButonAdauga.Size = new Size(305, 50);
            ButonAdauga.TabIndex = 35;
            ButonAdauga.Text = "Adaugati Produsul";
            ButonAdauga.UseVisualStyleBackColor = true;
            ButonAdauga.Click += ButonAdauga_Click;
            // 
            // AdaugaProdusMeniu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(678, 351);
            ControlBox = false;
            Controls.Add(ButonAdauga);
            Controls.Add(Inapoi);
            Controls.Add(Produs);
            Controls.Add(label2);
            Controls.Add(Categorie);
            Controls.Add(label6);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdaugaProdusMeniu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adaugati un Produs in Meniu";
            Load += AdaugaProdusMeniu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox Categorie;
        private Label label6;
        private ComboBox Produs;
        private Label label2;
        private Button Inapoi;
        private Button ButonAdauga;
    }
}