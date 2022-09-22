using MySupermarket.Core;
using MySupermarket.Modules.ModuleName.ViewModels;
using MySupermarket.Modules.ModuleName.ViewModels.Music;
using MySupermarket.Modules.ModuleName.ViewModels.Settings;
using MySupermarket.Modules.ModuleName.Views;
using MySupermarket.Modules.ModuleName.Views.Music;
using MySupermarket.Modules.ModuleName.Views.Settings;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MySupermarket.Modules.ModuleName
{
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleNameModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            // 默认显示首页
            _regionManager.RequestNavigate(RegionNames.ContentRegionName, "IndexView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册登录窗口
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();

            //注册弹窗（自定义弹窗，只要添加到容器里就行，不管用什么方法）
            containerRegistry.RegisterForNavigation<MessageView, MessageViewModel>();

            //注册导航条
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<MusicLibraryView, MusicLibraryViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();

            //设置中的侧边导航栏
            containerRegistry.RegisterForNavigation<IndividuationView, IndividuationViewModel>();
            containerRegistry.RegisterForNavigation<SystemSettingsView, SystemSettingsViewModel>();
            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();


        }
    }
}