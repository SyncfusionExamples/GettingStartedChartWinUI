using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularChartUWP
{
    public class ChartViewModel
    {
        public ObservableCollection<Sales> Data { get; set; }

        public ChartViewModel()
        {
            Data = new ObservableCollection<Sales>()
            {
                new Sales(){Product = "iPad", SalesRate = 25},
                new Sales(){Product = "iPhone", SalesRate = 35},
                new Sales(){Product = "MacBook", SalesRate = 15},
                new Sales(){Product = "Mac", SalesRate = 5},
                new Sales(){Product = "Others", SalesRate = 10},
            };
        }
    }
}
