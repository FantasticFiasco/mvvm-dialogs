using System.ComponentModel;
using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;

namespace DemoApplication.Features.OpenFileDialog.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 3)]
    public class OpenFileTabItemViewModel : TabItemViewModel
    {
        private readonly OpenFileTabContentViewModel content;

        [ImportingConstructor]
        public OpenFileTabItemViewModel(OpenFileTabContentViewModel content)
        {
            this.content = content;
        }

        public override string Title
        {
            get { return "Open File"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return content; }
        }
    }
}