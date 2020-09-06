namespace CarAccidentAwareness
{
    partial class CrashMapWindow
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSelFilter = new System.Windows.Forms.ComboBox();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.btnLoadInfo = new System.Windows.Forms.Button();
            this.dataGridInfoLoaded = new System.Windows.Forms.DataGridView();
            this.filterCategorical = new System.Windows.Forms.ComboBox();
            this.labelFilterCategorical = new System.Windows.Forms.Label();
            this.filterMinValue = new System.Windows.Forms.TextBox();
            this.filterMaxValue = new System.Windows.Forms.TextBox();
            this.filterText = new System.Windows.Forms.TextBox();
            this.labelFilterMinValue = new System.Windows.Forms.Label();
            this.labelFilterMaxValue = new System.Windows.Forms.Label();
            this.labelFilterText = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.diagramBars = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.diagramPoints = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dragramPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInfoLoaded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagramBars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagramPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragramPie)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter:";
            // 
            // comboBoxSelFilter
            // 
            this.comboBoxSelFilter.FormattingEnabled = true;
            this.comboBoxSelFilter.Location = new System.Drawing.Point(295, 26);
            this.comboBoxSelFilter.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSelFilter.Name = "comboBoxSelFilter";
            this.comboBoxSelFilter.Size = new System.Drawing.Size(224, 21);
            this.comboBoxSelFilter.TabIndex = 1;
            this.comboBoxSelFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelFilter_SelectedIndexChanged);
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(720, 95);
            this.map.Margin = new System.Windows.Forms.Padding(2);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(570, 334);
            this.map.TabIndex = 2;
            this.map.Zoom = 0D;
            this.map.Load += new System.EventHandler(this.map_Load);
            // 
            // btnLoadInfo
            // 
            this.btnLoadInfo.Location = new System.Drawing.Point(12, 15);
            this.btnLoadInfo.Name = "btnLoadInfo";
            this.btnLoadInfo.Size = new System.Drawing.Size(198, 41);
            this.btnLoadInfo.TabIndex = 3;
            this.btnLoadInfo.Text = "Load Info";
            this.btnLoadInfo.UseVisualStyleBackColor = true;
            this.btnLoadInfo.Click += new System.EventHandler(this.btnLoadInfo_Click_1);
            // 
            // dataGridInfoLoaded
            // 
            this.dataGridInfoLoaded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInfoLoaded.Location = new System.Drawing.Point(12, 95);
            this.dataGridInfoLoaded.Name = "dataGridInfoLoaded";
            this.dataGridInfoLoaded.Size = new System.Drawing.Size(703, 334);
            this.dataGridInfoLoaded.TabIndex = 4;
            // 
            // filterCategorical
            // 
            this.filterCategorical.FormattingEnabled = true;
            this.filterCategorical.Location = new System.Drawing.Point(533, 26);
            this.filterCategorical.Name = "filterCategorical";
            this.filterCategorical.Size = new System.Drawing.Size(121, 21);
            this.filterCategorical.TabIndex = 5;
            this.filterCategorical.Visible = false;
            // 
            // labelFilterCategorical
            // 
            this.labelFilterCategorical.AutoSize = true;
            this.labelFilterCategorical.Location = new System.Drawing.Point(530, 5);
            this.labelFilterCategorical.Name = "labelFilterCategorical";
            this.labelFilterCategorical.Size = new System.Drawing.Size(84, 13);
            this.labelFilterCategorical.TabIndex = 6;
            this.labelFilterCategorical.Text = "Filter categorical";
            this.labelFilterCategorical.Visible = false;
            // 
            // filterMinValue
            // 
            this.filterMinValue.Location = new System.Drawing.Point(530, 26);
            this.filterMinValue.Name = "filterMinValue";
            this.filterMinValue.Size = new System.Drawing.Size(100, 20);
            this.filterMinValue.TabIndex = 7;
            this.filterMinValue.Visible = false;
            this.filterMinValue.TextChanged += new System.EventHandler(this.minValueFilter_TextChanged);
            // 
            // filterMaxValue
            // 
            this.filterMaxValue.Location = new System.Drawing.Point(640, 26);
            this.filterMaxValue.Name = "filterMaxValue";
            this.filterMaxValue.Size = new System.Drawing.Size(100, 20);
            this.filterMaxValue.TabIndex = 8;
            this.filterMaxValue.Visible = false;
            // 
            // filterText
            // 
            this.filterText.Location = new System.Drawing.Point(530, 27);
            this.filterText.Name = "filterText";
            this.filterText.Size = new System.Drawing.Size(100, 20);
            this.filterText.TabIndex = 9;
            this.filterText.Visible = false;
            // 
            // labelFilterMinValue
            // 
            this.labelFilterMinValue.AutoSize = true;
            this.labelFilterMinValue.Location = new System.Drawing.Point(530, 5);
            this.labelFilterMinValue.Name = "labelFilterMinValue";
            this.labelFilterMinValue.Size = new System.Drawing.Size(75, 13);
            this.labelFilterMinValue.TabIndex = 10;
            this.labelFilterMinValue.Text = "Min value filter";
            this.labelFilterMinValue.Visible = false;
            this.labelFilterMinValue.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelFilterMaxValue
            // 
            this.labelFilterMaxValue.AutoSize = true;
            this.labelFilterMaxValue.Location = new System.Drawing.Point(637, 5);
            this.labelFilterMaxValue.Name = "labelFilterMaxValue";
            this.labelFilterMaxValue.Size = new System.Drawing.Size(78, 13);
            this.labelFilterMaxValue.TabIndex = 11;
            this.labelFilterMaxValue.Text = "Max value filter";
            this.labelFilterMaxValue.Visible = false;
            this.labelFilterMaxValue.Click += new System.EventHandler(this.label4_Click);
            // 
            // labelFilterText
            // 
            this.labelFilterText.AutoSize = true;
            this.labelFilterText.Location = new System.Drawing.Point(527, 6);
            this.labelFilterText.Name = "labelFilterText";
            this.labelFilterText.Size = new System.Drawing.Size(50, 13);
            this.labelFilterText.TabIndex = 12;
            this.labelFilterText.Text = "Text filter";
            this.labelFilterText.Visible = false;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(786, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(142, 39);
            this.btnFilter.TabIndex = 13;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // diagramBars
            // 
            chartArea1.Name = "ChartArea1";
            this.diagramBars.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.diagramBars.Legends.Add(legend1);
            this.diagramBars.Location = new System.Drawing.Point(12, 492);
            this.diagramBars.Name = "diagramBars";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.diagramBars.Series.Add(series1);
            this.diagramBars.Size = new System.Drawing.Size(409, 300);
            this.diagramBars.TabIndex = 14;
            this.diagramBars.Text = "chart1";
            // 
            // diagramPoints
            // 
            chartArea2.Name = "ChartArea1";
            this.diagramPoints.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.diagramPoints.Legends.Add(legend2);
            this.diagramPoints.Location = new System.Drawing.Point(886, 492);
            this.diagramPoints.Name = "diagramPoints";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.diagramPoints.Series.Add(series2);
            this.diagramPoints.Size = new System.Drawing.Size(404, 300);
            this.diagramPoints.TabIndex = 15;
            this.diagramPoints.Text = "chart2";
            // 
            // dragramPie
            // 
            chartArea3.Name = "ChartArea1";
            this.dragramPie.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.dragramPie.Legends.Add(legend3);
            this.dragramPie.Location = new System.Drawing.Point(451, 492);
            this.dragramPie.Name = "dragramPie";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.dragramPie.Series.Add(series3);
            this.dragramPie.Size = new System.Drawing.Size(404, 300);
            this.dragramPie.TabIndex = 16;
            this.dragramPie.Text = "chart3";
            // 
            // CrashMapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 954);
            this.Controls.Add(this.dragramPie);
            this.Controls.Add(this.diagramPoints);
            this.Controls.Add(this.diagramBars);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.labelFilterText);
            this.Controls.Add(this.labelFilterMaxValue);
            this.Controls.Add(this.labelFilterMinValue);
            this.Controls.Add(this.filterText);
            this.Controls.Add(this.filterMaxValue);
            this.Controls.Add(this.filterMinValue);
            this.Controls.Add(this.labelFilterCategorical);
            this.Controls.Add(this.filterCategorical);
            this.Controls.Add(this.dataGridInfoLoaded);
            this.Controls.Add(this.btnLoadInfo);
            this.Controls.Add(this.map);
            this.Controls.Add(this.comboBoxSelFilter);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CrashMapWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInfoLoaded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagramBars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagramPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragramPie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSelFilter;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Button btnLoadInfo;
        private System.Windows.Forms.DataGridView dataGridInfoLoaded;
        private System.Windows.Forms.ComboBox filterCategorical;
        private System.Windows.Forms.Label labelFilterCategorical;
        private System.Windows.Forms.TextBox filterMinValue;
        private System.Windows.Forms.TextBox filterMaxValue;
        private System.Windows.Forms.TextBox filterText;
        private System.Windows.Forms.Label labelFilterMinValue;
        private System.Windows.Forms.Label labelFilterMaxValue;
        private System.Windows.Forms.Label labelFilterText;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataVisualization.Charting.Chart diagramBars;
        private System.Windows.Forms.DataVisualization.Charting.Chart diagramPoints;
        private System.Windows.Forms.DataVisualization.Charting.Chart dragramPie;
    }
}

