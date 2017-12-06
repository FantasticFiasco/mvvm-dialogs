using GalaSoft.MvvmLight;

namespace Demo.CustomContentDialog
{
    public class AddTextCustomContentDialogViewModel : ViewModelBase
    {
        private string text;
        private bool isOkButtonEnabled;

        public string Text
        {
            get => text;
            set
            {
                if (Set(nameof(Text), ref text, value))
                {
                    IsOkButtonEnabled = !string.IsNullOrEmpty(value);
                }
            }
        }

        public bool IsOkButtonEnabled
        {
            get => isOkButtonEnabled;
            private set => Set(nameof(IsOkButtonEnabled), ref isOkButtonEnabled, value);
        }
    }
}