using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class AdaugaProdusGestiune : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public AdaugaProdusGestiune()
        {
            InitializeComponent();
        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButonAdauga_Click(object sender, EventArgs e)
        {
            string nume = NumeProdus.Text.Trim();
            string cantitateText = CantitateIncepere.Text.Trim();
            string pretText = PretProdus.Text.Trim();
            string cantMinimaText = CantitateMinima.Text.Trim();
            string unitate = Unitate.Text.Trim();

            // Validare câmpuri obligatorii
            if (string.IsNullOrWhiteSpace(nume) || string.IsNullOrWhiteSpace(cantitateText) ||
                string.IsNullOrWhiteSpace(pretText) || string.IsNullOrWhiteSpace(cantMinimaText) ||
                string.IsNullOrWhiteSpace(unitate))
            {
                MessageBox.Show("Completați toate câmpurile obligatorii!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validare numerică
            if (!int.TryParse(cantitateText, out int cantitate) || cantitate < 0)
            {
                MessageBox.Show("Cantitatea trebuie să fie un număr întreg pozitiv!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(pretText, out decimal pret) || pret < 0)
            {
                MessageBox.Show("Prețul trebuie să fie un număr valid și pozitiv!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(cantMinimaText, out int cantitateMinima) || cantitateMinima < 0)
            {
                MessageBox.Show("Cantitatea minimă trebuie să fie un număr întreg pozitiv!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificare existență produs
                    string checkQuery = "SELECT COUNT(*) FROM Produse WHERE NUME = @NUME";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@NUME", nume);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Există deja un produs cu acest nume!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Inserare produs nou
                    string insertQuery = @"
                        INSERT INTO Produse (NUME, CANTITATE, PRET, CANTITATE_MINIMA, UNITATE, AFISAT)
                        VALUES (@NUME, @CANTITATE, @PRET, @CANTITATE_MINIMA, @UNITATE, 0)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@NUME", nume);
                        insertCmd.Parameters.AddWithValue("@CANTITATE", cantitate);
                        insertCmd.Parameters.AddWithValue("@PRET", pret);
                        insertCmd.Parameters.AddWithValue("@CANTITATE_MINIMA", cantitateMinima);
                        insertCmd.Parameters.AddWithValue("@UNITATE", unitate);
                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Produsul a fost adăugat cu succes în gestiune!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Resetare câmpuri
                    NumeProdus.Clear();
                    CantitateIncepere.Clear();
                    PretProdus.Clear();
                    CantitateMinima.Clear();
                    Unitate.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea produsului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
