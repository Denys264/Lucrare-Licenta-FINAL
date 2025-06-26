namespace Gestiune_Bar_proiect_LICENTA
{
    partial class AdaugaCategorie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdaugaCategorie));
            Inapoi = new Button();
            ButonAdauga = new Button();
            label1 = new Label();
            NumeCategorie = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(361, 267);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 9;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            Inapoi.Click += Inapoi_Click;
            // 
            // ButonAdauga
            // 
            ButonAdauga.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButonAdauga.Location = new Point(24, 267);
            ButonAdauga.Name = "ButonAdauga";
            ButonAdauga.Size = new Size(305, 50);
            ButonAdauga.TabIndex = 19;
            ButonAdauga.Text = "Adaugati Produsul";
            ButonAdauga.UseVisualStyleBackColor = true;
            ButonAdauga.Click += ButonAdauga_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(62, 9);
            label1.Name = "label1";
            label1.Size = new Size(559, 43);
            label1.TabIndex = 20;
            label1.Text = "Adaugati o Categorie in Meniu";
            // 
            // NumeCategorie
            // 
            NumeCategorie.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumeCategorie.Location = new Point(233, 133);
            NumeCategorie.Name = "NumeCategorie";
            NumeCategorie.Size = new Size(332, 30);
            NumeCategorie.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 117);
            label2.Name = "label2";
            label2.Size = new Size(226, 78);
            label2.TabIndex = 22;
            label2.Text = "Nume Categorie*:";
            // 
            // AdaugaCategorie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(678, 329);
            ControlBox = false;
            Controls.Add(NumeCategorie);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ButonAdauga);
            Controls.Add(Inapoi);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdaugaCategorie";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adaugati o Categorie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Inapoi;
        private Button ButonAdauga;
        private Label label1;
        private TextBox NumeCategorie;
        private Label label2;
    }
}