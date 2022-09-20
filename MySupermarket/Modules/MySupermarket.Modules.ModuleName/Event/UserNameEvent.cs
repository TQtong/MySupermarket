using MySupermarket.Common.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.Event
{
    public class UserNameEvent : PubSubEvent<UserDto>
    {
    }
}
