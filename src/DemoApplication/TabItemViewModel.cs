using GalaSoft.MvvmLight;

namespace DemoApplication
{
    public abstract class TabItemViewModel : ViewModelBase
    {
        public abstract string Title { get; }

        public abstract ViewModelBase Content { get; }
    }
}