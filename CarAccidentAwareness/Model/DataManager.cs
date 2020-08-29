using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace CarAccidentAwareness.Model
{
    class DataManager
    {
        DataTable dt = new DataTable();
        public DataTable GetDataTable(String path)
        {
            List<List<String>> data = ReadData(path);
            for (int i = 0; i < data.Count; i++)
            {
                DataRow row = dt.NewRow();


                for (int j = 0; j < data.Count - 1; j++)
                {
                    row[j] = data[i][j];
                    //row[1] = data[i][1];
                    //row[2] = data[i][2];
                    //row[3] = data[i][3];
                    //row[4] = data[i][4];
                    //row[j] = data[i][0];
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        private List<List<String>> ReadData(String path)
        {
            StreamReader reader = new StreamReader(path);
            List<List<String>> temp = new List<List<string>>();
            String line = reader.ReadLine();
            String[] dataItem = line.Split(',');
            for (int g = 0; g < dataItem.Length; g++)
            {
                CreateDataTable(dataItem[g]);
            }
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                dataItem = line.Split(',');
                List<String> item = new List<string>();
                for (int i = 0; i < dataItem.Length; i++)
                {
                    item.Add(dataItem[i]);
                }
                temp.Add(item);
            }
            return temp;
        }
        private void CreateDataTable(string columnName)
        {
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = columnName;
            dt.Columns.Add(column);
        }
    }
}
