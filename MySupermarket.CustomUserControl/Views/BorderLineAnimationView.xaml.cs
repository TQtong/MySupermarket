using MySupermarket.CustomUserControl.Extensions;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySupermarket.CustomUserControl.Views
{
    /// <summary>
    /// BorderLineAnimationView.xaml 的交互逻辑
    /// </summary>
    public partial class BorderLineAnimationView : UserControl
    {
        private static readonly DependencyProperty _Duration = DependencyProperty.Register("Duration", typeof(int), typeof(BorderLineAnimationView), new PropertyMetadata(200, (DependencyObject d, DependencyPropertyChangedEventArgs eventArgs) => { ((BorderLineAnimationView)d).Duration = (int)eventArgs.NewValue; }));
        private static readonly DependencyProperty _BColor = DependencyProperty.Register("BColor", typeof(Brush), typeof(BorderLineAnimationView), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(174, 234, 0)), (DependencyObject d, DependencyPropertyChangedEventArgs eventArgs) => { ((BorderLineAnimationView)d).BColor = (Brush)eventArgs.NewValue; }));

        private Storyboard storyboard;

        public BorderLineAnimationView()
        {
            InitializeComponent();

            InitSbs();
        }

        public int Duration
        {
            get
            {
                return (int)GetValue(_Duration);
            }

            set
            {
                SetValue(_Duration, value);
            }
        }

        public Brush BColor
        {
            get
            {
                return (Brush)GetValue(_BColor);
            }

            set
            {
                SetValue(_BColor, value);
            }
        }

        private void InitSbs()
        {
            BorderLineAnimationExtension startMoveT = CreateGridLengthAnim("TopStart", 0, 1, true, 0, Duration);
            BorderLineAnimationExtension endMoveT = CreateGridLengthAnim("TopEnd", 1, 0, true, 0, Duration);
            BorderLineAnimationExtension startMoveR = CreateGridLengthAnim("RightStart", 0, 1, false, 0, Duration);
            BorderLineAnimationExtension endMoveR = CreateGridLengthAnim("RightEnd", 1, 0, false, 0, Duration);
            BorderLineAnimationExtension startMoveB = CreateGridLengthAnim("BottomSuperStart", 1, 0, true, 0, Duration);
            BorderLineAnimationExtension endMoveB = CreateGridLengthAnim("BottomPenEnd", 0, 1, true, 0, Duration);
            BorderLineAnimationExtension startMoveL = CreateGridLengthAnim("LeftSuperStart", 1, 0, false, 0, Duration);
            BorderLineAnimationExtension endMoveL = CreateGridLengthAnim("LeftPenEnd", 0, 1, false, 0, Duration);
            BorderLineAnimationExtension startSubMoveT = CreateGridLengthAnim("TopSuperStart", 0, 1, true, Duration, Duration);
            BorderLineAnimationExtension endPenMoveT = CreateGridLengthAnim("TopPenEnd", 1, 0, true, Duration, Duration);
            BorderLineAnimationExtension startSubMoveR = CreateGridLengthAnim("RightSuperStart", 0, 1, false, Duration, Duration);
            BorderLineAnimationExtension endPenMoveR = CreateGridLengthAnim("RightPenEnd", 1, 0, false, Duration, Duration);
            BorderLineAnimationExtension startSubMoveB = CreateGridLengthAnim("BottomStart", 1, 0, true, Duration, Duration);
            BorderLineAnimationExtension endPenMoveB = CreateGridLengthAnim("BottomEnd", 0, 1, true, Duration, Duration);
            BorderLineAnimationExtension startSubMoveL = CreateGridLengthAnim("LeftStart", 1, 0, false, Duration, Duration);
            BorderLineAnimationExtension endPenMoveL = CreateGridLengthAnim("LeftEnd", 0, 1, false, Duration, Duration);

            storyboard = new Storyboard();
            storyboard.Children.Add(startMoveT);
            storyboard.Children.Add(endMoveT);
            storyboard.Children.Add(startMoveR);
            storyboard.Children.Add(endMoveR);
            storyboard.Children.Add(startMoveB);
            storyboard.Children.Add(endMoveB);
            storyboard.Children.Add(startMoveL);
            storyboard.Children.Add(endMoveL);
            storyboard.Children.Add(startSubMoveT);
            storyboard.Children.Add(endPenMoveT);
            storyboard.Children.Add(startSubMoveR);
            storyboard.Children.Add(endPenMoveR);
            storyboard.Children.Add(startSubMoveB);
            storyboard.Children.Add(endPenMoveB);
            storyboard.Children.Add(startSubMoveL);
            storyboard.Children.Add(endPenMoveL);
            storyboard.RepeatBehavior = RepeatBehavior.Forever;
        }

        private BorderLineAnimationExtension CreateGridLengthAnim(string name, double from, double to, bool isCol, int beginTime, int duration)
        {
            BorderLineAnimationExtension anim = new BorderLineAnimationExtension();
            anim.From = new GridLength(from, GridUnitType.Star);
            anim.To = new GridLength(to, GridUnitType.Star);
            anim.Duration = new Duration(new System.TimeSpan(0, 0, 0, 0, duration));
            anim.BeginTime = new System.TimeSpan(0, 0, 0, 0, beginTime);
            Storyboard.SetTargetName(anim, name);
            if (isCol)
            {
                Storyboard.SetTargetProperty(anim, new PropertyPath(ColumnDefinition.WidthProperty));
            }
            else
            {
                Storyboard.SetTargetProperty(anim, new PropertyPath(RowDefinition.HeightProperty));
            }

            return anim;
        }

        public void Start()
        {
            RootObj.Visibility = Visibility.Visible;
            storyboard.Begin(this, true);
        }

        public void Stop()
        {
            RootObj.Visibility = Visibility.Collapsed;
            storyboard.Stop(this);
        }
    }
}
