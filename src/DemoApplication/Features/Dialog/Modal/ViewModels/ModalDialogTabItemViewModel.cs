using System.ComponentModel;
using DemoApplication.TabItemInfrastructure;

namespace DemoApplication.Features.Dialog.Modal.ViewModels
{
    public class ModalDialogTabItemViewModel : TabItemViewModel
    {
        private readonly ModalDialogTabContentViewModel content;

        public ModalDialogTabItemViewModel(ModalDialogTabContentViewModel content)
        {
            this.content = content;
        }

        public override string Title
        {
            get { return "Modal Dialog"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return content; }
        }

        public override int Priority
        {
            get { return 1; }
        }
    }
}