using CommunityToolkit.Mvvm.ComponentModel;

namespace Demo.ContentDialog
{
    public class AddTextContentDialogViewModel : ObservableObject
    {
        private string text;
        private bool isOkButtonEnabled;

        public string Text
        {
            get => text;
            set
            {
                if (SetProperty(ref text, value))
                {
                    IsOkButtonEnabled = !string.IsNullOrEmpty(value);
                }
            }
        }

        public bool IsOkButtonEnabled
        {
            get => isOkButtonEnabled;
            private set => SetProperty(ref isOkButtonEnabled, value);
        }
    }
}
