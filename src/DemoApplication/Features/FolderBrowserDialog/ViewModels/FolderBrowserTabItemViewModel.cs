using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;
using GalaSoft.MvvmLight;

namespace DemoApplication.Features.FolderBrowserDialog.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 6)]
    public class FolderBrowserTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Folder Browser"; }
        }

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}