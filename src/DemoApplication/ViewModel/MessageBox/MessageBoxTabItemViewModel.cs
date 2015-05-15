using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel.MessageBox
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