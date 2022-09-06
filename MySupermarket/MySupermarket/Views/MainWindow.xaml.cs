using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;

namespace MySupermarket.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //窗口拖动
            colorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };

            //双击窗口放大
            colorZone.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            };
        }

        private void LeftOpenMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                if (LeftOpenMenuToggleButton.IsChecked == true)
                {
                    LeftOpenMenuToggleButton.Visibility = Visibility.Collapsed;
                    LeftOpenMenuToggleButton.IsChecked = false;
                    LeftCloseMenuToggleButton.Visibility = Visibility.Visible;
                }
            };


        }

        private void LeftCloseMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                if (LeftCloseMenuToggleButton.IsChecked == false)
                {
                    LeftCloseMenuToggleButton.Visibility = Visibility.Collapsed;
                    LeftCloseMenuToggleButton.IsChecked = true;
                    LeftOpenMenuToggleButton.Visibility = Visibility.Visible;
                }
            };

        }
    }
}
