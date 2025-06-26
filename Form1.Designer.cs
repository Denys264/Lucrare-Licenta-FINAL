namespace Gestiune_Bar_proiect_LICENTA
{
    partial class PaginaLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginaLogin));
            label1 = new Label();
            label2 = new Label();
            NumeUtilizator = new TextBox();
            label3 = new Label();
            Parola = new TextBox();
            Logare = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Stencil", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(228, 24);
            label1.Name = "label1";
            label1.Size = new Size(369, 58);
            label1.TabIndex = 0;
            label1.Text = "Meniu Logare";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Stencil", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(228, 121);
            label2.Name = "label2";
            label2.Size = new Size(211, 27);
            label2.TabIndex = 1;
            label2.Text = "Nume Utilizator";
            // 
            // NumeUtilizator
            // 
            NumeUtilizator.BackColor = SystemColors.ActiveBorder;
            NumeUtilizator.BorderStyle = BorderStyle.FixedSingle;
            NumeUtilizator.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumeUtilizator.ForeColor = Color.White;
            NumeUtilizator.Location = new Point(228, 151);
            NumeUtilizator.Name = "NumeUtilizator";
            NumeUtilizator.Size = new Size(265, 30);
            NumeUtilizator.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Stencil", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(228, 214);
            label3.Name = "label3";
            label3.Size = new Size(98, 27);
            label3.TabIndex = 3;
            label3.Text = "PAROLA";
            // 
            // Parola
            // 
            Parola.BackColor = SystemColors.ActiveBorder;
            Parola.BorderStyle = BorderStyle.FixedSingle;
            Parola.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Parola.ForeColor = Color.White;
            Parola.Location = new Point(228, 244);
            Parola.Name = "Parola";
            Parola.Size = new Size(265, 30);
            Parola.TabIndex = 4;
            // 
            // Logare
            // 
            Logare.BackColor = Color.Black;
            Logare.Font = new Font("Stencil", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Logare.ForeColor = Color.White;
            Logare.Location = new Point(262, 317);
            Logare.Name = "Logare";
            Logare.Size = new Size(195, 67);
            Logare.TabIndex = 5;
            Logare.Text = "LOGIN";
            Logare.UseVisualStyleBackColor = false;
            Logare.Click += Logare_Click;
            // 
            // PaginaLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(Logare);
            Controls.Add(Parola);
            Controls.Add(label3);
            Controls.Add(NumeUtilizator);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PaginaLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += PaginaLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox NumeUtilizator;
        private Label label3;
        private TextBox Parola;
        private Button Logare;
    }
}
