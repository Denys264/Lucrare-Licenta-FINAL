namespace Gestiune_Bar_proiect_LICENTA
{
    partial class Administrare
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrare));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            AdaugaConturi = new Button();
            StergereConturi = new Button();
            InapoiPagina = new Button();
            PanouAdauga = new FlowLayoutPanel();
            Adauga = new Button();
            AdaugaFurnizor = new Button();
            AdaugaProdus = new Button();
            AdaugaProdusGestiune = new Button();
            AdaugaNIR = new Button();
            AdaugaCategorie = new Button();
            AdaugaTimer = new System.Windows.Forms.Timer(components);
            ModificaPanou = new FlowLayoutPanel();
            Modifica = new Button();
            ModificaFurnizor = new Button();
            ModificaProdus = new Button();
            ModificaCategorie = new Button();
            ModificaTimer = new System.Windows.Forms.Timer(components);
            PanouSterge = new FlowLayoutPanel();
            Sterge = new Button();
            StergeFurnizor = new Button();
            StergeProdusMeniu = new Button();
            StergeProdus = new Button();
            StergeCategorie = new Button();
            StergeTimer = new System.Windows.Forms.Timer(components);
            PanouAdauga.SuspendLayout();
            ModificaPanou.SuspendLayout();
            PanouSterge.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 23.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(564, 40);
            label1.Name = "label1";
            label1.Size = new Size(300, 51);
            label1.TabIndex = 0;
            label1.Text = "Administrare";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Elephant", 23.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(177, 51);
            label2.TabIndex = 1;
            label2.Text = "Stocuri";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Elephant", 23.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(24, 510);
            label3.Name = "label3";
            label3.Size = new Size(186, 51);
            label3.TabIndex = 8;
            label3.Text = "Conturi";
            // 
            // AdaugaConturi
            // 
            AdaugaConturi.BackColor = Color.AliceBlue;
            AdaugaConturi.Font = new Font("Elephant", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdaugaConturi.ForeColor = SystemColors.ControlText;
            AdaugaConturi.Location = new Point(38, 591);
            AdaugaConturi.Name = "AdaugaConturi";
            AdaugaConturi.Size = new Size(332, 70);
            AdaugaConturi.TabIndex = 9;
            AdaugaConturi.Text = "Adauga un cont ";
            AdaugaConturi.UseVisualStyleBackColor = false;
            AdaugaConturi.Click += AdaugaConturi_Click;
            // 
            // StergereConturi
            // 
            StergereConturi.BackColor = Color.AliceBlue;
            StergereConturi.Font = new Font("Elephant", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StergereConturi.ForeColor = SystemColors.ControlText;
            StergereConturi.Location = new Point(1031, 591);
            StergereConturi.Name = "StergereConturi";
            StergereConturi.Size = new Size(332, 70);
            StergereConturi.TabIndex = 10;
            StergereConturi.Text = "Sterge un cont ";
            StergereConturi.UseVisualStyleBackColor = false;
            StergereConturi.Click += StergereConturi_Click;
            // 
            // InapoiPagina
            // 
            InapoiPagina.BackColor = Color.AliceBlue;
            InapoiPagina.Font = new Font("Elephant", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InapoiPagina.ForeColor = SystemColors.ControlText;
            InapoiPagina.Location = new Point(1031, 696);
            InapoiPagina.Name = "InapoiPagina";
            InapoiPagina.Size = new Size(332, 70);
            InapoiPagina.TabIndex = 12;
            InapoiPagina.Text = "Inapoi la pagina principala ";
            InapoiPagina.UseVisualStyleBackColor = false;
            InapoiPagina.Click += InapoiPagina_Click;
            // 
            // PanouAdauga
            // 
            PanouAdauga.BackColor = Color.White;
            PanouAdauga.Controls.Add(Adauga);
            PanouAdauga.Controls.Add(AdaugaFurnizor);
            PanouAdauga.Controls.Add(AdaugaProdus);
            PanouAdauga.Controls.Add(AdaugaProdusGestiune);
            PanouAdauga.Controls.Add(AdaugaNIR);
            PanouAdauga.Controls.Add(AdaugaCategorie);
            PanouAdauga.Font = new Font("Elephant", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PanouAdauga.Location = new Point(38, 139);
            PanouAdauga.Margin = new Padding(0);
            PanouAdauga.MaximumSize = new Size(332, 371);
            PanouAdauga.MinimumSize = new Size(332, 61);
            PanouAdauga.Name = "PanouAdauga";
            PanouAdauga.Size = new Size(332, 65);
            PanouAdauga.TabIndex = 13;
            PanouAdauga.Paint += flowLayoutPanel1_Paint;
            // 
            // Adauga
            // 
            Adauga.BackColor = Color.White;
            Adauga.BackgroundImageLayout = ImageLayout.Stretch;
            Adauga.FlatStyle = FlatStyle.Flat;
            Adauga.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Adauga.ImageAlign = ContentAlignment.MiddleRight;
            Adauga.Location = new Point(0, 0);
            Adauga.Margin = new Padding(0);
            Adauga.Name = "Adauga";
            Adauga.Size = new Size(332, 65);
            Adauga.TabIndex = 5;
            Adauga.Text = "Adauga";
            Adauga.UseVisualStyleBackColor = false;
            Adauga.Click += Adauga_Click;
            // 
            // AdaugaFurnizor
            // 
            AdaugaFurnizor.BackgroundImageLayout = ImageLayout.Stretch;
            AdaugaFurnizor.FlatStyle = FlatStyle.Flat;
            AdaugaFurnizor.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdaugaFurnizor.ImageAlign = ContentAlignment.MiddleRight;
            AdaugaFurnizor.Location = new Point(0, 65);
            AdaugaFurnizor.Margin = new Padding(0);
            AdaugaFurnizor.Name = "AdaugaFurnizor";
            AdaugaFurnizor.Size = new Size(332, 61);
            AdaugaFurnizor.TabIndex = 4;
            AdaugaFurnizor.Text = "Adauga un Furnizor";
            AdaugaFurnizor.UseVisualStyleBackColor = true;
            AdaugaFurnizor.Click += AdaugaFurnizor_Click;
            // 
            // AdaugaProdus
            // 
            AdaugaProdus.BackgroundImageLayout = ImageLayout.Stretch;
            AdaugaProdus.FlatStyle = FlatStyle.Flat;
            AdaugaProdus.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdaugaProdus.ImageAlign = ContentAlignment.MiddleRight;
            AdaugaProdus.Location = new Point(0, 126);
            AdaugaProdus.Margin = new Padding(0);
            AdaugaProdus.Name = "AdaugaProdus";
            AdaugaProdus.Size = new Size(332, 61);
            AdaugaProdus.TabIndex = 3;
            AdaugaProdus.Text = "Adauga un Produs in Meniu";
            AdaugaProdus.UseVisualStyleBackColor = true;
            AdaugaProdus.Click += AdaugaProdus_Click;
            // 
            // AdaugaProdusGestiune
            // 
            AdaugaProdusGestiune.BackgroundImageLayout = ImageLayout.Stretch;
            AdaugaProdusGestiune.FlatStyle = FlatStyle.Flat;
            AdaugaProdusGestiune.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdaugaProdusGestiune.ImageAlign = ContentAlignment.MiddleRight;
            AdaugaProdusGestiune.Location = new Point(0, 187);
            AdaugaProdusGestiune.Margin = new Padding(0);
            AdaugaProdusGestiune.Name = "AdaugaProdusGestiune";
            AdaugaProdusGestiune.Size = new Size(332, 61);
            AdaugaProdusGestiune.TabIndex = 1;
            AdaugaProdusGestiune.Text = "Adauga un Produs in Gestiune";
            AdaugaProdusGestiune.UseVisualStyleBackColor = true;
            AdaugaProdusGestiune.Click += AdaugaProdusGestiune_Click;
            // 
            // AdaugaNIR
            // 
            AdaugaNIR.BackgroundImageLayout = ImageLayout.Stretch;
            AdaugaNIR.FlatStyle = FlatStyle.Flat;
            AdaugaNIR.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdaugaNIR.ImageAlign = ContentAlignment.MiddleRight;
            AdaugaNIR.Location = new Point(0, 248);
            AdaugaNIR.Margin = new Padding(0);
            AdaugaNIR.Name = "AdaugaNIR";
            AdaugaNIR.Size = new Size(332, 61);
            AdaugaNIR.TabIndex = 0;
            AdaugaNIR.Text = "Adauga o Nota de Intrare";
            AdaugaNIR.UseVisualStyleBackColor = true;
            AdaugaNIR.Click += AdaugaNIR_Click;
            // 
            // AdaugaCategorie
            // 
            AdaugaCategorie.BackgroundImageLayout = ImageLayout.Stretch;
            AdaugaCategorie.FlatStyle = FlatStyle.Flat;
            AdaugaCategorie.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdaugaCategorie.ImageAlign = ContentAlignment.MiddleRight;
            AdaugaCategorie.Location = new Point(0, 309);
            AdaugaCategorie.Margin = new Padding(0);
            AdaugaCategorie.Name = "AdaugaCategorie";
            AdaugaCategorie.Size = new Size(332, 61);
            AdaugaCategorie.TabIndex = 2;
            AdaugaCategorie.Text = "Adauga o Categorie in Meniu";
            AdaugaCategorie.UseVisualStyleBackColor = true;
            AdaugaCategorie.Click += AdaugaCategorie_Click;
            // 
            // AdaugaTimer
            // 
            AdaugaTimer.Interval = 1;
            AdaugaTimer.Tick += AdaugaTimer_Tick;
            // 
            // ModificaPanou
            // 
            ModificaPanou.BackColor = Color.White;
            ModificaPanou.Controls.Add(Modifica);
            ModificaPanou.Controls.Add(ModificaFurnizor);
            ModificaPanou.Controls.Add(ModificaProdus);
            ModificaPanou.Controls.Add(ModificaCategorie);
            ModificaPanou.Font = new Font("Elephant", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModificaPanou.Location = new Point(564, 139);
            ModificaPanou.Margin = new Padding(0);
            ModificaPanou.MaximumSize = new Size(332, 248);
            ModificaPanou.MinimumSize = new Size(332, 61);
            ModificaPanou.Name = "ModificaPanou";
            ModificaPanou.Size = new Size(332, 65);
            ModificaPanou.TabIndex = 14;
            ModificaPanou.Paint += ModificaPanou_Paint;
            // 
            // Modifica
            // 
            Modifica.BackColor = Color.White;
            Modifica.BackgroundImageLayout = ImageLayout.Stretch;
            Modifica.FlatStyle = FlatStyle.Flat;
            Modifica.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Modifica.ImageAlign = ContentAlignment.MiddleRight;
            Modifica.Location = new Point(0, 0);
            Modifica.Margin = new Padding(0);
            Modifica.Name = "Modifica";
            Modifica.Size = new Size(332, 65);
            Modifica.TabIndex = 5;
            Modifica.Text = "Modifica";
            Modifica.UseVisualStyleBackColor = false;
            Modifica.Click += Modifica_Click;
            // 
            // ModificaFurnizor
            // 
            ModificaFurnizor.BackgroundImageLayout = ImageLayout.Stretch;
            ModificaFurnizor.FlatStyle = FlatStyle.Flat;
            ModificaFurnizor.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModificaFurnizor.ImageAlign = ContentAlignment.MiddleRight;
            ModificaFurnizor.Location = new Point(0, 65);
            ModificaFurnizor.Margin = new Padding(0);
            ModificaFurnizor.Name = "ModificaFurnizor";
            ModificaFurnizor.Size = new Size(332, 61);
            ModificaFurnizor.TabIndex = 4;
            ModificaFurnizor.Text = "Modifica un Furnizor";
            ModificaFurnizor.UseVisualStyleBackColor = true;
            ModificaFurnizor.Click += ModificaFurnizor_Click;
            // 
            // ModificaProdus
            // 
            ModificaProdus.BackgroundImageLayout = ImageLayout.Stretch;
            ModificaProdus.FlatStyle = FlatStyle.Flat;
            ModificaProdus.Font = new Font("Elephant", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModificaProdus.ImageAlign = ContentAlignment.MiddleRight;
            ModificaProdus.Location = new Point(0, 126);
            ModificaProdus.Margin = new Padding(0);
            ModificaProdus.Name = "ModificaProdus";
            ModificaProdus.Size = new Size(332, 61);
            ModificaProdus.TabIndex = 3;
            ModificaProdus.Text = "Modifica un Produs din Gestiune";
            ModificaProdus.UseVisualStyleBackColor = true;
            ModificaProdus.Click += ModificaProdus_Click;
            // 
            // ModificaCategorie
            // 
            ModificaCategorie.BackgroundImageLayout = ImageLayout.Stretch;
            ModificaCategorie.FlatStyle = FlatStyle.Flat;
            ModificaCategorie.Font = new Font("Elephant", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModificaCategorie.ImageAlign = ContentAlignment.MiddleRight;
            ModificaCategorie.Location = new Point(0, 187);
            ModificaCategorie.Margin = new Padding(0);
            ModificaCategorie.Name = "ModificaCategorie";
            ModificaCategorie.Size = new Size(332, 61);
            ModificaCategorie.TabIndex = 2;
            ModificaCategorie.Text = "Modifica o Categorie din Meniu";
            ModificaCategorie.UseVisualStyleBackColor = true;
            ModificaCategorie.Click += ModificaCategorie_Click;
            // 
            // ModificaTimer
            // 
            ModificaTimer.Interval = 1;
            ModificaTimer.Tick += ModificaTimer_Tick;
            // 
            // PanouSterge
            // 
            PanouSterge.BackColor = Color.White;
            PanouSterge.Controls.Add(Sterge);
            PanouSterge.Controls.Add(StergeFurnizor);
            PanouSterge.Controls.Add(StergeProdusMeniu);
            PanouSterge.Controls.Add(StergeProdus);
            PanouSterge.Controls.Add(StergeCategorie);
            PanouSterge.Font = new Font("Elephant", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PanouSterge.Location = new Point(1031, 139);
            PanouSterge.Margin = new Padding(0);
            PanouSterge.MaximumSize = new Size(332, 309);
            PanouSterge.MinimumSize = new Size(332, 61);
            PanouSterge.Name = "PanouSterge";
            PanouSterge.Size = new Size(332, 65);
            PanouSterge.TabIndex = 15;
            PanouSterge.Paint += PanouSterge_Paint;
            // 
            // Sterge
            // 
            Sterge.BackColor = Color.White;
            Sterge.BackgroundImageLayout = ImageLayout.Stretch;
            Sterge.FlatStyle = FlatStyle.Flat;
            Sterge.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Sterge.ImageAlign = ContentAlignment.MiddleRight;
            Sterge.Location = new Point(0, 0);
            Sterge.Margin = new Padding(0);
            Sterge.Name = "Sterge";
            Sterge.Size = new Size(332, 65);
            Sterge.TabIndex = 5;
            Sterge.Text = "Sterge";
            Sterge.UseVisualStyleBackColor = false;
            Sterge.Click += Sterge_Click;
            // 
            // StergeFurnizor
            // 
            StergeFurnizor.BackgroundImageLayout = ImageLayout.Stretch;
            StergeFurnizor.FlatStyle = FlatStyle.Flat;
            StergeFurnizor.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StergeFurnizor.ImageAlign = ContentAlignment.MiddleRight;
            StergeFurnizor.Location = new Point(0, 65);
            StergeFurnizor.Margin = new Padding(0);
            StergeFurnizor.Name = "StergeFurnizor";
            StergeFurnizor.Size = new Size(332, 61);
            StergeFurnizor.TabIndex = 4;
            StergeFurnizor.Text = "Sterge un Furnizor";
            StergeFurnizor.UseVisualStyleBackColor = true;
            StergeFurnizor.Click += StergeFurnizor_Click;
            // 
            // StergeProdusMeniu
            // 
            StergeProdusMeniu.BackgroundImageLayout = ImageLayout.Stretch;
            StergeProdusMeniu.FlatStyle = FlatStyle.Flat;
            StergeProdusMeniu.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StergeProdusMeniu.ImageAlign = ContentAlignment.MiddleRight;
            StergeProdusMeniu.Location = new Point(0, 126);
            StergeProdusMeniu.Margin = new Padding(0);
            StergeProdusMeniu.Name = "StergeProdusMeniu";
            StergeProdusMeniu.Size = new Size(332, 61);
            StergeProdusMeniu.TabIndex = 3;
            StergeProdusMeniu.Text = "Sterge un  Produs din Meniu";
            StergeProdusMeniu.UseVisualStyleBackColor = true;
            StergeProdusMeniu.Click += StergeProdusMeniu_Click;
            // 
            // StergeProdus
            // 
            StergeProdus.BackgroundImageLayout = ImageLayout.Stretch;
            StergeProdus.FlatStyle = FlatStyle.Flat;
            StergeProdus.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StergeProdus.ImageAlign = ContentAlignment.MiddleRight;
            StergeProdus.Location = new Point(0, 187);
            StergeProdus.Margin = new Padding(0);
            StergeProdus.Name = "StergeProdus";
            StergeProdus.Size = new Size(332, 61);
            StergeProdus.TabIndex = 1;
            StergeProdus.Text = "Sterge un Produs din Gestiune";
            StergeProdus.UseVisualStyleBackColor = true;
            StergeProdus.Click += StergeProdus_Click;
            // 
            // StergeCategorie
            // 
            StergeCategorie.BackgroundImageLayout = ImageLayout.Stretch;
            StergeCategorie.FlatStyle = FlatStyle.Flat;
            StergeCategorie.Font = new Font("Elephant", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StergeCategorie.ImageAlign = ContentAlignment.MiddleRight;
            StergeCategorie.Location = new Point(0, 248);
            StergeCategorie.Margin = new Padding(0);
            StergeCategorie.Name = "StergeCategorie";
            StergeCategorie.Size = new Size(332, 61);
            StergeCategorie.TabIndex = 2;
            StergeCategorie.Text = "Sterge o Categorie din Meniu";
            StergeCategorie.UseVisualStyleBackColor = true;
            StergeCategorie.Click += StergeCategorie_Click;
            // 
            // StergeTimer
            // 
            StergeTimer.Interval = 1;
            StergeTimer.Tick += StergeTimer_Tick;
            // 
            // Administrare
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RoyalBlue;
            ClientSize = new Size(1405, 778);
            ControlBox = false;
            Controls.Add(PanouSterge);
            Controls.Add(ModificaPanou);
            Controls.Add(PanouAdauga);
            Controls.Add(InapoiPagina);
            Controls.Add(StergereConturi);
            Controls.Add(AdaugaConturi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Administrare";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administare";
            Load += Administrare_Load;
            PanouAdauga.ResumeLayout(false);
            ModificaPanou.ResumeLayout(false);
            PanouSterge.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button AdaugaConturi;
        private Button StergereConturi;
        private Button AdaugaProdus;
        
        private Button InapoiPagina;
        private FlowLayoutPanel PanouAdauga;
        private Button AdaugaNIR;
        private Button AdaugaProdusGestiune;
        private Button AdaugaCategorie;
        private Button Adauga;
        private Button AdaugaFurnizor;
        private System.Windows.Forms.Timer AdaugaTimer;
        private FlowLayoutPanel ModificaPanou;
        private Button Modifica;
        private Button ModificaFurnizor;
        private Button ModificaProdus;
        
        private Button ModificaCategorie;
        private System.Windows.Forms.Timer ModificaTimer;
        private FlowLayoutPanel PanouSterge;
        private Button Sterge;
        private Button StergeFurnizor;
        private Button StergeProdusMeniu;
        private Button StergeProdus;
        
        private Button StergeCategorie;
        private System.Windows.Forms.Timer StergeTimer;
    }
}