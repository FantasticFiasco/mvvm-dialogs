using System.ComponentModel;
using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;

namespace DemoApplication.Features.MessageBox.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 3)]
    public class MessageBoxTabItemViewModel : TabItemViewModel
    {
        private readonly MessageBoxTabContentViewModel content;

        [ImportingConstructor]
        public MessageBoxTabItemViewModel(MessageBoxTabContentViewModel content)
        {
            this.content = content;
        }

        public override string Title
        {
            get { return "Message Box"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return content; }
        }
    }
}