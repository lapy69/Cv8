using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv8
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = "TXT.txt";
            string SavePath = "TXT2.txt";

            TemperatureArchive temperatures = new TemperatureArchive();

            temperatures.Load(Path);

            temperatures.PrintTemperatures();
            temperatures.PrintAnnualAverageTemperature();
            temperatures.PrintMonthlyAverageTemperature();

            temperatures.Calibration(1);
            temperatures.PrintTemperatures();

            temperatures.Search(2018);

            temperatures.Save(SavePath);

            Console.ReadLine();
        }
    }
}
