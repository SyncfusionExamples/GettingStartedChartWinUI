# GettingStartedCartesianChartWinUI
This is demo application of WinUI SfCartesianChart control. The minimal set of required properties have been configured in this project to get started with SfCartesianChart in WinUI.

## <a name="description"></a>Description ##

## Initialize chart
Add reference to [`Syncfusion.Chart.WinUI`](https://www.nuget.org/packages/Syncfusion.Chart.WinUI/) NuGet and import the control namespace `Syncfusion.UI.Xaml.Charts`  in XAML or C# to initialize the control.

###### Xaml
```xaml

<Page
    x:Class="CartesianChartGettingStartedUWP.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:model="using:CartesianChartGettingStartedUWP"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">  
    <Grid>
        <chart:SfCartesianChart />            
    </Grid>
</Page>
 ```
###### C#
```C#

using Syncfusion.UI.Xaml.Charts;

namespace CartesianChartGettingStartedUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            
            SfCartesianChart chart = new SfCartesianChart();      
            Root_Chart.Children.Add(chart);
        }
    }   
}
```

## Initialize chart axis
`Chart`supports default axes, so that these axes ([`PrimaryAxis`]() and [`SecondaryAxis`]()) will get generated automatically based upon the data bind to the chart.

Axes will be explicitly specified for it's customization purpose. The initialization of an empty chart with two axes as shown below,

###### Xaml
```xaml
<chart:SfCartesianChart> 
      <chart:SfCartesianChart.PrimaryAxis> 
           <chart:CategoryAxis /> 
      </chart:SfCartesianChart.PrimaryAxis> 
      <chart:SfCartesianChart.SecondaryAxis> 
           <chart:NumericalAxis/> 
      </chart:SfCartesianChart.SecondaryAxis>
</chart:SfCartesianChart>
```
###### C#
```C#

SfCartesianChart chart = new SfCartesianChart();
CategoryAxis primaryAxis = new CategoryAxis();
chart.PrimaryAxis = primaryAxis;    
NumericalAxis secondaryAxis = new NumericalAxis();
chart.SecondaryAxis = secondaryAxis;
```

## Initialize view model

Now, let us define a simple data model that represents a data point in chart.

###### C#
```C#

public class Person   
{   
    public string Name { get; set; }

    public double Height { get; set; }
}
```

Next, create a view model class and initialize a list of `Person` objects as follows.

###### C#
```C#
public class ViewModel  
{
      public ObservableCollection<Person> Data { get; set; }      

      public ViewModel()       
      {
            Data = new ObservableCollection<Person>()
            {
                new Person { Name = "David", Height = 180 },
                new Person { Name = "Michael", Height = 170 },
                new Person { Name = "Steve", Height = 160 },
                new Person { Name = "Joel", Height = 182 }
            }; 
       }
 }
 ```

Set the `ViewModel` instance as the `DataContext` of your window; this is done to bind properties of `ViewModel` to  the chart.
 
N> Add namespace of `ViewModel` class to your XAML Page if you prefer to set `DataContext` in XAML.

###### Xaml
```xaml
<Page
    x:Class="CartesianChartGettingStartedUWP.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:model="using:CartesianChartGettingStartedUWP"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <chart:SfCartesianChart>
        <chart:SfCartesianChart.DataContext>
            <model:ViewModel/>
        </chart:SfCartesianChart.DataContext>
    </chart:SfCartesianChart>
</Page>
```
###### C#
```C#
ViewModel viewModel = new ViewModel();
chart.DataContext = viewModel;
```

## Populate chart with data

As we are going to visualize the comparison of heights in the data model, add [`ColumnSeries`](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ColumnSeries.html) to [`Series`]() property of chart, and then bind the `Data` property of the above `ViewModel` to the `ColumnSeries.ItemsSource` as follows.

N> You need to set [`XBindingPath`](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_XBindingPath) and [`YBindingPath`](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.XyDataSeries.html#Syncfusion_UI_Xaml_Charts_XyDataSeries_YBindingPath) properties, so that chart would fetch values from the respective properties in the data model to plot the series.

###### Xaml
```xaml
<chart:SfCartesianChart>
    <chart:SfCartesianChart.PrimaryAxis>
        <chart:CategoryAxis Header="Name"/>
    </chart:SfCartesianChart.PrimaryAxis>
    <chart:SfCartesianChart.SecondaryAxis>
        <chart:NumericalAxis Header="Height(in cm)"/>
    </chart:SfCartesianChart.SecondaryAxis>    
    <chart:ColumnSeries  ItemsSource="{Binding Data}"
                              XBindingPath="Name"
                              YBindingPath="Height">
    </chart:ColumnSeries>

 </chart:SfCartesianChart> 
```

###### C#
```C#
SfCartesianChart chart = new SfCartesianChart();

//Adding horizontal axis to the chart 
CategoryAxis primaryAxis = new CategoryAxis();
primaryAxis.Header = "Name";   
chart.PrimaryAxis = primaryAxis;

//Adding vertical axis to the chart 
NumericalAxis secondaryAxis = new NumericalAxis();
secondaryAxis.Header = "Height(in cm)";  
chart.SecondaryAxis = secondaryAxis;

//Initialize the column series for chart
ColumnSeries series = new ColumnSeries();
series.ItemsSource = (new ViewModel()).Data;
series.XBindingPath = "Name";            
series.YBindingPath = "Height";         
            
//Adding Series to the Chart Series Collection
chart.Series.Add(series);
```
## Add title

The header of the chart acts as the title to provide quick information to the user about the data being plotted in the chart. You can set title using the `Header` property of chart as follows.

###### Xaml
```xaml
<Grid>
   <chart:SfCartesianChart Header="Height Comparison"> 
   </chart:SfCartesianChart> 
</Grid>
```
###### C#
```C#
chart.Header = "Height Comparison";
```

## Enable data labels

The [ShowDataLabels]() property of series can be used to enable the data labels to improve the readability of the chart. The label visibility is set to `False` by default.

###### Xaml
```xaml
<chart:SfCartesianChart>
	...
    <chart:ColumnSeries ShowDataLabels="True">
    </chart:ColumnSeries>  
	...
</chart:SfCartesianChart>
```
###### C#
```C#
SfCartesianChart chart = new SfCartesianChart();
. . .
ColumnSeries series = new ColumnSeries();
series.ShowDataLabels = true;
chart.Series.Add(series); 
```

## Enable legend

The legend provides information about the data point displayed in the chart. The [Legend](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartBase.html#Syncfusion_UI_Xaml_Charts_ChartBase_Legend) property of the chart was used to enable it.

###### Xaml
```xaml
<chart:SfCartesianChart >
    . . .
    <chart:SfCartesianChart.Legend>
        <chart:ChartLegend/>
    </chart:SfCartesianChart.Legend>
    . . .
</chart:SfCartesianChart>
```
###### C#
```C#
SfCartesianChart chart = new SfCartesianChart();
chart.Legend = new ChartLegend ();
```

Additionally, you need to set label for each series using the [`Label`](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_Label) property of ChartSeries, which will be displayed in corresponding legend.

###### Xaml
```xaml
<chart:SfCartesianChart>
. . .
    <chart:ColumnSeries Label="Heights"
                        ItemsSource="{Binding Data}"
                        XBindingPath="Name" 
                        YBindingPath="Height">
    </chart:ColumnSeries>
</chart:SfCartesianChart>
```
###### C#
```C#
ColumnSeries series = new ColumnSeries (); 
series.ItemsSource = (new ViewModel()).Data;
series.XBindingPath = "Name"; 
series.YBindingPath = "Height"; 
series.Label = "Heights";
```
## Enable tooltip

Tooltips are used to show information about the segment, when you click the segment. You can enable tooltip by setting series [`ShowTooltip`](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_ShowTooltip) property to true.

###### Xaml
```xaml
<chart:SfCartesianChart>
	...
   <chart:ColumnSeries ShowTooltip="True" ItemsSource="{Binding Data}" 
            XBindingPath="Name" YBindingPath="Height"/>
	...
</chart:SfCartesianChart> 
```
###### C#
```C#
ColumnSeries series = new ColumnSeries();
series.ItemsSource = (new ViewModel()).Data;
series.XBindingPath = "Name";          
series.YBindingPath = "Height";
series.ShowTooltip = true;
```
The following code example gives you the complete code of above configurations.

###### Xaml
```xaml
<Page
    x:Class="CartesianChartGettingStartedUWP.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:model="using:CartesianChartGettingStartedUWP"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d" 
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    
    <chart:SfCartesianChart Header="Height Comparison" 
                 Palette="BlueChrome" Height="500" Width="800">

        <!--Setting DataContext-->
        <chart:SfCartesianChart.DataContext>
            <Model:ViewModel/>
        </chart:SfCartesianChart.DataContext>
        
        <!--Initialize the horizontal axis to the SfCartesianChart-->
        <chart:SfCartesianChart.PrimaryAxis>
            <chart:CategoryAxis Header="Names"/>
        </chart:SfCartesianChart.PrimaryAxis>

       <!--Initialize the vertical axis to the SfCartesianChart-->
        <chart:SfCartesianChart.SecondaryAxis>
            <chart:NumericalAxis Header="Height(in cm)"/>
        </chart:SfCartesianChart.SecondaryAxis>

        <!--Initialize the legend to the SfCartesianChart-->
        <chart:SfCartesianChart.Legend>
            <chart:ChartLegend/>
        </chart:SfCartesianChart.Legend>

        <!--Initialize the series to the SfCartesianChart-->
        <chart:ColumnSeries Label="Heights" ShowTooltip="True"
                                ShowDataLabels="True"
                                ItemsSource="{Binding Data}"
                                XBindingPath="Name" 
                                YBindingPath="Height">
            <chart:ColumnSeries.DataLabelSettings>
                <chart:CartesianDataLabelSettings Position="Inner"/>
            </chart:ColumnSeries.DataLabelSettings>
        </chart:ColumnSeries>
        
    </chart:SfCartesianChart>
</Page>
``` 
###### C#
```C#
using Syncfusion.UI.Xaml.Charts;

namespace CartesianChartGettingStartedUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            
            SfCartesianChart chart = new SfCartesianChart() { Header = "Height Comparison", 
            Palette = ChartColorPalette.BlueChrome, Height="500", Width="800" };

            //Adding horizontal axis to the Cartesian chart 
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Header = "Name";
            primaryAxis.FontSize = 14;
            chart.PrimaryAxis = primaryAxis;

            //Adding vertical axis to the Cartesian chart 
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Header = "Height(in cm)";
            secondaryAxis.FontSize = 14;
            chart.SecondaryAxis = secondaryAxis;

            //Adding Legends for the Cartesian chart
            ChartLegend legend = new ChartLegend();
            chart.Legend = legend;

            //Initializing column series
            ColumnSeries series = new ColumnSeries();
            series.ItemsSource = (new ViewModel()).Data;
            series.XBindingPath = "Name";            
            series.YBindingPath = "Height";
            series.ShowTooltip = true;
            series.Label = "Heights"; 
            series.ShowDataLabels = true;
            series.DataLabelSettings = new CartesianDataLabelSettings()
            {
                Position = DataLabelPosition.Inner,
            };

            //Adding Series to the Cartesian chart Series Collection
            chart.Series.Add(series);
            this.Content = chart;    
        }
    }   
}
```

## <a name="output"></a>Output ##

![WinUI Cartesian Chart Getting_Started image](CartesianChart_WinUI_GettingStarted.png)
