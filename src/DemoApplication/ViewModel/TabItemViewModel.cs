using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel
{
    public abstract class TabItemViewModel : ViewModelBase
    {
        public abstract string Title { get; }

        public abstract ViewModelBase Content { get; }
    }
}