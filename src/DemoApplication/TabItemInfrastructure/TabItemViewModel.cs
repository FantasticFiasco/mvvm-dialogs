using System.ComponentModel;
using MvvmFoundation.Wpf;

namespace DemoApplication.TabItemInfrastructure
{
    public abstract class TabItemViewModel : ObservableObject
    {
        public abstract string Title { get; }

        public abstract INotifyPropertyChanged Content { get; }
    }
}