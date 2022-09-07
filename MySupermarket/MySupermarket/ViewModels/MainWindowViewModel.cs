using ImTools;
using MySupermarket.Common.Enums;
using MySupermarket.Common.Extensions;
using MySupermarket.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Input;

namespace MySupermarket.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";

        private readonly IRegionManager regionManager;

        /// <summary>
        /// 导航日志
        /// </summary>
        private IRegionNavigationJournal journal;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> ChangeNavgationCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            ChangeNavgationCommand = new DelegateCommand<string>(ChangeNavgation);
            this.regionManager = regionManager;
        }

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

            regionManager.Regions[RegionNames.ContentRegion].RequestNavigate(navigation.ToString(), callback =>
            {
                if ((bool)callback.Result)
                {
                    journal = callback.Context.NavigationService.Journal;
                }
            });

        }
    }
}
