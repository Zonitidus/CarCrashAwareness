namespace CarAccidentAwareness
{
    partial class CrashMap
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
            this.btnLoadInfo = new System.Windows.Forms.Button();
            this.dataGridInfoLoaded = new System.Windows.Forms.DataGridView();
            this.comboBoxSelFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInfoLoaded)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadInfo
            // 
            this.btnLoadInfo.Location = new System.Drawing.Point(12, 12);
            this.btnLoadInfo.Name = "btnLoadInfo";
            this.btnLoadInfo.Size = new System.Drawing.Size(108, 36);
            this.btnLoadInfo.TabIndex = 0;
            this.btnLoadInfo.Text = "Load Information";
            this.btnLoadInfo.UseVisualStyleBackColor = true;
            this.btnLoadInfo.Click += new System.EventHandler(this.btnLoadInfo_Click);
            // 
            // dataGridInfoLoaded
            // 
            this.dataGridInfoLoaded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInfoLoaded.Location = new System.Drawing.Point(12, 54);
            this.dataGridInfoLoaded.Name = "dataGridInfoLoaded";
            this.dataGridInfoLoaded.Size = new System.Drawing.Size(588, 409);
            this.dataGridInfoLoaded.TabIndex = 1;
            // 
            // comboBoxSelFilter
            // 
            this.comboBoxSelFilter.FormattingEnabled = true;
            this.comboBoxSelFilter.Location = new System.Drawing.Point(209, 21);
            this.comboBoxSelFilter.Name = "comboBoxSelFilter";
            this.comboBoxSelFilter.Size = new System.Drawing.Size(178, 21);
            this.comboBoxSelFilter.TabIndex = 2;
            // 
            // CrashMap
            // 
            this.ClientSize = new System.Drawing.Size(1162, 494);
            this.Controls.Add(this.comboBoxSelFilter);
            this.Controls.Add(this.dataGridInfoLoaded);
            this.Controls.Add(this.btnLoadInfo);
            this.Name = "CrashMap";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInfoLoaded)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Button btnLoadInfo;
        private System.Windows.Forms.DataGridView dataGridInfoLoaded;
        private System.Windows.Forms.ComboBox comboBoxSelFilter;
    }
}

