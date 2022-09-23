using DryIoc;
using MySupermarket.CustomUserControl;
using MySupermarket.Modules.ModuleName;
using MySupermarket.Modules.ModuleName.Common;
using MySupermarket.Modules.ModuleName.Managers.Music;
using MySupermarket.Modules.ModuleName.Service;
using MySupermarket.Modules.ModuleName.Service.Music;
using MySupermarket.Services;
using MySupermarket.Services.Interfaces;
using MySupermarket.Services.Interfaces.ViewModelInterfaces.Music;
using MySupermarket.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Services.Dialogs;
using System.Windows;

namespace MySupermarket
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册HttpRestClient
            //先拿到指定容器后注册服务，并对构造函数设置一个默认值
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));
            //设置根路径
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:5211/", serviceKey: "webUrl");

            //注册客户端服务(调用API)
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.Register<ILoginService, LoginService>();
            containerRegistry.Register<IMusicInfoService, MusicInfoService>();

            //注册自定义弹窗服务
            containerRegistry.Register<IDialogHostService, DialogHostService>();

            //注册自定义viewmodel服务(不调用API)
            containerRegistry.Register<IMusicHallService, MusicHallManager>();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Application.Current.MainWindow.Hide();

            var dialog = Container.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK || callback.Result == ButtonResult.None)
                {
                    Application.Current.Shutdown();
                    return;
                }

                base.OnInitialized();
            });

            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// 退出当前账号
        /// </summary>
        public static void ExitAccout(IContainerProvider container)
        {
            Application.Current.MainWindow.Hide();
            var dialog = container.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK || callback.Result == ButtonResult.None)
                {
                    Application.Current.Shutdown();
                    return;
                }
            });

            Application.Current.MainWindow.Show();
        }
    }
}
