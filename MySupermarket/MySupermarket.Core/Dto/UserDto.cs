using MySupermarket.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Core.Dto
{
    public class UserDto : UserBaseObject
    {
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
                SetProperty(ref account, value);
            }
        }

        private string? name;
        /// <summary>
        /// 用户名
        /// </summary>
        public string? Name
        {
            get => name;
            set
            {
                name = value;
                SetProperty(ref name, value);
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
                SetProperty(ref password, value);
            }
        }
    }
}
