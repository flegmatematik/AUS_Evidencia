using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EvidenciaObjektovManazer;
using K_DTree;

namespace ActionGenerator
{
    public class Generator
    {
        public void PopulujEvidenciu(ref EvidenciaObjektov1 evidencia, int pocetNehnutelnosti, int pocetParciel)
        {

            Random randKeys = new Random(1);

            Random randData = new Random(2);

            for (int i = 0; i < pocetNehnutelnosti; i++)
            {
                evidencia.AddNehnutelnost(randData.Next(),"",randKeys.NextDouble()*1000.0,randKeys.NextDouble()*1000.0);
            }

            for (int i = 0; i < pocetParciel; i++)
            {
                evidencia.AddParcela(randData.Next(), "", randKeys.NextDouble()*1000.0, randKeys.NextDouble()*1000.0);
            }
        }

        public void GeneratorForTree(ref KdTree<int, int> struktura, int pridaj, int odstran, int najdi, int najdiInterval)
        {
            if (odstran > pridaj)
            {
                odstran = pridaj;
            }

            int sum = pridaj + odstran + najdi + najdiInterval;
            int dimension = struktura.Dimension;

            List<Akcia> actionList = new List<Akcia>(sum);
            List<int[]> aktivneKluce = new List<int[]>(sum);

            Random randAction = new Random(0);

            Random randKeys = new Random(1);

            Random randData = new Random(2);

            Random randPick = new Random(3);

            for (int i = 0; i < sum; i++)
            {                
                int temp = randAction.Next(pridaj+odstran+najdi+najdiInterval);
                bool zmenaPridaj = false;
                bool zmenaOdstran = false;
                bool zmenaNajdi = false;
                bool zmenaNajdiInterval = false;

                if (aktivneKluce.Count == 0 || temp < pridaj)
                {
                    TypAkcie typ = TypAkcie.Pridaj;

                    int[] kluc = new int[dimension];
                    for (int j = 0; j < dimension; j++)
                    {
                        kluc[j] = randKeys.Next(1000);
                    }

                    int data = randData.Next(1000);
                    Akcia novaAkcia = new Akcia(typ, kluc, data);
                    aktivneKluce.Add(kluc);
                    actionList.Add(novaAkcia);

                    zmenaPridaj = true;
                }
                else if (temp - pridaj < odstran)
                {
                    TypAkcie typ = TypAkcie.Odstran;

                    int index = randPick.Next(aktivneKluce.Count);

                    int[] kluc = aktivneKluce[index];
                    aktivneKluce.RemoveAt(index);

                    Akcia novaAkcia = new Akcia(typ, kluc);
                    actionList.Add(novaAkcia);

                    zmenaOdstran = true;
                }
                else if (temp - pridaj - odstran < najdi)
                {
                    TypAkcie typ = TypAkcie.Najdi;

                    int index = randPick.Next(aktivneKluce.Count);

                    int[] kluc = aktivneKluce[index];

                    Akcia novaAkcia = new Akcia(typ, kluc);
                    actionList.Add(novaAkcia);

                    zmenaNajdi = true;
                }
                else if(temp - pridaj - odstran - najdi < najdiInterval)
                {
                    TypAkcie typ = TypAkcie.NajdiInterval;

                    int index = randPick.Next(aktivneKluce.Count);

                    int[] kluc = aktivneKluce[index];

                    Akcia novaAkcia = new Akcia(typ, kluc);
                    actionList.Add(novaAkcia);

                    zmenaNajdiInterval = true;
                }
                else
                {
                    throw new System.ArgumentException("This should not happen");
                }

                if(zmenaPridaj)
                    pridaj--;
                else if (zmenaOdstran)
                    odstran--;
                else if (zmenaNajdi)
                    najdi--;
                else if (zmenaNajdiInterval)
                    najdiInterval--;
                else
                {
                    throw new ArgumentOutOfRangeException("DEBUG: Nemoze nastat");
                }
            }

            aktivneKluce = null;
            Console.WriteLine("Pocet akcií: {0}",actionList.Count);
            Console.WriteLine("Velkost kluca: {0}", struktura.Dimension);

            Console.WriteLine("Zaciatok testovania");

            Console.WriteLine("/////////////////////////////////////////");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (Akcia akcia in actionList)
            {
                //akcia.Vypis();
                switch (akcia.TypAkcie)
                {
                    case TypAkcie.Pridaj:
                        struktura.AddNode(akcia.Kluc, akcia.Data);
                        break;
                    case TypAkcie.Odstran:
                        struktura.DeleteNode(akcia.Kluc,true);
                        break;
                    case TypAkcie.Najdi:
                        struktura.FindNode(akcia.Kluc);
                        break;
                    case TypAkcie.NajdiInterval:
                        struktura.FindInterval(akcia.Kluc.Select(x => x - 20).ToArray(),
                            akcia.Kluc.Select(x => x + 20).ToArray());
                        break;
                    default:
                        return;
                }
            }
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.WriteLine("Koniec Testovania");
        }
        
        public class Akcia
        {
            public int[] Kluc { get; set; }
            public int Data { get; set; }
            public TypAkcie TypAkcie { get; set; }
            public Akcia(TypAkcie typAkcie, int[] kluc, int data = 0)
            {
                TypAkcie = typAkcie;
                Kluc = kluc;
                Data = data;
            }

            public void Vypis()
            {
                Console.Write( TypAkcie + " | ");
                foreach (int key in Kluc)
                {
                    Console.Write(key + " ");
                }
                Console.Write("\n");               
            }
        }

        public enum TypAkcie
        {
            Pridaj,
            Odstran,
            Najdi,
            NajdiInterval
        }
    }
}
