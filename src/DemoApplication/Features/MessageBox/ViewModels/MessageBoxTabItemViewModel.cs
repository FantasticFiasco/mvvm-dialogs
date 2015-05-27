using GalaSoft.MvvmLight;

namespace DemoApplication.Features.MessageBox.ViewModels
{
    public class MessageBoxTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Message Box"; }
        }

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}