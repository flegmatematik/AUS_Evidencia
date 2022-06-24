using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using EvidenciaObjektovManazer;

namespace MVC2
{
    public partial class NajdiNehnutelnostView : Form
    {
        private EvidenciaObjektov1 _evi;
        private List<ObjektEvidencie> _shownObjects;
        
        public NajdiNehnutelnostView(EvidenciaObjektov1 evi)
        {
            InitializeComponent();
            _evi = evi;
        }


        private void ButtonNajdi_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.Rows.Clear();
                Gps gps = new Gps(pozSirka: Double.Parse(TextSirka.Text, CultureInfo.InvariantCulture),pozDlzka: Double.Parse(TextDlzka.Text, CultureInfo.InvariantCulture));
                _shownObjects  =_evi.FindNehnutelnosti(gps);

                //dataGridView.DataSource = _shownObjects;

                foreach (ObjektEvidencie objekt in _shownObjects)
                {
                    var index = dataGridView.Rows.Add();
                    dataGridView.Rows[index].Cells["Id"].Value = objekt.IdCislo;
                    dataGridView.Rows[index].Cells["Popis"].Value = objekt.Popis;
                    dataGridView.Rows[index].Cells["Sirka"].Value = objekt.Gps.PozSirka;
                    dataGridView.Rows[index].Cells["Dlzka"].Value = objekt.Gps.PozDlzka;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zadane data niesu v spravnom formate!");
                //Console.WriteLine("Unable to convert '{0}'.", value);
            }
        }


        private void ButtonVymaz_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow riadok in dataGridView.SelectedRows)
                {
                    //_evi.
                    //riadok.Cells["Sirka"]
                }
            }
        }
    }
}
