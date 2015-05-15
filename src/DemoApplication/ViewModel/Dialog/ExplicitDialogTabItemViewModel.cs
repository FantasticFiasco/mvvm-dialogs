using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel.Dialog
{
    public class ExplicitDialogTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Explicit Dialog"; }
        }

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}