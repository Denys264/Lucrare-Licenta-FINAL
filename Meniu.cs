using iText.Layout.Element;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class Meniu : Form
    {
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private readonly Color _culoareFundal = Color.FromArgb(32, 32, 32);
        private readonly Color _culoarePrimara = Color.FromArgb(70, 130, 180);
        private readonly Color _culoareSecundara = Color.FromArgb(50, 50, 50);
        private readonly System.Drawing.Font _fontTitlu = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold);
        private readonly System.Drawing.Font _fontText = new System.Drawing.Font("Segoe UI", 10);
        private readonly System.Drawing.Font _fontCantitate = new System.Drawing.Font("Segoe UI", 9);
        private string cantitateCurenta = "1";
        private string NumeTabela;
        private string numecasier;
        private int verificare;

        public Meniu(string nume, string casier, int verificat)
        {   verificare = verificat;
            numecasier = casier;
            NumeTabela = nume;
            InitializeComponent();
            ConfigureazaInterfata();
            ConfigureazaDataGridView();
            IncarcaCategorii();
            LeagaEvenimenteButonCantitate();
            IncarcaProduseInDataGridView(dataGridViewProduse);
            Cant.Text = "1";
        }

        private void ConfigureazaInterfata()
        {
            this.Text = "RAULE CAFE BAR - Meniu Digital";
            this.BackColor = _culoareFundal;
            this.ForeColor = Color.White;
            this.DoubleBuffered = true;

            PanouCategorii.BackColor = _culoareSecundara;
            PanouCategorii.BorderStyle = BorderStyle.FixedSingle;
            PanouCategorii.AutoScroll = true;

            PanouProduse.BackColor = _culoareFundal;
            PanouProduse.AutoScroll = true;
            PanouProduse.Padding = new Padding(10);

            this.Resize += (s, e) => ActualizeazaLayout();
        }

        private void ConfigureazaDataGridView()
        {
            dataGridViewProduse.BackgroundColor = Color.White;
            dataGridViewProduse.BorderStyle = BorderStyle.None;
            dataGridViewProduse.GridColor = Color.FromArgb(230, 230, 230);
            dataGridViewProduse.Dock = DockStyle.Fill;

            dataGridViewProduse.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewProduse.ColumnHeadersHeight = 35;
            dataGridViewProduse.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dataGridViewProduse.DefaultCellStyle.BackColor = Color.White;
            dataGridViewProduse.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewProduse.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
            dataGridViewProduse.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dataGridViewProduse.Columns.Add("Nume", "NUME PRODUS");
            dataGridViewProduse.Columns.Add("Cantitate", "CANTITATE");
            dataGridViewProduse.Columns.Add("Pret", "PREȚ (RON)");

            dataGridViewProduse.Columns["Nume"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewProduse.Columns["Cantitate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewProduse.Columns["Pret"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewProduse.Columns["Nume"].FillWeight = 45;
            dataGridViewProduse.Columns["Cantitate"].FillWeight = 30;
            dataGridViewProduse.Columns["Pret"].FillWeight = 25;

            dataGridViewProduse.Columns["Nume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduse.Columns["Cantitate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProduse.Columns["Pret"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewProduse.Columns["Pret"].DefaultCellStyle.Format = "0.00";

            dataGridViewProduse.AllowUserToAddRows = false;
            dataGridViewProduse.ReadOnly = true;
            dataGridViewProduse.RowHeadersVisible = false;
            dataGridViewProduse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProduse.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewProduse.Height = dataGridViewProduse.Parent.Height;

            foreach (DataGridViewColumn column in dataGridViewProduse.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void IesireForm()
        {   if (numecasier == "Admin")
            {
                MeniuAdministrator f1 = new MeniuAdministrator(verificare);
                f1.Show();
                this.Hide();
            }
            else
            {
                MeniuBarman f1 = new MeniuBarman(numecasier, verificare);
                    f1.Show();
                this.Hide();
            }
        }

        private void TrimiteresiIesire()

        {
            // Verificare DataGridView
            bool toateNegativeInGrid = true;
            foreach (DataGridViewRow row in dataGridViewProduse.Rows)
            {
                if (row.Cells["Cantitate"].Value != null)
                {
                    int cantitate;
                    if (int.TryParse(row.Cells["Cantitate"].Value.ToString(), out cantitate))
                    {
                        if (cantitate >= 0)
                        {
                            toateNegativeInGrid = false;
                            break;
                        }
                    }
                }
            }
            if (toateNegativeInGrid == true)
            {
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
                {
                    conn.Open();

                    MessageBox.Show("Toate Produsele sunt returnate asa ca se va anula masa");
                    dataGridViewProduse.Rows.Clear();
                    // Șterge toate rândurile
                    string deleteQuery = $"DELETE FROM COMENZI.{NumeTabela}";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Resetează ID-ul/autoincrementul (presupunând că tabela are identity)
                    string reseedQuery = $"DBCC CHECKIDENT ('COMENZI.{NumeTabela}', RESEED, 0)";
                    using (SqlCommand reseedCmd = new SqlCommand(reseedQuery, conn))
                    {
                        reseedCmd.ExecuteNonQuery();
                    }
                }
                
                
            }

            else if (dataGridViewProduse.Rows.Count == 0)
            {
                MessageBox.Show("Nu există produse în listă.");
                return;
            }

            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
            {
                try
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridViewProduse.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string nume = row.Cells["Nume"].Value?.ToString();
                        int cantitate = Convert.ToInt32(row.Cells["Cantitate"].Value);
                        decimal pret = Convert.ToDecimal(row.Cells["Pret"].Value);

                        Color culoare = row.DefaultCellStyle.ForeColor;

                        if (culoare == Color.Blue)
                        {
                            string insertQuery = $@"
                                INSERT INTO COMENZI.{NumeTabela} (NUME, CANTITATE, PRET)
                                VALUES (@nume, @cantitate, @pret)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@nume", nume);
                                insertCmd.Parameters.AddWithValue("@cantitate", cantitate);
                                insertCmd.Parameters.AddWithValue("@pret", pret);
                                insertCmd.ExecuteNonQuery();
                            }

                            
                        }
                        else if (culoare == Color.Red)
                        {
                            string deleteInverseQuery = $@"
                                DELETE TOP (1) FROM COMENZI.{NumeTabela}
                                WHERE NUME = @nume AND CANTITATE = @cantitatePoz";
                            using (SqlCommand deleteInvCmd = new SqlCommand(deleteInverseQuery, conn))
                            {
                                deleteInvCmd.Parameters.AddWithValue("@nume", nume);
                                deleteInvCmd.Parameters.AddWithValue("@cantitatePoz", -cantitate);
                                deleteInvCmd.ExecuteNonQuery();
                            }

                            string insertQuery = $@"
                                INSERT INTO COMENZI.{NumeTabela} (NUME, CANTITATE, PRET)
                                VALUES (@nume, @cantitate, @pret)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@nume", nume);
                                insertCmd.Parameters.AddWithValue("@cantitate", cantitate);
                                insertCmd.Parameters.AddWithValue("@pret", pret);
                                insertCmd.ExecuteNonQuery();
                            }

                            string updateStocQuery = @"
                                UPDATE Produse
                                SET Cantitate = Cantitate + @cantitate
                                WHERE Nume = @nume";
                            using (SqlCommand updateCmd = new SqlCommand(updateStocQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@nume", nume);
                                updateCmd.Parameters.AddWithValue("@cantitate", Math.Abs(cantitate));
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la trimiterea produselor: " + ex.Message);
                }
            }
        }
        // Variabilă membru în formular:
        private Button btnCategorieSelectata;

        // Încarcă toate categoriile
        private void IncarcaCategorii()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT name FROM sys.tables WHERE schema_id = SCHEMA_ID('CATEGORII') ORDER BY name";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AdaugaButonCategorie(reader["name"].ToString());
                    }
                }
            }
        }

        // Adaugă un buton pentru fiecare categorie
        private void AdaugaButonCategorie(string numeTabela)
        {
            var btn = new Button
            {
                Text = FormatareText(numeTabela),
                Height = 50,
                Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                Font = _fontTitlu,
                ForeColor = Color.White,
                BackColor = _culoareSecundara,
                Tag = numeTabela,
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btn.FlatAppearance.MouseDownBackColor = _culoarePrimara;

            btn.Click += (s, e) =>
            {
                btnCategorieSelectata = btn; // Salvează categoria curentă
                IncarcaProdusePentruCategorie(numeTabela);
            };

            PanouCategorii.Controls.Add(btn);
        }

        // Încarcă produsele pentru o categorie
        private void IncarcaProdusePentruCategorie(string numeCategorie)
        {
            PanouProduse.SuspendLayout();
            PanouProduse.Controls.Clear();

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = $@"SELECT p.NUME, p.PRET, p.UNITATE, p.CANTITATE FROM PRODUSE p 
                          INNER JOIN CATEGORII.[{numeCategorie}] c ON p.ID = c.ID_Produs 
                          WHERE p.AFISAT = 1 ORDER BY p.NUME";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    int top = 0;
                    while (reader.Read())
                    {
                        AdaugaCardProdus(reader["NUME"].ToString(),
                                         Convert.ToDecimal(reader["PRET"]),
                                         reader["UNITATE"].ToString(),
                                         Convert.ToDecimal(reader["CANTITATE"]),
                                         ref top);
                    }
                }
            }

            PanouProduse.ResumeLayout();
        }

        // Adaugă card vizual pentru un produs
        private void AdaugaCardProdus(string nume, decimal pretUnitar, string unitate, decimal cantitateDisponibila, ref int topPosition)
        {
            var card = new Panel
            {
                BackColor = _culoareSecundara,
                Size = new Size(PanouProduse.ClientSize.Width - 25, 90),
                Location = new Point(0, topPosition),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand
            };

            var lblNume = new Label
            {
                Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nume.ToLower()),
                Font = _fontTitlu,
                ForeColor = Color.White,
                Location = new Point(15, 15),
                AutoSize = true
            };

            var lblPret = new Label
            {
                Text = $"{pretUnitar:0.00} RON/{unitate}",
                Font = _fontText,
                ForeColor = _culoarePrimara,
                Location = new Point(15, 40),
                AutoSize = true
            };

            var lblCant = new Label
            {
                Text = $"Disponibil: {cantitateDisponibila} {unitate}",
                Font = _fontCantitate,
                ForeColor = Color.FromArgb(180, 180, 180),
                Location = new Point(15, 62),
                AutoSize = true
            };

            var linie = new Panel
            {
                BackColor = _culoarePrimara,
                Size = new Size(50, 2),
                Location = new Point(15, 35)
            };

            card.Controls.Add(lblNume);
            card.Controls.Add(lblPret);
            card.Controls.Add(lblCant);
            card.Controls.Add(linie);

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(60, 60, 60);
            card.MouseLeave += (s, e) => card.BackColor = _culoareSecundara;

            card.Click += (s, e) =>
            {
                int cantitate = int.TryParse(Cant.Text, out int val) ? val : 1;
                decimal total = cantitate * pretUnitar;

                if (cantitate == 0)
                {
                    MessageBox.Show("Cantitate invalidă!");
                }
                else if (cantitateDisponibila < cantitate)
                {
                    MessageBox.Show("Stocul este prea mic pentru această comandă!");
                }
                else
                {
                    // 1. Adăugare în DataGridView
                    int rowIndex = dataGridViewProduse.Rows.Add(nume, cantitate.ToString(), total.ToString("0.00"));
                    dataGridViewProduse.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Blue;

                    // 2. Scădere stoc în baza de date
                    using (var conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string updateQuery = @"UPDATE PRODUSE SET CANTITATE = CANTITATE - @cantitate WHERE NUME = @nume";
                        using (var cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@cantitate", cantitate);
                            cmd.Parameters.AddWithValue("@nume", nume);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 3. Reîncarcă produsele pentru categoria curentă
                    if (btnCategorieSelectata != null)
                        IncarcaProdusePentruCategorie((string)btnCategorieSelectata.Tag);
                }

                dataGridViewProduse.ClearSelection();
                cantitateCurenta = "1";
                Cant.Text = "1";
                CalculeazaTotal();
            };

            PanouProduse.Controls.Add(card);
            topPosition += card.Height + 15;
        }

        // Ajustează layout-ul cardurilor
        private void ActualizeazaLayout()
        {
            foreach (Control c in PanouProduse.Controls)
            {
                if (c is Panel panel)
                    panel.Width = PanouProduse.ClientSize.Width - 25;
            }
        }

        private string FormatareText(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.Replace("_", " ").ToLower());
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            cantitateCurenta = "1";
            Cant.Text = "1";
        }

        private void Buton_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            if (clicked == null) return;

            string cifra = clicked.Text;

            if (cantitateCurenta == "1" && Cant.Text == "1")
                cantitateCurenta = cifra;
            else
                cantitateCurenta += cifra;

            if (int.TryParse(cantitateCurenta, out int val))
            {
                if (val > 999)
                {
                    val = 999;
                    cantitateCurenta = "999";
                }
                Cant.Text = val.ToString();
            }
            else
            {
                cantitateCurenta = "1";
                Cant.Text = "1";
            }
        }

        private void LeagaEvenimenteButonCantitate()
        {
            Buton0.Click += Buton_Click;
            Buton1.Click += Buton_Click;
            Buton2.Click += Buton_Click;
            Buton3.Click += Buton_Click;
            Buton4.Click += Buton_Click;
            Buton5.Click += Buton_Click;
            Buton6.Click += Buton_Click;
            Buton7.Click += Buton_Click;
            Buton8.Click += Buton_Click;
            Buton9.Click += Buton_Click;
        }

        private decimal CalculeazaTotalSilent()
        {
            decimal suma = 0;
            foreach (DataGridViewRow row in dataGridViewProduse.Rows)
            {
                if (decimal.TryParse(row.Cells["Pret"].Value?.ToString(), out decimal valoare))
                {
                    suma += valoare;
                }
            }
            return suma;
        }

        private void CalculeazaTotal()
        {
            decimal suma = CalculeazaTotalSilent();
            TotalPret.Text = $"Total: {suma:0.00} RON";
        }

        private void Sterge_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduse.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectează un produs pentru a-l șterge.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow randSelectat = dataGridViewProduse.SelectedRows[0];

            if (randSelectat.DefaultCellStyle.ForeColor == Color.Blue)
            {
                dataGridViewProduse.Rows.Remove(randSelectat);
                CalculeazaTotal();
                return;
            }

            string nume = randSelectat.Cells["Nume"].Value?.ToString();
            string cantitateText = randSelectat.Cells["Cantitate"].Value?.ToString();
            string pretText = randSelectat.Cells["Pret"].Value?.ToString();

            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(cantitateText) || string.IsNullOrEmpty(pretText))
            {
                MessageBox.Show("Date incomplete în rândul selectat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cantitateText.StartsWith("-") || pretText.StartsWith("-"))
            {
                MessageBox.Show("Nu poți șterge un produs care a fost deja returnat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(cantitateText, out int cantitate) || !decimal.TryParse(pretText, out decimal pret))
            {
                MessageBox.Show("Cantitatea sau prețul nu sunt valide.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalCurent = CalculeazaTotalSilent();
            if (totalCurent - pret < 0)
            {
                MessageBox.Show("Nu poți avea un total negativ!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridViewProduse.Rows.Add(nume, $"-{cantitate}", $"0.00");
            DataGridViewRow randNou = dataGridViewProduse.Rows[dataGridViewProduse.Rows.Count - 1];
            randNou.DefaultCellStyle.ForeColor = Color.Red;
            randNou.DefaultCellStyle.Font = new System.Drawing.Font(dataGridViewProduse.DefaultCellStyle.Font, FontStyle.Italic);

            dataGridViewProduse.Rows.Remove(randSelectat);
            dataGridViewProduse.ClearSelection();
            CalculeazaTotal();
        }

        private void Iesire_Click(object sender, EventArgs e)
        {
            IesireForm();
        }

        public void IncarcaProduseInDataGridView(DataGridView dataGridViewProduse)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            try
            {
                dataGridViewProduse.Rows.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT NUME, CANTITATE, PRET FROM [COMENZI].[{NumeTabela}]";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nume = reader["NUME"].ToString();
                            string cantitate = reader["CANTITATE"].ToString();
                            string pret = reader["PRET"].ToString();

                            dataGridViewProduse.Rows.Add(nume, cantitate, pret);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea produselor: " + ex.Message);
            }
            dataGridViewProduse.ClearSelection();
            CalculeazaTotal();
        }

        private void TrimitereIesire_Click(object sender, EventArgs e)
        {
            TrimiteresiIesire();
            IesireForm();
            
        }

        private void NotaPlata_Click(object sender, EventArgs e)

        {
            TrimiteresiIesire();
            
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
            {
                try
                {
                    conn.Open();

                    // Preiau datele din COMENZI.{NumeTabela} și le stochez în listă
                    string query = $@"
                SELECT NUME, SUM(CANTITATE) AS TotalCantitate, SUM(PRET) AS PretUnitar
                FROM COMENZI.{NumeTabela}
                WHERE CANTITATE > 0
                GROUP BY NUME";

                    var produse = new List<(string nume, int cantitate, decimal pretUnitar)>();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nume = reader.GetString(0);
                            int cantitate = reader.GetInt32(1);
                            decimal pretUnitar = reader.GetDecimal(2);
                            produse.Add((nume, cantitate, pretUnitar));
                        }
                    }

                    //  Actualizez tabelele RAPOARTE pe baza listei
                    string[] tabeleRapoarte = new string[]
                    {
                "RAPOARTE.NotaPlata",
                "RAPOARTE.ZilnicTotal",
                "RAPOARTE.SaptamanaTotal",
                "RAPOARTE.LunarTotal",
                "RAPOARTE.TotalGeneral"
                    };

                    foreach (var prod in produse)
                    {
                        string nume = prod.nume;
                        int cantitate = prod.cantitate;
                        decimal pretUnitar = prod.pretUnitar;
                        decimal pretTotal = pretUnitar;

                        foreach (var tabela in tabeleRapoarte)
                        {
                            string checkQuery = $@"SELECT COUNT(*) FROM {tabela} WHERE NUME = @nume";
                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@nume", nume);
                                int exists = (int)checkCmd.ExecuteScalar();

                                if (exists > 0)
                                {
                                    string updateQuery = $@"
                                UPDATE {tabela}
                                SET CANTITATE = CANTITATE + @cantitate,
                                    PRET = PRET + @pretTotal
                                WHERE NUME = @nume";

                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@nume", nume);
                                        updateCmd.Parameters.AddWithValue("@cantitate", cantitate);
                                        updateCmd.Parameters.AddWithValue("@pretTotal", pretTotal);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    string insertQuery = $@"
                                INSERT INTO {tabela} (NUME, CANTITATE, PRET)
                                VALUES (@nume, @cantitate, @pretTotal)";

                                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                                    {
                                        insertCmd.Parameters.AddWithValue("@nume", nume);
                                        insertCmd.Parameters.AddWithValue("@cantitate", cantitate);
                                        insertCmd.Parameters.AddWithValue("@pretTotal", pretTotal);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    // Generez PDF cu RAPOARTE.NotaPlata

                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string folderPath = Path.Combine(desktopPath, "Rapoarte", "Note de plata");
                    Directory.CreateDirectory(folderPath);

                    int nrNota = Directory.GetFiles(folderPath, "Nota plata *.pdf").Length + 1;
                    DateTime azi = DateTime.Now;
                    string dataAzi = azi.ToString("dd.MM.yyyy");
                    string oraAzi = azi.ToString("HH:mm:ss");
                    string fileName = $"Nota plata nr {nrNota} din data de {dataAzi}.pdf";
                    string filePath = Path.Combine(folderPath, fileName);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    using (Document doc = new Document(PageSize.A4, 40, 40, 50, 40))
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.Open();

                        // Fonts
                        var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.BLACK);
                        var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                        var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                        var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
                        var footerFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.DARK_GRAY);

                        // Titlu centrat, cu underline
                        iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("NOTA DE PLATA", titleFont);

                        title.Alignment = Element.ALIGN_CENTER;
                        doc.Add(title);

                        // Linie subtitlu
                        var line = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, iTextSharp.text.BaseColor.DARK_GRAY, Element.ALIGN_CENTER, -2);

                        doc.Add(new Chunk(line));

                        // Spacer mic
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        // Info data, ora, casier pe o linie, cu spatii între ele (folosim un PdfPTable cu 3 coloane)
                        PdfPTable infoTable = new PdfPTable(3);
                        infoTable.WidthPercentage = 100;
                        infoTable.SetWidths(new float[] { 33f, 34f, 33f });

                        PdfPCell dataCell = new PdfPCell(new Phrase("Data: " + dataAzi, normalFont));
                        dataCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        dataCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        infoTable.AddCell(dataCell);

                        PdfPCell oraCell = new PdfPCell(new Phrase("Ora: " + oraAzi, normalFont));
                        oraCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        oraCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        infoTable.AddCell(oraCell);

                        
                        PdfPCell casierCell = new PdfPCell(new Phrase("Casier: " + numecasier, normalFont));
                        casierCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        casierCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        infoTable.AddCell(casierCell);

                        doc.Add(infoTable);

                        // Spacer
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        // Tabel cu produse
                        PdfPTable table = new PdfPTable(3);
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 60f, 20f, 20f });

                        // Header cu fundal colorat
                        BaseColor headerBackground = new BaseColor(0, 102, 204); // albastru
                        PdfPCell cellProdus = new PdfPCell(new Phrase("Produs", headerFont));
                        cellProdus.BackgroundColor = headerBackground;
                        cellProdus.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellProdus.Padding = 5;
                        table.AddCell(cellProdus);

                        PdfPCell cellCantitate = new PdfPCell(new Phrase("Cantitate", headerFont));
                        cellCantitate.BackgroundColor = headerBackground;
                        cellCantitate.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellCantitate.Padding = 5;
                        table.AddCell(cellCantitate);

                        PdfPCell cellPretTotal = new PdfPCell(new Phrase("Preț total", headerFont));
                        cellPretTotal.BackgroundColor = headerBackground;
                        cellPretTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellPretTotal.Padding = 5;
                        table.AddCell(cellPretTotal);

                        decimal subtotal = 0;

                        string selectQuery = "SELECT NUME, CANTITATE, PRET FROM RAPOARTE.NotaPlata";
                        using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nume = reader.GetString(0);
                                int cantitate = reader.GetInt32(1);
                                decimal pret = reader.GetDecimal(2);
                                subtotal += pret;

                                PdfPCell produsCell = new PdfPCell(new Phrase(nume, normalFont));
                                produsCell.Padding = 5;
                                produsCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(produsCell);

                                PdfPCell cantitateCell = new PdfPCell(new Phrase(cantitate.ToString(), normalFont));
                                cantitateCell.Padding = 5;
                                cantitateCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cantitateCell);

                                PdfPCell pretCell = new PdfPCell(new Phrase(pret.ToString("0.00") + " lei", normalFont));
                                pretCell.Padding = 5;
                                pretCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                table.AddCell(pretCell);
                            }
                        }

                        // Linie subtotal (dublu bold, mai mare)
                        PdfPCell subtotalCell = new PdfPCell(new Phrase("Subtotal", boldFont));
                        subtotalCell.Colspan = 2;
                        subtotalCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        subtotalCell.Padding = 7;
                        table.AddCell(subtotalCell);

                        PdfPCell subtotalValCell = new PdfPCell(new Phrase(subtotal.ToString("0.00") + " lei", boldFont));
                        subtotalValCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        subtotalValCell.Padding = 7;
                        table.AddCell(subtotalValCell);

                        doc.Add(table);

                        // Spacer
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        // Footer mulțumire centrat și gri închis
                        iTextSharp.text.Paragraph footer = new iTextSharp.text.Paragraph("Va multumim si va mai asteptam!", footerFont);
                        footer.Alignment = Element.ALIGN_CENTER;
                        doc.Add(footer);

                        doc.Close();
                    }

                    MessageBox.Show("Nota de plată a fost salvată, rapoartele actualizate și PDF-ul generat cu succes!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la salvarea notei de plată: " + ex.Message);
                }
            }
            string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                

                
                
                    // Șterge toate rândurile
                    string deleteQuery = $"DELETE FROM COMENZI.{NumeTabela}";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Resetează ID-ul/autoincrementul 
                    string reseedQuery = $"DBCC CHECKIDENT ('COMENZI.{NumeTabela}', RESEED, 0)";
                    using (SqlCommand reseedCmd = new SqlCommand(reseedQuery, conn))
                    {
                        reseedCmd.ExecuteNonQuery();
                    }
                // Șterge toate rândurile
                string deleteQuery1 = $"DELETE FROM RAPOARTE.NotaPlata";
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery1, conn))
                {
                    deleteCmd.ExecuteNonQuery();
                }

                // Resetează ID-ul/autoincrementul 
                string reseedQuery1 = $"DBCC CHECKIDENT ('RAPOARTE.NotaPlata', RESEED, 0)";
                using (SqlCommand reseedCmd = new SqlCommand(reseedQuery1, conn))
                {
                    reseedCmd.ExecuteNonQuery();
                }

            }
            IesireForm();
        }

        
    }

}