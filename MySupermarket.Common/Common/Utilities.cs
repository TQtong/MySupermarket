using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Common.Common
{
    public class Utilities
    {
        /// <summary>
        /// 获取当前应用的版本号
        /// </summary>
        /// <returns></returns>
        public static Version GetCurrentVersionNumber()
        {
            return new Version(GetCurrentVersionNumberStr());
        }

        /// <summary>
        /// 获取当前应用的版本号字符串
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentVersionNumberStr()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductVersion;
        }

    }
}
