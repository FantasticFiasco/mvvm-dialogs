using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel.Dialog
{
    public class ImplicitDialogTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Implicit Dialog"; }
        }

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}