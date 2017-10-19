using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Media;

namespace ConsoleApp26
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ViewModel ViewModel
        {
            get
            {
                return this.DataContext as ViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        /// <summary>
        /// 既定の初期値で <see cref="MainWindow"/> の新しいインスタンスを初期化します。
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.ViewModel = new ViewModel();

            var chart = new SimpleChart()
            {
                MaxAxisY = this.ViewModel.MaxY,
                MinAxisY = this.ViewModel.MinY,
                YGridPtich = this.ViewModel.PtichY,
            };

            this.ViewModel.ImageSource = ImageFactory.CreateImageSource(chart.CreateChart(850, 600));
        }

        protected virtual void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            var chart = new SimpleChart()
            {
                MaxAxisY = this.ViewModel.MaxY,
                MinAxisY = this.ViewModel.MinY,
                YGridPtich = this.ViewModel.PtichY,
            };

            var r = new Random();

            {
                var series = new Series
                {
                    LineColor = Color.FromRgb(255, 0, 0)
                };

                double val = 0;
                int cnt = this.ViewModel.SampleCount;

                for (int i = 0; i < cnt; i++)
                {
                    val = val + (double)r.Next(-100, 100) / (cnt/10);
                    series.Values.Add(val);
                }

                chart.SeriesList.Add(series);
            }

            {
                var series = new Series
                {
                    LineColor = Color.FromRgb(167, 93, 208)
                };

                double val = 0;
                int cnt = this.ViewModel.SampleCount;

                for (int i = 0; i < cnt; i++)
                {
                    val = val + (double)r.Next(-100, 100) / (cnt/10);
                    series.Values.Add(val);
                }

                chart.SeriesList.Add(series);
            }


            this.ViewModel.ImageSource = ImageFactory.CreateImageSource(chart.CreateChart(850, 600));
        }
    }
}
