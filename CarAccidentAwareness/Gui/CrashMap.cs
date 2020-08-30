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
        OpenFileDialog ofd = new OpenFileDialog();
        DataManager dm = new DataManager();
        DataTable dt;
        GMapOverlay markerOverlay;

        public CrashMap()
        {


            InitializeComponent();

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "CSV (*.cvs)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.dt = dm.GetDataTable(ofd.FileName);
            }
        }

        private void UpdateMap() {

            GMapOverlay markers = new GMapOverlay("markers");

            List<String> x = new List<string>();
            x.Add("40.7128845408551, -74.00882950344852");
            x.Add("40.709999129321915, -74.0059413");

            int i = 0;
            while (i<2)
            {



                String[] coor = ((String)x[i]).Split(',');

                PointLatLng point = new PointLatLng(Convert.ToDouble(coor[0]), Convert.ToDouble(coor[1]));
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red);

                markers.Markers.Add(marker);

                i += 1;
            }


            map.Overlays.Add(markers);

        }


        private void CrashMap_Load(Object sender, EventArgs e) {

            map.DragButton = MouseButtons.Left;
            map.CanDragMap = true;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(40.7127837, -74.0059413);
            map.MinZoom = 0;
            map.MaxZoom = 24;
            map.Zoom = 9;
            map.AutoScroll = true;

            markerOverlay = new GMapOverlay();
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(40.7128845408551, -74.00882950344852), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Location: \n Lat:{0} \n Long: {1}", 40.7128845408551, -74.00882950344852);



            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(40.71107898822419, -74.00656786561852), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker2);

            marker2.ToolTipMode = MarkerTooltipMode.Always;
            marker2.ToolTipText = string.Format("Location: \n Lat:{0} \n Long: {1}", 40.71107898822419, -74.00656786561852);




            map.Overlays.Add(markerOverlay);
        }
    }
}