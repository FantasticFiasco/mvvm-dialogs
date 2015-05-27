using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;
using GalaSoft.MvvmLight;

namespace DemoApplication.Features.SaveFileDialog.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 5)]
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