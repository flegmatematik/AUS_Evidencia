using System;
using System.Windows.Forms;
using ActionGenerator;
using EvidenciaObjektovManazer;
using MVC2.NajdiForms;

namespace MVC2
{
    public partial class MainForm : Form
    {
        private  EvidenciaObjektov1 _evi;
        public MainForm(ref EvidenciaObjektov1 evidencia)
        {
            _evi = evidencia;
            InitializeComponent();
        }

        private void MenuItemPridajNehnutelnost_Click(object sender, EventArgs e)
        {
            Form nova = new PridajNehnutelnostView(_evi);
            nova.Show();
        }

        private void MenuItemNajdiNehnutelnost_Click(object sender, EventArgs e)
        {
            Form nova = new NajdiNehnutelnostView(_evi);
            nova.Show();
        }

        private void MenuItemNajdiVsetkyObjekty_Click(object sender, EventArgs e)
        {
            Form nova = new NajdiVsetkyForm(_evi);
            nova.Show();
        }

        private void ButtonPopulujEvidenciu_Click(object sender, EventArgs e)
        {
            new Generator().PopulujEvidenciu(ref _evi, 20000, 52000);
        }
    }
}
