using System.ComponentModel;

namespace DemoApplication.Features.FolderBrowserDialog.ViewModels
{
    public class FolderBrowserTabItemViewModel : TabItemViewModel
    {
        private readonly FolderBrowserTabContentViewModel content;

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

        public override int Priority
        {
            get { return 6; }
        }
    }
}