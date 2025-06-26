namespace Gestiune_Bar_proiect_LICENTA
{
    partial class ModificaFurnizor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificaFurnizor));
            label1 = new Label();
            Inapoi = new Button();
            ButonModifica = new Button();
            dataGridViewFurnizor = new DataGridView();
            Furnizor = new ComboBox();
            label8 = new Label();
            NumeNou = new TextBox();
            label3 = new Label();
            AdresaNoua = new TextBox();
            label2 = new Label();
            CUINou = new TextBox();
            label4 = new Label();
            TelNou = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFurnizor).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(191, 9);
            label1.Name = "label1";
            label1.Size = new Size(377, 43);
            label1.TabIndex = 37;
            label1.Text = "Modificati Furnizor";
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(472, 388);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 50;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            // 
            // ButonModifica
            // 
            ButonModifica.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButonModifica.Location = new Point(23, 388);
            ButonModifica.Name = "ButonModifica";
            ButonModifica.Size = new Size(305, 50);
            ButonModifica.TabIndex = 51;
            ButonModifica.Text = "Modificati Produsul";
            ButonModifica.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFurnizor
            // 
            dataGridViewFurnizor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFurnizor.Location = new Point(23, 232);
            dataGridViewFurnizor.Name = "dataGridViewFurnizor";
            dataGridViewFurnizor.RowHeadersWidth = 51;
            dataGridViewFurnizor.Size = new Size(754, 135);
            dataGridViewFurnizor.TabIndex = 52;
            // 
            // Furnizor
            // 
            Furnizor.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Furnizor.FormattingEnabled = true;
            Furnizor.Items.AddRange(new object[] { "50ml", "buc" });
            Furnizor.Location = new Point(191, 69);
            Furnizor.Name = "Furnizor";
            Furnizor.Size = new Size(258, 30);
            Furnizor.TabIndex = 54;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(-1, 52);
            label8.Name = "label8";
            label8.Size = new Size(197, 78);
            label8.TabIndex = 53;
            label8.Text = "Nume Furnizor:";
            // 
            // NumeNou
            // 
            NumeNou.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumeNou.Location = new Point(139, 115);
            NumeNou.Name = "NumeNou";
            NumeNou.Size = new Size(251, 30);
            NumeNou.TabIndex = 56;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(-1, 99);
            label3.Name = "label3";
            label3.Size = new Size(153, 78);
            label3.TabIndex = 55;
            label3.Text = "Nume Nou:";
            // 
            // AdresaNoua
            // 
            AdresaNoua.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdresaNoua.Location = new Point(158, 164);
            AdresaNoua.Name = "AdresaNoua";
            AdresaNoua.Size = new Size(232, 30);
            AdresaNoua.TabIndex = 58;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(415, 99);
            label2.Name = "label2";
            label2.Size = new Size(127, 78);
            label2.TabIndex = 57;
            label2.Text = "CUI Nou:";
            // 
            // CUINou
            // 
            CUINou.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CUINou.Location = new Point(535, 115);
            CUINou.Name = "CUINou";
            CUINou.Size = new Size(242, 30);
            CUINou.TabIndex = 60;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(-1, 148);
            label4.Name = "label4";
            label4.Size = new Size(175, 78);
            label4.TabIndex = 59;
            label4.Text = "Adresa Noua:";
            // 
            // TelNou
            // 
            TelNou.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TelNou.Location = new Point(535, 167);
            TelNou.Name = "TelNou";
            TelNou.Size = new Size(242, 30);
            TelNou.TabIndex = 62;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(396, 151);
            label5.Name = "label5";
            label5.Size = new Size(154, 78);
            label5.TabIndex = 61;
            label5.Text = "Nr. Tel. Nou:";
            // 
            // ModificaFurnizor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(AdresaNoua);
            Controls.Add(Furnizor);
            Controls.Add(label4);
            Controls.Add(TelNou);
            Controls.Add(label5);
            Controls.Add(CUINou);
            Controls.Add(label2);
            Controls.Add(NumeNou);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(dataGridViewFurnizor);
            Controls.Add(ButonModifica);
            Controls.Add(Inapoi);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ModificaFurnizor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificacti un Furnizor";
            Load += ModificaFurnizor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFurnizor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Inapoi;
        private Button ButonModifica;
        private DataGridView dataGridViewFurnizor;
        private ComboBox Furnizor;
        private Label label8;
        private TextBox NumeNou;
        private Label label3;
        private TextBox AdresaNoua;
        private Label label2;
        private TextBox CUINou;
        private Label label4;
        private TextBox TelNou;
        private Label label5;
    }
}