using MySupermarket.Common.Extensions;
using MySupermarket.Core.Domain;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.ViewModels
{
    public class LoginBaseViewModel : BindableBase
    {
        private readonly IContainerProvider container;

        public readonly IEventAggregator aggregator;

        public LoginBaseViewModel(IContainerProvider container)
        {
            this.container = container;
            aggregator = container.Resolve<IEventAggregator>();
        }

        /// <summary>
        /// 通知窗口的状态
        /// </summary>
        /// <param name="IsOpen"></param>
        public void UpdateLoading(bool IsOpen)
        {
            aggregator.UpdateLoading(new UpdateModel()
            {
                IsOpen = IsOpen
            });
        }
    }
}
