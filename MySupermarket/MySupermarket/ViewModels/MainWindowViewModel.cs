using ImTools;
using MySupermarket.Common.Enums;
using MySupermarket.Common.Extensions;
using MySupermarket.Core;
using MySupermarket.Services.Interfaces;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MySupermarket.ViewModels
{
    public class MainWindowViewModel : BindableBase, IConfigureService
    {
        private string _title = "Prism Application";

        private readonly IRegionManager regionManager;
        private readonly IContainerProvider container;
        private readonly IDialogHostService dialog;

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

        public DelegateCommand ExitCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager, IContainerProvider container, IDialogHostService dialog)
        {
            ChangeNavgationCommand = new DelegateCommand<string>(ChangeNavgation);
            ExitCommand = new DelegateCommand(Exit);
            this.regionManager = regionManager;
            this.container = container;
            this.dialog = dialog;
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

        public void Configure()
        {
            regionManager.Regions[RegionNames.ContentRegion].RequestNavigate("IndexView");
        }

        private async void Exit()
        {
            bool result = await Question();
            if (result)
            {
                App.ExitAccout(container);
            }
        }

        private async Task<bool> Question()
        {
            var dialogResult = await dialog.Question("温馨提示", $"确认退出当前账号 ?");
            if (dialogResult.Result != ButtonResult.OK)
            {
                return false;
            }

            return true;
        }
    }
}
