using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class AdaugaProdusMeniu : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public AdaugaProdusMeniu()
        {
            InitializeComponent();

            // Asocieri evenimente
            this.Load += AdaugaProdusMeniu_Load;
            this.ButonAdauga.Click += ButonAdauga_Click;
            this.Inapoi.Click += (s, e) => this.Close();
        }

        /// <summary>
        /// Încarcă categoriile existente și produsele ascunse în ComboBox-uri
        /// </summary>
        private void AdaugaProdusMeniu_Load(object sender, EventArgs e)
        {
            Categorie.Items.Clear();
            Produs.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Populare categorii (tabele din schema CATEGORII)
                    string categoriiQuery = @"
                        SELECT TABLE_NAME 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_SCHEMA = 'CATEGORII'
                        ORDER BY TABLE_NAME";

                    using (SqlCommand cmd = new SqlCommand(categoriiQuery, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categorie.Items.Add(reader["TABLE_NAME"].ToString());
                        }
                    }

                    // 2. Populare produse ascunse (AFISAT = 0)
                    string produseQuery = @"
                        SELECT ID, NUME 
                        FROM Produse 
                        WHERE AFISAT = 0 
                        ORDER BY NUME";

                    using (SqlCommand cmd = new SqlCommand(produseQuery, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new KeyValuePair<int, string>(
                                (int)reader["ID"],
                                reader["NUME"].ToString());

                            Produs.Items.Add(item);
                        }
                    }

                    Produs.DisplayMember = "Value";
                    Produs.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea datelor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adaugă produsul selectat în categoria aleasă și îl face vizibil în meniu
        /// </summary>
        private void ButonAdauga_Click(object sender, EventArgs e)
        {
            if (Categorie.SelectedItem == null || Produs.SelectedItem == null)
            {
                MessageBox.Show("Selectați atât o categorie cât și un produs.", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string categorie = Categorie.SelectedItem.ToString();
            var produs = (KeyValuePair<int, string>)Produs.SelectedItem;
            int idProdus = produs.Key;
            string numeProdus = produs.Value;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificăm dacă produsul există deja în categoria respectivă
                    string verificareQuery = $@"
                        SELECT COUNT(*) 
                        FROM [CATEGORII].[{categorie}] 
                        WHERE ID_Produs = @idProdus";

                    using (SqlCommand cmdVerificare = new SqlCommand(verificareQuery, conn))
                    {
                        cmdVerificare.Parameters.AddWithValue("@idProdus", idProdus);
                        int exista = (int)cmdVerificare.ExecuteScalar();

                        if (exista > 0)
                        {
                            MessageBox.Show($"Produsul '{numeProdus}' există deja în categoria '{categorie}'.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Adăugăm produsul în tabelul categoriei
                    string insertQuery = $@"
                        INSERT INTO [CATEGORII].[{categorie}] (ID_Produs) 
                        VALUES (@idProdus)";

                    using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@idProdus", idProdus);
                        cmdInsert.ExecuteNonQuery();
                    }

                    // Facem produsul vizibil în meniu
                    string updateQuery = @"
                        UPDATE Produse 
                        SET AFISAT = 1 
                        WHERE ID = @idProdus";

                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@idProdus", idProdus);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // Eliminăm produsul din listă după adăugare
                    Produs.Items.Remove(produs);
                    Produs.SelectedItem = null;

                    MessageBox.Show($"Produsul '{numeProdus}' a fost adăugat în categoria '{categorie}' și este acum vizibil în meniu.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea produsului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
