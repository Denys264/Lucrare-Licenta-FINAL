using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gestiune_Bar_proiect_LICENTA
{


    public partial class MeniuAdministrator : Form
    {   public string NumeTabela;
        decimal sumaTotalaComenzi;
        decimal sumaTotala;
        private readonly Color PrimaryColor = Color.FromArgb(44, 62, 80);    // Dark blue
        private readonly Color SecondaryColor = Color.FromArgb(52, 152, 219); // Light blue
        private readonly Color AccentColor = Color.FromArgb(46, 204, 113);   // Green
        string filePath = @"C:\Users\Denis\Desktop\LICENTA\Gestiune Bar proiect LICENTA\Config.txt";
        string okstring;
        bool Inceput;
        public MeniuAdministrator()
        {
            InitializeComponent();
        }
       
        private void Comanda1_Click(object sender, EventArgs e)
        {
            if (Inceput==false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }
            NumeTabela = Comanda1.Name;

            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

      
        private void AdministrareStocuri_Click(object sender, EventArgs e)
        {
            Administrare f1 = new Administrare();
            f1.Show();
            this.Hide();
        }

        private void MeniuAdministrator_Load(object sender, EventArgs e)
        {
            DATA.Text = DateTime.Today.ToString("dd.MM.yyyy");
            ORA.Text = DateTime.Now.Hour.ToString("00");
            MINUTE.Text = DateTime.Now.Minute.ToString("00");
            SECUNDE.Text = DateTime.Now.Second.ToString("00");
            Temporizator.Start();
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Button btn)
                {
                    StyleCommandButton(btn);
                }
            }
            StyleMainButton(AdministrareStocuri, SecondaryColor);
            StyleMainButton(Rapoarte, AccentColor);
            StyleMainButton(SchimbareCont, Color.FromArgb(231, 76, 60)); // Red
            StyleMainButton(Incepere_Final, Color.FromArgb(155, 89, 182)); // Purple

            CalculeazaTotalComenzi();
            CalculeazaTotalZilnic();
            ValoareTotala.Text = $"{sumaTotala + sumaTotalaComenzi} RON";
            AfiseazaSumeComenzi();
            okstring= File.ReadAllText(filePath).Trim().ToLower();
            if (okstring == "true")
                Inceput= true;
            else 
                Inceput = false;
            if (Inceput==true)
            {
                Incepere_Final.Text = "Sfarsire Tura";
            }
            else
            {
                Incepere_Final.Text = "Incepere Tura";
            }
            saptamanal();
            lunar();

        }

       

        private void Temporizator_Tick(object sender, EventArgs e)
        {
            ORA.Text = DateTime.Now.Hour.ToString("00");
            MINUTE.Text = DateTime.Now.Minute.ToString("00");
            SECUNDE.Text = DateTime.Now.Second.ToString("00");
        }

        private void Incepere_Final_Click(object sender, EventArgs e)
        {
            

           
            
                string fileContent = File.ReadAllText(filePath).Trim().ToLower();

                if (fileContent == "false")
                    Inceput = false;
                else if (fileContent == "true")
                        Inceput = true;
                else
                {
                    MessageBox.Show("Fișierul conține o valoare invalidă (trebuie True/False).", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            
           

           
            if (Inceput == false)
            {
                Incepere_Final.Text = "Sfarsire Tura";
                Inceput = true;
                
                File.WriteAllText(filePath, "True"); // Actualizează fișierul

                
            }
            else
            {
                string textCuRon = ValoareDeIncasat.Text;

                // Extragem doar partea numerică folosind regex sau `Split`
                string doarNumar = textCuRon.Split(' ')[0]; // ia partea de dinainte de primul spațiu
                
                
                
                    if (decimal.Parse(doarNumar) > 0)
                    {
                        MessageBox.Show("Trebuie sa incheiati toate comenzile pentru a termina ziua!");
                        return;
                    }
                

                
                    
               

                Incepere_Final.Text = "Incepere Tura";
                Inceput = false;
                File.WriteAllText(filePath, "false");
                DialogResult confirmare = MessageBox.Show(
       "Ești sigur că vrei să închizi ziua și să generezi raportul final?",
       "Confirmare Închidere Zi",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

                if (confirmare != DialogResult.Yes)
                    return;

                try
                {
                    // PDF directories preparation
                    string dataAzi = DateTime.Now.ToString("yyyy-MM-dd");
                    string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Rapoarte", "Raport Zilnic");
                    Directory.CreateDirectory(folder);
                    string pdfPath = Path.Combine(folder, $"Raport Zilnic {dataAzi}.pdf");

                    // SQL Server connection
                    string connectionString = @"Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                    DataTable dt = new DataTable();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT NUME, CANTITATE, PRET FROM RAPOARTE.ZilnicTotal";
                        using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                        {
                            da.Fill(dt);
                        }
                    }

                    // Create PDF
                    using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    using (Document doc = new Document(PageSize.A4, 25, 25, 25, 25))
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.Open();

                        // Custom colors
                        BaseColor primaryColor = new BaseColor(44, 62, 80); // Dark blue
                        BaseColor secondaryColor = new BaseColor(52, 152, 219); // Blue
                        BaseColor accentColor = new BaseColor(231, 76, 60); // Red
                        BaseColor lightBg = new BaseColor(247, 247, 247); // Light gray
                        BaseColor darkText = new BaseColor(51, 51, 51); // Dark gray

                        // Company information header
                        Paragraph companyName = new Paragraph("S.C. RALU ELE CAFEBAR S.R.L",
                            FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, primaryColor));
                        companyName.Alignment = Element.ALIGN_CENTER;
                        companyName.SpacingAfter = 5f;
                        doc.Add(companyName);

                        // Company details
                        Paragraph companyDetails = new Paragraph();
                        companyDetails.Alignment = Element.ALIGN_CENTER;
                        companyDetails.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, darkText);
                        companyDetails.Add("CUI: 49439816\n");
                        companyDetails.Add("PIATRA-NEAMȚ, Str. MUREȘ, Nr. 22, Județ NEAMT\n");
                        companyDetails.Add("Tel: 0233-123456 | Email: office@raluelecafebar.ro");
                        companyDetails.SpacingAfter = 20f;
                        doc.Add(companyDetails);

                        // Report title with decorative elements
                        Paragraph reportTitle = new Paragraph("RAPORT ZILNIC DE ACTIVITATE",
                            FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, secondaryColor));
                        reportTitle.Alignment = Element.ALIGN_CENTER;
                        reportTitle.SpacingBefore = 10f;
                        reportTitle.SpacingAfter = 15f;
                        doc.Add(reportTitle);

                        // Date and time section
                        Paragraph reportDate = new Paragraph($"Data raport: {DateTime.Now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("ro-RO"))}",
                            FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC, BaseColor.GRAY));
                        reportDate.Alignment = Element.ALIGN_CENTER;
                        reportDate.SpacingAfter = 25f;
                        doc.Add(reportDate);

                        // Divider line
                       

                        // Main table section title
                        Paragraph tableTitle = new Paragraph("VÂNZARI ZILNICE",
                            FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, primaryColor));
                        tableTitle.SpacingBefore = 20f;
                        tableTitle.SpacingAfter = 15f;
                        doc.Add(tableTitle);

                        // Main table
                        PdfPTable mainTable = new PdfPTable(new float[] { 3, 1, 1 }); // Column widths
                        mainTable.WidthPercentage = 100;
                        mainTable.SpacingBefore = 10f;
                        mainTable.SpacingAfter = 20f;
                        mainTable.DefaultCell.Padding = 8f;

                        // Table headers
                        string[] headers = { "PRODUS", "CANTITATE", "VALOARE (lei)" };
                        foreach (string header in headers)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(header,
                                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, BaseColor.WHITE)))
                            {
                                BackgroundColor = primaryColor,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 10f,
                                BorderWidth = 0.5f
                            };
                            mainTable.AddCell(headerCell);
                        }

                        // Table rows with alternating colors
                        bool alternateRow = false;
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string cellValue = i == dt.Columns.Count - 1 ?
                                    string.Format("{0:0.00}", row[i]) :
                                    row[i].ToString();

                                PdfPCell cell = new PdfPCell(new Phrase(cellValue,
                                    FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, darkText)))
                                {
                                    BackgroundColor = alternateRow ? lightBg : BaseColor.WHITE,
                                    Padding = 8f,
                                    BorderWidth = 0.2f
                                };

                                if (i == 0) cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                else if (i == 1) cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                else cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                mainTable.AddCell(cell);
                            }
                            alternateRow = !alternateRow;
                        }

                        doc.Add(mainTable);

                        // Totals section
                        decimal totalVal = dt.AsEnumerable()
                            .Where(r => r["PRET"] != DBNull.Value)
                            .Sum(r => Convert.ToDecimal(r["PRET"]));
                        int totalQty = dt.AsEnumerable()
                            .Sum(r => Convert.ToInt32(r["CANTITATE"]));

                        PdfPTable totalsTable = new PdfPTable(2);
                        totalsTable.WidthPercentage = 50;
                        totalsTable.HorizontalAlignment = Element.ALIGN_RIGHT;
                        totalsTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        // Total quantity
                        PdfPCell qtyLabelCell = new PdfPCell(new Phrase("Total produse vândute:",
                            FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, darkText)));
                        qtyLabelCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        totalsTable.AddCell(qtyLabelCell);

                        PdfPCell qtyValueCell = new PdfPCell(new Phrase(totalQty.ToString(),
                            FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, darkText)));
                        qtyValueCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        qtyValueCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        totalsTable.AddCell(qtyValueCell);

                        // Total value
                        PdfPCell valLabelCell = new PdfPCell(new Phrase("Total încasari:",
                            FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, primaryColor)));
                        valLabelCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        totalsTable.AddCell(valLabelCell);

                        PdfPCell valValueCell = new PdfPCell(new Phrase($"{totalVal:0.00} lei",
                            FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, accentColor)));
                        valValueCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        valValueCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        totalsTable.AddCell(valValueCell);

                        doc.Add(totalsTable);

                        // Top products section
                        var top10 = dt.AsEnumerable()
                            .GroupBy(r => r["NUME"].ToString())
                            .Select(g => new
                            {
                                NUME = g.Key,
                                TotalCantitate = g.Sum(x => Convert.ToInt32(x["CANTITATE"]))
                            })
                            .OrderByDescending(x => x.TotalCantitate)
                            .Take(10)
                            .ToList();

                        // Section header
                        Paragraph topProductsHeader = new Paragraph("TOP 10 PRODUSE - CANTITĂȚI VÂNDUTE",
                            FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, primaryColor));
                        topProductsHeader.SpacingBefore = 30f;
                        topProductsHeader.SpacingAfter = 15f;
                        doc.Add(topProductsHeader);

                        // Top products table
                        PdfPTable topTable = new PdfPTable(new float[] { 3, 1, 1 }); // Product, Qty, Percentage
                        topTable.WidthPercentage = 80;
                        topTable.DefaultCell.Padding = 8f;

                        // Table header
                        string[] topHeaders = { "PRODUS", "CANTITATE", "PONDERE" };
                        foreach (string header in topHeaders)
                        {
                            topTable.AddCell(new PdfPCell(new Phrase(header,
                                FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE)))
                            { BackgroundColor = secondaryColor, Padding = 10f });
                        }

                        // Calculate total for percentage
                        int grandTotal = top10.Sum(x => x.TotalCantitate);

                        // Table rows
                        foreach (var p in top10)
                        {
                            // Product name
                            topTable.AddCell(new Phrase(p.NUME, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, darkText)));

                            // Quantity
                            topTable.AddCell(new Phrase(p.TotalCantitate.ToString(),
                                FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, darkText)));

                            // Percentage
                            double percentage = (double)p.TotalCantitate / grandTotal * 100;
                            topTable.AddCell(new Phrase($"{percentage:0.0}%",
                                FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.GRAY)));
                        }

                        doc.Add(topTable);

                        // Summary paragraph
                        Paragraph summary = new Paragraph();
                        summary.Alignment = Element.ALIGN_JUSTIFIED;
                        summary.Font = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, darkText);
                        summary.SpacingBefore = 20f;
                        summary.Add("Raport generat automat prin sistemul de gestiune al cafenelei. ");
                        summary.Add("Documentul prezinta activitatea comercială zilnică si poate fi folosit pentru analiza vânzărilor.");
                        doc.Add(summary);

                       
                        

                        // Footer text
                        Paragraph footer = new Paragraph();
                        footer.Alignment = Element.ALIGN_CENTER;
                        footer.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
                        footer.Add($"Document generat pe {DateTime.Now.ToString("dd.MM.yyyy HH:mm")} \u2022 ");
                        footer.Add($"S.C. RALU ELE CAFEBAR S.R.L \u2022 CUI: 49439816 \u2022 ");
                        footer.Add($"Tel: 0233-123456 \u2022 Email: office@raluelecafebar.ro");
                        footer.SpacingBefore = 10f;
                        doc.Add(footer);

                        // Page number
                        Paragraph pageNumber = new Paragraph($"Pagina {writer.PageNumber}",
                            FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.ITALIC, BaseColor.GRAY));
                        pageNumber.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(pageNumber);

                        doc.Close();
                    }

                    MessageBox.Show("Raportul PDF a fost generat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la generarea raportului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Șterge toate rândurile
                        string deleteQuery = "DELETE FROM RAPOARTE.ZilnicTotal";

                        using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn))
                        {
                            cmdDelete.ExecuteNonQuery();
                        }

                        // Resetează valoarea identității (presupunem că tabela are o coloană ID cu IDENTITY)
                        string resetIdentityQuery = "DBCC CHECKIDENT ('RAPOARTE.ZilnicTotal', RESEED, 0)";

                        using (SqlCommand cmdReset = new SqlCommand(resetIdentityQuery, conn))
                        {
                            cmdReset.ExecuteNonQuery();
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la golirea tabelei: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Application.Exit();
                
            }
        }

        private void Rapoarte_Click(object sender, EventArgs e)
        {
            Rapoarte f5 = new Rapoarte("Admin");
            f5.Show();
            this.Hide();
        }

        private void SchimbareCont_Click(object sender, EventArgs e)
        {
            PaginaLogin f1 = new PaginaLogin();
            f1.Show();
            this.Close();
        }

       

        private void Comanda2_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }
            NumeTabela = Comanda2.Name;

            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda3_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }

            NumeTabela = Comanda3.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda4_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }

            NumeTabela = Comanda4.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda5_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }

            NumeTabela = Comanda5.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda6_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }

            NumeTabela = Comanda6.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda7_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }

            NumeTabela = Comanda7.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda8_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }
            NumeTabela = Comanda8.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda9_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }
            NumeTabela = Comanda9.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda10_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }
            NumeTabela = Comanda10.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda11_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }
            NumeTabela = Comanda11.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda12_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }
            NumeTabela = Comanda12.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda13_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }
            NumeTabela = Comanda13.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda14_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }

            NumeTabela = Comanda14.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void Comanda15_Click(object sender, EventArgs e)
        {
            if (Inceput == false)
            {
                MessageBox.Show("Va rog sa incepeti tura pentru a pregati o comanda!");
                return;
            }

            NumeTabela = Comanda15.Name;
            Meniu f1 = new Meniu(NumeTabela, "Admin");
            f1.Show();
            this.Hide();
        }

        private void StyleCommandButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Font = new System.Drawing.Font("Segoe UI", 10);
            btn.Height = 70;
            btn.Width = 800;
            btn.Margin = new Padding(5);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);

            // Hover effects
            
            
        }
        private void StyleMainButton(Button btn, Color backgroundColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backgroundColor;

            btn.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 100;
            btn.Margin = new Padding(10);

            // Hover effects

            btn.MouseLeave += (s, e) => btn.BackColor = backgroundColor;
        }
        public void CalculeazaTotalComenzi()
        {
            sumaTotalaComenzi = 0;
            string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Obține numele tuturor tabelelor din schema COMENZI
                SqlCommand getTablesCommand = new SqlCommand(@"
            SELECT TABLE_NAME 
            FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_SCHEMA = 'COMENZI' AND TABLE_TYPE = 'BASE TABLE';
        ", connection);

                SqlDataReader reader = getTablesCommand.ExecuteReader();
                var tabele = new List<string>();

                while (reader.Read())
                {
                    tabele.Add(reader.GetString(0));
                }
                reader.Close();

                // Parcurge fiecare tabel și calculează suma (CANTITATE * PRET)
                foreach (string tabel in tabele)
                {
                    string query = $"SELECT SUM(PRET) FROM COMENZI.{tabel};";

                    SqlCommand sumCommand = new SqlCommand(query, connection);
                    object rezultat = sumCommand.ExecuteScalar();

                    if (rezultat != DBNull.Value && rezultat != null)
                        sumaTotalaComenzi += Convert.ToDecimal(rezultat);
                }
            }

            ValoareDeIncasat.Text = $"{sumaTotalaComenzi.ToString()} RON";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public void CalculeazaTotalZilnic()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
             sumaTotala = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SUM(PRET) FROM RAPOARTE.ZilnicTotal;";

                SqlCommand command = new SqlCommand(query, connection);
                object rezultat = command.ExecuteScalar();

                if (rezultat != DBNull.Value && rezultat != null)
                    sumaTotala = Convert.ToDecimal(rezultat);
            }

            ValoareIncasata.Text=$"{sumaTotala.ToString()} RON";
        }
        private void AfiseazaSumeComenzi()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=RALUELECAFEBAR;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                for (int i = 1; i <= 15; i++)
                {
                    string numeTabela = "Comanda" + i;
                    string sql = $"SELECT SUM(PRET) FROM COMENZI.{numeTabela}";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object rezultat = cmd.ExecuteScalar();

                        // Caută butonul pe formular
                        Button btn = this.Controls.Find(numeTabela, true).FirstOrDefault() as Button;

                        if (btn != null)
                        {
                            if (rezultat == DBNull.Value || rezultat == null)
                            {
                                btn.Text = $"Comanda {i}";
                            }
                            else
                            {
                                btn.Text = $"Comanda {i}                                                                                                Pret - {rezultat} RON";
                                btn.BackColor = Color.FromArgb(245, 167, 162);
                            }
                        }
                    }
                }
            }
        }

        private void saptamanal()
        {
            DateTime dataInitiala = new DateTime(2025, 6, 23);
            DateTime azi = DateTime.Now.Date;

            int zileTrecute = (int)(azi - dataInitiala).TotalDays;

            // Dacă zilele trecute sunt multiplu de 7 și au trecut cel puțin 7 zile
            if (zileTrecute >= 7 && zileTrecute % 7 == 0)
            {
                DialogResult confirmare = MessageBox.Show(
                 "Astazi este ziua pentru raportul saptamanal, doriti sa intrari direct in Rapoarte sa il scoateti?",
                     "Raport Saptamanal",
                        MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
  );

                if (confirmare != DialogResult.Yes)
                    return;
                Rapoarte f1 = new Rapoarte("Admin");
                this.Hide();
                f1.Show();
            }
        }
        private void lunar()
        {
            DateTime dataInitiala = new DateTime(2025, 6, 23);
            DateTime azi = DateTime.Now.Date; // sau altă dată dacă testezi

            // Calculează numărul de luni dintre data inițială și azi
            int luniTrecute = ((azi.Year - dataInitiala.Year) * 12) + azi.Month - dataInitiala.Month;

            // Verifică dacă s-a împlinit fix o lună, două luni, trei etc., și suntem exact în ziua 23
            if (luniTrecute >= 1 && azi.Day == dataInitiala.Day)
            {
                DialogResult confirmare = MessageBox.Show(
                 "Astazi este ziua pentru raportul lunar, doriti sa intrari direct in Rapoarte sa il scoateti?",
                     "Raport Lunar",
                        MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
  );

                if (confirmare != DialogResult.Yes)
                    return;
                Rapoarte f1 = new Rapoarte("Admin");
                this.Hide();
                f1.Show();
            }
        }
        
    }

}