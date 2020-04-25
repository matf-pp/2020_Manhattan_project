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
using System.Threading;
using System.IO;


namespace WindowsFormsApp2
{

    
    public partial class Form1 : Form
    {
       
        private Graph graph = new Graph();
        private Graph graphPesaci = new Graph();
        private Graph graphVozila = new Graph();
        private Graph graphTaxi = new Graph();
        
        private GMapOverlay overlay = new GMapOverlay();    //sve cemo dodavati na jedan overlay                         
        private bool click_count = false;
        GMapMarker first;
        private bool dijkstra = false;
        private GMapRoute currentDijkstra;
        private int tarifa = 0;
       

       
        //Racunanje razdaljine izmedju dve tacke (tip argumenata menjamo po potrebi)
        public static double distance(GMapMarker marker1, double x1, double y1)     
        {
            List<PointLatLng> pts = new List<PointLatLng>();
            pts.Add(marker1.Position);
            pts.Add(new PointLatLng(x1, y1));
            GMapRoute route = new GMapRoute(pts, "");
            return route.Distance;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            /*
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(40.756132, -73.985926);
            */
            gmap.Overlays.Add(overlay);
            

            //Lukin deo za ucitavanje iz cvorova koje je uneo
            gmap.ShowCenter = false;
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(40.760348, -73.981530);
            gmap.DragButton = MouseButtons.Left;
            var mapa_Cvorova = new Dictionary<int, Tuple<double, double, string>>();


            GMapOverlay polygons = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(40.757233, -73.989947));
            points.Add(new PointLatLng(40.766829, -73.982916));
            points.Add(new PointLatLng(40.763006, -73.973813));
            points.Add(new PointLatLng(40.753410, -73.980861));
            GMapPolygon polygon = new GMapPolygon(points, "Jardin des Tuileries");
            polygons.Polygons.Add(polygon);
            polygon.Fill = new SolidBrush(Color.FromArgb(40, Color.Green));
            polygon.Stroke = new Pen(Color.Red, 1);
            gmap.Overlays.Add(polygons);

            GMapOverlay markers = new GMapOverlay("markers");

            string textFilePath = @"C:\Users\joksi\OneDrive\Desktop\MATF\Programske paradigme\Projekat\2020_Manhattan_project-master\menhetn_cvorovi.txt";
            System.IO.FileStream filestream = new System.IO.FileStream(textFilePath,
                                                      System.IO.FileMode.Open,
                                                      System.IO.FileAccess.Read,
                                                      System.IO.FileShare.ReadWrite);
            var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

            string linijaTeksta;
            while ((linijaTeksta = file.ReadLine()) != null)
            {
                if (linijaTeksta == String.Empty)
                {
                    break;
                }
                string[] splitPoTackaZarez = linijaTeksta.Split(';');
                string[] koordinate = splitPoTackaZarez[0].Split(',');
                double x = Convert.ToDouble(koordinate[0]);
                double y = Convert.ToDouble(koordinate[1]);
                PointLatLng point= new PointLatLng(x, y);
                GMapMarker marker = new GMarkerGoogle(
                    point,
                    GMarkerGoogleType.blue_pushpin);
                string[] splitPoRazmaku = splitPoTackaZarez[1].Split(' ');
                marker.ToolTipText = splitPoRazmaku[0];
               // mapa_Cvorova.Add(Convert.ToInt32(splitPoRazmaku[0]), new Tuple<double, double, string>(x, y, splitPoRazmaku[1]));
                markers.Markers.Add(marker);
            
                graph.Add(point);
                graphPesaci.Add(point);
                graphVozila.Add(point);
                graphTaxi.Add(point);
                gmap.Overlays[0].Markers.Add(graph.getMarkerFromInt(graph.getSize() - 1));
                
            }
          // gmap.Overlays.Add(markers);
            filestream.Close();

            
            //Ucitavam grane iz genersianih fajlova
            textFilePath = @"C:\Users\joksi\OneDrive\Desktop\MATF\Programske paradigme\Projekat\2020_Manhattan_project-master\granePesaci.txt";
            filestream = new System.IO.FileStream(textFilePath,
                                                      System.IO.FileMode.Open,
                                                      System.IO.FileAccess.Read,
                                                      System.IO.FileShare.ReadWrite);
            file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

            while ((linijaTeksta = file.ReadLine()) != null)
            {
                string[] grane = linijaTeksta.Split(',');
                int prviCvor = Convert.ToInt32(grane[0]);
                int drugiCvor = Convert.ToInt32(grane[1]);
                double tezina = Convert.ToDouble(grane[2]);
                graphPesaci.AddEdge(prviCvor, drugiCvor, tezina);// Ovako ce se dvosmerno uneti jer su u fajlu unesena oba smera grane
               
            }

            filestream.Close();

            // Moramo da vidimo da li se voznja obavlja u spicu ili ne. Ovde bi valjalo neki try-catch staviti definitivno.
            DateTime trenutnoLokalno = DateTime.UtcNow;
            TimeZoneInfo njujorkZona= TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime menhetnVreme=TimeZoneInfo.ConvertTimeFromUtc(trenutnoLokalno,njujorkZona);
            tarifa = 0;// ako nije ni spic ni posle 8 uvece za naplatu taksija
            if (menhetnVreme.Hour >= 16 && menhetnVreme.Hour <= 20)
                tarifa = 1;
            if (menhetnVreme.Hour >= 20 || menhetnVreme.Hour <= 6)
                tarifa = 2;

            //Paralelno cemo za taksi i vozila citanje obavljati
            //Formula taksija u Njujorku je : 2,5$ (pocetno) + 0.3$ (taksa) + 0.5$(po 1/5 milje) + 0.5$(po minutu) + 0.5$ (ako je tarifa==2) + 1$(ako je tarifa==1)
            //Zato je tezina grane za taksi 0.5*5/1.61*rastojanjeGrana+0.5*vremeGrana

            string rastojanjaPath = @"C:\Users\joksi\OneDrive\Desktop\MATF\Programske paradigme\Projekat\2020_Manhattan_project-master\razdaljinaVozila.txt";
            System.IO.FileStream filestreamRastojanja = new System.IO.FileStream(rastojanjaPath,
                                                      System.IO.FileMode.Open,
                                                      System.IO.FileAccess.Read,
                                                      System.IO.FileShare.ReadWrite);
            string linijaRastojanja;

            var fileRastojanja = new System.IO.StreamReader(filestreamRastojanja, System.Text.Encoding.UTF8, true, 128);

            textFilePath = @"C:\Users\joksi\OneDrive\Desktop\MATF\Programske paradigme\Projekat\2020_Manhattan_project-master\graneVremena.txt";
            filestream = new System.IO.FileStream(textFilePath,
                                                      System.IO.FileMode.Open,
                                                      System.IO.FileAccess.Read,
                                                      System.IO.FileShare.ReadWrite);
            file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

            while ((linijaTeksta = file.ReadLine()) != null && (linijaRastojanja=fileRastojanja.ReadLine())!=null)
            {
                //Ovo su vremena splitovanje
                string[] grane = linijaTeksta.Split(',');
                int prviCvor = Convert.ToInt32(grane[0]);
                int drugiCvor = Convert.ToInt32(grane[1]);
                string[] vremena = grane[2].Split(';');

                //Ovo su rastojanja za vozila splitovanje
                string[] rastojanja = linijaRastojanja.Split(',');
                int prviRastojanja = Convert.ToInt32(rastojanja[0]);
                int drugiRastojanja = Convert.ToInt32(rastojanja[1]);
                double razdaljina = Convert.ToDouble(rastojanja[2]);

                double tezina=0;//Odnosi se na vreme samo!
                if (tarifa == 1)
                    tezina = Convert.ToDouble(vremena[1]);
                else
                    tezina = Convert.ToDouble(vremena[0]);
                tezina =tezina/ 200.0;//Ovo obrisi posle i promeni u 60!
                graphVozila.AddEdge(prviCvor, drugiCvor, tezina);

                double tezinaRastojanja = 0.5 * 5 / 1.61 * razdaljina + tezina * 0.5;
                graphTaxi.AddEdge(prviRastojanja, drugiRastojanja, tezinaRastojanja);
            }

            filestream.Close();
            filestreamRastojanja.Close();

            

        }

        public void drawAllRoutes()
        {
            

            List<GMapRoute> routes;
            for(int i=0; i<graph.getSize(); i++)
            {
                routes = graph.getRoute(i);
                overlay.Markers.Add(graph.getMarkerFromInt(i));

                foreach (GMapRoute route in routes)
                {
                    gmap.Overlays[0].Routes.Add(route);
                }
            }
            
        }

        //ovde sam dodao parametar i graf sam po sebi kako bih mogao da manipulisem s grafovima manuelno/pesaci/vozila/taksi
        public void drawDijkstraRoute(PointLatLng pt1, PointLatLng pt2,int i)
        {

            double ukupno = 0;
            switch (i)
            {
                case 0:
                    var tmp = graph.getDijkstraRoute(pt1, pt2);
                    currentDijkstra = tmp.Item1;
                    ukupno = tmp.Item2;
                    break;
                case 1:
                    var tmpPesaci = graphPesaci.getDijkstraRoute(pt1, pt2);
                    currentDijkstra = tmpPesaci.Item1;
                    ukupno = tmpPesaci.Item2;
                    break;
                case 2:
                    var tmpVozila= graphVozila.getDijkstraRoute(pt1, pt2);
                    currentDijkstra = tmpVozila.Item1;
                    ukupno = tmpVozila.Item2;
                    break;
                case 3:
                    var tmpTaxi = graphTaxi.getDijkstraRoute(pt1, pt2);
                    currentDijkstra = tmpTaxi.Item1;
                    ukupno = tmpTaxi.Item2;
                    break;
            }
            
            
            gmap.Overlays[0].Routes.Add(currentDijkstra);

            switch (i)
            {
                case 0:
                    tbUkupno.Text = ukupno + "km";
                    break;
                case 1:
                    //brzina coveka kad pesaci je u proseku  4.5 km/h sto je 0.075 km/minut
                    double brzina = 0.075;
                    double vreme = ukupno / brzina;
                    tbUkupno.Text = vreme.ToString() + "  minuta";
                    break;
                case 2:
                    tbUkupno.Text = ukupno.ToString() + " minuta";
                    break;
                case 3:
                    ukupno += 2.8;
                    if (tarifa == 1)
                        ukupno += 1;
                    if (tarifa == 2)
                        ukupno += 0.5;
                    tbUkupno.Text = ukupno.ToString() + "$";
                    break;
            }
          
        }

        
        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e )
        {
            PointLatLng point = gmap.FromLocalToLatLng(e.X, e.Y);
            graph.Add(point);
            gmap.Overlays[0].Markers.Add(graph.getMarkerFromInt(graph.getSize() - 1));
        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
           
                 
            if (dijkstra && !click_count)
            {
                first = item;
                click_count = true;
                return;
            }
            if (dijkstra)
            {
                //Da bi se obrisao prethodni Djikstra
                gmap.Overlays[0].Routes.Remove(currentDijkstra);
                if (rbManuelno.Checked == true)
                    drawDijkstraRoute(first.Position, item.Position, 0);

                if (rbPeske.Checked == true)
                    drawDijkstraRoute(first.Position, item.Position, 1);

                if (rbVozilo.Checked == true)
                    drawDijkstraRoute(first.Position, item.Position, 2);

                if (rbTaksi.Checked == true)
                    drawDijkstraRoute(first.Position, item.Position, 3);
                
                click_count = false;
                dijkstra = false;
                return;
            }
            if (!click_count)
            {
                first = item;
                click_count = true;
            }
            else
            {
              
                graph.AddEdge(first, item);
                drawAllRoutes();
                click_count = false;
            }
                    
               
                  
        
        }

            
        private void label3_Click(object sender, EventArgs e)
        {
            dijkstra = true;
        }

        /*
        private void label8_Click(object sender, EventArgs e)
        {
            gmap.Overlays[0].Routes.Remove(currentDijkstra);
            tbUkupno.Text = "";
        }
        */
     
    }
}
