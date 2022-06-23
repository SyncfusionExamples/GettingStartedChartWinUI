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
        public ObservableCollection<PlantData> PlantDetails { get; set; }

        public ChartViewModel()
        {
            PlantDetails = new ObservableCollection<PlantData>()
            {
            new PlantData(){ Direction = "North", Tree = 80 },
            new PlantData(){ Direction = "NorthWest", Tree = 87 },
            new PlantData(){ Direction = "West", Tree = 78 },
            new PlantData(){ Direction = "SouthWest", Tree = 85 },
            new PlantData(){ Direction = "South", Tree = 81 },
            new PlantData(){ Direction = "SouthEast", Tree = 88 },
            new PlantData(){ Direction = "East", Tree = 80 },
            new PlantData(){ Direction = "NorthEast", Tree = 85 },
            };
        }
    }
}
