using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class StergeProdusGestiune : Form
    {
        // Șirul de conexiune către baza de date
        private string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public StergeProdusGestiune()
        {
            InitializeComponent();

            // Asocierea evenimentelor la controale
            this.Load += StergeProdusGestiune_Load;
            this.ButonSterge.Click += ButonSterge_Click;
            this.Inapoi.Click += Inapoi_Click;
        }

        private void StergeProdusGestiune_Load(object sender, EventArgs e)
        {
            // La încărcarea formularului, încărcăm toate produsele în ComboBox și DataGridView
            try
            {
                Produs.Items.Clear();

                using (SqlConnection conexiune = new SqlConnection(connectionString))
                {
                    conexiune.Open();

                    string interogare = @"SELECT ID, NUME, CANTITATE, PRET, CANTITATE_MINIMA, UNITATE FROM Produse ORDER BY NUME";

                    // Populăm ComboBox-ul cu produsele din baza de date
                    using (SqlCommand comanda = new SqlCommand(interogare, conexiune))
                    using (SqlDataReader reader = comanda.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idProdus = (int)reader["ID"];
                            string numeProdus = reader["NUME"].ToString();
                            Produs.Items.Add(new KeyValuePair<int, string>(idProdus, numeProdus));
                        }
                    }

                    // Populăm DataGridView cu toate detaliile produselor
                    SqlDataAdapter adaptor = new SqlDataAdapter(interogare, conexiune);
                    DataTable tabelDate = new DataTable();
                    adaptor.Fill(tabelDate);

                    dataGridViewProduse.DataSource = tabelDate;
                    ConfigureDataGridView();
                }

                // Configurăm afișarea ComboBox-ului
                Produs.DisplayMember = "Value"; // Nume produs
                Produs.ValueMember = "Key";     // ID produs
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea produselor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            // Configurăm aspectul DataGridView-ului pentru afișare clară și profesională
            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridViewProduse.EnableHeadersVisualStyles = false;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewProduse.RowHeadersVisible = false;
            dataGridViewProduse.BackgroundColor = Color.White;

            // Setăm anteturile coloanelor și ascundem coloana ID
            if (dataGridViewProduse.Columns["ID"] != null)
                dataGridViewProduse.Columns["ID"].Visible = false;

            if (dataGridViewProduse.Columns["NUME"] != null)
                dataGridViewProduse.Columns["NUME"].HeaderText = "Nume Produs";

            if (dataGridViewProduse.Columns["CANTITATE"] != null)
                dataGridViewProduse.Columns["CANTITATE"].HeaderText = "Cantitate";

            if (dataGridViewProduse.Columns["PRET"] != null)
                dataGridViewProduse.Columns["PRET"].HeaderText = "Preț";

            if (dataGridViewProduse.Columns["CANTITATE_MINIMA"] != null)
                dataGridViewProduse.Columns["CANTITATE_MINIMA"].HeaderText = "Stoc Minim";

            if (dataGridViewProduse.Columns["UNITATE"] != null)
                dataGridViewProduse.Columns["UNITATE"].HeaderText = "Unitate";
        }

        private void ButonSterge_Click(object sender, EventArgs e)
        {
            // Se execută la apăsarea butonului de ștergere produs
            if (Produs.SelectedItem == null)
            {
                MessageBox.Show("Vă rugăm să selectați un produs pentru ștergere.", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var produsSelectat = (KeyValuePair<int, string>)Produs.SelectedItem;
            int idProdus = produsSelectat.Key;
            string numeProdus = produsSelectat.Value;

            // Confirmăm ștergerea cu utilizatorul
            DialogResult confirmare = MessageBox.Show(
                $"Sigur doriți să ștergeți definitiv produsul '{numeProdus}'?",
                "Confirmare ștergere",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmare == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conexiune = new SqlConnection(connectionString))
                    {
                        conexiune.Open();

                        // Ștergem produsul din tabela Produse
                        string queryStergere = "DELETE FROM Produse WHERE ID = @IdProdus";

                        using (SqlCommand comandaStergere = new SqlCommand(queryStergere, conexiune))
                        {
                            comandaStergere.Parameters.AddWithValue("@IdProdus", idProdus);
                            int randuriSterse = comandaStergere.ExecuteNonQuery();

                            if (randuriSterse > 0)
                            {
                                MessageBox.Show($"Produsul '{numeProdus}' a fost șters definitiv din gestiune.",
                                                "Ștergere reușită",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);

                                // Reîncărcăm lista de produse pentru a actualiza interfața
                                StergeProdusGestiune_Load(null, null);
                            }
                        }
                    }
                }
                catch (SqlException ex) when (ex.Number == 547) // Cheie străină blocată
                {
                    MessageBox.Show(
                        "Nu se poate șterge acest produs deoarece este utilizat în alte tabele (categorii).",
                        "Eroare ștergere",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"A apărut o eroare la ștergerea produsului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            // Închidem formularul curent la apăsarea butonului Înapoi
            this.Close();
        }
    }
}
