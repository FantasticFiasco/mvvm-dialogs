using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;
using GalaSoft.MvvmLight;

namespace DemoApplication.Features.MessageBox.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 3)]
    public class MessageBoxTabItemViewModel : TabItemViewModel
    {
        private readonly MessageBoxTabContentViewModel contentViewModel;

        [ImportingConstructor]
        public MessageBoxTabItemViewModel(MessageBoxTabContentViewModel contentViewModel)
        {
            this.contentViewModel = contentViewModel;
        }

        public override string Title
        {
            get { return "Message Box"; }
        }

        public override ViewModelBase Content
        {
            get { return contentViewModel; }
        }
    }
}