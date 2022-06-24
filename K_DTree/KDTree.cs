using System;
using System.Collections.Generic;

namespace K_DTree
{
    public class KdTree<TKeyType, TDataType> where TKeyType : IComparable
    {
        private TreeNode<TKeyType, TDataType> Root { get; set; }
        public int Dimension { get; set; }

        public KdTree(int pocetSuradnic)
        {
            Dimension = pocetSuradnic;
        }


        // ARGS key = pole klucov, data = data
        // vrati vzdy true - neexistuje dovod, preco by sa pridanie namalo uskutocnit
        //public bool AddNode(TKeyType[] key, TDataType data)
        //{
        //    if (key.Length == Dimension)
        //    {
        //        TreeNode<TKeyType, TDataType> foundParent = null;
        //        int dimenzia = 0;

        //        // hlada sa miesto na ktore sa prida Node na zaklade key. 
        //        bool found = FindNode(key, ref foundParent, ref dimenzia);
        //        // found je true, ak Node s danym klucom uz nasiel - v tom pripade sa iba pridaju data na zoznam dat v danom Node
        //        if (found)
        //        {
        //            foundParent.Data.Add(data);
        //        }
        //        // found je false, ak sa nenasiel dany Node
        //        else
        //        {
        //            TreeNode<TKeyType, TDataType> newSon = new TreeNode<TKeyType, TDataType>(key, new List<TDataType>() { data });
        //            // iba v pripade, ze struktura je prazdna, a teda neexistuje ani root - zaradenie Node na vrchol struktury
        //            if (foundParent == null)
        //            {
        //                Root = newSon;
        //            }
        //            // ak je najdeny potencionalny otec, tak struktura nieje prazdna - iba zistim, ci ma byt jeho lavy alebo pravy syn.  
        //            else
        //            {
        //                // ak je otcov kluc na danej dimenzii mensi ako synov-> novy syn bude jeho pravy syn, inak bude jeho lavym synom
        //                if (foundParent.Key[dimenzia].CompareTo(key[dimenzia]) < 0)
        //                {
        //                    newSon.Parent = foundParent;
        //                    foundParent.RightSon = newSon;
        //                }
        //                else
        //                {
        //                    newSon.Parent = foundParent;
        //                    foundParent.LeftSon = newSon;
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Provided key does not match defined size of key");
        //    }
        //}

        public bool AddNode(TKeyType[] key, TDataType data)
        {            
            if (key.Length == Dimension)
            {
                TreeNode<TKeyType, TDataType> foundParent = null;
                int dimenzia = 0;

                // hlada sa miesto na ktore sa prida Node na zaklade key. 
                bool found = FindNode(key, ref foundParent, ref dimenzia);
                // found je true, ak Node s danym klucom uz nasiel - v tom pripade sa iba pridaju data na zoznam dat v danom Node
                if (found)
                {
                    foundParent.Data.Add(data);
                }
                // found je false, ak sa nenasiel dany Node
                else
                {
                    TreeNode<TKeyType, TDataType> newSon = new TreeNode<TKeyType, TDataType>(key, new List<TDataType>() { data });
                    // iba v pripade, ze struktura je prazdna, a teda neexistuje ani root - zaradenie Node na vrchol struktury
                    if (foundParent == null)
                    {
                        Root = newSon;
                    }
                    // ak je najdeny potencionalny otec, tak struktura nieje prazdna - iba zistim, ci ma byt jeho lavy alebo pravy syn.  
                    else
                    {
                        // ak je otcov kluc na danej dimenzii mensi ako synov-> novy syn bude jeho pravy syn, inak bude jeho lavym synom
                        if (foundParent.Key[dimenzia].CompareTo(key[dimenzia]) < 0)
                        {
                            newSon.Parent = foundParent;
                            foundParent.RightSon = newSon;
                        }
                        else
                        {
                            newSon.Parent = foundParent;
                            foundParent.LeftSon = newSon;
                        }
                    }
                }
                return true;
            }
            else
            {
                throw new ArgumentException("Provided key does not match defined size of key");
            }
        }

        ///@args - key je kluc dat ktore sa maju vymazat. alwaysFirst - ak true, tak vzdy vymaze prve data ak je kluc duplicitny. Ak false, tak necha vybrat uzivatela
        /// Najprv pomocou FindNode zisti, ci sa dany kluc v strukture nachadza a vrati jeho referenciu -> ak found==true tak pokracuje dalej, inak mazanie konci
        /// Ak ma najdeny Node viacero dat, tak iba odstrani vybrane.
        /// Ak je Node list, tak taktiez jednoducho odstrani dany Node.
        /// Ak nieje listom, tak nasledne sa cyklicky vymienaju data a kluc bud s InOrder predchodcom, alebo Najvacsim nasledovnikom podla danej dimenzie.
        /// Vyuzivana metoda InOrder na najdenie nielen InOrder predchodcov ale aj najvacsieho nasledovnika, v pripade prazdneho laveho podstromu
        /// Cyklicky, kym nenajde Node na vymenu, ktora je Listom
        public bool DeleteNode(TKeyType[] key, bool alwaysFirst=false)
        {
            TreeNode<TKeyType, TDataType> foundNode = null;
            int dimenzia = 0;            
            bool found = FindNode(key, ref foundNode, ref dimenzia);
            if (found)
            {
                if (foundNode.Data.Count > 1)
                {
                    if (alwaysFirst)
                    {
                        foundNode.Data.RemoveAt(0);
                    }
                    else
                    {
                        //Vybratie Dat uzivatelom. Vyuzije sa neskor ToString
                        for (int i = 0; i < foundNode.Data.Count; i++)
                        {
                            Console.WriteLine(i + ". Node data: " + foundNode.Data[i]);
                        }
                        Console.WriteLine("\nVyberte index dat:");

                        int.TryParse(Console.ReadLine(), out var index);
                        foundNode.Data.RemoveAt(index);
                    }                   
                }
                else
                {
                    if (foundNode.IsList())
                    {
                        if (foundNode == Root)
                        {
                            Root = null;
                        }
                        else
                        {
                            if (foundNode.Parent.LeftSon == foundNode)
                            {
                                foundNode.Parent.LeftSon = null;
                            }
                            else
                            {
                                foundNode.Parent.RightSon = null;
                            }
                        }                       
                    }
                    // V pripade ze vymazavany Node nieje listom sa cyklicky prehladava jeho lavy podstrom, a ak ho nema, tak pravy podstrom - Implementovane v InOrder metode
                    else
                    {
                        TreeNode<TKeyType, TDataType> tempNode = foundNode;
                        // Cyklicke prehladavanie kym nieje vymeneny za list
                        do
                        {
                            // Prehodenie dat a klucov - referencie zostavaju rovnake
                            tempNode = FindInOrder(tempNode, ref dimenzia);

                            TreeNode<TKeyType, TDataType> remeberNode = new TreeNode<TKeyType, TDataType>(foundNode.Key, foundNode.Data);

                            foundNode.Key = tempNode.Key;
                            foundNode.Data = tempNode.Data;

                            tempNode.Key = remeberNode.Key;
                            tempNode.Data = remeberNode.Data;

                            // v pripade, ze vymienany Node nema lavy podstrom, tak sa najde najvacsi prvok z praveho podstromu, a pravy podstrom sa stane lavym podstromom najdeneho prvku
                            if(foundNode.LeftSon == null)
                            {
                                foundNode.LeftSon = foundNode.RightSon;
                                foundNode.RightSon = null;
                            }

                            foundNode = tempNode;

                        } while (!tempNode.IsList());
                        //odstranenie referencie rodicov na Node ktory je uz listom, a moze byt odstraneny
                        if (foundNode.Parent.LeftSon == foundNode)
                        {
                            foundNode.Parent.LeftSon = null;
                        }
                        else
                        {
                            foundNode.Parent.RightSon = null;
                        }
                    }                   
                }
                return true;
            }
            else
            {
                //Iba pre Info
                Console.Write("Uzol s danym klucom nebol najdeny: ");
                foreach (TKeyType k in key)               
                    Console.Write("{0} ",k);                

                Console.WriteLine();
                Vypis();
                return false;
            }
        }

        /// args key je hladany kluc, ref found je referencia(vklada sa null) ktory vrati bud najdeny Node alebo najblizsi Node k hladanemu klucu(jeho potencionalneho otca), ref dimenzia vrati v akej dimenzii sa nachadza najdena referecia 
        /// POZOR - ak najde prvok, tak dimenzia je najdeneho prvku, ak ho nenajde, tak je dimenzia potencionalneho otca
        /// ak najde Node s danym klucom vrati true, v ref found sa nachadza dany Node a dimenzia ukazuje na dimenziu daneho Node
        /// ak nenajde Node, tak v referencii found sa nachadza potencionalny otec, a dimenzia je daneho otca
        private bool FindNode(TKeyType[] key, ref TreeNode<TKeyType, TDataType> found, ref int dimenzia)
        {            
            if (Root == null)
            {
                return false;
            }
            else
            {
                TreeNode<TKeyType, TDataType> tempNode = Root;

                dimenzia = -1;
                while (tempNode != null)
                {
                    dimenzia = (dimenzia + 1) % Dimension;
                    //ak su kluce identicke, nasiel sa hladany Node
                    if (IsEqual(tempNode.Key, key))
                    {
                        found = tempNode;
                        return true;
                    }

                    // inak ak TempNode - prave pozorovany Node ma hodnotu kluca na sledovanej dimenzii MENSI (<) ako hladany kluc -> hladanie pokracuje pravym synom
                    // ak dany Node nema praveho syna, hladanie konci - nasli sme potencionalneho otca nanajdeneho prvku
                    else if (tempNode.Key[dimenzia].CompareTo(key[dimenzia]) < 0)
                    {
                        if (tempNode.RightSon == null)
                        {
                            found = tempNode;
                            return false;
                        }
                        tempNode = tempNode.RightSon;
                    }
                    // inak ak TempNode ma hodnotu kluca na sledovanej dimenzii VACSI alebo ROVNY (>=) ako hladany kluc -> hladanie pokracuje lavym synom
                    // ak dany Node nema laveho syna, hladanie konci - nasli sme potencionalneho otca nanajdeneho prvku
                    else if (tempNode.Key[dimenzia].CompareTo(key[dimenzia]) >= 0)
                    {
                        if (tempNode.LeftSon == null)
                        {
                            found = tempNode;
                            return false;
                        }
                        tempNode = tempNode.LeftSon;
                    }
                    else
                    {
                        throw new ArgumentException("Toto by nemalo nikdy nastat");
                    }
                }
                return false;                
            }
        }

        public TreeNode<TKeyType, TDataType> FindNode(TKeyType[] key)
        {
            if (Root == null)
            {
                return null;
            }
            else
            {
                TreeNode<TKeyType, TDataType> tempNode = Root;

                int dimenzia = -1;
                while (tempNode != null)
                {
                    dimenzia = (dimenzia + 1) % Dimension;
                    //ak su kluce identicke, nasiel sa hladany Node
                    if (IsEqual(tempNode.Key, key))
                    {
                        return tempNode;
                    }

                    // inak ak TempNode - prave pozorovany Node ma hodnotu kluca na sledovanej dimenzii MENSI (<) ako hladany kluc -> hladanie pokracuje pravym synom
                    // ak dany Node nema praveho syna, hladanie konci - nasli sme potencionalneho otca nanajdeneho prvku
                    else if (tempNode.Key[dimenzia].CompareTo(key[dimenzia]) < 0)
                    {
                        if (tempNode.RightSon == null)
                        {
                            return null;
                        }
                        tempNode = tempNode.RightSon;
                    }
                    // inak ak TempNode ma hodnotu kluca na sledovanej dimenzii VACSI alebo ROVNY (>=) ako hladany kluc -> hladanie pokracuje lavym synom
                    // ak dany Node nema laveho syna, hladanie konci - nasli sme potencionalneho otca nanajdeneho prvku
                    else if (tempNode.Key[dimenzia].CompareTo(key[dimenzia]) >= 0)
                    {
                        if (tempNode.LeftSon == null)
                        {
                            return null;
                        }
                        tempNode = tempNode.LeftSon;
                    }
                    else
                    {
                        throw new ArgumentException("Toto by nemalo nikdy nastat");
                    }
                }

                return null;
            }
        }

        public List<TreeNode<TKeyType, TDataType>> FindInterval(TKeyType[] lowerBoundary, TKeyType[] upperBoundary)
        {
            if (Root == null)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < Dimension; i++)
                {
                    if (lowerBoundary[i].CompareTo(upperBoundary[i]) > 0)
                    {
                        throw new ArgumentException("Lower boundary must contain only values that are lower than the values of upper boundary");
                    }
                }

                List<TreeNode<TKeyType,TDataType>> listFound = new List<TreeNode<TKeyType, TDataType>>();
                Queue<TreeNode<TKeyType,TDataType>> frontPrehladavanych = new Queue<TreeNode<TKeyType, TDataType>>();
                Queue<int> frontDimenzii = new Queue<int>();

                frontPrehladavanych.Enqueue(Root);
                frontDimenzii.Enqueue(0);

                while (frontPrehladavanych.Count != 0)
                {
                    TreeNode<TKeyType, TDataType> aktualnyNode = frontPrehladavanych.Dequeue();
                    int aktualnaDimenzia = frontDimenzii.Dequeue();

                    if (BelongsIn(aktualnyNode.Key, lowerBoundary, upperBoundary))
                    {
                        listFound.Add(aktualnyNode);
                    }

                    if (aktualnyNode.Key[aktualnaDimenzia].CompareTo(upperBoundary[aktualnaDimenzia]) < 0)
                    {
                        if (aktualnyNode.RightSon != null)
                        {
                            frontPrehladavanych.Enqueue(aktualnyNode.RightSon);
                            frontDimenzii.Enqueue((aktualnaDimenzia + 1) % Dimension);
                        }                        
                    }

                    if (aktualnyNode.Key[aktualnaDimenzia].CompareTo(lowerBoundary[aktualnaDimenzia]) >= 0)
                    {
                        if (aktualnyNode.LeftSon != null)
                        {
                            frontPrehladavanych.Enqueue(aktualnyNode.LeftSon);
                            frontDimenzii.Enqueue((aktualnaDimenzia + 1) % Dimension);
                        }                       
                    }
                }
                return listFound;
            }
        }


        /// <summary>
        /// Nachadza nahradnika pre parent Node ktory ma byt odstraneny. Ak ma lavy podstrom, nahradnikom je InOrder predchodca, inak je nahradnikom
        /// najvacsi Node v pravom podstrome podla danej dimenzie. Postupne vytvara Front podstromov, v ktorych sa moze nachadzat hladany prvok.
        /// Najlepsie Node-y uklada do Listu, kde vsetky maju rovnaku hodnotu kluca v danej dimenzii. Spolu s nim sa ukladaju aj jednotlive dimenzie. 
        /// Na konci prehladavania sa vyberie z Najlepsich vzdy prvy najdeny List, inak vrati prvy. 
        /// </summary>
        /// <param name="parent">Node, ktoremu chceme najst nahradnika v pripade mazania</param>
        /// <param name="dimenzia">Referencia na dimenziu v ktorej sa parent nachadza, po skonceni sa tu uklada dimenzia nahradnika</param>
        /// <returns>Vracia nahradnika pre parent Node</returns>
        public TreeNode<TKeyType, TDataType> FindInOrder(TreeNode<TKeyType, TDataType> parent, ref int dimenzia)
        {
            List<TreeNode<TKeyType,TDataType>> bestNodes = new List<TreeNode<TKeyType, TDataType>>();
            List<int> dimensions = new List<int>();

            if (parent != null)
            {
                int localDimenzia = dimenzia;
                Queue<TreeNode<TKeyType, TDataType>> frontVhodnych = new Queue<TreeNode<TKeyType, TDataType>>();
                Queue<int> frontDimension = new Queue<int>();

                // vybera InOrderPredchodcu
                if (parent.LeftSon != null)
                {
                    frontVhodnych.Enqueue(parent.LeftSon);
                    frontDimension.Enqueue((localDimenzia + 1)%Dimension);

                    // kym existuje Node, ktoreho podstrom by mohol obsahovat najvhodnejsieho nahradnika, tak prehladava
                    while (frontVhodnych.Count > 0)
                    {
                        TreeNode<TKeyType, TDataType> curNode = frontVhodnych.Dequeue();
                        localDimenzia = frontDimension.Dequeue();

                        //iba pridavanie najlepsieho Node
                        if (bestNodes.Count > 0)
                        {
                            if (curNode.Key[dimenzia].CompareTo(bestNodes[0].Key[dimenzia]) > 0)
                            {
                                bestNodes.Clear();
                                dimensions.Clear();
                                bestNodes.Add(curNode);                               
                                dimensions.Add(localDimenzia);
                            }
                            else if (curNode.Key[dimenzia].CompareTo(bestNodes[0].Key[dimenzia]) == 0)
                            {
                                if (!bestNodes[0].IsList() && curNode.IsList())
                                {
                                    bestNodes.Clear();
                                    dimensions.Clear();
                                }
                                bestNodes.Add(curNode);
                                dimensions.Add(localDimenzia);                                
                            }
                        }
                        else
                        {
                            bestNodes.Add(curNode);
                            dimensions.Add(localDimenzia);
                        }

                        if (localDimenzia == dimenzia)
                        {
                            if (curNode.RightSon != null)
                            {
                                frontVhodnych.Enqueue(curNode.RightSon);
                                frontDimension.Enqueue((localDimenzia + 1) % Dimension);
                            }
                            else if (curNode.LeftSon != null)
                            {
                                // ak je lavy syn rovnako dobry ako aktualny Node a zaroven ak je aspon rovnako dobry ako najlepsi Node, tak pojdem lavym s dufanim, ze najdem mozno list.
                                // Inak nieje dovod hladat v lavom podstrome ked som v hladanej dimenzii 
                                if ((curNode.LeftSon.Key[dimenzia].CompareTo(curNode.Key[dimenzia]) == 0) &&  curNode.LeftSon.Key[dimenzia].CompareTo(bestNodes[0].Key[dimenzia]) >= 0)
                                {
                                    frontVhodnych.Enqueue(curNode.LeftSon);
                                    frontDimension.Enqueue((localDimenzia + 1) % Dimension);
                                }
                            }
                            
                        }
                        else
                        {
                            // ak niesom v hladanej dimenzii, tak musim preskumat oboch synov
                            if (curNode.LeftSon != null)
                            {
                                frontVhodnych.Enqueue(curNode.LeftSon);
                                frontDimension.Enqueue((localDimenzia + 1) % Dimension);
                            }

                            if (curNode.RightSon != null)
                            {
                                frontVhodnych.Enqueue(curNode.RightSon);
                                frontDimension.Enqueue((localDimenzia + 1) % Dimension);
                            }
                        }
                    }
                }
                // vybera Node s najvacsim klucom podla danej dimenzie 
                else
                {
                    frontVhodnych.Enqueue(parent.RightSon);
                    frontDimension.Enqueue((localDimenzia + 1) % Dimension);

                    while (frontVhodnych.Count > 0)
                    {
                        TreeNode<TKeyType, TDataType> curNode = frontVhodnych.Dequeue();
                        localDimenzia = frontDimension.Dequeue();

                        if (bestNodes.Count > 0)
                        {
                            if (curNode.Key[dimenzia].CompareTo(bestNodes[0].Key[dimenzia]) > 0)
                            {
                                bestNodes.Clear();
                                bestNodes.Add(curNode);
                                dimensions.Clear();
                                dimensions.Add(localDimenzia);
                            }
                            else if (curNode.Key[dimenzia].CompareTo(bestNodes[0].Key[dimenzia]) == 0)
                            {
                                bestNodes.Add(curNode);
                                dimensions.Add(localDimenzia);
                            }
                        }
                        else
                        {
                            bestNodes.Add(curNode);
                            dimensions.Add(localDimenzia);
                        }

                        if (localDimenzia == dimenzia)
                        {
                            if (curNode.RightSon != null)
                            {
                                frontVhodnych.Enqueue(curNode.RightSon);
                                frontDimension.Enqueue((localDimenzia + 1) % Dimension);
                            }
                        }
                        else
                        {
                            if (curNode.LeftSon != null)
                            {
                                frontVhodnych.Enqueue(curNode.LeftSon);
                                frontDimension.Enqueue((localDimenzia + 1) % Dimension);
                            }

                            if (curNode.RightSon != null)
                            {
                                frontVhodnych.Enqueue(curNode.RightSon);
                                frontDimension.Enqueue((localDimenzia + 1) % Dimension);
                            }
                        }
                    }
                }
                // vybratie najlepsieho Node. Najlepsie ak je list              
                if (bestNodes.Count > 0)
                {
                    if (bestNodes.Count == 1)
                    {
                        dimenzia = dimensions[0];
                        return bestNodes[0];
                    }
                    else
                    {
                        for (int i = 0; i < bestNodes.Count; i++)
                        {
                            if (bestNodes[i].IsList())
                            {
                                dimenzia = dimensions[i];
                                return bestNodes[i];
                            }
                        }
                        dimenzia = dimensions[0];
                        return bestNodes[0];
                    }
                }
                else
                {
                    throw new ArgumentException("Je nutne volat iba nad Node ktory nieje listom");
                }
                
            }

            return null;
        }

        public void Vypis()
        {
            Queue<TreeNode<TKeyType, TDataType>> frontNodes = new Queue<TreeNode<TKeyType, TDataType>>();
            Queue<int> frontDimension = new Queue<int>();

            if (Root != null)
            {
                frontNodes.Enqueue(Root);
                frontDimension.Enqueue(0);
            }

            int oldDim = 0;
            while (frontNodes.Count != 0)
            {               
                TreeNode<TKeyType, TDataType> tempNode = frontNodes.Dequeue();
                int dimension = frontDimension.Dequeue();

                if (oldDim != dimension)
                {
                    Console.WriteLine();
                    oldDim = dimension;
                }
                Console.Write("Key: ");
                foreach(TKeyType key in tempNode.Key)
                {
                    Console.Write(key+" ");
                }
                Console.Write("  Data: ");
                foreach (TDataType data in tempNode.Data)
                {
                    Console.Write(data + " ");
                }
                Console.Write("  |||  ");

                if (tempNode.LeftSon != null)
                {
                    frontNodes.Enqueue(tempNode.LeftSon);
                    frontDimension.Enqueue((dimension+1)%Dimension);
                }
                if (tempNode.RightSon != null)
                {
                    frontNodes.Enqueue(tempNode.RightSon);
                    frontDimension.Enqueue((dimension + 1) % Dimension);
                }
            }
        }

        public bool IsEqual(TKeyType[] arr1, TKeyType[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].CompareTo(arr2[i]) != 0)
                {
                    return false;
                }               
            }
            return true;
        }

        public bool BelongsIn(TKeyType[] key, TKeyType[] boundary1, TKeyType[] boundary2 )
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (key[i].CompareTo(boundary1[i]) < 0 || key[i].CompareTo(boundary2[i]) > 0 )
                {
                    return false;
                }
            }
            return true;
        }

    }
}
