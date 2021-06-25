using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarChartGettingStartedDesktop
{
    public class ChartViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ChartViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model(){ Category = "North", Value = 80 },
                new Model(){ Category = "NorthWest", Value = 87.5 },
                new Model(){ Category = "West", Value = 79 },
                new Model(){ Category = "SouthWest", Value = 83 },
                new Model(){ Category = "South", Value = 77.5 },
                new Model(){ Category = "SouthEast", Value = 90 },
                new Model(){ Category = "East", Value = 77.5 },
                new Model(){ Category = "NorthEast", Value = 85 },
            };
        }
    }
}
