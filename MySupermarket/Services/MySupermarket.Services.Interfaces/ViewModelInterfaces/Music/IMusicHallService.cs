using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Services.Interfaces.ViewModelInterfaces.Music
{
    public interface IMusicHallService
    {
        object CreateMusic();

        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <param name="obj"></param>
        Task<string> Play(object obj);
    }
}
