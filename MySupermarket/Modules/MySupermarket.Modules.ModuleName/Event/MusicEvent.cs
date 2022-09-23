using MySupermarket.Core.Dto;
using MySupermarket.Core.Vo;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.Event
{
    public class MusicEvent : PubSubEvent<Dictionary<MusicInfoVo, string>>
    {
    }
}
