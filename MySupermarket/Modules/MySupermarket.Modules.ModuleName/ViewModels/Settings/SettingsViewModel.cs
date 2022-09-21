using MySupermarket.Common.Enums;
using MySupermarket.Common.Extensions;
using MySupermarket.Core;
using MySupermarket.Core.Mvvm;
using Prism.Commands;
using Prism.Ioc;
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
        /// <summary>
        /// 导航日志
        /// </summary>
        private IRegionNavigationJournal journal;

        /// <summary>
        /// 导航管理
        /// </summary>
        private readonly IRegionManager regionManager;

        #region 命令
        /// <summary>
        /// 导航切换
        /// </summary>
        public DelegateCommand<string> ChangeNavgationCommand { get; private set; }
        #endregion

        public SettingsViewModel(IRegionManager regionManager) : base(regionManager)
        {
            this.regionManager = regionManager;
            ChangeNavgationCommand = new DelegateCommand<string>(ChangeNavgation);
        }

        /// <summary>
        /// 导航切换
        /// </summary>
        /// <param name="str"></param>
        private void ChangeNavgation(string str)
        {
            Enum navigation = null;
            foreach (Enum item in Enum.GetValues(typeof(NavigationEnum)))
            {
                if (string.Equals(str, item.GetDescription()))
                {
                    navigation = item;
                    break;
                }
            }

            regionManager.Regions[RegionNames.SettingsViewRegionName].RequestNavigate(navigation.ToString(), callback =>
            {
                if ((bool)callback.Result)
                {
                    journal = callback.Context.NavigationService.Journal;
                }
            });

        }
    }
}
