namespace Gestiune_Bar_proiect_LICENTA
{
    partial class ModificaCategorie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificaCategorie));
            Categorie = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            NumeNou = new TextBox();
            Inapoi = new Button();
            ButonModifica = new Button();
            dataGridViewCategorie = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategorie).BeginInit();
            SuspendLayout();
            // 
            // Categorie
            // 
            Categorie.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Categorie.FormattingEnabled = true;
            Categorie.Items.AddRange(new object[] { "50ml", "buc" });
            Categorie.Location = new Point(218, 94);
            Categorie.Name = "Categorie";
            Categorie.Size = new Size(258, 30);
            Categorie.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1, 77);
            label2.Name = "label2";
            label2.Size = new Size(226, 78);
            label2.TabIndex = 32;
            label2.Text = "Nume Categorie*:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(608, 43);
            label1.TabIndex = 31;
            label1.Text = "Modificati o Categorie din Meniu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1, 139);
            label3.Name = "label3";
            label3.Size = new Size(235, 78);
            label3.TabIndex = 34;
            label3.Text = "Nume Nume Nou*:";
            // 
            // NumeNou
            // 
            NumeNou.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumeNou.Location = new Point(218, 155);
            NumeNou.Name = "NumeNou";
            NumeNou.Size = new Size(258, 30);
            NumeNou.TabIndex = 35;
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(342, 411);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 36;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            // 
            // ButonModifica
            // 
            ButonModifica.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButonModifica.Location = new Point(12, 411);
            ButonModifica.Name = "ButonModifica";
            ButonModifica.Size = new Size(305, 50);
            ButonModifica.TabIndex = 37;
            ButonModifica.Text = "Modificati Categoria";
            ButonModifica.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCategorie
            // 
            dataGridViewCategorie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategorie.Location = new Point(23, 207);
            dataGridViewCategorie.Name = "dataGridViewCategorie";
            dataGridViewCategorie.RowHeadersWidth = 51;
            dataGridViewCategorie.Size = new Size(607, 188);
            dataGridViewCategorie.TabIndex = 38;
            // 
            // ModificaCategorie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(659, 473);
            ControlBox = false;
            Controls.Add(dataGridViewCategorie);
            Controls.Add(ButonModifica);
            Controls.Add(Inapoi);
            Controls.Add(NumeNou);
            Controls.Add(label3);
            Controls.Add(Categorie);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ModificaCategorie";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificati o categorie";
            Load += ModificaCategorie_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategorie).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Categorie;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox NumeNou;
        private Button Inapoi;
        private Button ButonModifica;
        private DataGridView dataGridViewCategorie;
    }
}