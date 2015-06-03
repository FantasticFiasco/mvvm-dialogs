using System;
using System.Windows.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using ReactiveUI;

namespace DemoApplication.Features.FolderBrowserDialog.ViewModels
{
    public class FolderBrowserTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ReactiveCommand<object> browseFolderCommand;

        private string path;

        public FolderBrowserTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            
            browseFolderCommand = ReactiveCommand.Create();
            browseFolderCommand.Subscribe(_ => BrowseFolder());
        }

        public string Path
        {
            get { return path; }
            set { this.RaiseAndSetIfChanged(ref path, value); }
        }

        public ICommand BrowseFolderCommand
        {
            get { return browseFolderCommand; }
        }

        private void BrowseFolder()
        {
            var settings = new FolderBrowserDialogSettings
            {
                Description = "This is a description"
            };

            bool? success = dialogService.ShowFolderBrowserDialog(this, settings);
            if (success == true)
            {
                Path = settings.SelectedPath;
            }
        }
    }
}