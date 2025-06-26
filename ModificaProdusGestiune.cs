using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class ModificaProdusGestiune : Form
    {
        // Stringul de conexiune la baza de date
        private string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ModificaProdusGestiune()
        {
            InitializeComponent();

            // Legarea evenimentelor la metode
            this.Load += ModificaProdusGestiune_Load;
            this.Categorie.SelectedIndexChanged += Categorie_SelectedIndexChanged;
            this.Produs.SelectedIndexChanged += Produs_SelectedIndexChanged;
            this.ButonModifica.Click += ButonModifica_Click;
            this.Inapoi.Click += Inapoi_Click;
        }

        // La încărcarea formularului
        private void ModificaProdusGestiune_Load(object sender, EventArgs e)
        {
            try
            {
                // Curăță ComboBox-ul cu categorii
                Categorie.Items.Clear();

                // Încarcă numele tabelelor (categoriilor) din schema CATEGORII
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT TABLE_NAME 
                                   FROM INFORMATION_SCHEMA.TABLES 
                                   WHERE TABLE_SCHEMA = 'CATEGORII'
                                   ORDER BY TABLE_NAME";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categorie.Items.Add(reader["TABLE_NAME"].ToString());
                        }
                    }
                }

                // Adaugă categoria specială "neafisate"
                Categorie.Items.Add("neafisate");

                // Încarcă toate produsele în DataGridView
                LoadAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea categoriilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Încarcă toate produsele în DataGridView
        private void LoadAllProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ID, NUME, CANTITATE, PRET, CANTITATE_MINIMA, UNITATE 
                                   FROM Produse 
                                   ORDER BY NUME";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewProduse.DataSource = dt;
                    ConfigureDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea produselor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eveniment: selectare categorie
        private void Categorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Categorie.SelectedItem == null) return;

            string selectedCategory = Categorie.SelectedItem.ToString();

            try
            {
                Produs.Items.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query;

                    // Se selectează doar produsele care nu sunt afișate
                    if (selectedCategory == "neafisate")
                    {
                        query = @"SELECT ID, NUME FROM Produse WHERE AFISAT = 0 ORDER BY NUME";
                    }
                    else
                    {
                        // Se selectează produsele din categoria respectivă (din schema CATEGORII)
                        query = $@"
                        SELECT p.ID, p.NUME 
                        FROM [CATEGORII].[{selectedCategory}] c
                        JOIN Produse p ON c.ID_Produs = p.ID
                        ORDER BY p.NUME";
                    }

                    // Umple ComboBox-ul "Produs"
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produs.Items.Add(new KeyValuePair<int, string>(
                                (int)reader["ID"],
                                reader["NUME"].ToString()));
                        }
                    }

                    // Reîncarcă DataGridView cu produsele din categoria selectată
                    if (selectedCategory == "neafisate")
                    {
                        query = @"SELECT ID, NUME, CANTITATE, PRET, CANTITATE_MINIMA, UNITATE 
                                FROM Produse 
                                WHERE AFISAT = 0
                                ORDER BY NUME";
                    }
                    else
                    {
                        query = $@"
                        SELECT p.ID, p.NUME, p.CANTITATE, p.PRET, p.CANTITATE_MINIMA, p.UNITATE 
                        FROM [CATEGORII].[{selectedCategory}] c
                        JOIN Produse p ON c.ID_Produs = p.ID
                        ORDER BY p.NUME";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewProduse.DataSource = dt;
                    ConfigureDataGridView();
                }

                // Setează cum sunt afișate itemele în ComboBox-ul de produse
                Produs.DisplayMember = "Value";
                Produs.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea produselor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eveniment: selectare produs
        private void Produs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Produs.SelectedItem == null) return;

            var selectedProduct = (KeyValuePair<int, string>)Produs.SelectedItem;
            int productId = selectedProduct.Key;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT NUME, CANTITATE, PRET, CANTITATE_MINIMA, UNITATE 
                                   FROM Produse 
                                   WHERE ID = @ProductId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Afișează detaliile produsului în câmpurile de editare
                                NumeNou.Text = reader["NUME"].ToString();
                                CantitateNoua.Text = reader["CANTITATE"].ToString();
                                PretNou.Text = reader["PRET"].ToString();
                                CantitateMinimaNoua.Text = reader["CANTITATE_MINIMA"].ToString();
                                UnitateNoua.Text = reader["UNITATE"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea detaliilor produsului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eveniment: modificare produs
        private void ButonModifica_Click(object sender, EventArgs e)
        {
            if (Produs.SelectedItem == null)
            {
                MessageBox.Show("Selectați un produs pentru modificare.", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = (KeyValuePair<int, string>)Produs.SelectedItem;
            int productId = selectedProduct.Key;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Creează dinamically query-ul UPDATE
                    string updateQuery = "UPDATE Produse SET ";
                    bool hasUpdates = false;

                    // Verifică și adaugă fiecare câmp completat
                    if (!string.IsNullOrWhiteSpace(NumeNou.Text))
                    {
                        updateQuery += "NUME = @Nume, ";
                        hasUpdates = true;
                    }

                    if (!string.IsNullOrWhiteSpace(CantitateNoua.Text))
                    {
                        updateQuery += "CANTITATE = @Cantitate, ";
                        hasUpdates = true;
                    }

                    if (!string.IsNullOrWhiteSpace(PretNou.Text))
                    {
                        updateQuery += "PRET = @Pret, ";
                        hasUpdates = true;
                    }

                    if (!string.IsNullOrWhiteSpace(CantitateMinimaNoua.Text))
                    {
                        updateQuery += "CANTITATE_MINIMA = @CantitateMinima, ";
                        hasUpdates = true;
                    }

                    if (!string.IsNullOrWhiteSpace(UnitateNoua.Text))
                    {
                        updateQuery += "UNITATE = @Unitate, ";
                        hasUpdates = true;
                    }

                    if (!hasUpdates)
                    {
                        MessageBox.Show("Nu ați completat niciun câmp pentru modificare.", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Elimină ultima virgulă din query
                    updateQuery = updateQuery.Remove(updateQuery.Length - 2);
                    updateQuery += " WHERE ID = @ProductId";

                    // Execută update-ul cu parametrii
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(NumeNou.Text))
                            cmd.Parameters.AddWithValue("@Nume", NumeNou.Text.Trim());

                        if (!string.IsNullOrWhiteSpace(CantitateNoua.Text))
                            cmd.Parameters.AddWithValue("@Cantitate", Convert.ToInt32(CantitateNoua.Text));

                        if (!string.IsNullOrWhiteSpace(PretNou.Text))
                            cmd.Parameters.AddWithValue("@Pret", Convert.ToDecimal(PretNou.Text));

                        if (!string.IsNullOrWhiteSpace(CantitateMinimaNoua.Text))
                            cmd.Parameters.AddWithValue("@CantitateMinima", Convert.ToInt32(CantitateMinimaNoua.Text));

                        if (!string.IsNullOrWhiteSpace(UnitateNoua.Text))
                            cmd.Parameters.AddWithValue("@Unitate", UnitateNoua.Text.Trim());

                        cmd.Parameters.AddWithValue("@ProductId", productId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Produsul a fost modificat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reîncarcă produsele pentru categoria curentă
                            if (Categorie.SelectedIndex != -1)
                            {
                                Categorie_SelectedIndexChanged(null, null);
                            }
                            else
                            {
                                LoadAllProducts();
                            }

                            // Golește câmpurile de modificare
                            NumeNou.Text = "";
                            CantitateNoua.Text = "";
                            PretNou.Text = "";
                            CantitateMinimaNoua.Text = "";
                            UnitateNoua.Text = "";

                            // Resetează selecția
                            Produs.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la modificarea produsului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Setări pentru DataGridView (estetică și antete)
        private void ConfigureDataGridView()
        {
            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridViewProduse.EnableHeadersVisualStyles = false;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewProduse.RowHeadersVisible = false;
            dataGridViewProduse.BackgroundColor = Color.White;

            // Redenumește coloanele pentru o afișare clară
            dataGridViewProduse.Columns["ID"].Visible = false;
            dataGridViewProduse.Columns["NUME"].HeaderText = "Nume Produs";
            dataGridViewProduse.Columns["CANTITATE"].HeaderText = "Cantitate";
            dataGridViewProduse.Columns["PRET"].HeaderText = "Preț";
            dataGridViewProduse.Columns["CANTITATE_MINIMA"].HeaderText = "Stoc Minim";
            dataGridViewProduse.Columns["UNITATE"].HeaderText = "Unitate";
        }

        // Închide formularul curent
        private void Inapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
