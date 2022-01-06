using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkPickers.FileSave;

namespace Demo.PickSaveFile
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        private string path;

        public MainPageViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            SaveFileCommand = new RelayCommand(SaveFile);
        }

        public string Path
        {
            get => path;
            private set => SetProperty(ref path, value);
        }

        public ICommand SaveFileCommand { get; }

        private async void SaveFile()
        {
            var settings = new FileSavePickerSettings
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                FileTypeChoices = new Dictionary<string, IList<string>>
                {
                    { "Text Documents", new List<string> { ".txt" } }
                },
                DefaultFileExtension = ".txt"
            };

            StorageFile storageFile = await dialogService.PickSaveFileAsync(settings);
            if (storageFile != null)
            {
                Path = storageFile.Path;
            }
        }
    }
}
