using MySupermarket.Core.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace MySupermarket.Modules.ModuleName.ViewModels
{
    public class IndexViewModel : RegionViewModelBase
    {
        public IndexViewModel(IRegionManager regionManager) : base(regionManager)
        {
        }

        /// <summary>
        /// 切换导航栏时，判断是否可以切换：true 可以.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        public override void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            //if (MessageBox.Show("确认切换？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    continuationCallback(true);
            //}
        }

        /// <summary>
        /// 每次重新导航的时候，是否重用之前的实例：true 重用.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 接收点击导航传过来的参数
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
