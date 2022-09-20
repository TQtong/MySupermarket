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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySupermarket.CustomUserControl.Views
{
    /// <summary>
    /// TextHighLightView.xaml 的交互逻辑
    /// </summary>
    public partial class TextHighLightView : UserControl
    {
        public TextHighLightView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var backColor = System.Drawing.ColorTranslator.FromHtml("#037be2");
            var forColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            img.Source = TextExtension.BitmapImageFromText("My Supermarket", new System.Drawing.Font("Microsoft YaHei", 30, System.Drawing.FontStyle.Bold), forColor, backColor, 6);
        }
    }
}
