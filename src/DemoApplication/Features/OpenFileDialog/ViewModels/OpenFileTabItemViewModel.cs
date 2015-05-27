using GalaSoft.MvvmLight;

namespace DemoApplication.Features.OpenFileDialog.ViewModels
{
    public class OpenFileTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Open File"; }
        }

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}