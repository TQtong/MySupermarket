using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Common.Enums
{
    public enum NavigationEnum
    {
        [Description("首页")]
        IndexView,
        [Description("登录")]
        LoginView,
    }
}
