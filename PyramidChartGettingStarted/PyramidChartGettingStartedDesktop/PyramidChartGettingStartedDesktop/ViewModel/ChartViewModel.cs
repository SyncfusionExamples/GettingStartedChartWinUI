using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidChartGettingStartedDesktop
{
    public class ChartViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ChartViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model(){FoodName = "Sweet treats", Calories = 250},
                new Model(){FoodName = "Cheese", Calories = 402},
                new Model(){FoodName = "Vegetables", Calories = 65},
                new Model(){FoodName = "Fish", Calories = 206},
                new Model(){FoodName = "Fruits", Calories = 52},
                new Model(){FoodName = "Rice", Calories = 130},
            };
        }
    }
}
