using System;
using System.Collections.Generic;

namespace EvidenciaObjektovManazer
{
    public class ObjektEvidencie
    {
        public int IdCislo { get; set; }
        public string Popis { get; set; }
        public List<ObjektEvidencie> ZoznamReferencii { get; set; }
        public Gps Gps { get; set; }

        public ObjektEvidencie(int idCislo, string popis, Gps gps)
        {
            IdCislo = idCislo;
            Popis = popis;
            Gps = gps;
        }

        public void Vypis()
        {
            Console.WriteLine("x:{0} y:{1} id:{2}:{3}",Gps.Sirka,Gps.Dlzka,IdCislo,Popis);
        }

        public override string ToString()
        {
            return "IdCislo:" + IdCislo + " |Popis:" + Popis + " |Dlzka:" + Gps.PozDlzka + " |Sirka:" + Gps.PozSirka;
        }
    }
}
