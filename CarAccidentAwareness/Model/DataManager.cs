using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace CarAccidentAwareness.Model
{
    class DataManager
    {
        private StreamReader csvFile;
        private DataTable dt = new DataTable();

        public DataTable Dt
        {
            get { return dt; }
        }

        public DataManager()
        {
            dt = new DataTable();
        }


        public DataTable GetDataTable(String path)
        {
            Console.WriteLine("Entro 1");
            List<List<String>> data = ReadData(path);
            Console.WriteLine("Entro 1.5");
            for (int i = 0; i < data.Count; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < data[0].Count; j++)
                {
                    try
                    {
                        row[j] = data[i][j];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(i);
                    }
                }
                dt.Rows.Add(row);
            }

            Console.WriteLine("Entro 4");
            csvFile = new StreamReader(path);
            return dt;
        }
        private List<List<String>> ReadData(String path)
        {
            StreamReader reader = new StreamReader(path);
            List<List<String>> temp = new List<List<string>>();
            String line = reader.ReadLine();
            String[] dataItem = line.Split(',');
            string unionString = "";
            for (int g = 0; g < dataItem.Length; g++)
            {
                CreateDataTable(dataItem[g]);
            }
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                dataItem = line.Split(',');
                List<String> item = new List<string>();
                for (int i = 0; i < dataItem.Length - 1; i++)
                {
                    if (i == 4)
                    {
                        unionString = dataItem[i] + dataItem[i + 1];
                        item.Add(unionString);
                    }
                    if (i < 4)
                    {
                        item.Add(dataItem[i]);
                    }

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

        public List<string> GeoReferences(DataTable dt)
        {
            List<String> geo = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {

                Console.WriteLine("GEOOOOO: " + dr.ItemArray[4]);
                geo.Add(Convert.ToString(dr.ItemArray[4]));
                //String temp = (String)dr["New Georeferenced Column"];
                //Console.Write("GEOOOOO: "+temp.ToString());
                //geo.Add(temp);
            }
            return geo;
        }

        public DataTable ReadCsv(string fileName)
        {
            DataTable dt = new DataTable("Data");
            using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                Path.GetDirectoryName(fileName) + "\";Extended Properties='text;HDR=yes;FMT=Delimited(,)';"))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format("select *from[{0}]", new FileInfo(fileName).Name), cn))
                {
                    cn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

            }
            csvFile = new StreamReader(fileName);
            return dt;
        }

        public Dictionary<string, string> loadFieldsToFilter()
        {
            Dictionary<string, string> dictFieldsFilter = new Dictionary<string, string>();

            using (var rd = csvFile)
            {
                int i = 0;
                while (!rd.EndOfStream && i == 0)
                {
                    var splitsFields = rd.ReadLine().Split(',');
                    foreach (string fieldName in splitsFields)
                    {
                        Console.WriteLine(AssingClasificationToField(fieldName));
                        dictFieldsFilter.Add(fieldName, AssingClasificationToField(fieldName));
                    }
                    i++;
                }

            }
            return dictFieldsFilter;
        }

        private string AssingClasificationToField(String nameField)
        {

            switch (nameField)
            {
                case "CC Number":
                    return "string";
                case "Date":
                    return "string";
                case "Time":
                    return "string";
                case "Accident Type":
                    return "categorical";
                case "New Georeferenced Column":
                    return "string";
                default:
                    return "default";
            }

        }
    }
}
