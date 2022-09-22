using MySupermarket.Core.Mvvm;
using MySupermarket.Core.Vo;
using MySupermarket.Services.Interfaces.ViewModelInterfaces.Music;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.ViewModels.Music
{
    public class MusicHallViewModel : RegionViewModelBase
    {
        private readonly IMusicHallService service;

        #region 属性
        private ObservableCollection<MusicInfoVo> musicInfo;
        /// <summary>
        /// 歌曲对象
        /// </summary>
        public ObservableCollection<MusicInfoVo> MusicInfo
        {
            get => musicInfo;
            set
            {
                musicInfo = value;
                SetProperty(ref musicInfo, value);
            }
        }
        #endregion


        #region 命令
        public DelegateCommand PlayMusicCommand { get; private set; }
        #endregion

        public MusicHallViewModel(IRegionManager regionManager, IMusicHallService service) : base(regionManager)
        {
            this.service = service;
            MusicInfo = (ObservableCollection<MusicInfoVo>)service.CreateMusic();
            PlayMusicCommand = new DelegateCommand(PlayMusic);
        }

        #region 方法
        public void PlayMusic()
        {
        }
        #endregion
    }
}
