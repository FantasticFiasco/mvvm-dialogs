using System.ComponentModel;

namespace DemoApplication.Features.MessageBox.ViewModels
{
    public class MessageBoxTabItemViewModel : TabItemViewModel
    {
        private readonly MessageBoxTabContentViewModel content;

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

        public override int Priority
        {
            get { return 3; }
        }
    }
}