using MySupermarket.Core.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.ViewModels.Settings
{
    public class SettingsViewModel : RegionViewModelBase
    {
        public SettingsViewModel(IRegionManager regionManager) : base(regionManager)
        {
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
