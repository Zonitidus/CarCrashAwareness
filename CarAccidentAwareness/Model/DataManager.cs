using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.OleDb;
using GMap.NET;

namespace CarAccidentAwareness.Model
{
    class DataManager
    {
        private Dictionary<string, string> dictFieldsFilter = new Dictionary<string, string>();
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
            List<List<String>> data = ReadData(path);
            double lat;
            double lng;

            for (int i = 1; i < data.Count; i++)
            {
                DataRow row = dt.NewRow();

                for (int j = 0; j < data[0].Count; j++)
                {
                    try
                    {
                        if (j == 0)
                        {

                            string id = data[i][j].Replace("\"", "");
                            row[0] = id;

                        }
                        else if (j == 2)
                        {

                            string[] arrayHour = data[i][j].Split(' ');
                            string hourAccident = arrayHour[1] + arrayHour[2].ToLower();
                            row[2] = arrayHour.Length == 3 ? hourAccident : "-";

                        }
                        else if (j == 4)
                        {
                            string geoRef = data[i][j].Replace("(", "").Replace(")", "").Replace("\"", "");
                            string[] arrayGeoRef = geoRef.Split(' ');
                            lat = double.Parse(arrayGeoRef[0], System.Globalization.CultureInfo.InvariantCulture);
                            lng = double.Parse(arrayGeoRef[1], System.Globalization.CultureInfo.InvariantCulture);
                            row[4] = data[i][j];
                            row[5] = lat;
                            row[6] = lng;
                        }
                        else
                        {
                            row[j] = data[i][j];
                        }
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(i);
                    }
                }
                dt.Rows.Add(row);
            }
            csvFile = new StreamReader(path);
            CreateDataToBarChart();
            return dt;
        }

        private List<List<String>> ReadData(String path)
        {
            StreamReader reader = new StreamReader(path);
            List<List<String>> temp = new List<List<string>>();
            String line = reader.ReadLine();
            String[] dataItem = line.Split(',');
            string unionString = "";
            /*for (int g = 0; g < dataItem.Length; g++)
            {
               // Console.WriteLine(dataItem[g]);
                CreateDataTable(dataItem[g]);
            }*/


            //---------------------------------------------
            //---------------------------------------------
            //Se garantiza que sin importar el formato que se descargue tome estas colu
            createColumns(dt);
            //---------------------------------------------
            //---------------------------------------------

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

        public List<PointLatLng> GeoReferences(DataTable dt)
        {
            List<PointLatLng> geo = new List<PointLatLng>();
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    string georeference = Convert.ToString(dr.ItemArray[4]);
                    string[] coord = georeference.Split(' ');

                    double lat = double.Parse(coord[0].Substring(2), System.Globalization.CultureInfo.InvariantCulture);
                    double lng = double.Parse(coord[1].Remove(coord[1].Length - 2), System.Globalization.CultureInfo.InvariantCulture);

                    geo.Add(new PointLatLng(lat, lng));
                }
                catch (Exception e)
                {
                }

            }
            return geo;
        }

        public List<PointLatLng> GeoReferences(DataTable dt, String param, int column)
        {
            List<PointLatLng> geo = new List<PointLatLng>();
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (Convert.ToString(dr.ItemArray[column]).Equals(param))
                    {

                        string georeference = Convert.ToString(dr.ItemArray[4]);
                        string[] coord = georeference.Split(',');
                        double lat = double.Parse(coord[0].Substring(2), System.Globalization.CultureInfo.InvariantCulture);
                        double lng = double.Parse(coord[1].Remove(coord[1].Length - 2), System.Globalization.CultureInfo.InvariantCulture);

                        geo.Add(new PointLatLng(lat, lng));
                    }
                }
                catch (Exception e) { }
            }
            return geo;
        }

        private void createColumns(DataTable dtInstance)

        {

            dtInstance.Columns.Add("CcNumber", typeof(string));
            dtInstance.Columns.Add("Date", typeof(string));
            dtInstance.Columns.Add("Time", typeof(string));
            dtInstance.Columns.Add("AccidentType", typeof(string));
            dtInstance.Columns.Add("NewGeoreferencedColumn", typeof(string));
            dtInstance.Columns.Add("Lat", typeof(double));
            dtInstance.Columns.Add("Lng", typeof(double));
        }

        //Entry must be day/mont/year
        public List<PointLatLng> GeoReferences(DataTable dt, String minDate, String maxDate)
        {
            List<PointLatLng> geo = new List<PointLatLng>();

            string[] minDatet = minDate.Split('/');
            //YEAR - MONTH - DAY
            DateTime dateMin = new DateTime(Convert.ToInt32(minDatet[2]), Convert.ToInt32(minDatet[1]), Convert.ToInt32(minDatet[0]));

            string[] maxDatet = maxDate.Split('/');
            DateTime dateMax = new DateTime(Convert.ToInt32(maxDatet[2]), Convert.ToInt32(maxDatet[1]), Convert.ToInt32(maxDatet[0]));

            try
            {
                foreach (DataRow dr in dt.Rows)
                {

                    string[] stringDate = Convert.ToString(dr.ItemArray[1]).Split('/');
                    DateTime date = new DateTime(Convert.ToInt32(stringDate[2]), Convert.ToInt32(stringDate[1]), Convert.ToInt32(stringDate[0]));


                    if ((dateMin <= date) && (dateMax >= date))
                    {

                        string georeference = Convert.ToString(dr.ItemArray[4]);
                        string[] coord = georeference.Split(',');
                        double lat = double.Parse(coord[0].Substring(2), System.Globalization.CultureInfo.InvariantCulture);
                        double lng = double.Parse(coord[1].Remove(coord[1].Length - 2), System.Globalization.CultureInfo.InvariantCulture);

                        geo.Add(new PointLatLng(lat, lng));
                    }
                }

            }
            catch (Exception e) { }

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

        public Dictionary<string, string> LoadFieldsToFilter()
        {
            dictFieldsFilter.Add("CcNumber", "string");
            dictFieldsFilter.Add("Date", "number");
            dictFieldsFilter.Add("AccidentType", "categorical");
            dictFieldsFilter.Add("Lat", "number");
            dictFieldsFilter.Add("Lng", "number");

            return dictFieldsFilter;
        }


        public string GetValueFilter(string key)
        {
            return dictFieldsFilter[key];
        }

        public HashSet<string> getCategoricalElementsColumn(string columName)
        {
            var hashSetCatEleFilter = new HashSet<string>();

            foreach (DataRow row in dt.Rows)
            {
                hashSetCatEleFilter.Add(row[columName].ToString());
            }

            return hashSetCatEleFilter;
        }


        public DataTable FilterByColumnsCatText(string nameColumn, string dataFilter)
        {
            string expression = $"{nameColumn} = '{dataFilter}'";
            
            DataRow[] foundRows;
            DataTable dataTableResult = new DataTable();
            DataTable dtCopy = dt.Copy();
            foundRows = dtCopy.Select(expression);

            createColumns(dataTableResult);

            Console.WriteLine(foundRows.Length);
            for (int i = 0; i < foundRows.Length; i++)
            {

                try
                {

                    if (foundRows[i].ItemArray.Length == dtCopy.Columns.Count)
                    {
                        Console.WriteLine(foundRows[i].ItemArray.Length+ " == "+ dtCopy.Columns.Count);
                        dataTableResult.Rows.Add(foundRows[i].ItemArray);
                        //dataTableResult.ImportRow(foundRows[i]);
                    }
                    else
                    {
                        Console.WriteLine("AaaAAAAaaAAAAaaaA");
                    }

                   


                }
                catch (Exception e) {

                    if (i == 0)
                        Console.WriteLine(e.StackTrace);
                        Console.WriteLine(e.Message);
                }
            }

            //this.dt = dataTableResult;
            return dataTableResult;
        }


        public DataTable FilterByColumnsNumber(string nameColumn, string minValue, string maxValue, Boolean isDate)
        {
            string expression = isDate ? $"{nameColumn} > '{minValue}' And {nameColumn} < '{maxValue}'" : $"{nameColumn} > {minValue} And {nameColumn} < {maxValue}";
            DataRow[] foundRows;
            DataTable dataTableResult = new DataTable();
            DataTable dtCopy = dt.Copy();
            Console.WriteLine(" -------------------- Expresión: " + minValue);
            Console.WriteLine(" -------------------- Expresión: " + maxValue);
            Console.WriteLine(" -------------------- Expresión: "+expression);
            foundRows = dtCopy.Select(expression);

            createColumns(dataTableResult);

            Console.WriteLine(foundRows.Length);


            //if (minValue.Split('/').Length <= 1) {

                foreach (DataRow dr in foundRows)
                {
                    Console.WriteLine(dr.ItemArray[0]);
                    dataTableResult.Rows.Add(dr.ItemArray);
                }
            //}
           /* else {

                string[] minDatet = minValue.Split('/');
                //YEAR - MONTH - DAY
                DateTime dateMin = new DateTime(Convert.ToInt32(minDatet[2]), Convert.ToInt32(minDatet[1]), Convert.ToInt32(minDatet[0]));

                string[] maxDatet = maxValue.Split('/');
                DateTime dateMax = new DateTime(Convert.ToInt32(maxDatet[2]), Convert.ToInt32(maxDatet[1]), Convert.ToInt32(maxDatet[0]));


                foreach (DataRow dr in dtCopy.Rows)
                {
                    string[] date = Convert.ToString(dr.ItemArray[1]).Split('/');
                    DateTime dateD = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));

                    Console.WriteLine(dateD.ToString());
                    Console.WriteLine(dateMin.ToString());
                    Console.WriteLine(dateMax.ToString());



                    if ((dateD >= dateMin) && (dateD <= dateMax)) {

                        Console.WriteLine(dr.ItemArray[0]);
                        dataTableResult.Rows.Add(dr.ItemArray);
                    }
                }

            }*/

            Console.WriteLine(" -------------------- ENTró ----------");
            return dataTableResult;
        }

        private string AssingClasificationToField(String nameField)
        {
            switch (nameField)
            {
                case "CCNumber":
                    return "string";
                case "Date":
                    return "number";
                case "Time":
                    return "number";
                case "AccidentType":
                    return "categorical";
                case "New Georeferenced Column":
                    return "string";
                case "Lat":
                    return "number";
                case "Lng":
                    return "number";
                default:
                    return "default";
            }

        }

        public Dictionary<string, int> CreateDataToBarChart() 
        {
            Dictionary<string,int> dictNumberAccPerYear = new Dictionary<string, int>();
            DataRow[] foundRows = dt.Select();


            foreach (DataRow row in dt.Rows)
            {
                string[] arrayDate = row["Date"].ToString().Split('/');

                if (arrayDate.Length == 3 && !dictNumberAccPerYear.ContainsKey(arrayDate[2]))
                {
                    dictNumberAccPerYear.Add(arrayDate[2], 1);
                }
                else if (dictNumberAccPerYear.ContainsKey(arrayDate[2]))
                {
                    dictNumberAccPerYear[arrayDate[2]] = dictNumberAccPerYear[arrayDate[2]] + 1;
                }
                else 
                {
                    Console.WriteLine("Bad date format");
                }
            }

            return dictNumberAccPerYear;
        }


        public Dictionary<string, int> CreateDataToPieChart()
        {
            Dictionary<string, int> dictNumberTypeAccidents = new Dictionary<string, int>();
            DataRow[] foundRows = dt.Select();


            foreach (DataRow row in dt.Rows)
            {
                if (!row.Equals("") && !dictNumberTypeAccidents.ContainsKey(row["AccidentType"].ToString()))
                {
                    dictNumberTypeAccidents.Add(row["AccidentType"].ToString(), 1);
                }
                else if (dictNumberTypeAccidents.ContainsKey(row["AccidentType"].ToString()))
                {
                    dictNumberTypeAccidents[row["AccidentType"].ToString()] = dictNumberTypeAccidents[row["AccidentType"].ToString()] + 1;
                }
                else
                {
                    Console.WriteLine("Bad type accident format");
                }
            }

            return dictNumberTypeAccidents;
        }

        public Dictionary<string, int> CreateDataToPointsChart()
        {
            Dictionary<string, int> dictNumberAccPerMonth2020 = new Dictionary<string, int>();
            DataRow[] foundRows = dt.Select();


            foreach (DataRow row in dt.Rows)
            {
                
                if(row["Date"].ToString().Contains("/2020"))
                {
                    string[] arrayDate = row["Date"].ToString().Split('/');
                    string dateToRegister = arrayDate[0] + "-" + arrayDate[2];

                    if (arrayDate.Length == 3 && !dictNumberAccPerMonth2020.ContainsKey(dateToRegister))
                    {
                        dictNumberAccPerMonth2020.Add(dateToRegister, 1);
                    }
                    else if (dictNumberAccPerMonth2020.ContainsKey(dateToRegister))
                    {
                        dictNumberAccPerMonth2020[dateToRegister] = dictNumberAccPerMonth2020[dateToRegister] + 1;
                    }
                    else
                    {
                        Console.WriteLine("Bad date format");
                    }
                }
            }
            return dictNumberAccPerMonth2020;
        }
    }
}
