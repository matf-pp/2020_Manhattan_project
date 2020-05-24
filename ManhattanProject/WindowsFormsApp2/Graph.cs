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
using System.IO;

namespace WindowsFormsApp2
{
    //Pomocna klasa za Milojevog Dijkstru
    class IncomingPath : IComparable
    {
        
        private int vertex;
        private double weight;

        public IncomingPath(int mark, double t)
        {
            vertex = mark;
            weight = t;
        }

        public int getVertex()
        {
            return vertex;
        }
        public double getWeight()
        {
            return weight;
        }

        public void setweight(double t)
        {
            weight = t;
        }
        public static bool operator <(IncomingPath x, IncomingPath y)
            => x.weight < y.weight;
        public static bool operator >(IncomingPath x, IncomingPath y)
            => x.weight > y.weight;

        public int CompareTo(Object obj)
        {
            IncomingPath second = obj as IncomingPath;
            return this.weight.CompareTo(second.weight);
        }
    }
    // VLADAN:
    // marker ~ cvor grafa
    // GMapMarker, int i PointLatLng mozemo koristiti za cvorove
    // Lako prelazimo sa jednog na drugo, opisano je ovde ispod

    // GMapMarker -> int ===> int.Parse(marker.Tag.toSring())    (Tag - polje objekta marker, u njemu cuvamo i redni broj markera)
    // int -> GMapMarker ===> getMarkerFromInt(i) ili intToMarker[i] (privatno, u klasi)
    // GMapMarker -> PointLatLng ===> marker.Position
    // PointLatLng -> GMapMarker ===> new GMapMarker(point)
    // PointLatLng -> int ===> getIntFromPosition(point)
 
    class Graph
    {

        //Za ispis u fajl tezine edge
        //private StreamWriter sw = new StreamWriter("graneVremenski.txt");
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
            intToMarker[size].Tag = size.ToString();  //dodajemo tag (redni broj) objektu marker
            adjList.Add(new List<Tuple<int, double>>());        
            size++;

        }

        public void AddEdge(int index1, int index2, double weight = 0) //Funkcija za dodavanje grane izmednju postojecih cvorova
        {
            adjList[index1].Add(new Tuple<int, double>(index2, weight));

            //Miloje: Sluzi za lakse pisanje u datoteku iz koje se kasnije cita
            //Jer nisu sve neusmerene grane! adjList[index2].Add(new Tuple<int, double>(index1, weight));
            //Dodajemo tezine edge u fajl dvosmerne za pesake, a jednosmerne za vozila!
            //sw.WriteLine(index1.ToString() + "," + index2.ToString() + "," + weight.ToString());
            // sw.WriteLine(index2.ToString() + "," + index1.ToString() + "," + weight.ToString());
            // sw.Flush();

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

        public double edgeWeight(int a,int b)
        {
            if (a < 0)
                return -1;
            
            foreach (var i in adjList[a])
            {
                if (i.Item1 == b)
                    return i.Item2;
            }
            return -1; // u slucaju greske
        }

        //Ovde sam modifikovao da dobijem i duzinu, zato imam tuple povratnu vrendost

            //LUKA: umesto da vraca tuple <GmapRoute,double> vracace <List<GmapMarker>,double>listu markera sadrzanih u optimalnom putu
            //..treba mi zbog ispisivanja imena znamenitosti iznad markera(ToolTextTip).
        public Tuple<List<GMapMarker>,double> getDijkstraRoute(PointLatLng pt1, PointLatLng pt2)
        {
            int u = pointToInt[pt1];
            int v = pointToInt[pt2];
            double duzina = 0;
            List<GMapMarker> listOfDijsktraMarkers = new List<GMapMarker>();
            int[] parent = Dijkstra(u, v);
            while(v != u)
            {
                listOfDijsktraMarkers.Add(intToMarker[v]);
                duzina += edgeWeight(parent[v],v);// obrnuto jer Dijkstra vraca cvorove unazad!
                v = parent[v];
            }
            listOfDijsktraMarkers.Add(intToMarker[u]);
            Tuple<List<GMapMarker>, double> final = new Tuple<List<GMapMarker>, double>(listOfDijsktraMarkers, duzina);
            return final;
        }

       

        public int[]  Dijkstra(int startVertex, int endVertex)
        {

            int[] predecessors = new int[size]; //Definisemo prethodni cvor svakog elementa u najkracem putu i onda cemo unazad procitati, tj. iscrtati put
            for (int i = 0; i < size; i++)
                predecessors[i] = -1;



            double[] priceTo = new double[size];// Pamti cenu od poocetnog do i-tog cvora.
                                                      //Postavljamo sve ceneDo u pocetku na "beskonacno", nama je ok da bude negativna vrednost, posto su sve tezine pozitivne.

            SortedSet<IncomingPath> paths = new SortedSet<IncomingPath>(); //Skladistimo predjene puteve 

            double infinity = 1.7976931348623157E+308;
            for (int i = 0; i < size; i++)
            {
                priceTo[i] = infinity;
            }

            priceTo[startVertex] = 0;
            paths.Add(new IncomingPath(startVertex, 0));


            while (paths.Count != 0)
            {
                IncomingPath v = paths.Min;
                paths.Remove(v);
                int previousVertex = v.getVertex();
                double previousWeight = v.getWeight();

                for (int i = 0; i < adjList[previousVertex].Count; i++)
                {
                    int tmpVertex = adjList[previousVertex][i].Item1;
                    double edge = adjList[previousVertex][i].Item2;
                    double currentPrice = priceTo[previousVertex] + edge;
                    if (currentPrice < priceTo[tmpVertex])
                    {
                        paths.Remove(new IncomingPath(tmpVertex, priceTo[tmpVertex]));//Brisemo trenutni put do cvora, da ne bismo prolazili posle opet kroz sve susede
                        priceTo[tmpVertex] = currentPrice;
                        paths.Add(new IncomingPath(tmpVertex, priceTo[tmpVertex]));// Dodali smo novi najkraci put nakon promene 
                        predecessors[tmpVertex] = previousVertex;//Znamo da je prethodni cvor koji je vodio do naseg trenutnog cvora, zapravo ovaj cvor
                    }

                }

            }

            return predecessors;
        }
        public GMapMarker getMarkerFromInt(int u)
        {
            return intToMarker[u];
        }

        public int getIntFromPosition(PointLatLng pt)
        {
            return pointToInt[pt];
        }

        public int getSize()
        {
            return size;
        }

    }
}
