using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv8
{
    class YearTemperature
    {
        public int Year { get; private set; }

        public List<double> MonthTemperatures;

        public double MaxTemperature
        {
            get
            {
                return MonthTemperatures.Max();
            }
            private set
            {

            }
        }
        public double MinTemperature
        {
            get
            {
                return MonthTemperatures.Min();
            }
            private set
            {

            }
        }

        public double AnnualAvgTemperature
        {
            get
            {
                double temporary = 0.0;

                foreach (double temperature in MonthTemperatures)
                {
                    temporary = temporary + temperature;
                }

                return temporary/12.0;
            }
            private set
            {

            }
        }

        public YearTemperature(int y, List<double> t)
        {
            Year = y;
            MonthTemperatures = new List<double>();
            MonthTemperatures = t;
        }
    }
}
