using System.ComponentModel;
using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;

namespace DemoApplication.Features.Dialog.Modal.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 1)]
    public class DialogTabItemViewModel : TabItemViewModel
    {
        private readonly DialogTabContentViewModel content;

        [ImportingConstructor]
        public DialogTabItemViewModel(DialogTabContentViewModel content)
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
    }
}