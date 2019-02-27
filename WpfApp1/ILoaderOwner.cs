using System.ComponentModel;
using System.Windows;

namespace CSharp_Pechura_01
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
