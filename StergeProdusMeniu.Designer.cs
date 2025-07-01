namespace Gestiune_Bar_proiect_LICENTA
{
    partial class StergeProdusMeniu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StergeProdusMeniu));
            ButonSterge = new Button();
            Inapoi = new Button();
            Produs = new ComboBox();
            label2 = new Label();
            Categorie = new ComboBox();
            label6 = new Label();
            label1 = new Label();
            dataGridViewProduse = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).BeginInit();
            SuspendLayout();
            // 
            // ButonSterge
            // 
            ButonSterge.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButonSterge.Location = new Point(21, 388);
            ButonSterge.Name = "ButonSterge";
            ButonSterge.Size = new Size(305, 50);
            ButonSterge.TabIndex = 42;
            ButonSterge.Text = "Stergeti Produsul";
            ButonSterge.UseVisualStyleBackColor = true;
            ButonSterge.Click += ButonSterge_Click;
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(467, 388);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 41;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            Inapoi.Click += Inapoi_Click;
            // 
            // Produs
            // 
            Produs.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Produs.FormattingEnabled = true;
            Produs.Items.AddRange(new object[] { "50ml", "buc" });
            Produs.Location = new Point(243, 149);
            Produs.Name = "Produs";
            Produs.Size = new Size(263, 30);
            Produs.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(2, 132);
            label2.Name = "label2";
            label2.Size = new Size(256, 78);
            label2.TabIndex = 39;
            label2.Text = "Numele Produsului*:";
            // 
            // Categorie
            // 
            Categorie.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Categorie.FormattingEnabled = true;
            Categorie.Items.AddRange(new object[] { "50ml", "buc" });
            Categorie.Location = new Point(243, 99);
            Categorie.Name = "Categorie";
            Categorie.Size = new Size(263, 30);
            Categorie.TabIndex = 38;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(2, 82);
            label6.Name = "label6";
            label6.Size = new Size(251, 78);
            label6.TabIndex = 37;
            label6.Text = "Numele Categoriei*:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(135, 9);
            label1.Name = "label1";
            label1.Size = new Size(525, 43);
            label1.TabIndex = 36;
            label1.Text = "Stergeti un Produs in Meniu";
            // 
            // dataGridViewProduse
            // 
            dataGridViewProduse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduse.Location = new Point(21, 194);
            dataGridViewProduse.Name = "dataGridViewProduse";
            dataGridViewProduse.RowHeadersWidth = 51;
            dataGridViewProduse.Size = new Size(746, 168);
            dataGridViewProduse.TabIndex = 43;
            // 
            // StergeProdusMeniu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(dataGridViewProduse);
            Controls.Add(ButonSterge);
            Controls.Add(Inapoi);
            Controls.Add(Produs);
            Controls.Add(label2);
            Controls.Add(Categorie);
            Controls.Add(label6);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StergeProdusMeniu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stergeti un Produs din Meniu";
            Load += StergeProdusMeniu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButonSterge;
        private Button Inapoi;
        private ComboBox Produs;
        private Label label2;
        private ComboBox Categorie;
        private Label label6;
        private Label label1;
        private DataGridView dataGridViewProduse;
    }
}