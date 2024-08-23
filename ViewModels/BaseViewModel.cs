using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MeonMark.ViewModels
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        public INavigation? Navigation { get; set; }
    }
}
