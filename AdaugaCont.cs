using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class AdaugaCont : Form
    {
         SqlConnection connectionString = new SqlConnection("Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Trust Server Certificate=True");
        public AdaugaCont()
        {
            InitializeComponent();
        }

        private void Inapoi_Click_1(object sender, EventArgs e)
        {
            
            this.Close();


        }

        private void AdaugaUnCont_Click(object sender, EventArgs e)
        {
            string nume = NumeUtilizator.Text.Trim();
            string parola = NumeParola.Text;

            if (string.IsNullOrWhiteSpace(nume) || string.IsNullOrWhiteSpace(parola))
            {
                MessageBox.Show("Completează toate câmpurile!");
            }
            else
            {
                string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;TrustServerCertificate=True;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificăm dacă utilizatorul există
                    string sqlVerificare = "SELECT 1 FROM Conturi WHERE NUME_UTILIZATOR = @nume";
                    using (SqlCommand cmdVerificare = new SqlCommand(sqlVerificare, conn))
                    {
                        cmdVerificare.Parameters.AddWithValue("@nume", nume);
                        var exista = cmdVerificare.ExecuteScalar();

                        if (exista != null)
                        {
                            MessageBox.Show("Numele de utilizator există deja!");
                        }
                        else
                        {
                            // Inserăm contul dacă nu există deja
                            string sqlInsert = "INSERT INTO Conturi (NUME_UTILIZATOR, PAROLA) VALUES (@nume, @parola)";
                            using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
                            {
                                cmdInsert.Parameters.AddWithValue("@nume", nume);
                                cmdInsert.Parameters.AddWithValue("@parola", parola);

                                int rezultat = cmdInsert.ExecuteNonQuery();

                                if (rezultat > 0)
                                    MessageBox.Show("Cont adăugat cu succes!");
                                else
                                    MessageBox.Show("Eroare la adăugarea contului.");
                            }
                        }
                    }
                }
            }

        }

        private void AdaugaCont_Load(object sender, EventArgs e)
        {
           

        }
    }
}
