using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class NotaIntrare : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public NotaIntrare()
        {
            InitializeComponent();
            this.Load += NotaIntrare_Load;
            Categorie.SelectedIndexChanged += Categorie_SelectedIndexChanged;
            Adauga.Click += Adauga_Click;
            Salveaza.Click += Salveaza_Click;
        }

        private void NotaIntrare_Load(object sender, EventArgs e)
        {
            UmpleFurnizori();
            UmpleCategorii();
            ConfigurareDataGridView();
        }

        private void ConfigurareDataGridView()
        {
            dataGridViewProduse.Columns.Clear();
            dataGridViewProduse.Columns.Add("Produs", "Produs");
            dataGridViewProduse.Columns.Add("Cantitate", "Cantitate");
            dataGridViewProduse.Columns.Add("PretTotal", "Preț Total");
            dataGridViewProduse.Columns.Add("Furnizor", "Furnizor");
            dataGridViewProduse.Columns.Add("CUI", "CUI");

            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridViewProduse.EnableHeadersVisualStyles = false;
            dataGridViewProduse.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewProduse.RowHeadersVisible = false;
            dataGridViewProduse.BackgroundColor = Color.White;
            dataGridViewProduse.ReadOnly = true;
        }

        private void UmpleFurnizori()
        {
            Furnizor.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT NUME FROM dbo.Furnizori", conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Furnizor.Items.Add(reader["NUME"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea furnizorilor: {ex.Message}");
            }
        }

        private void UmpleCategorii()
        {
            Categorie.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'CATEGORII'", conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categorie.Items.Add(reader["TABLE_NAME"].ToString());
                        }
                    }

                    Categorie.Items.Add("Neafisate"); // produse care nu apar pe ecran, dar pot fi adăugate
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea categoriilor: {ex.Message}");
            }
        }

        private void Categorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produs.Items.Clear();
            string categorieAleasa = Categorie.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(categorieAleasa))
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Dacă e "Neafisate", luăm produsele neafisate din tabelul principal
                    SqlCommand cmd = (categorieAleasa == "Neafisate") ?
                        new SqlCommand("SELECT NUME FROM dbo.Produse WHERE AFISAT = 0", conn) :
                        new SqlCommand($"SELECT P.NUME FROM CATEGORII.[{categorieAleasa}] C INNER JOIN dbo.Produse P ON C.ID_Produs = P.ID", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produs.Items.Add(reader["NUME"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea produselor: {ex.Message}");
            }
        }

        private void Adauga_Click(object sender, EventArgs e)
        {
            if (Produs.SelectedItem == null || string.IsNullOrWhiteSpace(Cantitate.Text))
            {
                MessageBox.Show("Selectează un produs și introdu o cantitate validă.");
                return;
            }

            if (!int.TryParse(Cantitate.Text, out int cantitateIntrodusa) || cantitateIntrodusa <= 0)
            {
                MessageBox.Show("Cantitatea trebuie să fie un număr natural pozitiv.");
                return;
            }

            string numeProdus = Produs.SelectedItem.ToString();
            string numeFurnizor = Furnizor.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(numeFurnizor))
            {
                MessageBox.Show("Selectează un furnizor.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdProdus = new SqlCommand("SELECT ID, UNITATE, PRET, CANTITATE FROM dbo.Produse WHERE NUME = @nume", conn))
                    {
                        cmdProdus.Parameters.AddWithValue("@nume", numeProdus);
                        using (SqlDataReader reader = cmdProdus.ExecuteReader())
                        {
                            if (!reader.Read()) return;

                            string unitate = reader["UNITATE"].ToString();
                            decimal pret = Convert.ToDecimal(reader["PRET"]);

                            // Ajustăm cantitatea pentru "50ml"
                            int cantitateFinala = cantitateIntrodusa;
                            if (unitate == "50ml")
                            {   if ( cantitateIntrodusa%50==0)
                                cantitateFinala = (int)Math.Ceiling(cantitateIntrodusa / 50.0);
                                else
                                {
                                    MessageBox.Show("Cantiatea pentru acest produs trebuie sa fie un multiplu de 50!");
                                    return;
                                }
                            }

                            decimal pretTotal = pret * cantitateFinala;

                            reader.Close();

                            using (SqlCommand cmdFurnizor = new SqlCommand("SELECT CUI FROM dbo.Furnizori WHERE NUME = @nume", conn))
                            {
                                cmdFurnizor.Parameters.AddWithValue("@nume", numeFurnizor);
                                string cui = cmdFurnizor.ExecuteScalar()?.ToString() ?? "N/A";

                                dataGridViewProduse.Rows.Add(numeProdus, cantitateFinala, pretTotal.ToString("0.00"), numeFurnizor, cui);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea produsului: {ex.Message}");
            }
        }


        private void Salveaza_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduse.Rows.Count == 0 || dataGridViewProduse.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Nu există produse de salvat în notă.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridViewProduse.Rows)
                    {
                        if (row.IsNewRow || row.Cells[0].Value == null) continue;

                        string numeProdus = row.Cells["Produs"].Value?.ToString();
                        string cantitateStr = row.Cells["Cantitate"].Value?.ToString();

                        if (!string.IsNullOrEmpty(numeProdus) && int.TryParse(cantitateStr, out int cantitate))
                        {
                            // Actualizăm stocul în DB
                            using (SqlCommand cmdUpdate = new SqlCommand(
                                "UPDATE dbo.Produse SET CANTITATE = CANTITATE + @cantitate WHERE NUME = @nume", conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@nume", numeProdus);
                                cmdUpdate.Parameters.AddWithValue("@cantitate", cantitate);
                                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show($"Produsul {numeProdus} nu a fost găsit în baza de date!", "Atenție",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }

                GenereazaPDF(); // Generăm PDF-ul notei de intrare

                dataGridViewProduse.Rows.Clear();
                Produs.SelectedIndex = -1;
                Furnizor.SelectedIndex = -1;
                Cantitate.Text = string.Empty;

                MessageBox.Show("Cantități actualizate și nota generată cu succes!", "Succes",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea cantităților: {ex.Message}", "Eroare",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenereazaPDF()
        {
            try
            {
                // Calea către folderul Desktop al utilizatorului
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string folderNote = Path.Combine(desktopPath, "Rapoarte", "Note de Intrare");

                // Asigură-te că folderele există
                Directory.CreateDirectory(folderNote);

                int nrNota = Directory.GetFiles(folderNote, "Nota intrare *.pdf").Length + 1;
                string numeFisier = $"Nota intrare {nrNota:000} din {DateTime.Today:dd.MM.yyyy}.pdf";
                string caleCompleta = Path.Combine(folderNote, numeFisier);

                using (PdfDocument document = new PdfDocument())
                {
                    document.Info.Title = "Notă de Intrare";
                    PdfPage page = document.AddPage();
                    page.Size = PdfSharp.PageSize.A4;
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Fonturi și culori
                    XFont fontHeader = new XFont("Arial", 16, XFontStyle.Bold);
                    XFont fontSubheader = new XFont("Arial", 10, XFontStyle.Bold);
                    XFont fontNormal = new XFont("Arial", 9);
                    XFont fontBold = new XFont("Arial", 9, XFontStyle.Bold);
                    XColor colorHeader = XColor.FromArgb(0, 70, 130);

                    // Antet firmă
                    gfx.DrawString("S.C. RALUELE CAFEGAMES S.R.L.", fontHeader, new XSolidBrush(colorHeader),
                                new XRect(0, 30, page.Width, 30), XStringFormats.TopCenter);

                    // Titlu document
                    gfx.DrawString("NOTĂ DE INTRARE / RECEPTIE", fontSubheader, XBrushes.Black,
                                new XRect(0, 80, page.Width, 20), XStringFormats.TopCenter);

                    // Informații document
                    double y = 110;
                    gfx.DrawString($"Nr. document: NIR{nrNota:0000}", fontBold, XBrushes.Black, 50, y);
                    gfx.DrawString($"Data: {DateTime.Today:dd.MM.yyyy}", fontBold, XBrushes.Black, page.Width - 150, y);
                    y += 20;
                    gfx.DrawString($"Furnizor: {dataGridViewProduse.Rows[0].Cells["Furnizor"].Value}", fontNormal, XBrushes.Black, 50, y);
                    y += 30;

                    // Tabel produse
                    double tableY = y;
                    double[] columnWidths = { 30, 180, 30, 50, 50, 50, 60 };
                    string[] headers = { "Nr.", "Denumire produs", "UM", "Cant.", "Pret", "Valoare" };

                    // Antet tabel
                    XRect rect;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        rect = new XRect(50 + columnWidths.Take(i).Sum(), tableY, columnWidths[i], 20);
                        gfx.DrawRectangle(new XSolidBrush(colorHeader), rect);
                        gfx.DrawString(headers[i], fontBold, XBrushes.White, rect, XStringFormats.Center);
                    }
                    tableY += 20;

                    // Randuri produse
                    decimal totalGeneral = 0;
                    int rowNum = 1;

                    foreach (DataGridViewRow row in dataGridViewProduse.Rows)
                    {
                        if (row.IsNewRow || row.Cells[0].Value == null) continue;

                        string denumire = row.Cells["Produs"].Value?.ToString() ?? "";
                        string cantitate = row.Cells["Cantitate"].Value?.ToString() ?? "1";
                        string pretTotal = row.Cells["PretTotal"].Value?.ToString() ?? "0";

                        if (!decimal.TryParse(pretTotal, out decimal valoare)) valoare = 0;
                        decimal pretUnitar = valoare / (decimal.TryParse(cantitate, out decimal cant) && cant > 0 ? cant : 1);
                        totalGeneral += valoare;

                        for (int i = 0; i < columnWidths.Length; i++)
                        {
                            rect = new XRect(50 + columnWidths.Take(i).Sum(), tableY, columnWidths[i], 20);
                            gfx.DrawRectangle(XPens.LightGray, rect);

                            string cellValue = i switch
                            {
                                0 => rowNum.ToString(),
                                1 => denumire,
                                2 => "buc",
                                3 => cantitate,
                                4 => pretUnitar.ToString("0.00"),
                                5 => valoare.ToString("0.00"),
                                _ => ""
                            };

                            gfx.DrawString(cellValue, fontNormal, XBrushes.Black, rect,
                                         i == 1 ? XStringFormats.TopLeft : XStringFormats.Center);
                        }

                        tableY += 20;
                        rowNum++;
                    }

                    // Total general
                    tableY += 10;
                    rect = new XRect(50 + columnWidths.Take(4).Sum(), tableY, columnWidths[4] + columnWidths[5], 25);
                    gfx.DrawRectangle(new XSolidBrush(colorHeader), rect);
                    gfx.DrawString("TOTAL GENERAL:", fontBold, XBrushes.White,
                                 new XRect(50 + columnWidths.Take(4).Sum(), tableY, columnWidths[4], 25),
                                 XStringFormats.CenterRight);
                    gfx.DrawString(totalGeneral.ToString("0.00") + " RON", fontBold, XBrushes.White,
                                 new XRect(50 + columnWidths.Take(5).Sum(), tableY, columnWidths[5], 25),
                                 XStringFormats.Center);

                    // Semnături
                    tableY += 40;
                    gfx.DrawLine(new XPen(XColors.Black, 0.5), 100, tableY, 300, tableY);
                    gfx.DrawLine(new XPen(XColors.Black, 0.5), page.Width - 300, tableY, page.Width - 100, tableY);
                    tableY += 15;
                    gfx.DrawString("Primit de,", fontNormal, XBrushes.Black, 100, tableY);
                    gfx.DrawString("Depozitar,", fontNormal, XBrushes.Black, page.Width - 300, tableY);
                    tableY += 20;
                    gfx.DrawString("Nume și semnătura", fontNormal, XBrushes.DarkGray, 100, tableY);
                    gfx.DrawString("Nume și semnătura", fontNormal, XBrushes.DarkGray, page.Width - 300, tableY);

                    document.Save(caleCompleta);
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la generarea notei de intrare:\n{ex.Message}", "Eroare",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}