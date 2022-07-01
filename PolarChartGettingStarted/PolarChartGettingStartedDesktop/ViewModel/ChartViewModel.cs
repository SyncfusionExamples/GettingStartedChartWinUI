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
            new Model(){ Category = "NorthWest", Value = 87 },
            new Model(){ Category = "West", Value = 78 },
            new Model(){ Category = "SouthWest", Value = 85 },
            new Model(){ Category = "South", Value = 81 },
            new Model(){ Category = "SouthEast", Value = 88 },
            new Model(){ Category = "East", Value = 80 },
            new Model(){ Category = "NorthEast", Value = 85 },
            };
        }
    }
}
