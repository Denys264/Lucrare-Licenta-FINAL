using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class ModificaFurnizor : Form
    {
        // Șir de conexiune la baza de date SQL Server
        private string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ModificaFurnizor()
        {
            InitializeComponent();

            // Legăm evenimentele la controalele din formular
            this.Load += ModificaFurnizor_Load;
            this.Furnizor.SelectedIndexChanged += Furnizor_SelectedIndexChanged;
            this.ButonModifica.Click += ButonModifica_Click;
            this.Inapoi.Click += Inapoi_Click;
        }

        // Eveniment la încărcarea formularului
        private void ModificaFurnizor_Load(object sender, EventArgs e)
        {
            // Încărcăm lista de furnizori și grid-ul aferent
            IncarcaFurnizori();
        }

        // Încarcă toți furnizorii în combobox și în DataGridView
        private void IncarcaFurnizori()
        {
            try
            {
                Furnizor.Items.Clear();
                dataGridViewFurnizor.DataSource = null;

                using (SqlConnection conexiune = new SqlConnection(connectionString))
                {
                    conexiune.Open();

                    // Interogare SQL pentru preluarea tuturor furnizorilor
                    string interogare = @"SELECT ID, NUME, CUI, ADRESA, NUMAR_TELEFON FROM Furnizori ORDER BY NUME";

                    // Populăm combobox-ul cu perechi (ID, NUME)
                    using (SqlCommand comanda = new SqlCommand(interogare, conexiune))
                    using (SqlDataReader reader = comanda.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Furnizor.Items.Add(new KeyValuePair<int, string>(
                                (int)reader["ID"],
                                reader["NUME"].ToString()));
                        }
                    }

                    // Populăm DataGridView-ul cu toți furnizorii
                    SqlDataAdapter adaptor = new SqlDataAdapter(interogare, conexiune);
                    DataTable tabel = new DataTable();
                    adaptor.Fill(tabel);
                    dataGridViewFurnizor.DataSource = tabel;

                    ConfigureazaDataGridView();
                }

                // Setăm valorile de afișare pentru combobox
                Furnizor.DisplayMember = "Value";
                Furnizor.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea furnizorilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Setează stilul grafic și coloanele DataGridView-ului
        private void ConfigureazaDataGridView()
        {
            dataGridViewFurnizor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFurnizor.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridViewFurnizor.EnableHeadersVisualStyles = false;
            dataGridViewFurnizor.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewFurnizor.RowHeadersVisible = false;
            dataGridViewFurnizor.BackgroundColor = Color.White;

            dataGridViewFurnizor.Columns["ID"].Visible = false;
            dataGridViewFurnizor.Columns["NUME"].HeaderText = "Nume Furnizor";
            dataGridViewFurnizor.Columns["CUI"].HeaderText = "Cod Unic de Înregistrare";
            dataGridViewFurnizor.Columns["ADRESA"].HeaderText = "Adresă";
            dataGridViewFurnizor.Columns["NUMAR_TELEFON"].HeaderText = "Număr de Telefon";
        }

        // Afișează datele unui furnizor selectat în câmpurile de editare
        private void Furnizor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Furnizor.SelectedItem == null) return;

            var furnizorSelectat = (KeyValuePair<int, string>)Furnizor.SelectedItem;
            int idFurnizor = furnizorSelectat.Key;

            try
            {
                using (SqlConnection conexiune = new SqlConnection(connectionString))
                {
                    conexiune.Open();
                    string interogare = @"SELECT NUME, CUI, ADRESA, NUMAR_TELEFON FROM Furnizori WHERE ID = @IdFurnizor";

                    using (SqlCommand comanda = new SqlCommand(interogare, conexiune))
                    {
                        comanda.Parameters.AddWithValue("@IdFurnizor", idFurnizor);

                        using (SqlDataReader reader = comanda.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                NumeNou.Text = reader["NUME"].ToString();
                                CUINou.Text = reader["CUI"].ToString();
                                AdresaNoua.Text = reader["ADRESA"].ToString();
                                TelNou.Text = reader["NUMAR_TELEFON"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea detaliilor furnizorului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Salvează modificările aduse furnizorului selectat
        private void ButonModifica_Click(object sender, EventArgs e)
        {
            if (Furnizor.SelectedItem == null)
            {
                MessageBox.Show("Vă rugăm selectați un furnizor din listă!", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var furnizorSelectat = (KeyValuePair<int, string>)Furnizor.SelectedItem;
            int idFurnizor = furnizorSelectat.Key;
            string numeCurent = furnizorSelectat.Value;

            string numeNou = NumeNou.Text.Trim();
            string cuiNou = CUINou.Text.Trim();
            string adresaNoua = AdresaNoua.Text.Trim();
            string nrTelNou = TelNou.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeNou) || string.IsNullOrWhiteSpace(cuiNou))
            {
                MessageBox.Show("Câmpurile 'Nume' și 'CUI' sunt obligatorii!", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexiune = new SqlConnection(connectionString))
                {
                    conexiune.Open();

                    // Verificăm dacă noul nume există deja, dacă s-a schimbat
                    if (numeNou != numeCurent)
                    {
                        string interogareVerificareNume = @"SELECT COUNT(*) FROM Furnizori WHERE NUME = @NumeNou AND ID != @IdFurnizor";
                        using (SqlCommand comanda = new SqlCommand(interogareVerificareNume, conexiune))
                        {
                            comanda.Parameters.AddWithValue("@NumeNou", numeNou);
                            comanda.Parameters.AddWithValue("@IdFurnizor", idFurnizor);
                            int numeExistent = (int)comanda.ExecuteScalar();

                            if (numeExistent > 0)
                            {
                                MessageBox.Show("Există deja un furnizor cu acest nume în baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Verificăm dacă CUI-ul este unic
                    string interogareVerificareCui = @"SELECT COUNT(*) FROM Furnizori WHERE CUI = @CuiNou AND ID != @IdFurnizor";
                    using (SqlCommand comanda = new SqlCommand(interogareVerificareCui, conexiune))
                    {
                        comanda.Parameters.AddWithValue("@CuiNou", cuiNou);
                        comanda.Parameters.AddWithValue("@IdFurnizor", idFurnizor);
                        int cuiExistent = (int)comanda.ExecuteScalar();

                        if (cuiExistent > 0)
                        {
                            MessageBox.Show("Există deja un furnizor cu acest Cod Unic de Înregistrare!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Executăm UPDATE pentru furnizor
                    string interogareActualizare = @"UPDATE Furnizori 
                        SET NUME = @NumeNou, CUI = @CuiNou, ADRESA = @AdresaNoua, NUMAR_TELEFON = @NrTelNou 
                        WHERE ID = @IdFurnizor";

                    using (SqlCommand comanda = new SqlCommand(interogareActualizare, conexiune))
                    {
                        comanda.Parameters.AddWithValue("@NumeNou", numeNou);
                        comanda.Parameters.AddWithValue("@CuiNou", cuiNou);
                        comanda.Parameters.AddWithValue("@AdresaNoua", adresaNoua);
                        comanda.Parameters.AddWithValue("@NrTelNou", nrTelNou);
                        comanda.Parameters.AddWithValue("@IdFurnizor", idFurnizor);

                        int randuriAfectate = comanda.ExecuteNonQuery();

                        if (randuriAfectate > 0)
                        {
                            MessageBox.Show("Datele furnizorului au fost actualizate cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reîncărcăm lista și selectăm din nou furnizorul modificat
                            IncarcaFurnizori();
                            foreach (KeyValuePair<int, string> item in Furnizor.Items)
                            {
                                if (item.Key == idFurnizor)
                                {
                                    Furnizor.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la actualizarea furnizorului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Închide formularul curent
        private void Inapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
