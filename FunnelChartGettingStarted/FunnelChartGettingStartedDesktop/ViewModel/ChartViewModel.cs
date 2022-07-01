using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnelChartGettingStartedDesktop
{
    public class ChartViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ChartViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model(){Category = "Lava", Value = 50},
                new Model(){Category = "HP", Value = 30},
                new Model(){Category = "Moto", Value = 60},
                new Model(){Category = "Sony", Value = 50},
                new Model(){Category = "LG", Value = 45},
                new Model(){Category = "Samsung", Value = 40},
            };
        }
    }
}
