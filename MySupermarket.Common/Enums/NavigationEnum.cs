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
        [Description("登录")]
        LoginView,
        [Description("首    页")]
        IndexView,
        [Description("乐    库")]
        MusicLibraryView,
        [Description("设置中心")]
        SettingsView,
        [Description("个性化")]
        IndividuationView,
        [Description("系统设置")]
        SystemSettingsView,
        [Description("关于")]
        AboutView,

    }
}
