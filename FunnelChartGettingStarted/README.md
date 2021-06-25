# GettingStartedFunnelChartWinUI
This is demo application of WinUI SfFunnelChart control. The minimal set of required properties have been configured in this project to get started with SfFunnelChart in WinUI.

## <a name="description"></a>Description ##

## Initialize chart
Add reference to [`Syncfusion.Chart.WinUI`](https://www.nuget.org/packages/Syncfusion.Chart.WinUI/) NuGet and import the control namespace `Syncfusion.UI.Xaml.Charts`  in XAML or C# to initialize the control.

###### Xaml
```xaml

<Page
    x:Class="FunnelChartGettingStartedUWP.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:model="using:FunnelChartGettingStartedUWP"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">  
    <Grid>
        <chart:SfFunnelChart />            
    </Grid>
</Page>
 ```
###### C#
```C#

using Syncfusion.UI.Xaml.Charts;

namespace FunnelChartGettingStartedUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            
            SfFunnelChart chart = new SfFunnelChart();
            . . .
            this.Content = chart;
        }
    }   
}
```

## Initialize view model

Now, let us define a simple data model that represents a data point in chart.

###### C#
```C#

public class Model
{
    public string Category { get; set; }

    public double Value { get; set; }
}
```

Next, create a view model class and initialize a list of `Model` objects as follows.

###### C#
```C#
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
 ```

Create a `ChartViewModel` instance and set it as the chart's `DataContext`. This enables property binding from `ChartViewModel` class.
 
N> Add namespace of `ChartViewModel` class to your XAML Page if you prefer to set `DataContext` in XAML.

###### Xaml
```xaml
<Page
    x:Class="FunnelChartGettingStartedUWP.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:model="using:FunnelChartGettingStartedUWP"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <chart:SfFunnelChart>
        <chart:SfFunnelChart.DataContext>
            <model:ChartViewModel/>
        </chart:SfFunnelChart.DataContext>
    </chart:SfFunnelChart>
</Page>
```
###### C#
```C#
ChartViewModel viewModel = new ChartViewModel();
chart.DataContext = viewModel;
```

## Add title

The title of the chart provide quick information to the user about the data being plotted in the chart. You can set the title using the [Header]() property of the funnel chart as follows.

###### Xaml
```xaml
<Grid>
   <chart:SfFunnelChart Header="PRODUCT SALES">
   . . .
   </chart:SfFunnelChart> 
</Grid>
```
###### C#
```C#
SfFunnelChart chart = new SfFunnelChart();
. . .
chart.Header = "PRODUCT SALES";
```

## Enable data labels

The [ShowDataLabels]() property of [SfFunnelChart]() can be used to enable data labels to improve the readability of the funnel chart. The label visibility is set to `False` by default.

###### Xaml
```xaml
<chart:SfFunnelChart ShowDataLabels="True">
. . . 
</chart:SfFunnelChart>
```
###### C#
```C#
SfFunnelChart chart = new SfFunnelChart();

. . .

chart.ShowDataLabels = true; 
```

## Enable legend

The legend provides information about the data point displayed in the chart. The [Legend](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartBase.html#Syncfusion_UI_Xaml_Charts_ChartBase_Legend) property of the chart was used to enable it.

###### Xaml
```xaml
<chart:SfFunnelChart>
    . . .
    <chart:SfFunnelChart.Legend>
        <chart:ChartLegend/>
    </chart:SfFunnelChart.Legend>
    ...
</chart:SfFunnelChart>
```
###### C#
```C#
SfFunnelChart chart = new SfFunnelChart();
. . .
chart.Legend = new ChartLegend();
```

## Enable tooltip

Tooltips are used to show information about the segment, when mouse over on it. Enable tooltip by setting funnel chart [ShowTooltip]() property as true.

###### Xaml
```xaml
<chart:SfFunnelChart ShowTooltip="True">
    . . . 
</chart:SfFunnelChart> 
```
###### C#
```C#
SfFunnelChart chart = new SfFunnelChart();
. . .
chart.ShowTooltip = true;
```

The following code example gives you the complete code of above configurations.

N> To plot the chart, the [XBindingPath]() and [YBindingPath]() properties must be configured so that the chart may get values from the respective properties in the data model.

###### Xaml
```xaml
<Page
    x:Class="FunnelChartGettingStartedUWP.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:model="using:FunnelChartGettingStartedUWP"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d" 
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    
    <chart:SfFunnelChart x:Name="chart" Header="PRODUCT SALES" 
                             ShowTooltip="True"
                             ShowDataLabels="True"
                             Palette="BlueChrome"
                             Height="500" Width="600"  
                             ItemsSource="{Binding Data}" 
                             XBindingPath="Category"
                             YBindingPath="Value">

        <chart:SfFunnelChart.DataContext>
            <model:ChartViewModel />
        </chart:SfFunnelChart.DataContext>

        <chart:SfFunnelChart.Legend>
            <chart:ChartLegend />
        </chart:SfFunnelChart.Legend>
            
    </chart:SfFunnelChart>
</Page>
``` 
###### C#
```C#
using Syncfusion.UI.Xaml.Charts;

namespace FunnelChartGettingStartedUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            SfFunnelChart chart = new SfFunnelChart();
            ChartViewModel viewModel = new ChartViewModel();
            chart.DataContext = viewModel;
            chart.SetBinding(SfFunnelChart.ItemsSourceProperty, new Binding() { Path = new PropertyPath("Data") });
            chart.XBindingPath = "Category";
            chart.YBindingPath = "Value";
            chart.Header = "PRODUCT SALES";
            chart.Height = 500;
            chart.Width = 600;
            chart.Legend = new ChartLegend();
            chart.ShowTooltip = true;
            chart.ShowDataLabels = true;
            chart.Palette = ChartColorPalette.BlueChrome;

            this.Content = chart;
            
        }
    }   
}
```

## <a name="output"></a>Output ##

![WinUI Funnel Chart Getting_Started image](FunnelChart_WinUI_GettingStarted.png)
