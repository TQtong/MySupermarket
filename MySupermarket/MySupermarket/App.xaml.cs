using MySupermarket.CustomUserControl;
using MySupermarket.Modules.ModuleName;
using MySupermarket.Services;
using MySupermarket.Services.Interfaces;
using MySupermarket.Views;
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
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
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

            var dialog = Container.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK || callback.Result == ButtonResult.None)
                {
                    Application.Current.Shutdown();
                    return;
                }

                var service = App.Current.MainWindow.DataContext as IConfigureService;

                if (service != null)
                {
                    service.Configure();
                }

                base.OnInitialized();
            });

        }
    }
}
