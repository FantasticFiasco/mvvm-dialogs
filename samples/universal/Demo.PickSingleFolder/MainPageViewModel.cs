using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using MvvmDialogs.FrameworkPickers.Folder;

namespace Demo.PickSingleFolder
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private string path;

        public MainPageViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            BrowseFolderCommand = new RelayCommand(BrowseFolder);
        }

        public string Path
        {
            get => path;
            private set { Set(() => Path, ref path, value); }
        }

        public ICommand BrowseFolderCommand { get; }

        private async void BrowseFolder()
        {
            var settings = new FolderPickerSettings
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                FileTypeFilter = new List<string> { ".txt" }
            };

            StorageFolder storageFolder = await dialogService.PickSingleFolderAsync(settings);
            if (storageFolder != null)
            {
                Path = storageFolder.Path;
            }
        }
    }
}