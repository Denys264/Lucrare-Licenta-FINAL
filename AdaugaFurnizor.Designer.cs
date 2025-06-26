namespace Gestiune_Bar_proiect_LICENTA
{
    partial class AdaugaFurnizor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdaugaFurnizor));
            Inapoi = new Button();
            label1 = new Label();
            label2 = new Label();
            NumeFurnizor = new TextBox();
            CUIFurnizor = new TextBox();
            label3 = new Label();
            AdresaFurnizor = new TextBox();
            label4 = new Label();
            NumarTelefon = new TextBox();
            label5 = new Label();
            ButonAdauga = new Button();
            SuspendLayout();
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(512, 346);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 7;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            Inapoi.Click += Inapoi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 22.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(201, 19);
            label1.Name = "label1";
            label1.Size = new Size(440, 47);
            label1.TabIndex = 8;
            label1.Text = "Adaugati un Furnizor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(206, 78);
            label2.TabIndex = 9;
            label2.Text = "Nume furnizor*:";
            // 
            // NumeFurnizor
            // 
            NumeFurnizor.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumeFurnizor.Location = new Point(22, 144);
            NumeFurnizor.Name = "NumeFurnizor";
            NumeFurnizor.Size = new Size(251, 30);
            NumeFurnizor.TabIndex = 10;
            // 
            // CUIFurnizor
            // 
            CUIFurnizor.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CUIFurnizor.Location = new Point(22, 228);
            CUIFurnizor.Name = "CUIFurnizor";
            CUIFurnizor.Size = new Size(251, 30);
            CUIFurnizor.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 177);
            label3.Name = "label3";
            label3.Size = new Size(92, 78);
            label3.TabIndex = 11;
            label3.Text = "CUI*:";
            // 
            // AdresaFurnizor
            // 
            AdresaFurnizor.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdresaFurnizor.Location = new Point(408, 147);
            AdresaFurnizor.Name = "AdresaFurnizor";
            AdresaFurnizor.Size = new Size(251, 30);
            AdresaFurnizor.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(398, 96);
            label4.Name = "label4";
            label4.Size = new Size(215, 78);
            label4.TabIndex = 13;
            label4.Text = "Adresa furnizor*:";
            // 
            // NumarTelefon
            // 
            NumarTelefon.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumarTelefon.Location = new Point(408, 240);
            NumarTelefon.Name = "NumarTelefon";
            NumarTelefon.Size = new Size(251, 30);
            NumarTelefon.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(398, 189);
            label5.Name = "label5";
            label5.Size = new Size(299, 78);
            label5.TabIndex = 15;
            label5.Text = "Numar Telefon(optional):";
            // 
            // ButonAdauga
            // 
            ButonAdauga.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButonAdauga.Location = new Point(22, 346);
            ButonAdauga.Name = "ButonAdauga";
            ButonAdauga.Size = new Size(305, 50);
            ButonAdauga.TabIndex = 17;
            ButonAdauga.Text = "Adaugati Furnizorul";
            ButonAdauga.UseVisualStyleBackColor = true;
            ButonAdauga.Click += ButonAdauga_Click;
            // 
            // AdaugaFurnizor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(838, 408);
            ControlBox = false;
            Controls.Add(ButonAdauga);
            Controls.Add(NumarTelefon);
            Controls.Add(label5);
            Controls.Add(AdresaFurnizor);
            Controls.Add(label4);
            Controls.Add(CUIFurnizor);
            Controls.Add(label3);
            Controls.Add(NumeFurnizor);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Inapoi);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdaugaFurnizor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adaugati un Furnizor";
            Load += AdaugaFurnizor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Inapoi;
        private Label label1;
        private Label label2;
        private TextBox NumeFurnizor;
        private TextBox CUIFurnizor;
        private Label label3;
        private TextBox AdresaFurnizor;
        private Label label4;
        private TextBox NumarTelefon;
        private Label label5;
        private Button ButonAdauga;
    }
}