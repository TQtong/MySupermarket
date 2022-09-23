using MySupermarket.Common.Enums;
using MySupermarket.Common.Extensions;
using MySupermarket.Core;
using MySupermarket.Core.Mvvm;
using MySupermarket.Core.Vo;
using MySupermarket.Modules.ModuleName.Event;
using MySupermarket.Modules.ModuleName.Views.Music;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MySupermarket.Modules.ModuleName.ViewModels.Music
{
    public class MusicLibraryViewModel : RegionViewModelBase
    {
        /// <summary>
        /// 导航日志
        /// </summary>
        private IRegionNavigationJournal journal;

        /// <summary>
        /// 导航管理
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// 事件聚合器
        /// </summary>
        private readonly IEventAggregator aggregator;

        /// <summary>
        /// 容器
        /// </summary>
        private readonly IContainerProvider containe;

        private MusicLibraryView musicLibrary;

        public MusicLibraryView MusicLibrary
        {
            get => musicLibrary;
            set
            {
                musicLibrary = value;
                RaisePropertyChanged();
            }
        }


        #region 属性
        private MusicInfoVo selectMusic;
        /// <summary>
        /// 用户当前播放的音乐
        /// </summary>
        public MusicInfoVo SelectMusic
        {
            get => selectMusic;
            set
            {
                selectMusic = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 命令
        /// <summary>
        /// 导航切换
        /// </summary>
        public DelegateCommand<string> ChangeNavgationCommand { get; private set; }
        #endregion

        public MusicLibraryViewModel(IRegionManager regionManager, IContainerProvider containe, MusicLibraryView view) : base(regionManager)
        {
            this.regionManager = regionManager;
            this.containe = containe;
            ChangeNavgationCommand = new DelegateCommand<string>(ChangeNavgation);

            this.aggregator = this.containe.Resolve<IEventAggregator>();
            aggregator.GetEvent<MusicEvent>().Subscribe(GetMusicInfo);
            MusicLibrary = view;
        }


        #region 方法

        /// <summary>
        /// 导航切换
        /// </summary>
        /// <param name="str"></param>
        private void ChangeNavgation(string str)
        {
            Enum navigation = null;
            foreach (Enum item in Enum.GetValues(typeof(NavigationEnum)))
            {
                if (string.Equals(str, item.GetDescription()))
                {
                    navigation = item;
                    break;
                }
            }

            regionManager.Regions[RegionNames.MusicViewRegionName].RequestNavigate(navigation.ToString(), callback =>
            {
                if ((bool)callback.Result)
                {
                    journal = callback.Context.NavigationService.Journal;
                }
            });

        }

        /// <summary>
        /// 获取用户当前播放的音乐
        /// </summary>
        /// <param name="music"></param>
        private void GetMusicInfo(Dictionary<MusicInfoVo, string> music)
        {
            foreach (var item in music)
            {
                SelectMusic = item.Key;
            }
        }

        #endregion


    }
}
