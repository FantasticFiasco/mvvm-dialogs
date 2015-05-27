using System.ComponentModel;
using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;

namespace DemoApplication.Features.Dialog.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 1)]
    public class ImplicitDialogTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Implicit Dialog"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return null; }
        }
    }
}