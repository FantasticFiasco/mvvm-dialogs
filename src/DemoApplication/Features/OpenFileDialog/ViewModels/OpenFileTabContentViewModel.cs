using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using ReactiveUI;

namespace DemoApplication.Features.OpenFileDialog.ViewModels
{
    [Export]
    public class OpenFileTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ReactiveCommand<object> openFileCommand;

        private string path;

        [ImportingConstructor]
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
            var openFileDialogViewModel = new OpenFileDialogViewModel
            {
                Title = "This Is The Title",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            bool? success = dialogService.ShowOpenFileDialog(this, openFileDialogViewModel);
            if (success == true)
            {
                Path = openFileDialogViewModel.FileName;
            }
        }
    }
}