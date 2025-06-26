namespace Gestiune_Bar_proiect_LICENTA
{
    partial class MeniuAdministrator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeniuAdministrator));
            panel1 = new Panel();
            ValoareTotala = new Label();
            ValoareIncasata = new Label();
            ValoareDeIncasat = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            MINUTE = new Label();
            label2 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            DATA = new Label();
            ORA = new Label();
            SECUNDE = new Label();
            USER = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            AdministrareStocuri = new Button();
            Rapoarte = new Button();
            SchimbareCont = new Button();
            Incepere_Final = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Comanda1 = new Button();
            Comanda2 = new Button();
            Comanda3 = new Button();
            Comanda4 = new Button();
            Comanda5 = new Button();
            Comanda6 = new Button();
            Comanda7 = new Button();
            Comanda8 = new Button();
            Comanda9 = new Button();
            Comanda10 = new Button();
            Comanda11 = new Button();
            Comanda12 = new Button();
            Comanda13 = new Button();
            Comanda14 = new Button();
            Comanda15 = new Button();
            Temporizator = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 224, 192);
            panel1.Controls.Add(ValoareTotala);
            panel1.Controls.Add(ValoareIncasata);
            panel1.Controls.Add(ValoareDeIncasat);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(MINUTE);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(DATA);
            panel1.Controls.Add(ORA);
            panel1.Controls.Add(SECUNDE);
            panel1.Controls.Add(USER);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1405, 264);
            panel1.TabIndex = 0;
            // 
            // ValoareTotala
            // 
            ValoareTotala.AutoSize = true;
            ValoareTotala.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ValoareTotala.Location = new Point(658, 199);
            ValoareTotala.Name = "ValoareTotala";
            ValoareTotala.Size = new Size(0, 42);
            ValoareTotala.TabIndex = 15;
            // 
            // ValoareIncasata
            // 
            ValoareIncasata.AutoSize = true;
            ValoareIncasata.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ValoareIncasata.Location = new Point(658, 119);
            ValoareIncasata.Name = "ValoareIncasata";
            ValoareIncasata.Size = new Size(0, 35);
            ValoareIncasata.TabIndex = 14;
            // 
            // ValoareDeIncasat
            // 
            ValoareDeIncasat.AutoSize = true;
            ValoareDeIncasat.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ValoareDeIncasat.Location = new Point(683, 164);
            ValoareDeIncasat.Name = "ValoareDeIncasat";
            ValoareDeIncasat.Size = new Size(0, 35);
            ValoareDeIncasat.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(396, 198);
            label8.Name = "label8";
            label8.Size = new Size(266, 42);
            label8.TabIndex = 12;
            label8.Text = "Valoare Totala:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(396, 161);
            label7.Name = "label7";
            label7.Size = new Size(287, 35);
            label7.TabIndex = 11;
            label7.Text = "Valoare de Incasat:";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(396, 119);
            label6.Name = "label6";
            label6.Size = new Size(261, 35);
            label6.TabIndex = 10;
            label6.Text = "Valoare Incasata:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Britannic Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(71, 143);
            label1.Name = "label1";
            label1.Size = new Size(35, 52);
            label1.TabIndex = 4;
            label1.Text = ":";
            // 
            // MINUTE
            // 
            MINUTE.Font = new Font("Britannic Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MINUTE.Location = new Point(100, 143);
            MINUTE.Name = "MINUTE";
            MINUTE.Size = new Size(80, 52);
            MINUTE.TabIndex = 2;
            MINUTE.Text = "00 ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Britannic Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(173, 143);
            label2.Name = "label2";
            label2.Size = new Size(35, 52);
            label2.TabIndex = 5;
            label2.Text = ":";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(10, 9);
            label5.Name = "label5";
            label5.Size = new Size(544, 31);
            label5.TabIndex = 9;
            label5.Text = "PIATRA-NEAMȚ, Str. MUREȘ, Nr. 22, județ NEAMȚ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 78);
            label4.Name = "label4";
            label4.Size = new Size(186, 31);
            label4.TabIndex = 8;
            label4.Text = "C.U.I.: 49439816";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 40);
            label3.Name = "label3";
            label3.Size = new Size(408, 38);
            label3.TabIndex = 7;
            label3.Text = "S.C RALU ELE CAFE BAR S.R.L.";
            // 
            // DATA
            // 
            DATA.AutoSize = true;
            DATA.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DATA.Location = new Point(12, 198);
            DATA.Name = "DATA";
            DATA.Size = new Size(79, 27);
            DATA.TabIndex = 6;
            DATA.Text = "label3";
            // 
            // ORA
            // 
            ORA.Font = new Font("Britannic Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ORA.Location = new Point(3, 143);
            ORA.Name = "ORA";
            ORA.Size = new Size(81, 52);
            ORA.TabIndex = 3;
            ORA.Text = "00 ";
            // 
            // SECUNDE
            // 
            SECUNDE.AutoSize = true;
            SECUNDE.Font = new Font("Britannic Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SECUNDE.Location = new Point(204, 143);
            SECUNDE.Name = "SECUNDE";
            SECUNDE.Size = new Size(80, 52);
            SECUNDE.TabIndex = 3;
            SECUNDE.Text = "00";
            // 
            // USER
            // 
            USER.AutoSize = true;
            USER.Font = new Font("Elephant", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            USER.ForeColor = Color.Black;
            USER.Location = new Point(1023, 198);
            USER.Name = "USER";
            USER.Size = new Size(243, 38);
            USER.TabIndex = 1;
            USER.Text = "Administrator";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1050, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(198, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 224, 192);
            panel2.Controls.Add(AdministrareStocuri);
            panel2.Controls.Add(Rapoarte);
            panel2.Controls.Add(SchimbareCont);
            panel2.Controls.Add(Incepere_Final);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(835, 264);
            panel2.Name = "panel2";
            panel2.Size = new Size(570, 514);
            panel2.TabIndex = 1;
            // 
            // AdministrareStocuri
            // 
            AdministrareStocuri.BackColor = Color.Silver;
            AdministrareStocuri.FlatAppearance.BorderSize = 0;
            AdministrareStocuri.FlatStyle = FlatStyle.Flat;
            AdministrareStocuri.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdministrareStocuri.Location = new Point(22, 35);
            AdministrareStocuri.Margin = new Padding(0);
            AdministrareStocuri.Name = "AdministrareStocuri";
            AdministrareStocuri.Size = new Size(527, 110);
            AdministrareStocuri.TabIndex = 3;
            AdministrareStocuri.Text = "Administrare ";
            AdministrareStocuri.UseVisualStyleBackColor = false;
            AdministrareStocuri.Click += AdministrareStocuri_Click;
            // 
            // Rapoarte
            // 
            Rapoarte.BackColor = Color.Silver;
            Rapoarte.FlatAppearance.BorderSize = 0;
            Rapoarte.FlatStyle = FlatStyle.Flat;
            Rapoarte.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Rapoarte.Location = new Point(22, 151);
            Rapoarte.Name = "Rapoarte";
            Rapoarte.Size = new Size(527, 110);
            Rapoarte.TabIndex = 2;
            Rapoarte.Text = "Rapoarte";
            Rapoarte.UseVisualStyleBackColor = false;
            Rapoarte.Click += Rapoarte_Click;
            // 
            // SchimbareCont
            // 
            SchimbareCont.BackColor = Color.Silver;
            SchimbareCont.FlatAppearance.BorderSize = 0;
            SchimbareCont.FlatStyle = FlatStyle.Flat;
            SchimbareCont.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SchimbareCont.Location = new Point(22, 267);
            SchimbareCont.Name = "SchimbareCont";
            SchimbareCont.Size = new Size(527, 110);
            SchimbareCont.TabIndex = 1;
            SchimbareCont.Text = "Schimbare Cont";
            SchimbareCont.UseVisualStyleBackColor = false;
            SchimbareCont.Click += SchimbareCont_Click;
            // 
            // Incepere_Final
            // 
            Incepere_Final.BackColor = Color.Silver;
            Incepere_Final.FlatAppearance.BorderSize = 0;
            Incepere_Final.FlatStyle = FlatStyle.Flat;
            Incepere_Final.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Incepere_Final.Location = new Point(22, 383);
            Incepere_Final.Name = "Incepere_Final";
            Incepere_Final.Size = new Size(527, 110);
            Incepere_Final.TabIndex = 0;
            Incepere_Final.Text = "button16";
            Incepere_Final.UseVisualStyleBackColor = false;
            Incepere_Final.Click += Incepere_Final_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.ControlLight;
            flowLayoutPanel1.Controls.Add(Comanda1);
            flowLayoutPanel1.Controls.Add(Comanda2);
            flowLayoutPanel1.Controls.Add(Comanda3);
            flowLayoutPanel1.Controls.Add(Comanda4);
            flowLayoutPanel1.Controls.Add(Comanda5);
            flowLayoutPanel1.Controls.Add(Comanda6);
            flowLayoutPanel1.Controls.Add(Comanda7);
            flowLayoutPanel1.Controls.Add(Comanda8);
            flowLayoutPanel1.Controls.Add(Comanda9);
            flowLayoutPanel1.Controls.Add(Comanda10);
            flowLayoutPanel1.Controls.Add(Comanda11);
            flowLayoutPanel1.Controls.Add(Comanda12);
            flowLayoutPanel1.Controls.Add(Comanda13);
            flowLayoutPanel1.Controls.Add(Comanda14);
            flowLayoutPanel1.Controls.Add(Comanda15);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 264);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(835, 514);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // Comanda1
            // 
            Comanda1.BackColor = SystemColors.HighlightText;
            Comanda1.Location = new Point(3, 3);
            Comanda1.Name = "Comanda1";
            Comanda1.Size = new Size(805, 82);
            Comanda1.TabIndex = 0;
            Comanda1.Text = "Comanda 1";
            Comanda1.UseVisualStyleBackColor = false;
            Comanda1.Click += Comanda1_Click;
            // 
            // Comanda2
            // 
            Comanda2.Location = new Point(3, 91);
            Comanda2.Name = "Comanda2";
            Comanda2.Size = new Size(805, 82);
            Comanda2.TabIndex = 1;
            Comanda2.Text = "Comanda 2";
            Comanda2.UseVisualStyleBackColor = true;
            Comanda2.Click += Comanda2_Click;
            // 
            // Comanda3
            // 
            Comanda3.Location = new Point(3, 179);
            Comanda3.Name = "Comanda3";
            Comanda3.Size = new Size(805, 82);
            Comanda3.TabIndex = 2;
            Comanda3.Text = "Comanda 3";
            Comanda3.UseVisualStyleBackColor = true;
            Comanda3.Click += Comanda3_Click;
            // 
            // Comanda4
            // 
            Comanda4.Location = new Point(3, 267);
            Comanda4.Name = "Comanda4";
            Comanda4.Size = new Size(805, 82);
            Comanda4.TabIndex = 3;
            Comanda4.Text = "Comanda 4";
            Comanda4.UseVisualStyleBackColor = true;
            Comanda4.Click += Comanda4_Click;
            // 
            // Comanda5
            // 
            Comanda5.Location = new Point(3, 355);
            Comanda5.Name = "Comanda5";
            Comanda5.Size = new Size(805, 82);
            Comanda5.TabIndex = 4;
            Comanda5.Text = "Comanda 5";
            Comanda5.UseVisualStyleBackColor = true;
            Comanda5.Click += Comanda5_Click;
            // 
            // Comanda6
            // 
            Comanda6.Location = new Point(3, 443);
            Comanda6.Name = "Comanda6";
            Comanda6.Size = new Size(805, 82);
            Comanda6.TabIndex = 5;
            Comanda6.Text = "Comanda 6";
            Comanda6.UseVisualStyleBackColor = true;
            Comanda6.Click += Comanda6_Click;
            // 
            // Comanda7
            // 
            Comanda7.Location = new Point(3, 531);
            Comanda7.Name = "Comanda7";
            Comanda7.Size = new Size(805, 82);
            Comanda7.TabIndex = 6;
            Comanda7.Text = "Comanda 7";
            Comanda7.UseVisualStyleBackColor = true;
            Comanda7.Click += Comanda7_Click;
            // 
            // Comanda8
            // 
            Comanda8.Location = new Point(3, 619);
            Comanda8.Name = "Comanda8";
            Comanda8.Size = new Size(805, 82);
            Comanda8.TabIndex = 7;
            Comanda8.Text = "Comanda 8";
            Comanda8.UseVisualStyleBackColor = true;
            Comanda8.Click += Comanda8_Click;
            // 
            // Comanda9
            // 
            Comanda9.Location = new Point(3, 707);
            Comanda9.Name = "Comanda9";
            Comanda9.Size = new Size(805, 82);
            Comanda9.TabIndex = 8;
            Comanda9.Text = "Comanda 9";
            Comanda9.UseVisualStyleBackColor = true;
            Comanda9.Click += Comanda9_Click;
            // 
            // Comanda10
            // 
            Comanda10.Location = new Point(3, 795);
            Comanda10.Name = "Comanda10";
            Comanda10.Size = new Size(805, 82);
            Comanda10.TabIndex = 9;
            Comanda10.Text = "Comanda 10";
            Comanda10.UseVisualStyleBackColor = true;
            Comanda10.Click += Comanda10_Click;
            // 
            // Comanda11
            // 
            Comanda11.Location = new Point(3, 883);
            Comanda11.Name = "Comanda11";
            Comanda11.Size = new Size(805, 82);
            Comanda11.TabIndex = 10;
            Comanda11.Text = "Comanda 11";
            Comanda11.UseVisualStyleBackColor = true;
            Comanda11.Click += Comanda11_Click;
            // 
            // Comanda12
            // 
            Comanda12.Location = new Point(3, 971);
            Comanda12.Name = "Comanda12";
            Comanda12.Size = new Size(805, 82);
            Comanda12.TabIndex = 11;
            Comanda12.Text = "Comanda 12";
            Comanda12.UseVisualStyleBackColor = true;
            Comanda12.Click += Comanda12_Click;
            // 
            // Comanda13
            // 
            Comanda13.Location = new Point(3, 1059);
            Comanda13.Name = "Comanda13";
            Comanda13.Size = new Size(805, 82);
            Comanda13.TabIndex = 12;
            Comanda13.Text = "Comanda 13";
            Comanda13.UseVisualStyleBackColor = true;
            Comanda13.Click += Comanda13_Click;
            // 
            // Comanda14
            // 
            Comanda14.Location = new Point(3, 1147);
            Comanda14.Name = "Comanda14";
            Comanda14.Size = new Size(805, 82);
            Comanda14.TabIndex = 13;
            Comanda14.Text = "Comanda 14";
            Comanda14.UseVisualStyleBackColor = true;
            Comanda14.Click += Comanda14_Click;
            // 
            // Comanda15
            // 
            Comanda15.Location = new Point(3, 1235);
            Comanda15.Name = "Comanda15";
            Comanda15.Size = new Size(805, 82);
            Comanda15.TabIndex = 14;
            Comanda15.Text = "Comanda 15";
            Comanda15.UseVisualStyleBackColor = true;
            Comanda15.Click += Comanda15_Click;
            // 
            // Temporizator
            // 
            Temporizator.Interval = 1000;
            Temporizator.Tick += Temporizator_Tick;
            // 
            // MeniuAdministrator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1405, 778);
            ControlBox = false;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MeniuAdministrator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meniu Administrator";
            Load += MeniuAdministrator_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button Comanda1;
        private Button Comanda2;
        private Button Comanda3;
        private Button Comanda4;
        private Button Comanda5;
        private Button Comanda6;
        private Button Comanda7;
        private Button Comanda8;
        private Button Comanda9;
        private Button Comanda10;
        private Button Comanda11;
        private Button Comanda12;
        private Button Comanda13;
        private Button Comanda14;
        private Button Comanda15;
        private Label USER;
        private PictureBox pictureBox1;
        private Button Incepere_Final;
        private Button AdministrareStocuri;
        private Button Rapoarte;
        private Button SchimbareCont;
        private Label ORA;
        private Label SECUNDE;
        private Label MINUTE;
        private System.Windows.Forms.Timer Temporizator;
        private Label label2;
        private Label label1;
        private Label DATA;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label ValoareDeIncasat;
        private Label ValoareIncasata;
        private Label ValoareTotala;
    }
}