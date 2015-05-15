using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel.SaveFileDialog
{
    public class SaveFileTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Save File"; }
        }

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}