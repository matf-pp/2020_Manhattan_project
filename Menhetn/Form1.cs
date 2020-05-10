using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menhetn
{
    public partial class Manhattan_Project : Form
    {
        public Manhattan_Project()
        {
            InitializeComponent();
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            gmap.ShowCenter = false;
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(40.760348, -73.981530);
            gmap.DragButton = MouseButtons.Left;
            var mapa_Cvorova = new Dictionary<int, Tuple<double,double,string>>();


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
         
            string textFilePath =@"C:\Users\HP\source\repos\Menhetn\menhetn_cvorovi.txt";
            System.IO.FileStream filestream = new System.IO.FileStream(textFilePath,
                                                      System.IO.FileMode.Open,
                                                      System.IO.FileAccess.Read,
                                                      System.IO.FileShare.ReadWrite);
            var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

            string linijaTeksta;
            while ((linijaTeksta = file.ReadLine()) != null)
            {
                if (linijaTeksta == String.Empty) {
                    break;
                }
                string[] splitPoTackaZarez = linijaTeksta.Split(';');
                string[] koordinate = splitPoTackaZarez[0].Split(',');
                double x = Convert.ToDouble(koordinate[0]);
                double y = Convert.ToDouble(koordinate[1]);
                GMapMarker marker = new GMarkerGoogle(
                    new PointLatLng(x,y),
                    GMarkerGoogleType.blue_pushpin);
                string[] splitPoRazmaku = splitPoTackaZarez[1].Split(' '); 
                marker.ToolTipText =splitPoRazmaku[1] ;
                mapa_Cvorova.Add(Convert.ToInt32(splitPoRazmaku[0]), new Tuple<double,double,string>(x,y,splitPoRazmaku[1]));
                markers.Markers.Add(marker);
            }

            gmap.Overlays.Add(markers);

        }
    }
}
