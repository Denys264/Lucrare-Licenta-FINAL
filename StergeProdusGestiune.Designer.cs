namespace Gestiune_Bar_proiect_LICENTA
{
    partial class StergeProdusGestiune
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
            Produs = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            Inapoi = new Button();
            ButonSterge = new Button();
            dataGridViewProduse = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).BeginInit();
            SuspendLayout();
            // 
            // Produs
            // 
            Produs.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Produs.FormattingEnabled = true;
            Produs.Items.AddRange(new object[] { "50ml", "buc" });
            Produs.Location = new Point(265, 107);
            Produs.Name = "Produs";
            Produs.Size = new Size(263, 30);
            Produs.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 90);
            label2.Name = "label2";
            label2.Size = new Size(256, 78);
            label2.TabIndex = 34;
            label2.Text = "Numele Produsului*:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(119, 20);
            label1.Name = "label1";
            label1.Size = new Size(570, 43);
            label1.TabIndex = 36;
            label1.Text = "Stergeti un Produs in Gestiune";
            // 
            // Inapoi
            // 
            Inapoi.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inapoi.Location = new Point(474, 388);
            Inapoi.Name = "Inapoi";
            Inapoi.Size = new Size(305, 50);
            Inapoi.TabIndex = 37;
            Inapoi.Text = "Inapoi la pagina anterioara";
            Inapoi.UseVisualStyleBackColor = true;
            // 
            // ButonSterge
            // 
            ButonSterge.Font = new Font("Arial Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButonSterge.Location = new Point(12, 388);
            ButonSterge.Name = "ButonSterge";
            ButonSterge.Size = new Size(305, 50);
            ButonSterge.TabIndex = 38;
            ButonSterge.Text = "Stergeti Produsul";
            ButonSterge.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProduse
            // 
            dataGridViewProduse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduse.Location = new Point(12, 160);
            dataGridViewProduse.Name = "dataGridViewProduse";
            dataGridViewProduse.RowHeadersWidth = 51;
            dataGridViewProduse.Size = new Size(767, 188);
            dataGridViewProduse.TabIndex = 39;
            // 
            // StergeProdusGestiune
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(dataGridViewProduse);
            Controls.Add(ButonSterge);
            Controls.Add(Inapoi);
            Controls.Add(label1);
            Controls.Add(Produs);
            Controls.Add(label2);
            Name = "StergeProdusGestiune";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stergeti un Produs din Gestiune";
            Load += StergeProdusGestiune_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Produs;
        private Label label2;
        private Label label1;
        private Button Inapoi;
        private Button ButonSterge;
        private DataGridView dataGridViewProduse;
    }
}