using Microsoft.Data.SqlClient;


namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class PaginaLogin : Form
    { public static string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Trust Server Certificate=True";
        
        public PaginaLogin()
        {
            InitializeComponent();
        }

        private void PaginaLogin_Load(object sender, EventArgs e)
        {
           
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Logare_Click(object sender, EventArgs e)
        {
            string username = NumeUtilizator.Text.Trim();
            string parola = Parola.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(parola))
            {
                MessageBox.Show("Introduceți numele de utilizator și parola!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (username == "Admin" && parola == "raluelebar")
            {
                MeniuAdministrator f1 = new MeniuAdministrator();
                f1.Show();
                this.Hide();
                return;

            }           
            

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string query = "SELECT COUNT(*) FROM Conturi WHERE NUME_UTILIZATOR = @user AND PAROLA = @pass";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", parola);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // Autentificare reușită
                           MeniuBarman f1 = new MeniuBarman(username);  
                        f1.Show();
                        this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nume utilizator sau parolă incorectă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la conectarea cu baza de date:\n" + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

    }
}
