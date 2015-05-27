using System.ComponentModel;
using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;

namespace DemoApplication.Features.OpenFileDialog.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 4)]
    public class OpenFileTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Open File"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return null; }
        }
    }
}