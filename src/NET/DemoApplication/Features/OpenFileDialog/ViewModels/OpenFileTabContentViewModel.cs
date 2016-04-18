using System;
using System.Windows.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using ReactiveUI;

namespace DemoApplication.Features.OpenFileDialog.ViewModels
{
    public class OpenFileTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ReactiveCommand<object> openFileCommand;

        private string path;

        public OpenFileTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            
            openFileCommand = ReactiveCommand.Create();
            openFileCommand.Subscribe(_ => OpenFile());
        }

        public string Path
        {
            get { return path; }
            set { this.RaiseAndSetIfChanged(ref path, value); }
        }

        public ICommand OpenFileCommand
        {
            get { return openFileCommand; }
        }

        private void OpenFile()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "This Is The Title",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
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