using System;
using System.Globalization;
using System.Windows.Forms;
using EvidenciaObjektovManazer;

namespace MVC2
{
    public partial class PridajNehnutelnostView : Form
    {
        private EvidenciaObjektov1 _evi;
        public PridajNehnutelnostView(EvidenciaObjektov1 evi)
        {
            _evi = evi;
            InitializeComponent();
        }

        private void ButtonPridaj_Click(object sender, EventArgs e)
        {
            try
            {
                _evi.AddNehnutelnost(Int32.Parse(TextSupisneCislo.Text), TextPopis.Text, Double.Parse(TextSirka.Text, CultureInfo.InvariantCulture), Double.Parse(TextDlzka.Text, CultureInfo.InvariantCulture));
                MessageBox.Show("Vlozeny objekt");
            }
            catch (FormatException)
            {
                MessageBox.Show("Zadane data niesu v spravnom formate!");
                //Console.WriteLine("Unable to convert '{0}'.", value);
            }
        }
    }
}
