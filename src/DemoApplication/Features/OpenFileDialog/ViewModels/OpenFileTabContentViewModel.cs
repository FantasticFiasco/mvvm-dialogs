using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmFoundation.Wpf;

namespace DemoApplication.Features.OpenFileDialog.ViewModels
{
    [Export]
    public class OpenFileTabContentViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly ICommand openFileCommand;

        private string path;

        [ImportingConstructor]
        public OpenFileTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            openFileCommand = new RelayCommand(OpenFile);
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

        public ICommand OpenFileCommand
        {
            get { return openFileCommand; }
        }

        private void OpenFile()
        {
            var openFileDialogViewModel = new OpenFileDialogViewModel
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Title = "This Is The Title"
            };

            bool? success = dialogService.ShowOpenFileDialog(this, openFileDialogViewModel);
            if (success == true)
            {
                Path = openFileDialogViewModel.FileName;
            }
        }
    }
}