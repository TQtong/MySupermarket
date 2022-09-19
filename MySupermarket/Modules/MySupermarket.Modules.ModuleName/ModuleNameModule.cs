﻿using MySupermarket.Core;
using MySupermarket.Modules.ModuleName.ViewModels;
using MySupermarket.Modules.ModuleName.Views;
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
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            //注册登录窗口
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();

            //注册弹窗（自定义弹窗，只要添加到容器里就行，不管用什么方法）
            containerRegistry.RegisterForNavigation<MessageView, MessageViewModel>();
        }
    }
}