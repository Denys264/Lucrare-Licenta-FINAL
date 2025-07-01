using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class StergeProdusMeniu : Form
    {
        // Șirul de conexiune la baza de date
        private string sirConexiune = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public StergeProdusMeniu()
        {
            InitializeComponent();

            // Legăm evenimentele controalelor
            this.Load += StergeProdusMeniu_Load;
            this.Categorie.SelectedIndexChanged += Categorie_SelectedIndexChanged;
            this.ButonSterge.Click += ButonSterge_Click;
            this.Inapoi.Click += Inapoi_Click;
        }

        private void StergeProdusMeniu_Load(object sender, EventArgs e)
        {
            // La încărcarea formularului, aducem categoriile din schema CATEGORII
            try
            {
                Categorie.Items.Clear();

                using (SqlConnection conexiune = new SqlConnection(sirConexiune))
                {
                    conexiune.Open();

                    string interogare = @"SELECT TABLE_NAME 
                                          FROM INFORMATION_SCHEMA.TABLES 
                                          WHERE TABLE_SCHEMA = 'CATEGORII' 
                                          ORDER BY TABLE_NAME";

                    using (SqlCommand comanda = new SqlCommand(interogare, conexiune))
                    using (SqlDataReader cititor = comanda.ExecuteReader())
                    {
                        while (cititor.Read())
                        {
                            Categorie.Items.Add(cititor["TABLE_NAME"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la încărcarea categoriilor: {ex.Message}",
                                "Eroare",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Categorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se activează când se selectează o categorie nouă
            if (Categorie.SelectedItem == null) return;

            string categorieAleasa = Categorie.SelectedItem.ToString();

            // Validăm numele categoriei pentru a evita SQL injection
            if (!Regex.IsMatch(categorieAleasa, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Numele categoriei este invalid!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Produs.Items.Clear();
                dataGridViewProduse.DataSource = null;

                using (SqlConnection conexiune = new SqlConnection(sirConexiune))
                {
                    conexiune.Open();

                    string interogareProduse = $@"
                        SELECT p.ID, p.NUME, p.CANTITATE, p.PRET, p.UNITATE 
                        FROM [CATEGORII].[{categorieAleasa}] c
                        INNER JOIN Produse p ON c.ID_Produs = p.ID
                        WHERE p.AFISAT = 1
                        ORDER BY p.NUME";

                    // Umplem ComboBox-ul cu produsele disponibile în categoria selectată
                    using (SqlCommand comanda = new SqlCommand(interogareProduse, conexiune))
                    using (SqlDataReader cititor = comanda.ExecuteReader())
                    {
                        while (cititor.Read())
                        {
                            int idProdus = (int)cititor["ID"];
                            string numeProdus = cititor["NUME"].ToString();

                            Produs.Items.Add(new KeyValuePair<int, string>(idProdus, numeProdus));
                        }
                    }

                    // Setăm proprietățile ComboBox-ului
                    if (Produs.Items.Count > 0)
                    {
                        Produs.DisplayMember = "Value";
                        Produs.ValueMember = "Key";
                        Produs.SelectedIndex = 0;
                    }

                    // Umplem DataGridView cu detalii despre produse
                    SqlDataAdapter adapter = new SqlDataAdapter(interogareProduse, conexiune);
                    DataTable tabelProduse = new DataTable();
                    adapter.Fill(tabelProduse);

                    dataGridViewProduse.DataSource = tabelProduse;

                    ConfigureazaDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea produselor: {ex.Message}",
                                "Eroare",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ConfigureazaDataGridView()
        {
            // Configurăm aspectul și proprietățile DataGridView-ului
            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridViewProduse.EnableHeadersVisualStyles = false;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewProduse.RowHeadersVisible = false;
            dataGridViewProduse.BackgroundColor = Color.White;

            if (dataGridViewProduse.Columns.Contains("ID"))
                dataGridViewProduse.Columns["ID"].Visible = false;

            if (dataGridViewProduse.Columns.Contains("NUME"))
                dataGridViewProduse.Columns["NUME"].HeaderText = "Nume Produs";

            if (dataGridViewProduse.Columns.Contains("CANTITATE"))
                dataGridViewProduse.Columns["CANTITATE"].HeaderText = "Cantitate";

            if (dataGridViewProduse.Columns.Contains("PRET"))
                dataGridViewProduse.Columns["PRET"].HeaderText = "Preț";

            if (dataGridViewProduse.Columns.Contains("UNITATE"))
                dataGridViewProduse.Columns["UNITATE"].HeaderText = "Unitate";
        }

        private void ButonSterge_Click(object sender, EventArgs e)
        {
            // Verificăm că s-au selectat categorie și produs
            if (Categorie.SelectedItem == null || Produs.SelectedItem == null)
            {
                MessageBox.Show("Trebuie să selectați atât o categorie cât și un produs.",
                                "Atenție",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string categorieAleasa = Categorie.SelectedItem.ToString();
            var produsSelectat = (KeyValuePair<int, string>)Produs.SelectedItem;

            int idProdus = produsSelectat.Key;
            string numeProdus = produsSelectat.Value;

            // Confirmăm ștergerea
            DialogResult confirmare = MessageBox.Show(
                $"Sunteți sigur că vreți să ștergeți produsul '{numeProdus}' din categoria '{categorieAleasa}'?",
                "Confirmare ștergere",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmare == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conexiune = new SqlConnection(sirConexiune))
                    {
                        conexiune.Open();

                        // Ștergem produsul din tabela categoriei (link-ul)
                        string interogareStergere = $@"
                            DELETE FROM [CATEGORII].[{categorieAleasa}]
                            WHERE ID_Produs = @idProdus";

                        using (SqlCommand comandaStergere = new SqlCommand(interogareStergere, conexiune))
                        {
                            comandaStergere.Parameters.AddWithValue("@idProdus", idProdus);
                            int randuriSterse = comandaStergere.ExecuteNonQuery();

                            if (randuriSterse > 0)
                            {
                                // Actualizăm produsul ca "nevizibil" (AFISAT = 0)
                                string interogareActualizare = @"
                                    UPDATE Produse
                                    SET AFISAT = 0
                                    WHERE ID = @idProdus";

                                using (SqlCommand comandaActualizare = new SqlCommand(interogareActualizare, conexiune))
                                {
                                    comandaActualizare.Parameters.AddWithValue("@idProdus", idProdus);
                                    comandaActualizare.ExecuteNonQuery();
                                }

                                MessageBox.Show(
                                    $"Produsul '{numeProdus}' a fost șters cu succes din categoria '{categorieAleasa}'.",
                                    "Succes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                // Reîncărcăm lista de produse din categorie
                                Categorie_SelectedIndexChanged(null, null);
                            }
                            else
                            {
                                MessageBox.Show("Produsul nu a fost găsit în categoria selectată.",
                                                "Eroare",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la ștergerea produsului: {ex.Message}",
                                    "Eroare",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            // Închidem formularul curent pentru a ne întoarce la ecranul anterior
            this.Close();
        }

        
    }
}
