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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSelFilter = new System.Windows.Forms.ComboBox();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.btnLoadInfo = new System.Windows.Forms.Button();
            this.dataGridInfoLoaded = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInfoLoaded)).BeginInit();
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
            // CrashMapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 568);
            this.Controls.Add(this.dataGridInfoLoaded);
            this.Controls.Add(this.btnLoadInfo);
            this.Controls.Add(this.map);
            this.Controls.Add(this.comboBoxSelFilter);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CrashMapWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInfoLoaded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSelFilter;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Button btnLoadInfo;
        private System.Windows.Forms.DataGridView dataGridInfoLoaded;
    }
}

