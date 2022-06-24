using System;
using System.Collections.Generic;
using System.Linq;
using K_DTree;

namespace EvidenciaObjektovManazer
{
    public class EvidenciaObjektov1
    {
        private KdTree<double, ObjektEvidencie> _zoznamParciel;
        private KdTree<double, ObjektEvidencie> _zoznamNehnutelnosti;

        public EvidenciaObjektov1()
        {
            _zoznamParciel = new KdTree<double, ObjektEvidencie>(2);
            _zoznamNehnutelnosti = new KdTree<double, ObjektEvidencie>(2);
        }

        public void AddParcela(int cisloParcely, string popis, double pozSirka, double pozDlzka)
        {
            Gps gps = new Gps(pozSirka, pozDlzka);
            ObjektEvidencie data = new ObjektEvidencie(cisloParcely, popis, gps);

            List<ObjektEvidencie> nehnutelnosti = FindNehnutelnosti(gps);
            foreach (var nehnutelnost in nehnutelnosti)
            {
                nehnutelnost.ZoznamReferencii.Add(data);
            }

            data.ZoznamReferencii = nehnutelnosti;
            _zoznamParciel.AddNode(gps.ToKey(), data);
        }

        public void AddNehnutelnost(int supisneCislo, string popis, double pozSirka, double pozDlzka)
        {
            Gps gps = new Gps(pozSirka, pozDlzka);
            ObjektEvidencie data = new ObjektEvidencie(supisneCislo, popis, gps);

            List<ObjektEvidencie> parcely = FindParcely(gps);
            foreach (var parcela in parcely)
            {
                parcela.ZoznamReferencii.Add(data);
            }

            data.ZoznamReferencii = parcely;

            _zoznamNehnutelnosti.AddNode(gps.ToKey(), data);
        }

        public List<ObjektEvidencie> FindNehnutelnosti(Gps gps)
        {
            TreeNode<double, ObjektEvidencie> zoznamNode = _zoznamNehnutelnosti.FindNode(gps.ToKey());
            if (zoznamNode != null)
            {
                return zoznamNode.Data;
            }
            else
            {
                return new List<ObjektEvidencie>();
            }
        }

        public List<ObjektEvidencie> FindParcely(Gps gps)
        {
            TreeNode<double, ObjektEvidencie> zoznamNode = _zoznamParciel.FindNode(gps.ToKey());
            if (zoznamNode != null)
            {
                return zoznamNode.Data;
            }
            else
            {
                return new List<ObjektEvidencie>();
            }
        }

        public List<ObjektEvidencie> FindAllObjects(Gps lowerBoundary, Gps upperBoundary)
        {
            List<ObjektEvidencie> najdeneData = new List<ObjektEvidencie>();
            List<TreeNode<double, ObjektEvidencie>> najdeneParcely = _zoznamParciel.FindInterval(lowerBoundary.ToKey(), upperBoundary.ToKey());
            if (najdeneParcely != null)
            {
                foreach (TreeNode<double, ObjektEvidencie> zoznamObjektov in najdeneParcely)
                {
                    najdeneData.AddRange(zoznamObjektov.Data);
                }
            }

            List<TreeNode<double, ObjektEvidencie>> najdeneNehnutelnosti = _zoznamNehnutelnosti.FindInterval(lowerBoundary.ToKey(), upperBoundary.ToKey());
            if (najdeneNehnutelnosti != null)
            {
                foreach (TreeNode<double, ObjektEvidencie> zoznamObjektov in najdeneNehnutelnosti)
                {

                    najdeneData.AddRange(zoznamObjektov.Data);
                }
            }
            return najdeneData;
        }

        public void ZmenaNehnutelnosti(Gps gps)
        {
            List<ObjektEvidencie> najdeneNehnutelnosti = FindNehnutelnosti(gps);

            foreach (ObjektEvidencie nehnutelnost in najdeneNehnutelnosti)
            {
                
            }
        }

        public void ZmenaParcely(Gps gps)
        {
            throw new NotImplementedException();
        }

        public void VymazNehnutelnost(Gps gps)
        {
            _zoznamNehnutelnosti.DeleteNode(gps.ToKey());
        }

        public void VymazParcelu(Gps gps)
        {
            _zoznamParciel.DeleteNode(gps.ToKey());
        }


        public void Vypis()
        {
            Console.WriteLine("///////  NEHNUTELNOSTI ////////");
            _zoznamNehnutelnosti.Vypis();
            Console.WriteLine("///////     PARCELY    ////////");
            _zoznamParciel.Vypis();
        }

    }
}
