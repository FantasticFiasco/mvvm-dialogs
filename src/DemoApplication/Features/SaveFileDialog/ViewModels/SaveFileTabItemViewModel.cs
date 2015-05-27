using System.ComponentModel;
using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;

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

        public override INotifyPropertyChanged Content
        {
            get { return null; }
        }
    }
}