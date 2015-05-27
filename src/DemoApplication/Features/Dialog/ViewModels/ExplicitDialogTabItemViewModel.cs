using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;
using GalaSoft.MvvmLight;

namespace DemoApplication.Features.Dialog.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 2)]
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