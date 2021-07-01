using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartesianChartUWP
{
    public class ViewModel
    {
        public ObservableCollection<Person> Data { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<Person>()
            {
                new Person { Name = "David", Height = 170 },
                new Person { Name = "Michael", Height = 96 },
                new Person { Name = "Steve", Height = 65 },
                new Person { Name = "Joel", Height = 182 },
                new Person { Name = "Bob", Height = 134 }
            };
        }
    }
}
