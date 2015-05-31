using System.ComponentModel;
using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;

namespace DemoApplication.Features.Dialog.NonModal.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 2)]
    public class NonModalDialogTabItemViewModel : TabItemViewModel
    {
        private readonly NonModalDialogTabContentViewModel content;

        [ImportingConstructor]
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
    }
}