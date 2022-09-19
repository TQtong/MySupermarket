using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.Service
{
    /// <summary>
    /// 通用请求参数
    /// </summary>
    public class BaseRequest
    {
        public RestSharp.Method Method { get; set; }
        public string Route { get; set; }
        public object Parameter { get; set; }
    }
}
