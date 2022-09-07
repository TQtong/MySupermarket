using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; } = "登录";

        private string account;
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

        private string password;
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
