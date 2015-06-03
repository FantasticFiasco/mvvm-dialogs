using System.ComponentModel;

namespace DemoApplication.Features.SaveFileDialog.ViewModels
{
    public class SaveFileTabItemViewModel : TabItemViewModel
    {
        private readonly SaveFileTabContentViewModel content;

        public SaveFileTabItemViewModel(SaveFileTabContentViewModel content)
        {
            this.content = content;
        }

        public override string Title
        {
            get { return "Save File"; }
        }

        public override INotifyPropertyChanged Content
        {
            get { return content; }
        }

        public override int Priority
        {
            get { return 5; }
        }
    }
}