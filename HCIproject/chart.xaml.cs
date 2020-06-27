using MindFusion.Charting.Wpf;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for chart.xaml
    /// </summary>
    public partial class chart : Window
    {
		private List<string> customLabels=new List<string>();
		private DoubleCollection data = new DoubleCollection();
		public chart(long id)
        {
            InitializeComponent();


			var app = Application.Current as App;
			Drug drug = app.DrugDecorator.Get(id);

			foreach(Ingredient ing in drug.Ingredients)
			{
				customLabels.Add(ing.Name);
				data.Add(ing.Quantity);
			}
			pieChart.TitleVisibility = Visibility.Collapsed;

			PieSeries series = new PieSeries();
			series.Effect = new DropShadowEffect() { Opacity = 0.5, ShadowDepth = 3, };
			series.Data = data;
			series.PieType = PieType.Pie2D;
			series.InnerLabel = customLabels;
			series.OuterLabel = customLabels;
			series.LabelForeground = Brushes.White;
			series.OuterLabelOffset = 30;

			series.Fills.Add(Brushes.LightGreen);
			series.Fills.Add(Brushes.DodgerBlue);
			series.Fills.Add(Brushes.Violet);
			series.Fills.Add(Brushes.Yellow);
			series.Fills.Add(Brushes.PowderBlue);
			series.Fills.Add(Brushes.BurlyWood);
			series.Fills.Add(Brushes.Tomato);
			series.Fills.Add(Brushes.Orange);

			series.Strokes.Add(Brushes.Green);
			series.Strokes.Add(Brushes.Blue);
			series.Strokes.Add(Brushes.BlueViolet);
			series.Strokes.Add(Brushes.Orange);
			series.Strokes.Add(Brushes.CadetBlue);
			series.Strokes.Add(Brushes.Brown);
			series.Strokes.Add(Brushes.Red);
			series.Strokes.Add(Brushes.OrangeRed);
			series.Fills.Add(Brushes.Violet);
			series.Strokes.Add(Brushes.BlueViolet);
			pieChart.Series.Clear();
			pieChart.Series.Add(series);
			pieChart.PlotAreaMargin = new Thickness(40, 20, 40, 20);

		}
		private SeriesLegend GetSeriesLegend()
		{
			SeriesLegend seriesLegend = new SeriesLegend();
			seriesLegend.BorderBrush = Brushes.Silver;
			seriesLegend.BorderThickness = new Thickness(0);
			seriesLegend.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
			seriesLegend.Foreground = Brushes.White;
			seriesLegend.Padding = new Thickness(10);
			seriesLegend.Margin = new Thickness(0, 0, 0, 0);
			seriesLegend.LabelsSource = data;
			//seriesLegend.Effect = effect;
			seriesLegend.SnapsToDevicePixels = true;

			return seriesLegend;
		}
	}
}
