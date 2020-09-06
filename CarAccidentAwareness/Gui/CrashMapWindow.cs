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
using System.Windows.Forms.DataVisualization.Charting;

namespace CarAccidentAwareness
{
    public partial class CrashMapWindow : Form
    {

        private DataManager dataManager;
        private string filterNameSelected;
        private string filterTypeSelected;

        public CrashMapWindow()
        {
            //String path = "../MDTA_Accidents_2.csv";
            dataManager = new DataManager();
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
        }

        private void UpdateMap()
        {

            List<PointLatLng> coords = dataManager.GeoReferences(dataManager.Dt);

            GMapOverlay markerOverlay = new GMapOverlay();

            foreach (PointLatLng coor in coords)
            {
                try
                {
                    var marker = new GMarkerGoogle(coor, GMarkerGoogleType.red);
                    marker.IsVisible = true;
                    markerOverlay.Markers.Add(marker);

                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTipText = string.Format("Location: \n Lat: {0} \n Lng: {1}", coor.Lat, coor.Lng);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.StackTrace);
                }

            }

            map.Overlays.Add(markerOverlay);

        }

        private void btnLoadInfo_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        dataGridInfoLoaded.DataSource = dataManager.GetDataTable(ofd.FileName);
                        foreach (var itemFieldName in dataManager.LoadFieldsToFilter())
                        {
                            comboBoxSelFilter.Items.Add(itemFieldName.Key);
                        }
                        UpdateMap();
                    };
                }
                //Create Charts
                DrawBarsChart(dataManager.CreateDataToBarChart());
                DrawPieChart(dataManager.CreateDataToPieChart());
                DrawPointsChart(dataManager.CreateDataToPointsChart());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }
        private void comboBoxSelFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTypeSelected = dataManager.GetValueFilter(comboBoxSelFilter.SelectedItem.ToString());
            filterNameSelected = comboBoxSelFilter.SelectedItem.ToString();
            filterCategorical.Items.Clear();
            if (filterTypeSelected.Equals("categorical") && filterNameSelected.Equals("AccidentType"))
            {
                var hashSetCatEleFilter = dataManager.getCategoricalElementsColumn(comboBoxSelFilter.SelectedItem.ToString());
                foreach (string item in hashSetCatEleFilter)
                {
                    filterCategorical.Items.Add(item);
                }
            }
            AllowFilterByItemSelected(filterTypeSelected);
        }


        private void AllowFilterByItemSelected(string key)
        {

            switch (key)
            {
                case "categorical":
                    filterCategorical.Visible = true;
                    labelFilterCategorical.Visible = true;
                    //------------------------
                    filterMinValue.Visible = false;
                    labelFilterMinValue.Visible = false;
                    filterMaxValue.Visible = false;
                    labelFilterMaxValue.Visible = false;
                    filterText.Visible = false;
                    labelFilterText.Visible = false;
                    break;
                case "number":
                    filterMinValue.Visible = true;
                    labelFilterMinValue.Visible = true;
                    filterMaxValue.Visible = true;
                    labelFilterMaxValue.Visible = true;
                    //------------------------
                    filterCategorical.Visible = false;
                    labelFilterCategorical.Visible = false;
                    filterText.Visible = false;
                    labelFilterText.Visible = false;

                    break;
                case "string":
                    filterText.Visible = true;
                    labelFilterText.Visible = true;
                    //------------------------
                    filterCategorical.Visible = false;
                    labelFilterCategorical.Visible = false;
                    filterMinValue.Visible = false;
                    labelFilterMinValue.Visible = false;
                    filterMaxValue.Visible = false;
                    labelFilterMaxValue.Visible = false;
                    break;
            }

        }

        private void DrawBarsChart(Dictionary<string, int> dictValuesChart)
        {
            diagramBars.Titles.Add("Report Number of Transit Accidents since 2012 to 2020 in USA");
            
            var list = dictValuesChart.Keys.ToList();
            list.Sort();

            foreach (var key in list)
            {
                diagramBars.Series["Series1"].Points.AddXY(key, dictValuesChart[key]);
            }
        }


        private void DrawPieChart(Dictionary<string, int> dictValuesChart)
        {
            dragramPie.Titles.Add("Report Number of Transit Accidents per Type of Accidente since 2012 to 2020 in USA");
            dragramPie.Series["Series1"].IsValueShownAsLabel = true;

            foreach (KeyValuePair<string, int> item in dictValuesChart)
            {

                Console.WriteLine("Key = {0}, Value = {1}",
                              item.Key, item.Value);

                dragramPie.Series["Series1"].Points.AddXY(item.Key, item.Value);
            }
        }


        private void DrawPointsChart(Dictionary<string, int> dictValuesChart)
        {
            diagramPoints.Titles.Add("Report Number of Transit Accidents since 01-2020 to 07-2020 in USA");

            var list = dictValuesChart.Keys.ToList();
            list.Sort();

            foreach (var key in list)
            {
                diagramPoints.Series["Series1"].Points.AddXY(key, dictValuesChart[key]);
            }
        }

        private void minValueFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            switch (filterTypeSelected)
            {
                case "string":
                    dataManager.FilterByColumnsCatText(filterNameSelected, filterText.Text);
                    break;
                case "categorical":
                    dataManager.FilterByColumnsCatText(filterNameSelected, filterCategorical.SelectedItem.ToString());
                    break;
                case "number":
                    dataManager.FilterByColumnsNumber(filterNameSelected,filterMinValue.Text, filterMaxValue.Text,true);
                    break;
            }
        }
    }
}
