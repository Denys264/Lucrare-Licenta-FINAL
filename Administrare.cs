using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Gestiune_Bar_proiect_LICENTA
{
    public partial class Administrare : Form
    {
        public Administrare()
        {
            InitializeComponent();
        }

        private void InapoiPagina_Click(object sender, EventArgs e)
        {
            MeniuAdministrator f1 = new MeniuAdministrator();
            f1.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Administrare_Load(object sender, EventArgs e)
        {

        }
        public bool Expand1 = false;
        public bool Expand2 = false;
        public bool Expand3 = false;
        private void AdaugaTimer_Tick(object sender, EventArgs e)
        {
            if (Expand1 == false)
            {
                PanouAdauga.Height += 15;
                if (PanouAdauga.Height >= PanouAdauga.MaximumSize.Height)
                {

                    AdaugaTimer.Stop();
                    Expand1 = true;
                }
            }
            else
            {
                PanouAdauga.Height -= 15;
                if (PanouAdauga.Height <= PanouAdauga.MinimumSize.Height)
                {

                    AdaugaTimer.Stop();
                    Expand1 = false;
                }
            }
        }

        private void Adauga_Click(object sender, EventArgs e)
        {
            AdaugaTimer.Start();
        }

        private void ModificaPanou_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ModificaTimer_Tick(object sender, EventArgs e)
        {
            if (Expand2 == false)
            {
                ModificaPanou.Height += 15;
                if (ModificaPanou.Height >= ModificaPanou.MaximumSize.Height)
                {

                    ModificaTimer.Stop();
                    Expand2 = true;
                }
            }
            else
            {
                ModificaPanou.Height -= 15;
                if (ModificaPanou.Height <= ModificaPanou.MinimumSize.Height)
                {

                    ModificaTimer.Stop();
                    Expand2 = false;
                }
            }
        }

        private void Modifica_Click(object sender, EventArgs e)
        {
            ModificaTimer.Start();
        }

        private void PanouSterge_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StergeTimer_Tick(object sender, EventArgs e)
        {
            if (Expand3 == false)
            {
                PanouSterge.Height += 15;
                if (PanouSterge.Height >= PanouSterge.MaximumSize.Height)
                {

                    StergeTimer.Stop();
                    Expand3 = true;
                }
            }
            else
            {
                PanouSterge.Height -= 15;
                if (PanouSterge.Height <= PanouSterge.MinimumSize.Height)
                {

                    StergeTimer.Stop();
                    Expand3 = false;
                }
            }
        }

        private void Sterge_Click(object sender, EventArgs e)
        {
            StergeTimer.Start();
        }

        private void AdaugaConturi_Click(object sender, EventArgs e)
        {
            AdaugaCont f1 = new AdaugaCont();
            f1.ShowDialog();

        }

        private void StergereConturi_Click(object sender, EventArgs e)
        {
            StergeConturi f1 = new StergeConturi();
            f1.ShowDialog();

        }

        private void AdaugaFurnizor_Click(object sender, EventArgs e)
        {
            AdaugaFurnizor f1 = new AdaugaFurnizor();
            f1.ShowDialog();
        }

        private void AdaugaProdusGestiune_Click(object sender, EventArgs e)
        {
            AdaugaProdusGestiune f1 = new AdaugaProdusGestiune();
            f1.ShowDialog();
        }

        private void AdaugaCategorie_Click(object sender, EventArgs e)
        {
            AdaugaCategorie f1 = new AdaugaCategorie();
            f1.ShowDialog();
        }

        private void AdaugaProdus_Click(object sender, EventArgs e)
        {
            AdaugaProdusMeniu f1 = new AdaugaProdusMeniu();
            f1.ShowDialog();
        }

        private void StergeFurnizor_Click(object sender, EventArgs e)
        {
            StergeFurnizor f1 = new StergeFurnizor();
            f1.ShowDialog();
        }

        private void StergeProdusMeniu_Click(object sender, EventArgs e)
        {
            StergeProdusMeniu f1 = new StergeProdusMeniu();
            f1.ShowDialog();
        }

        private void StergeProdus_Click(object sender, EventArgs e)
        {
            StergeProdusGestiune f1 = new StergeProdusGestiune();
            f1.ShowDialog();
        }

        private void StergeCategorie_Click(object sender, EventArgs e)
        {
            StergeCategorie f1 = new StergeCategorie();
            f1.ShowDialog();
        }

        private void ModificaCategorie_Click(object sender, EventArgs e)
        {
            ModificaCategorie f1 = new ModificaCategorie();
            f1.ShowDialog();
        }

        private void ModificaProdus_Click(object sender, EventArgs e)
        {
            ModificaProdusGestiune f1 = new ModificaProdusGestiune();
            f1.ShowDialog();
        }

        private void ModificaFurnizor_Click(object sender, EventArgs e)
        {
            ModificaFurnizor f1 = new ModificaFurnizor();
            f1.ShowDialog();
        }

        private void AdaugaNIR_Click(object sender, EventArgs e)
        {
            NotaIntrare f1 = new NotaIntrare();
            f1.ShowDialog();
        }
    }
}
