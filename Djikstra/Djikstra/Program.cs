using System;
using System.Collections.Generic;// Tu se mapa nalazi


namespace Graf
{
    class Program//Ovde se naglasava genericki tip
    {



        // Ovo je otprilike kako ce nam izgledati cvor mape cisto da imamo okvirno kod
        class CvorMape
        {
            //uvek su int koordinate kad se radi grafika

            private int koordinataX;
            private int koordinataY;
            private bool znamenitost;


            public CvorMape(int x, int y, bool z)
            {
                koordinataX = x;
                koordinataY = y;
                znamenitost = z;
            }

            public CvorMape(int x, int y)
            {
                koordinataX = x;
                koordinataY = y;
                znamenitost = false;
            }

            public int getKoordinataX()
            {
                return koordinataX;
            }

            public int getKoordinataY()
            {
                return koordinataY;
            }

            public bool getZnamenitost()
            {
                return znamenitost;
            }

            public void setKoordinataX(int x)
            {
                koordinataX = x;
            }

            public void setKoordinataY(int y)
            {
                koordinataY = y;
            }

            public void setZnamenitost(bool b)
            {
                znamenitost = b;
            }

        }


        class DolazniPut : IComparable
        {
            //
            private int cvor;
            private double tezina;

            public DolazniPut(int x, double t)
            {
                cvor = x;
                tezina = t;
            }

            public int getCvor()
            {
                return cvor;
            }
            public double getTezina()
            {
                return tezina;
            }

            public void setTezina(double t)
            {
                tezina = t;
            }
            public static bool operator <(DolazniPut x, DolazniPut y)
                => x.tezina < y.tezina;
            public static bool operator >(DolazniPut x, DolazniPut y)
                => x.tezina > y.tezina;

            public int CompareTo(Object obj)
            {
                DolazniPut drugi = obj as DolazniPut;
                return this.tezina.CompareTo(drugi.tezina);
            }

        }


       


        
        //Za Dijkstrin algoritam cemo koristiti vektor (u C# je List) za skladistenje suseda, a mapu neuredjenu (u C# je Dictionary) za skladistenje ivica, par(u C# Tuple) ivica slikamo u tezinu, 
        //Ovo radimo da bismo mogli da koristimo optimalniji algoritam, sa skupom ( ili heapom svejedno), jer ce nas graf biti slabo povezan (jedan cvor ce imati mali broj suseda)
        // Sve ivice ce nam biti tezine double zbog prirode problema kojim se bavimos
        //Nema potrebe da imamo niz cvorova, jer cemo radi svoje jednostavnosti numerisati cvorove od 0, redom ( ne moramo da radimo nikakvo genericko programiranje, niti hesiranje )
        public static void Dijkstra(int pocetniCvor,int zavrsniCvor,int brojCvorova,List<int> [] susedi,Dictionary<Tuple<int,int>,double> grane)
        {
            int [] prethodnik=new int [brojCvorova]; //Definisemo prethodni cvor svakog elementa u najkracem putu i onda cemo unazad procitati, tj. iscrtati put
            for (int i = 0; i < brojCvorova; i++)
                prethodnik[i] = -1;



            double[] cenaDo = new double[brojCvorova];// Pamti cenu od poocetnog do i-tog cvora.
                                                      //Postavljamo sve ceneDo u pocetku na "beskonacno", nama je ok da bude negativna vrednost, posto su sve tezine pozitivne.

            SortedSet<DolazniPut> putevi = new SortedSet<DolazniPut>(); //Skladistimo predjene puteve 

            double infinity = 1.7976931348623157E+308;
            for (int i = 0; i < brojCvorova; i++)
            {
                    cenaDo[i] = infinity;
            }

            cenaDo[pocetniCvor] = 0;
            putevi.Add(new DolazniPut(pocetniCvor, 0));
            

            while (putevi.Count != 0)
            {
                DolazniPut v = putevi.Min;
                putevi.Remove(v);
                int prethodniCvor = v.getCvor();
                double prethodnaTezina = v.getTezina();

                for(int i = 0; i < susedi[prethodniCvor].Count; i++)
                {
                    Tuple<int, int> spojeniCvorovi = new Tuple<int, int>(prethodniCvor, susedi[prethodniCvor][i]);//Cvorovi koi se spajaju datom granom
                    double trenutnaCena = cenaDo[prethodniCvor] + grane[spojeniCvorovi];
                    if(trenutnaCena<cenaDo[spojeniCvorovi.Item2])
                    {
                        putevi.Remove(new DolazniPut(spojeniCvorovi.Item2, cenaDo[spojeniCvorovi.Item2]));//Brisemo trenutni put do cvora, da ne bismo prolazili posle opet kroz sve susede
                        cenaDo[spojeniCvorovi.Item2] = trenutnaCena;
                        putevi.Add(new DolazniPut(spojeniCvorovi.Item2, cenaDo[spojeniCvorovi.Item2]));// Dodali smo novi najkraci put nakon promene 
                        prethodnik[spojeniCvorovi.Item2] = spojeniCvorovi.Item1;//Znamo da je prethodni cvor koji je vodio do naseg trenutnog cvora, zapravo ovaj cvor
                    }


                }

            }


            Console.WriteLine("Najkrace rastojanje je "+ cenaDo[zavrsniCvor]);
            int trenutniCvor = zavrsniCvor;
            Console.WriteLine("Put: ");
            while (trenutniCvor!=pocetniCvor)
            {
                Console.WriteLine(trenutniCvor);
                trenutniCvor = prethodnik[trenutniCvor];
            }
            Console.WriteLine(pocetniCvor);

           



        }
       



        static void Main(string[] args)
        {

            //Testiramo Dijsktru, slika grafa je u folderu Dijkstra projekta
            int n = 6;
            int pocetniCvor = 1;
            int zavrsniCvor = 5;
            List<int>[] susedi = new List<int> [6];
            for (int i = 0; i < n; i++)
                susedi[i] = new List<int>();
            susedi[0].Add(1);susedi[0].Add(2);susedi[0].Add(5);
            susedi[1].Add(0);susedi[1].Add(2);susedi[1].Add(3);
            susedi[2].Add(0);susedi[2].Add(1);susedi[2].Add(3);susedi[2].Add(5);
            susedi[3].Add(1);susedi[3].Add(2);susedi[3].Add(4);
            susedi[4].Add(3);susedi[4].Add(5);
            susedi[5].Add(0);susedi[5].Add(2);susedi[5].Add(4);

            Dictionary<Tuple<int, int>, double> grane = new Dictionary<Tuple<int, int>, double>();
            grane[new Tuple<int, int>(0, 1)] = 7; grane[new Tuple<int, int>(1, 0)] = 7;
            grane[new Tuple<int, int>(0, 2)] = 9; grane[new Tuple<int, int>(2, 0)] = 9;
            grane[new Tuple<int, int>(0, 5)] = 14; grane[new Tuple<int, int>(5, 0)] = 14;
            grane[new Tuple<int, int>(1, 2)] = 10; grane[new Tuple<int, int>(2, 1)] = 10;
            grane[new Tuple<int, int>(1, 3)] = 15; grane[new Tuple<int, int>(3, 1)] = 15;
            grane[new Tuple<int, int>(2, 3)] = 11; grane[new Tuple<int, int>(3, 2)] = 11;
            grane[new Tuple<int, int>(2, 5)] = 2; grane[new Tuple<int, int>(5, 2)] = 2;
            grane[new Tuple<int, int>(3, 4)] = 6; grane[new Tuple<int, int>(4, 3)] = 6;
            grane[new Tuple<int, int>(4, 5)] = 9; grane[new Tuple<int, int>(5, 4)] = 9;


            
            Dijkstra(pocetniCvor, zavrsniCvor, n, susedi, grane);


        }
    }
}
