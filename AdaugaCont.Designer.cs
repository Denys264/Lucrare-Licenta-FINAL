namespace Gestiune_Bar_proiect_LICENTA
{
    partial class AdaugaCont
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdaugaCont));
            label1 = new Label();
            label2 = new Label();
            NumeUtilizator = new TextBox();
            label3 = new Label();
            NumeParola = new TextBox();
            AdaugaUnCont = new Button();
            Inapoi = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(292, 9);
            label1.Name = "label1";
            label1.Size = new Size(313, 43);
            label1.TabIndex = 0;
            label1.Text = "Adaugati un Cont";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(206, 78);
            label2.TabIndex = 1;
            label2.Text = "Nume Utilizator:";
            // 
            // NumeUtilizator
            // 
            NumeUtilizator.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NumeUtilizator.Location = new Point(23, 116);
            NumeUtilizator.Name = "NumeUtilizator";
            NumeUtilizator.Size = new Size(308, 30);
            NumeUtilizator.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 149);
            label3.Name = "label3";
            label3.Size = new Size(108, 78);
            label3.TabIndex = 3;
            label3.Text = "Parola:";
            // 
            // NumeParola
            // 
            NumeParola.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NumeParola.Location = new Point(23, 197);
            NumeParola.Name = "NumeParola";
            NumeParola.Size = new Size(308, 30);
            NumeParola.TabIndex = 4;
            // 
            // AdaugaUnCont
            // 
            AdaugaUnCont.Font = new Font("Arial Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdaugaUnCont.Location = new Point(26, 253);
            AdaugaUnCont.Name = "AdaugaUnCont";
            AdaugaUnCont.Size = new Size(305, 50);
            AdaugaUnCont.TabIndex = 5;
            AdaugaUnCont.Text = "Adaugati Contul";
            AdaugaUnCont.UseVisualStyleBackColor = true;
            AdaugaUnCont.Click += AdaugaUnCont_Click;
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(569, 253);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 6;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            Inapoi.Click += Inapoi_Click_1;
            // 
            // AdaugaCont
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(904, 324);
            ControlBox = false;
            Controls.Add(Inapoi);
            Controls.Add(AdaugaUnCont);
            Controls.Add(NumeParola);
            Controls.Add(label3);
            Controls.Add(NumeUtilizator);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdaugaCont";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adaugati un Cont";
            Load += AdaugaCont_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox NumeUtilizator;
        private Label label3;
        private TextBox NumeParola;
        private Button AdaugaUnCont;
        private Button Inapoi;
    }
}