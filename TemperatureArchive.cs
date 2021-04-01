using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cv8
{
    class TemperatureArchive
    {
        private SortedDictionary <double, YearTemperature> _archive;

        public void Load(string path)
        {
            StreamReader reader = File.OpenText(path);
            _archive = new SortedDictionary <double, YearTemperature>();

            string line;
 
            while ((line = reader.ReadLine()) != null)
            {
                int year = 0;
                List<double> temperatures = new List<double>();

                line = line.Replace(":", "");
                List<string> values = line.Split('\t').ToList();

                for (int i = 0; i < values.Count; i++)
                {
                    if (i == 0)
                    {
                        year = Convert.ToInt32(values[i]);
                    }
                    else
                    {
                        temperatures.Add(Convert.ToDouble(values[i]));
                    }
                }

                _archive.Add(year, new YearTemperature(year, temperatures));
            }
        }
        public void Save(string path)
        {
            StreamWriter writer = File.CreateText(path);

            foreach (var item in _archive.Values)
            {
                writer.Write("{0}:\t", item.Year);

                foreach (double temperature in item.MonthTemperatures)
                {
                    writer.Write("{0:0.0}\t", temperature);
                }

                writer.WriteLine();
            }

            writer.Close();
        }

        public void Calibration(double number)
        {
            foreach (var item in _archive.Values)
            {
                for (int i = 0; i < item.MonthTemperatures.Count; i++)
                {
                    item.MonthTemperatures[i] = item.MonthTemperatures[i] + number;
                }
            }
        }

        public void Search(int y)
        {
            if (_archive.ContainsKey(y))
            {
                Console.Write("\n\n{0}:\t", y);

                foreach (double temperature in _archive[y].MonthTemperatures)
                {
                    Console.Write("{0:0.0}\t", temperature);
                }
            }
            else
            {
                Console.WriteLine("Year not found");
            }   
        }

        public void PrintTemperatures()
        {
            foreach (var item in _archive.Values)
            {
                Console.Write("\n{0}:\t", item.Year);

                foreach (double temperature in item.MonthTemperatures)
                {
                    Console.Write("{0:0.0}\t", temperature);
                }
            }
        }

        public void PrintAnnualAverageTemperature()
        {
            Console.WriteLine("\n");
            foreach (var item in _archive.Values)
            {
                Console.WriteLine("{0}: {1:0.0}", item.Year, item.AnnualAvgTemperature);
            }
        }

        public void PrintMonthlyAverageTemperature()
        {
            List<double> AvgMonthTemp = new List<double>();
            
            for (int i = 0; i < 12; i++)
            {
                AvgMonthTemp.Add(0);
            }

            foreach (var item in _archive.Values)
            {
                for (int i = 0; i < item.MonthTemperatures.Count; i++)
                {
                    AvgMonthTemp[i] = AvgMonthTemp[i] + item.MonthTemperatures[i];
                }
            }

            Console.WriteLine("\nAvgMothlyTemperature:\t");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("{0:0.0}\t", AvgMonthTemp[i] / _archive.Keys.Count);
            }
        }
    }
}
