using MySupermarket.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Core.Vo
{
    public class MusicInfoVo : ViewModelBase
    {
		private string songName;
		/// <summary>
		/// 歌曲名字
		/// </summary>
		public string SongName
		{
			get => songName;
			set
			{
				songName = value;
				SetProperty(ref songName, value);
			}
		}

        private string singerName;
        /// <summary>
        /// 歌手名字
        /// </summary>
        public string SingerName
        {
            get => singerName;
            set
            {
                singerName = value;
                SetProperty(ref singerName, value);
            }
        }

        private string songAlbum;
        /// <summary>
        /// 歌曲专辑
        /// </summary>
        public string SongAlbum
        {
            get => songAlbum;
            set
            {
                songAlbum = value;
                SetProperty(ref songAlbum, value);
            }
        }

        private string songTime;
        /// <summary>
        /// 歌曲时长
        /// </summary>
        public string SongTime
        {
            get => songTime;
            set
            {
                songTime = value;
                SetProperty(ref songTime, value);
            }
        }
    }
}
