using System.ComponentModel;
using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;

namespace DemoApplication.Features.FolderBrowserDialog.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 6)]
    public class FolderBrowserTabItemViewModel : TabItemViewModel
    {
        private readonly FolderBrowserTabContentViewModel content;

        [ImportingConstructor]
        public FolderBrowserTabItemViewModel(FolderBrowserTabContentViewModel content)
        {
            this.content = content;
        }

        public override string Title
        {
            get { return "Folder Browser"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return content; }
        }
    }
}