using System.ComponentModel;

namespace DemoApplication.Features.Dialog.NonModal.ViewModels
{
    public class NonModalDialogTabItemViewModel : TabItemViewModel
    {
        private readonly NonModalDialogTabContentViewModel content;

        public NonModalDialogTabItemViewModel(NonModalDialogTabContentViewModel content)
        {
            this.content = content;
        }

        public override string Title
        {
            get { return "Non-Modal Dialog"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return content; }
        }

        public override int Priority
        {
            get { return 2; }
        }
    }
}