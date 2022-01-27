using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using IOPath = System.IO.Path;

namespace Demo.SaveFileDialog
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        private string? path;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            SaveFileCommand = new RelayCommand(SaveFile);
        }

        public string? Path
        {
            get => path;
            private set => SetProperty(ref path, value);
        }

        public ICommand SaveFileCommand { get; }

        private void SaveFile()
        {
            var settings = new SaveFileDialogSettings
            {
                Title = "This Is The Title",
                InitialDirectory = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*",
                CheckFileExists = false
            };

            bool? success = dialogService.ShowSaveFileDialog(this, settings);
            if (success == true)
            {
                Path = settings.FileName;
            }
        }
    }
}
