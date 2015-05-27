using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;
using GalaSoft.MvvmLight;

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

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}