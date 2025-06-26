namespace Gestiune_Bar_proiect_LICENTA
{
    partial class NotaIntrare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaIntrare));
            label1 = new Label();
            Categorie = new ComboBox();
            Produs = new ComboBox();
            label2 = new Label();
            label8 = new Label();
            label3 = new Label();
            Inapoi = new Button();
            Salveaza = new Button();
            Adauga = new Button();
            Cantitate = new TextBox();
            label4 = new Label();
            dataGridViewProduse = new DataGridView();
            Furnizor = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(316, 9);
            label1.Name = "label1";
            label1.Size = new Size(299, 43);
            label1.TabIndex = 37;
            label1.Text = "Nota de Intrare";
            // 
            // Categorie
            // 
            Categorie.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Categorie.FormattingEnabled = true;
            Categorie.Items.AddRange(new object[] { "50ml", "buc" });
            Categorie.Location = new Point(690, 103);
            Categorie.Name = "Categorie";
            Categorie.Size = new Size(258, 30);
            Categorie.TabIndex = 52;
            // 
            // Produs
            // 
            Produs.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Produs.FormattingEnabled = true;
            Produs.Items.AddRange(new object[] { "50ml", "buc" });
            Produs.Location = new Point(202, 215);
            Produs.Name = "Produs";
            Produs.Size = new Size(258, 30);
            Produs.TabIndex = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 199);
            label2.Name = "label2";
            label2.Size = new Size(197, 78);
            label2.TabIndex = 49;
            label2.Text = "Nume Produs*:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(487, 86);
            label8.Name = "label8";
            label8.Size = new Size(213, 78);
            label8.TabIndex = 51;
            label8.Text = "Nume Categorie:";
            // 
            // label3
            // 
            label3.Font = new Font("Elephant", 10.1999989F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(12, 147);
            label3.Name = "label3";
            label3.Size = new Size(960, 69);
            label3.TabIndex = 53;
            label3.Text = "ATENTIE!! Pentru produsele care au unitatea \"50ml\" va rog sa introduceti cantitea in ml, de exemplu daca aveti o sticla de whisky de 1L (nu conteaza brandul) introduceti 1000 (ml)";
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(660, 452);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 54;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            Inapoi.Click += Inapoi_Click;
            // 
            // Salveaza
            // 
            Salveaza.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Salveaza.Location = new Point(12, 452);
            Salveaza.Name = "Salveaza";
            Salveaza.Size = new Size(305, 50);
            Salveaza.TabIndex = 55;
            Salveaza.Text = "Salveaza";
            Salveaza.UseVisualStyleBackColor = true;
            // 
            // Adauga
            // 
            Adauga.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Adauga.Location = new Point(338, 457);
            Adauga.Name = "Adauga";
            Adauga.Size = new Size(305, 40);
            Adauga.TabIndex = 56;
            Adauga.Text = "Adauga";
            Adauga.UseVisualStyleBackColor = true;
            // 
            // Cantitate
            // 
            Cantitate.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Cantitate.Location = new Point(697, 215);
            Cantitate.Name = "Cantitate";
            Cantitate.Size = new Size(251, 30);
            Cantitate.TabIndex = 59;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(541, 199);
            label4.Name = "label4";
            label4.Size = new Size(137, 78);
            label4.TabIndex = 58;
            label4.Text = "Cantitate:";
            // 
            // dataGridViewProduse
            // 
            dataGridViewProduse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduse.Location = new Point(12, 268);
            dataGridViewProduse.Name = "dataGridViewProduse";
            dataGridViewProduse.RowHeadersWidth = 51;
            dataGridViewProduse.Size = new Size(943, 163);
            dataGridViewProduse.TabIndex = 60;
            // 
            // Furnizor
            // 
            Furnizor.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Furnizor.FormattingEnabled = true;
            Furnizor.Items.AddRange(new object[] { "50ml", "buc" });
            Furnizor.Location = new Point(204, 103);
            Furnizor.Name = "Furnizor";
            Furnizor.Size = new Size(258, 30);
            Furnizor.TabIndex = 62;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 86);
            label5.Name = "label5";
            label5.Size = new Size(197, 78);
            label5.TabIndex = 61;
            label5.Text = "Nume Furnizor:";
            // 
            // NotaIntrare
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(967, 514);
            ControlBox = false;
            Controls.Add(Furnizor);
            Controls.Add(dataGridViewProduse);
            Controls.Add(Cantitate);
            Controls.Add(label4);
            Controls.Add(Adauga);
            Controls.Add(Salveaza);
            Controls.Add(Inapoi);
            Controls.Add(label3);
            Controls.Add(Categorie);
            Controls.Add(Produs);
            Controls.Add(label2);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(label5);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NotaIntrare";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "N.I.R";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox Categorie;
        private ComboBox Produs;
        private Label label2;
        private Label label8;
        private Label label3;
        private Button Inapoi;
        private Button Salveaza;
        private Button Adauga;
        private TextBox Cantitate;
        private Label label4;
        private DataGridView dataGridViewProduse;
        private ComboBox Furnizor;
        private Label label5;
    }
}