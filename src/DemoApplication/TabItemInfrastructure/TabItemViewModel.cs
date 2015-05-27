using GalaSoft.MvvmLight;

namespace DemoApplication.TabItemInfrastructure
{
    public abstract class TabItemViewModel : ViewModelBase
    {
        public abstract string Title { get; }

        public abstract ViewModelBase Content { get; }
    }
}