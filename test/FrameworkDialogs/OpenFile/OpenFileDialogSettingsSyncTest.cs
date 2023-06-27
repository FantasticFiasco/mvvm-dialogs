using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    public class OpenFileDialogSettingsSyncTest
    {
        [Fact]
        public void ToDialog()
        {
            // Arrange
            var dialog = new Microsoft.Win32.OpenFileDialog();
            var settings = new OpenFileDialogSettings();
            var sync = new OpenFileDialogSettingsSync(dialog, settings);

            settings.AddExtension = !settings.AddExtension;
            settings.CheckFileExists = !settings.CheckFileExists;
            settings.CheckPathExists = !settings.CheckPathExists;
            settings.CustomPlaces = new List<Microsoft.Win32.FileDialogCustomPlace>(new[] { new Microsoft.Win32.FileDialogCustomPlace(Guid.NewGuid()) });
            settings.DefaultExt = "txt";
            settings.DereferenceLinks = !settings.DereferenceLinks;
            settings.FileName = "SomeFile.txt";
            settings.FileNames = new[] { "SomeFile.txt" };
            settings.Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*";
            settings.FilterIndex = 2;
            settings.InitialDirectory = @"C:\temp";
            settings.Multiselect = !settings.Multiselect;
            settings.ReadOnlyChecked = !settings.ReadOnlyChecked;
            settings.SafeFileName = "SomeFile.txt";
            settings.SafeFileNames = new[] { "SomeFile.txt" };
            settings.ShowReadOnly = !settings.ShowReadOnly;
            settings.Title = "Some Title";
            settings.ValidateNames = !settings.ValidateNames;

            // Act
            sync.ToDialog();

            // Assert
            Assert.Equal(settings.AddExtension, dialog.AddExtension);
            Assert.Equal(settings.CheckFileExists, dialog.CheckFileExists);
            Assert.Equal(settings.CheckPathExists, dialog.CheckPathExists);
            Assert.Equal(settings.CustomPlaces, dialog.CustomPlaces);
            Assert.Equal(settings.DefaultExt, dialog.DefaultExt);
            Assert.Equal(settings.DereferenceLinks, dialog.DereferenceLinks);
            Assert.Equal(settings.FileName, dialog.FileName);
            Assert.Equal(settings.FileNames, dialog.FileNames);
            Assert.Equal(settings.Filter, dialog.Filter);
            Assert.Equal(settings.FilterIndex, dialog.FilterIndex);
            Assert.Equal(settings.InitialDirectory, dialog.InitialDirectory);
            Assert.Equal(settings.Multiselect, dialog.Multiselect);
            Assert.Equal(settings.ReadOnlyChecked, dialog.ReadOnlyChecked);
            Assert.Equal(settings.SafeFileName, dialog.SafeFileName);
            Assert.Equal(settings.SafeFileNames, dialog.SafeFileNames);
            Assert.Equal(settings.ShowReadOnly, dialog.ShowReadOnly);
            Assert.Equal(settings.Title, dialog.Title);
            Assert.Equal(settings.ValidateNames, dialog.ValidateNames);
        }

        [Fact]
        public void ToSettings()
        {
            // Arrange
            var dialog = new Microsoft.Win32.OpenFileDialog();
            var settings = new OpenFileDialogSettings();
            var sync = new OpenFileDialogSettingsSync(dialog, settings);

            dialog.FileName = "SomeFile.txt";
            dialog.FilterIndex = 2;

            // Act
            sync.ToSettings();

            // Assert
            Assert.Equal(settings.FileName, dialog.FileName);
            Assert.Equal(settings.FileNames, dialog.FileNames);
            Assert.Equal(settings.FilterIndex, dialog.FilterIndex);
            Assert.Equal(settings.SafeFileName, dialog.SafeFileName);
            Assert.Equal(settings.SafeFileNames, dialog.SafeFileNames);
        }
    }
}
