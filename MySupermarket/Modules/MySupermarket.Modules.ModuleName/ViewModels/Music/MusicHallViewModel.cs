using MySupermarket.Common.Event;
using MySupermarket.Core.Mvvm;
using MySupermarket.Core.Vo;
using MySupermarket.Modules.ModuleName.Event;
using MySupermarket.Modules.ModuleName.Managers.Music;
using MySupermarket.Modules.ModuleName.Views.Music;
using MySupermarket.Services.Interfaces.ViewModelInterfaces.Music;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.ViewModels.Music
{
    public class MusicHallViewModel : RegionViewModelBase
    {
        /// <summary>
        /// 音乐大厅管理者
        /// </summary>
        private readonly MusicHallManager manager;
        private readonly IEventAggregator aggregator;

        /// <summary>
        /// 乐库对象
        /// </summary>

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
                RaisePropertyChanged();
            }
        }

        private MusicInfoVo selectMusicInfo;
        /// <summary>
        /// 当前选择的歌曲对象
        /// </summary>
        public MusicInfoVo SelectMusicInfo
        {
            get => selectMusicInfo;
            set
            {
                selectMusicInfo = value;
                SetProperty(ref selectMusicInfo, value);
            }
        }

        #endregion


        #region 命令
        public DelegateCommand<object> PlayMusicCommand { get; private set; }
        #endregion

        public MusicHallViewModel(IRegionManager regionManager, MusicHallManager manager, IEventAggregator aggregator) : base(regionManager)
        {
            this.manager = manager;
            this.aggregator = aggregator;
            Init();
            PlayMusicCommand = new DelegateCommand<object>(PlayMusic);
        }

        

        #region 方法

        private async void Init()
        {
            if (MusicInfo != null)
            {
                MusicInfo.Clear();
            }
            MusicInfo = await this.manager.GetAllMusic();
        }

        private async void PlayMusic(object obj)
        {
            Dictionary<MusicInfoVo, string> valuePairs = new Dictionary<MusicInfoVo, string>();
            string path = await this.manager.Play(obj);

            valuePairs.Add((MusicInfoVo)obj, path);

            aggregator.GetEvent<MusicEvent>().Publish(valuePairs);
        }
        #endregion
    }
}
