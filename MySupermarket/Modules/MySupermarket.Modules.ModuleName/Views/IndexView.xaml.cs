using MySupermarket.Common.Extensions;
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

namespace MySupermarket.Modules.ModuleName.Views
{
    /// <summary>
    /// IndexView.xaml 的交互逻辑
    /// </summary>
    public partial class IndexView : UserControl
    {
        public IndexView(IEventAggregator aggregator)
        {
            InitializeComponent();

            //注册提示消息（跟mainwindow类似）
            aggregator.ResgiterHintMessage(arg =>
            {
                //loginSnackBar.MessageQueue.Enqueue(arg.Message);
            }, "Login");
        }
    }
}
