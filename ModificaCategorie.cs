using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class ModificaCategorie : Form
    {
        // Stringul de conexiune la baza de date
        private string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ModificaCategorie()
        {
            InitializeComponent();

            // Evenimente pentru încărcarea formularului și butoane
            this.Load += ModificaCategorie_Load;
            this.ButonModifica.Click += ButonModifica_Click;
            this.Inapoi.Click += ButonInapoi_Click;
        }

        /// <summary>
        /// La încărcarea formularului: Populează ComboBox-ul și DataGridView-ul cu tabelele din schema CATEGORII
        /// </summary>
        private void ModificaCategorie_Load(object sender, EventArgs e)
        {
            try
            {
                Categorie.Items.Clear();
                dataGridViewCategorie.DataSource = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT TABLE_NAME 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_SCHEMA = 'CATEGORII'
                        ORDER BY TABLE_NAME";

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Categorii Existente");

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tableName = reader["TABLE_NAME"].ToString();
                            Categorie.Items.Add(tableName);      // Populare ComboBox
                            dt.Rows.Add(tableName);             // Populare DataGridView
                        }
                    }

                    dataGridViewCategorie.DataSource = dt;
                    ConfigureDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea categoriilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configurează stilul vizual al DataGridView-ului
        /// </summary>
        private void ConfigureDataGridView()
        {
            dataGridViewCategorie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCategorie.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridViewCategorie.EnableHeadersVisualStyles = false;
            dataGridViewCategorie.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewCategorie.RowHeadersVisible = false;
            dataGridViewCategorie.BackgroundColor = Color.White;
            dataGridViewCategorie.ReadOnly = true;
        }

        /// <summary>
        /// La apăsarea butonului de modificare, se redenumește tabela selectată
        /// </summary>
        private void ButonModifica_Click(object sender, EventArgs e)
        {
            if (Categorie.SelectedItem == null || string.IsNullOrWhiteSpace(NumeNou.Text))
            {
                MessageBox.Show("Selectați o categorie și introduceți un nume nou.", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string numeVeche = Categorie.SelectedItem.ToString();
            string numeNou = NumeNou.Text.Trim();

            // Verificare dacă numele nou este identic cu cel vechi
            if (numeVeche.Equals(numeNou, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Numele nou este identic cu cel vechi.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verificare caractere nepermise (simplificată)
            if (numeNou.Contains(" ") || numeNou.IndexOfAny(new[] { ';', '\'', '\"', '-', '/' }) >= 0)
            {
                MessageBox.Show("Numele nou conține caractere nepermise.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificare existență nume nou
                    string checkQuery = @"
                        SELECT COUNT(*) 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_SCHEMA = 'CATEGORII' AND TABLE_NAME = @NumeNou";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@NumeNou", numeNou);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show($"Numele '{numeNou}' există deja. Alegeți alt nume.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Confirmare din partea utilizatorului
                    DialogResult confirm = MessageBox.Show(
                        $"Sunteți sigur că doriți să redenumiți categoria '{numeVeche}' în '{numeNou}'?",
                        "Confirmare modificare",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        // Redenumire tabelă folosind procedura sp_rename
                        string renameQuery = $"EXEC sp_rename '[CATEGORII].[{numeVeche}]', '{numeNou}', 'OBJECT'";

                        using (SqlCommand cmd = new SqlCommand(renameQuery, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Categoria '{numeVeche}' a fost redenumită în '{numeNou}'!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reîmprospătare formular
                        ModificaCategorie_Load(null, null);
                        NumeNou.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la modificarea categoriei: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Închide formularul curent
        /// </summary>
        private void ButonInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
