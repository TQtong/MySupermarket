using MySupermarket.Core.Vo;
using MySupermarket.Services.Interfaces.ViewModelInterfaces.Music;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Common.Managers.Music
{
    public class MusicHallManager : IMusicHallService
    {
        public object CreateMusic()
        {
            ObservableCollection<MusicInfoVo> musicInfoVos = new ObservableCollection<MusicInfoVo>()
            {
                new MusicInfoVo()
                {
                    SingerName = "TQtong",
                    SongName = "哈哈哈",
                    SongAlbum = "Something",
                    SongTime = "3:40"
                },
            };

            return musicInfoVos;
        }

        public void Play(object obj)
        {
            var result = (MusicInfoVo)obj;
        }
    }
}
