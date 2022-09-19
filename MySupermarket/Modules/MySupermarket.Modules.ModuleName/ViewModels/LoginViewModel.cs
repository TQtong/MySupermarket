using MySupermarket.Common.Extensions;
using MySupermarket.Common.Models;
using MySupermarket.Modules.ModuleName.Event;
using MySupermarket.Modules.ModuleName.Service;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.ViewModels
{
    public class LoginViewModel : LoginBaseViewModel, IDialogAware
    {
        public string Title { get; set; } = "登录";

        private string account = "admin";
        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get => account;
            set
            {
                account = value;
                RaisePropertyChanged();
            }
        }

        private string password = 123.ToString();
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }

        private int selectIndex;
        private readonly ILoginService service;
        private readonly IEventAggregator aggregator;

        /// <summary>
        /// 页面索引（用于切换登录注册界面）
        /// </summary>
        public int SelectIndex
        {
            get => selectIndex;
            set
            {
                selectIndex = value;
                RaisePropertyChanged();
            }
        }

        //private RegisterModel registerModel;

        //public RegisterModel RegisterModel
        //{
        //    get => registerModel;
        //    set
        //    {
        //        registerModel = value;
        //        RaisePropertyChanged();
        //    }
        //}

        public event Action<IDialogResult> RequestClose;

        #region 命令
        public DelegateCommand<string> ExecuteCommand { get; private set; }
        #endregion

        public LoginViewModel(ILoginService service, IEventAggregator aggregator, IContainerProvider container) : base(container)
        {
            this.service = service;
            this.aggregator = aggregator;

            ExecuteCommand = new DelegateCommand<string>(Execute);
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Login":
                    Login();//登录
                    break;
                case "Exit":
                    Exit();//退出
                    break;
                case "GoRegister":
                    SelectIndex = 1;//跳转注册界面
                    break;
                case "GoLogin":
                    SelectIndex = 0;//返回登录界面
                    break;
                case "Register":
                    //Register();//注册账号
                    break;
                case "GoPassword":
                    SelectIndex = 2;//跳转找回密码界面
                    break;
                case "Retrieve":
                    //Retrieve();//找回密码
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        private async void Login()
        {
            if (string.IsNullOrWhiteSpace(Account) || string.IsNullOrWhiteSpace(Password))
            {
                return;
            }

            try
            {
                UpdateLoading(true);

                var result = await service.LoginAsync(new UserDto()
                {
                    Account = Account,
                    Password = Password
                });

                if (result.Status)
                {
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                    //aggregator.SendHintMessage("登录成功", "Login");
                    aggregator.GetEvent<UserNameEvent>().Publish(result.Result.Name);
                }
                else
                {
                    aggregator.SendHintMessage(result.Message, "Login");
                }

                UpdateLoading(false);
            }
            finally
            {
            }

        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            Exit();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        /// <summary>
        /// 退出
        /// </summary>
        private void Exit()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }
    }
}
