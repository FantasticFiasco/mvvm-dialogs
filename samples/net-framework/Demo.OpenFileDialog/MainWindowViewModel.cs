using System.Reflection;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using IOPath = System.IO.Path;

namespace Demo.OpenFileDialog
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private string path;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            OpenFileCommand = new RelayCommand(OpenFile);
        }

        public string Path
        {
            get => path;
            private set { Set(() => Path, ref path, value); }
        }

        public ICommand OpenFileCommand { get; }

        private void OpenFile()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "This Is The Title",
                InitialDirectory = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            bool? success = dialogService.ShowOpenFileDialog(this, settings);
            if (success == true)
            {
                Path = settings.FileName;
            }
        }
    }
}