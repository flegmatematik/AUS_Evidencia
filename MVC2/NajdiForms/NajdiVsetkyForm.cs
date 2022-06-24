using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using EvidenciaObjektovManazer;

namespace MVC2.NajdiForms
{
    public partial class NajdiVsetkyForm : Form
    {
        private EvidenciaObjektov1 _evi;
        private List<ObjektEvidencie> _shownObjects;
        public NajdiVsetkyForm(EvidenciaObjektov1 evi)
        {
            InitializeComponent();
            _evi = evi;
        }

        private void ButtonNajdiVsetky_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewFoundObjects.Rows.Clear();
                Gps dolnaHranica = new Gps(pozSirka: Double.Parse(TextDolnaHranicaSirka.Text, CultureInfo.InvariantCulture), pozDlzka: Double.Parse(TextDolnaHranicaDlzka.Text, CultureInfo.InvariantCulture));
                Gps hornaHranica = new Gps(pozSirka: Double.Parse(TextHornaHranicaSirka.Text, CultureInfo.InvariantCulture), pozDlzka: Double.Parse(TextHornaHranicaDlzka.Text, CultureInfo.InvariantCulture));

                //_shownObjects = 

                //dataGridView.DataSource = _shownObjects;

                foreach (ObjektEvidencie objekt in _evi.FindAllObjects(dolnaHranica, hornaHranica))
                {
                    var index = DataGridViewFoundObjects.Rows.Add();
                    DataGridViewFoundObjects.Rows[index].Cells["Id"].Value = objekt.IdCislo;
                    DataGridViewFoundObjects.Rows[index].Cells["Popis"].Value = objekt.Popis;
                    DataGridViewFoundObjects.Rows[index].Cells["Sirka"].Value = objekt.Gps.PozSirka;
                    DataGridViewFoundObjects.Rows[index].Cells["Dlzka"].Value = objekt.Gps.PozDlzka;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zadane data niesu v spravnom formate!");
                //Console.WriteLine("Unable to convert '{0}'.", value);
            }
        }
    }
}
