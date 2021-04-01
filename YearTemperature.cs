﻿using System;
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

        public YearTemperature(int y, List<double> t)
        {
            Year = y;
            MonthTemperatures = new List<double>();
            MonthTemperatures = t;
        }
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
                return MonthTemperatures.Average();
            }
            private set
            {

            }
        }
    }
}
