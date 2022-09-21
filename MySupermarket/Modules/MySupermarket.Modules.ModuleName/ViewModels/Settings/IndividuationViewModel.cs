using MaterialDesignColors;
using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using MySupermarket.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MySupermarket.Modules.ModuleName.ViewModels.Settings
{
    public class IndividuationViewModel : RegionViewModelBase
    {
        #region 属性
        private bool _isDarkTheme;
        /// <summary>
        /// 是否切换主题
        /// </summary>
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (SetProperty(ref _isDarkTheme, value))
                {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? Theme.Dark : Theme.Light));
                }
            }
        }
        #endregion

        #region 字段
        /// <summary>
        /// 颜色列表
        /// </summary>
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;

        /// <summary>
        /// 颜色列表帮助类
        /// </summary>
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        #endregion

        #region 命令
        /// <summary>
        /// 选择对应的颜色
        /// </summary>
        public DelegateCommand<object> SelectColorCommand { get; private set; }
        #endregion

        #region 构造函数
        public IndividuationViewModel(IRegionManager regionManager) : base(regionManager)
        {
            SelectColorCommand = new DelegateCommand<object>(SelectColor);
        }
        #endregion

        /// <summary>
        /// 每次重新导航的时候，是否重用之前的实例：true 重用.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 接收点击导航传过来的参数
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        #region 方法
        /// <summary>
        /// 切换主题
        /// </summary>
        /// <param name="modificationAction"></param>
        private static void ModifyTheme(Action<ITheme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }

        /// <summary>
        /// 选择颜色
        /// </summary>
        /// <param name="obj"></param>
        private void SelectColor(object obj)
        {
            var hue = (Color)obj;
            ITheme theme = paletteHelper.GetTheme();
            theme.PrimaryLight = new ColorPair(hue.Lighten());
            theme.PrimaryMid = new ColorPair(hue);
            theme.PrimaryDark = new ColorPair(hue.Darken());
            paletteHelper.SetTheme(theme);
        }
        #endregion

    }
}
