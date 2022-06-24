namespace EvidenciaObjektovManazer
{
    public class Gps
    {
        public char Sirka { get; set; }
        public double PozSirka { get; set; }
        public char Dlzka { get; set; }
        public double PozDlzka { get; set; }

        public Gps(double pozSirka, double pozDlzka, char sirka='N', char dlzka='W')
        {
            PozSirka = pozSirka;
            PozDlzka = pozDlzka;
            Sirka = sirka;
            Dlzka = dlzka;
        }

        public double[] ToKey()
        {
            return new[] {PozSirka, PozDlzka};
        }
    }
}
