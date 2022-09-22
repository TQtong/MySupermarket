using MySupermarket.Core.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.ViewModels.Music
{
    public class MusicLibraryViewModel : RegionViewModelBase
    {
        public MusicLibraryViewModel(IRegionManager regionManager) : base(regionManager)
        {
        }
    }
}
