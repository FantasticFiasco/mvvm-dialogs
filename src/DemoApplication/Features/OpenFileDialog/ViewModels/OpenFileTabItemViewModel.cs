using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;
using GalaSoft.MvvmLight;

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

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}