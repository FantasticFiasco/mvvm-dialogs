using System.ComponentModel.Composition;
using DemoApplication.TabItemInfrastructure;
using GalaSoft.MvvmLight;

namespace DemoApplication.Features.MessageBox.ViewModels
{
    [Export(typeof(TabItemViewModel))]
    [ExportMetadata("Priority", 3)]
    public class MessageBoxTabItemViewModel : TabItemViewModel
    {
        public override string Title
        {
            get { return "Message Box"; }
        }

        public override ViewModelBase Content
        {
            get { return null; }
        }
    }
}