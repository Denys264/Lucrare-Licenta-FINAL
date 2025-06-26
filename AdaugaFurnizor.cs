using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class AdaugaFurnizor : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public AdaugaFurnizor()
        {
            InitializeComponent();
        }

        private void AdaugaFurnizor_Load(object sender, EventArgs e)
        {
            // Dacă e nevoie de inițializări suplimentare la încărcare
        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButonAdauga_Click(object sender, EventArgs e)
        {
            string nume = NumeFurnizor.Text.Trim();
            string cui = CUIFurnizor.Text.Trim();
            string adresa = AdresaFurnizor.Text.Trim();
            string telefon = NumarTelefon.Text.Trim();

            // Validare câmpuri obligatorii
            if (string.IsNullOrWhiteSpace(nume) || string.IsNullOrWhiteSpace(cui) || string.IsNullOrWhiteSpace(adresa))
            {
                MessageBox.Show("Completați toate câmpurile obligatorii (Nume, CUI, Adresă)!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificare existență CUI
                    string checkQuery = "SELECT COUNT(*) FROM Furnizori WHERE CUI = @CUI";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@CUI", cui);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Acest CUI este deja înregistrat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Inserare furnizor nou
                    string insertQuery = @"
                        INSERT INTO Furnizori (CUI, NUME, ADRESA, NUMAR_TELEFON)
                        VALUES (@CUI, @NUME, @ADRESA, @TELEFON)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@CUI", cui);
                        insertCmd.Parameters.AddWithValue("@NUME", nume);
                        insertCmd.Parameters.AddWithValue("@ADRESA", adresa);
                        insertCmd.Parameters.AddWithValue("@TELEFON", string.IsNullOrWhiteSpace(telefon) ? DBNull.Value : telefon);

                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Furnizorul a fost adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Resetare câmpuri
                    NumeFurnizor.Clear();
                    CUIFurnizor.Clear();
                    AdresaFurnizor.Clear();
                    NumarTelefon.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea furnizorului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
