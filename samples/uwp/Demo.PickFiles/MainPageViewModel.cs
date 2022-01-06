using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkPickers.FileOpen;
using IOPath = System.IO.Path;

namespace Demo.PickFiles
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        private string singleFilePath;
        private string multipleFilesPath;

        public MainPageViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            PickSingleFileCommand = new RelayCommand(PickSingleFile);
            PickMultipleFilesCommand = new RelayCommand(PickMultipleFiles);
        }

        public string SingleFilePath
        {
            get => singleFilePath;
            private set => SetProperty(ref singleFilePath, value);
        }

        public string MultipleFilesPath
        {
            get => multipleFilesPath;
            private set => SetProperty(ref multipleFilesPath, value);
        }

        public ICommand PickSingleFileCommand { get; }

        public ICommand PickMultipleFilesCommand { get; }

        private async void PickSingleFile()
        {
            var settings = new FileOpenPickerSettings
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                FileTypeFilter = new List<string> { ".txt" }
            };

            StorageFile storageFile = await dialogService.PickSingleFileAsync(settings);
            if (storageFile != null)
            {
                SingleFilePath = storageFile.Path;
            }
        }

        private async void PickMultipleFiles()
        {
            var settings = new FileOpenPickerSettings
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                FileTypeFilter = new List<string> { ".txt" }
            };

            IReadOnlyList<StorageFile> storageFiles = await dialogService.PickMultipleFilesAsync(settings);
            if (storageFiles.Any())
            {
                MultipleFilesPath = string.Join(";", storageFiles.Select(storageFile => storageFile.Path));
            }
        }
    }
}
