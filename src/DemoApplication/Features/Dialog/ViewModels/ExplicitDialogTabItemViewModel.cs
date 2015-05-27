using GalaSoft.MvvmLight;

namespace DemoApplication.Features.Dialog.ViewModels
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