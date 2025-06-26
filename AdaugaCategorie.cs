using Microsoft.Data.SqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class AdaugaCategorie : Form
    {
        // Șirul de conexiune la baza de date
        private readonly string _sirConexiune =
            "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public AdaugaCategorie()
        {
            InitializeComponent();
        }

        private void ButonAdauga_Click(object sender, EventArgs e)
        {
            // Preluăm textul introdus și eliminăm spațiile inutile
            string numeCategorie = NumeCategorie.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeCategorie))
            {
                MessageBox.Show("Introduceți un nume pentru categorie!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Curățăm numele de caractere nepermise și îl convertim la lowercase
            string numeValid = Regex.Replace(numeCategorie.ToLower(), @"[^a-z0-9_]", "");

            if (string.IsNullOrWhiteSpace(numeValid))
            {
                MessageBox.Show("Numele categoriei este invalid după filtrare!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conexiune = new SqlConnection(_sirConexiune))
                {
                    conexiune.Open();

                    // Verificăm dacă tabela există deja în schema CATEGORII
                    string interogareVerificare = @"
                        SELECT COUNT(*) 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_SCHEMA = 'CATEGORII' AND LOWER(TABLE_NAME) = @NumeTabela";

                    using (SqlCommand cmdVerificare = new SqlCommand(interogareVerificare, conexiune))
                    {
                        cmdVerificare.Parameters.AddWithValue("@NumeTabela", numeValid);
                        int existaTabela = (int)cmdVerificare.ExecuteScalar();

                        if (existaTabela > 0)
                        {
                            MessageBox.Show("O categorie cu acest nume există deja!", "Categorie duplicată", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Creăm tabela pentru categoria nouă în schema CATEGORII
                    string queryCreareTabela = $@"
                        CREATE TABLE CATEGORII.[{numeValid}] (
                            ID INT IDENTITY(1,1) PRIMARY KEY,
                            ID_Produs INT NOT NULL,
                            FOREIGN KEY (ID_Produs) REFERENCES dbo.Produse(ID)
                        );

                        CREATE INDEX IDX_{numeValid}_ID ON CATEGORII.[{numeValid}] (ID);
                    ";

                    using (SqlCommand cmdCreare = new SqlCommand(queryCreareTabela, conexiune))
                    {
                        cmdCreare.ExecuteNonQuery();
                    }

                    MessageBox.Show("Categoria a fost creată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NumeCategorie.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la crearea categoriei: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
