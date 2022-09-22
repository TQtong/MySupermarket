using MySupermarket.Core.Domain;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Common.Event
{
    /// <summary>
    /// 提示信息
    /// </summary>
    public class HintMessageEvent : PubSubEvent<MessageModel>
    {
    }
}
