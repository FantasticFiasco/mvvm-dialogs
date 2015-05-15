using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel.FolderBrowserDialog
{
    public class FolderBrowserTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Folder Browser"; }
        }

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}