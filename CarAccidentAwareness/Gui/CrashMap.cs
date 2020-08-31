using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarAccidentAwareness.Model;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace CarAccidentAwareness
{
    public partial class CrashMap : Form
    {
        OpenFileDialog ofd;
        DataManager dm;
        DataTable dt;

        public CrashMap()
        {
            String path = "Dataset/SMALL.csv";
            this.dt = dm.GetDataTable(path);
            this.dm = new DataManager();
            ofd = new OpenFileDialog();
            InitializeComponent();

        }

        private void map_Load(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.CanDragMap = true;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(39.26673266, -76.56170009);
            map.MinZoom = 0;
            map.MaxZoom = 24;
            map.Zoom = 12;
            map.ShowCenter = false;
            map.AutoScroll = true;

            List<String> coords = dm.GeoReferences(this.dt);

            GMapOverlay markerOverlay = new GMapOverlay();

            foreach (String coor in coords)
            {
                String[] coordenadas = coor.Split(' ');

                Console.WriteLine(coordenadas[0].Substring(2) + " " + coordenadas[1].Remove(coordenadas[1].Length - 2));

                double lat = Convert.ToDouble(coordenadas[0].Substring(2));
                double lng = Convert.ToDouble(coordenadas[1].Remove(coordenadas[1].Length - 2));


                var marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red);
                marker.IsVisible = true;
                markerOverlay.Markers.Add(marker);

                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = string.Format("Location: \n Lat: {0} \n Lng: {1}", lat, lng);

            }

            map.Overlays.Add(markerOverlay);
        }
    }
}
