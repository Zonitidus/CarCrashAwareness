using CarAccidentAwareness.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CarAccidentAwareness
{
    public partial class CrashMap : Form
    {
        DataManager dataManage;
        public CrashMap()
        {
            InitializeComponent();
            dataManage = new DataManager();
        }

        private void btnLoadInfo_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        /*dataGridInfoLoaded.DataSource = dataManage.ReadCsv(ofd.FileName);

                        foreach(var itemFieldName in dataManage.loadFieldsToFilter())
                        {
                            comboBoxSelFilter.Items.Add(itemFieldName.Key);
                        }*/
                        dataGridInfoLoaded.DataSource = dataManage.GetDataTable(ofd.FileName);

                        foreach (var itemFieldName in dataManage.loadFieldsToFilter())
                        {
                            comboBoxSelFilter.Items.Add(itemFieldName.Key);
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
