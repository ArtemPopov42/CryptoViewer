using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.ViewModels
{
    public class BaseViewModel:ObservableObject
    {
        public virtual void Dispose() { }
    }
}
