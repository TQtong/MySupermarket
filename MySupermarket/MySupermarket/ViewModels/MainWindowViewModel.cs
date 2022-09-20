using ImTools;
using MySupermarket.Common.Enums;
using MySupermarket.Common.Extensions;
using MySupermarket.Common.Models;
using MySupermarket.Core;
using MySupermarket.Modules.ModuleName.Event;
using MySupermarket.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MySupermarket.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 导航管理
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// 容器
        /// </summary>
        private readonly IContainerProvider container;

        /// <summary>
        /// 弹窗接口(自定义)
        /// </summary>
        private readonly IDialogHostService dialog;

        /// <summary>
        /// 事件聚合器
        /// </summary>
        private readonly IEventAggregator aggregator;

        /// <summary>
        /// 导航日志
        /// </summary>
        private IRegionNavigationJournal journal;

        /// <summary>
        /// 定时器
        /// </summary>
        private System.Windows.Threading.DispatcherTimer timer;

        #region 属性
        private UserDto user;
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public UserDto User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private string nowTime;
        /// <summary>
        /// 当前时间
        /// </summary>
        public string NowTime
        {
            get { return nowTime; }
            set { SetProperty(ref nowTime, value); }
        }

        #endregion

        #region 命令

        /// <summary>
        /// 导航
        /// </summary>
        public DelegateCommand<string> ChangeNavgationCommand { get; private set; }

        /// <summary>
        /// 退出
        /// </summary>
        public DelegateCommand ExitCommand { get; private set; }
        #endregion


        public MainWindowViewModel(IRegionManager regionManager, IContainerProvider container, IDialogHostService dialog)
        {
            timer = new System.Windows.Threading.DispatcherTimer();//创建定时器
            timer.Tick += Timer_Tick; ;//执行事件
            timer.Interval = new TimeSpan(0, 0, 0, 1);//1s执行
            timer.Start();//开启

            ChangeNavgationCommand = new DelegateCommand<string>(ChangeNavgation);
            ExitCommand = new DelegateCommand(Exit);
            this.regionManager = regionManager;
            this.container = container;
            this.dialog = dialog;

            this.aggregator = container.Resolve<IEventAggregator>();
            aggregator.GetEvent<UserNameEvent>().Subscribe(GetName);
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

            regionManager.Regions[RegionNames.ContentRegion].RequestNavigate(navigation.ToString(), callback =>
            {
                if ((bool)callback.Result)
                {
                    journal = callback.Context.NavigationService.Journal;
                }
            });

        }

        /// <summary>
        /// 退出
        /// </summary>
        private async void Exit()
        {
            bool result = await Question();
            if (result)
            {
                App.ExitAccout(container);
            }
        }

        /// <summary>
        /// 询问窗口
        /// </summary>
        /// <returns></returns>
        private async Task<bool> Question()
        {
            var dialogResult = await dialog.Question("温馨提示", $"确认退出当前账号 ?");
            if (dialogResult.Result != ButtonResult.OK)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 定时器，隔一秒更新下标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            NowTime = $"现在是：{DateTime.Now.ToString("yyyy年MM月dd日 dddd tt HH:mm:ss")}";
        }

        /// <summary>
        /// 获取登录的用户名，用于动态改名字
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void GetName(UserDto obj)
        {
            User = obj;
            NowTime = $"现在是：{DateTime.Now.ToString("yyyy年MM月dd日 dddd tt HH:mm:ss")}";
        }
    }
}
