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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       
        private Graph graph = new Graph();
        private GMapOverlay overlay = new GMapOverlay();    //sve cemo dodavati na jedan overlay                         
        private bool click_count = false;
        GMapMarker first;
        private bool dijkstra = false;
        private GMapRoute currentDijkstra;

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
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(40.756132, -73.985926);

            

            gmap.Overlays.Add(overlay);
            
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

        public void drawDijkstraRoute(PointLatLng pt1, PointLatLng pt2)
        {
            GMapRoute dijkstraRoute = graph.getDijkstraRoute(pt1, pt2);
            currentDijkstra = dijkstraRoute;
            gmap.Overlays[0].Routes.Add(dijkstraRoute);
            textBox3.Text = dijkstraRoute.Distance.ToString() + "km";
        }

        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PointLatLng point = gmap.FromLocalToLatLng(e.X, e.Y);
            graph.Add(point);
            gmap.Overlays[0].Markers.Add(graph.getMarkerFromInt(graph.getSize() - 1));
        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if(dijkstra && !click_count)
            {
                first = item;
                click_count = true;
                return;
            }
            if(dijkstra)
            {
                drawDijkstraRoute(first.Position, item.Position);
                click_count = false;
                dijkstra = false;
                return;
            }
            if(!click_count)
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

        private void label8_Click(object sender, EventArgs e)
        {
            gmap.Overlays[0].Routes.Remove(currentDijkstra);
            textBox3.Text = "";
        }
    }
}
