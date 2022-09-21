using MySupermarket.Common.Common;
using MySupermarket.Core.Mvvm;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.ViewModels.Settings
{
    public class AboutViewModel : RegionViewModelBase
    {
		private string version;

		public string Version
		{
			get => version;
			set
			{
				version = value;
				SetProperty(ref version, value);
			}
		}

		public AboutViewModel(IRegionManager regionManager) : base(regionManager)
		{
            Version = Utilities.GetCurrentVersionNumberStr();
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
