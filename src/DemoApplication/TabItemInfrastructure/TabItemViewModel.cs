using System.ComponentModel;
using ReactiveUI;

namespace DemoApplication.TabItemInfrastructure
{
    public abstract class TabItemViewModel : ReactiveObject
    {
        public abstract string Title { get; }

        public abstract INotifyPropertyChanged Content { get; }

        public abstract int Priority { get; }
    }
}