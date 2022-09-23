using MySupermarket.Core.Vo;
using MySupermarket.Modules.ModuleName.Event;
using Prism.Events;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MySupermarket.Modules.ModuleName.Views.Music
{
    /// <summary>
    /// MusicLibraryView.xaml 的交互逻辑
    /// </summary>
    public partial class MusicLibraryView : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();  //声明时间控件

        public MusicLibraryView(IEventAggregator aggregator)
        {
            InitializeComponent();
            mediaElement.MediaOpened += MediaElement_MediaOpened;
            aggregator.GetEvent<MusicEvent>().Subscribe(Play);
            //设置间隔时间
            timer.Interval = TimeSpan.FromMilliseconds(10);
            //添加计时器
            timer.Tick += Timer_Tick;
        }

        private void Play(Dictionary<MusicInfoVo, string> obj)
        {
            //mediaElement.Source = new Uri(@"F:\KuGou\Mobb Deep - Shook Ones, Pt. 2.flac", UriKind.Relative);
            foreach (var item in obj)
            {
                mediaElement.Source = new Uri(item.Value, UriKind.Relative);
                
                mediaElement.Play();
                timer.Start();
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //时间的格式
            start.Text = mediaElement.Position.ToString("hh':'mm':'ss");

            slider.Value = mediaElement.Position.TotalSeconds; //歌曲播放时长对应的滑块位置
        }

        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {

            //获取音乐的时间
            TimeSpan time = mediaElement.NaturalDuration.TimeSpan;
            slider.Maximum = time.TotalSeconds;
            //设置添加时间的格式
            end.Text = time.ToString("hh':'mm':'ss");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Volume = ((Slider)sender).Value;

        }
    }
}
