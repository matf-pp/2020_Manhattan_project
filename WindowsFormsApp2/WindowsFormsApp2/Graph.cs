using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace WindowsFormsApp2
{
    //Pomocna klasa za Milojevog Dijkstru
    class DolazniPut : IComparable
    {
        
        private int cvor;
        private double tezina;

        public DolazniPut(int mark, double t)
        {
            cvor = mark;
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

    // MARKER = CVOR GRAFA
    // GMapMarker, int i PointLatLng mozemo koristiti za cvorove !
    // Moze umesto PointLatLng i Tuple<double, double> !
    // Lako prelazimo sa jednog na drugo, opisano je ovde ispod

    // GMapMarker -> int ===> int.Parse(marker.Tag.toSring())    (Tag - polje objekta marker, u njemu cuvam i redni broj markera)
    // int -> GMapMarker ===> getMarkerFromInt(i) ili intToMarker[i] (privatno, u klasi)
    // GMapMarker -> PointLatLng ===> marker.Position
    // PointLatLng -> GMapMarker ===> new GMapMarker(point)
    // I obrnuto
    class Graph
    {
        //Mapiramo MARKERE sa REDNIM BROJEVIMA
        private Dictionary<int, GMapMarker> intToMarker = new Dictionary<int, GMapMarker>();
        private Dictionary<PointLatLng, int> pointToInt = new Dictionary<PointLatLng, int>();

        //Lista povezanosti NEUSMERENOG TEZINSKOG GRAFA
        //Ako hocemo USMERENI npr jednosmerne ulice itd. moracemo jos malo da se drkamo hehe
        private List<List<Tuple<int, double>>> adjList = new List<List<Tuple<int, double>>>();

        //Velicina grafa, ujedno i INDEKS SLEDECEG CVORA KOJI DODAJEMO
        private int size = 0;

        public void Add(PointLatLng position)
        {
            intToMarker.Add(size, new GMarkerGoogle(position, GMarkerGoogleType.blue)); //dodajemo novi cvor u mapiranje
            pointToInt.Add(position, size);
            intToMarker[size].Tag = size.ToString();            //dodajemo tag (redni broj) objektu marker
            adjList.Add(new List<Tuple<int, double>>());        
            size++;

        }


        public void AddEdge(GMapMarker marker1, GMapMarker marker2, double weight=0) //Funkcija za dodavanje grane izmednju postojecih cvorova
        {
            weight = Form1.distance(marker1, marker2.Position.Lat, marker2.Position.Lng);
            int index1 = int.Parse(marker1.Tag.ToString());
            int index2 = int.Parse(marker2.Tag.ToString());
            adjList[index1].Add(new Tuple<int, double>(index2, weight));
            adjList[index2].Add(new Tuple<int, double>(index1, weight));
        }


        public List<GMapRoute> getRoute(int u)    //Pravimo rutu od jednog cvora do svih suseda (test funkcija)
        {
            
            List<PointLatLng> pts = new List<PointLatLng>();
            List<GMapRoute> routes = new List<GMapRoute>();
            GMapRoute tmp;
            
            foreach (var vertex in adjList[u])
            {
                pts.Add(getMarkerFromInt(u).Position);
                pts.Add(new PointLatLng(intToMarker[vertex.Item1].Position.Lat, intToMarker[vertex.Item1].Position.Lng));
                tmp = new GMapRoute(pts, "");
                tmp.Stroke = new Pen(Color.Red, 3);
                routes.Add(tmp);
                pts.Clear();
            }
            GMapRoute route = new GMapRoute(pts, "");
            route.Stroke = new Pen(Color.Red, 3);
            return routes;
        }

        public GMapRoute getDijkstraRoute(PointLatLng pt1, PointLatLng pt2)
        {
            int u = pointToInt[pt1];
            int v = pointToInt[pt2];
            GMapRoute route = new GMapRoute("Dijsktra");
            int[] parent = Dijkstra(u, v);
            while(v != u)
            {
                route.Points.Add(intToMarker[v].Position);
                v = parent[v];
            }
            route.Points.Add(intToMarker[u].Position);
            route.Stroke = new Pen(Color.Green, 5);
            return route;
        }

        public int[]  Dijkstra(int pocetniCvor, int zavrsniCvor)
        {

            int[] prethodnik = new int[size]; //Definisemo prethodni cvor svakog elementa u najkracem putu i onda cemo unazad procitati, tj. iscrtati put
            for (int i = 0; i < size; i++)
                prethodnik[i] = -1;



            double[] cenaDo = new double[size];// Pamti cenu od poocetnog do i-tog cvora.
                                                      //Postavljamo sve ceneDo u pocetku na "beskonacno", nama je ok da bude negativna vrednost, posto su sve tezine pozitivne.

            SortedSet<DolazniPut> putevi = new SortedSet<DolazniPut>(); //Skladistimo predjene puteve 

            double infinity = 1.7976931348623157E+308;
            for (int i = 0; i < size; i++)
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

                for (int i = 0; i < adjList[prethodniCvor].Count; i++)
                {
                    int trenutni = adjList[prethodniCvor][i].Item1;
                    double grana = adjList[prethodniCvor][i].Item2;
                    double trenutnaCena = cenaDo[prethodniCvor] + grana;
                    if (trenutnaCena < cenaDo[trenutni])
                    {
                        putevi.Remove(new DolazniPut(trenutni, cenaDo[trenutni]));//Brisemo trenutni put do cvora, da ne bismo prolazili posle opet kroz sve susede
                        cenaDo[trenutni] = trenutnaCena;
                        putevi.Add(new DolazniPut(trenutni, cenaDo[trenutni]));// Dodali smo novi najkraci put nakon promene 
                        prethodnik[trenutni] = prethodniCvor;//Znamo da je prethodni cvor koji je vodio do naseg trenutnog cvora, zapravo ovaj cvor
                    }

                }

            }

            return prethodnik;
        }
        public GMapMarker getMarkerFromInt(int u)
        {
            return intToMarker[u];
        }

        public int getSize()
        {
            return size;
        }

    }
}
