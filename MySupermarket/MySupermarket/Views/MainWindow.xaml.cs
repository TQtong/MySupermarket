using MaterialDesignThemes.Wpf;
using MySupermarket.Common.Extensions;
using MySupermarket.CustomUserControl.Extensions;
using MySupermarket.CustomUserControl.Views;
using MySupermarket.Services.Interfaces;
using Prism.Events;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace MySupermarket.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDialogHostService dialog;

        public MainWindow(IEventAggregator aggregator, IDialogHostService dialog)
        {
            InitializeComponent();

            //注册提示消息
            aggregator.ResgiterHintMessage(arg =>
            {
                snackBar.MessageQueue.Enqueue(arg.Message);
            });

            //注册等待消息窗口
            aggregator.Resgiter(arg =>
            {
                dialogTheme.IsOpen = arg.IsOpen;

                if (dialogTheme.IsOpen)
                {
                    dialogTheme.DialogContent = new CircleProgressView();
                }
            });

            //窗口最小化
            btnMin.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            //窗口最大化
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            };

            //窗口关闭
            btnClose.Click += async (s, e) =>
            {
                var dialogResult = await dialog.Question("温馨提示", $"确认退出系统 ?");
                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK)
                {
                    return;
                }
                this.Close();
            };

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
            this.dialog = dialog;
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

        /// <summary>
        /// 文字滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bd_Loaded(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation();

            thicknessAnimation.From = new Thickness(0, 0, 0, 0);
            thicknessAnimation.By = new Thickness(-150, 0, 0, 0);
            thicknessAnimation.Duration = new Duration(TimeSpan.FromSeconds(5))
            {

            };
            thicknessAnimation.BeginTime = TimeSpan.FromSeconds(3);
            thicknessAnimation.Completed += (object? sender, EventArgs e) =>
            {
                tb.BeginAnimation(CustomUserControl.Views.TextHighLightView.MarginProperty, thicknessAnimation);
            };
            tb.BeginAnimation(CustomUserControl.Views.TextHighLightView.MarginProperty, thicknessAnimation);
        }

    }
}
