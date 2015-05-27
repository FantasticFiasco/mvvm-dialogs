using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using MvvmFoundation.Wpf;

namespace DemoApplication.Features.SaveFileDialog.ViewModels
{
    [Export]
    public class SaveFileTabContentViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly ICommand saveFileCommand;

        private string path;

        [ImportingConstructor]
        public SaveFileTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            saveFileCommand = new RelayCommand(SaveFile);
        }

        public string Path
        {
            get { return path; }
            set
            {
                if (path == value)
                    return;

                path = value;
                RaisePropertyChanged("Path");
            }
        }

        public ICommand SaveFileCommand
        {
            get { return saveFileCommand; }
        }

        private void SaveFile()
        {
            var saveFileDialogViewModel = new SaveFileDialogViewModel
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Title = "This Is The Title",
                Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            bool? success = dialogService.ShowSaveFileDialog(this, saveFileDialogViewModel);
            if (success == true)
            {
                Path = saveFileDialogViewModel.FileName;
            }
        }
    }
}