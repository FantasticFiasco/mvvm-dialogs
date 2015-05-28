using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using ReactiveUI;

namespace DemoApplication.Features.SaveFileDialog.ViewModels
{
    [Export]
    public class SaveFileTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ReactiveCommand<object> saveFileCommand;

        private string path;

        [ImportingConstructor]
        public SaveFileTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            saveFileCommand = ReactiveCommand.Create();
            saveFileCommand.Subscribe(_ => SaveFile());
        }

        public string Path
        {
            get { return path; }
            set { this.RaiseAndSetIfChanged(ref path, value); }
        }

        public ICommand SaveFileCommand
        {
            get { return saveFileCommand; }
        }

        private void SaveFile()
        {
            var saveFileDialogViewModel = new SaveFileDialogViewModel
            {
                Title = "This Is The Title",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*",
                CheckFileExists = false
            };

            bool? success = dialogService.ShowSaveFileDialog(this, saveFileDialogViewModel);
            if (success == true)
            {
                Path = saveFileDialogViewModel.FileName;
            }
        }
    }
}