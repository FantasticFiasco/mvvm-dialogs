using System;
using System.Collections.Generic;
using Microsoft.Win32;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    [TestFixture]
    public class SaveFileDialogSettingsSyncTest
    {
        [Test]
        public void ToDialog()
        {
            // Arrange
            var dialog = new SaveFileDialog();
            var settings = new SaveFileDialogSettings();
            var sync = new SaveFileDialogSettingsSync(dialog, settings);

            settings.AddExtension = !settings.AddExtension;
            settings.CheckFileExists = !settings.CheckFileExists;
            settings.CheckPathExists = !settings.CheckPathExists;
            settings.CreatePrompt = !settings.CreatePrompt;
            settings.CustomPlaces = new List<FileDialogCustomPlace>(new[] { new FileDialogCustomPlace(Guid.NewGuid()) });
            settings.DefaultExt = "txt";
            settings.DereferenceLinks = !settings.DereferenceLinks;
            settings.FileName = "SomeFile.txt";
            settings.FileNames = new[] { "SomeFile.txt" };
            settings.Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*";
            settings.FilterIndex = 2;
            settings.InitialDirectory = @"C:\temp";
            settings.OverwritePrompt = !settings.OverwritePrompt;
            settings.SafeFileName = "SomeFile.txt";
            settings.SafeFileNames = new[] { "SomeFile.txt" };
            settings.Title = "Some Title";
            settings.ValidateNames = !settings.ValidateNames;

            // Act
            sync.ToDialog();

            // Assert
            Assert.That(dialog.AddExtension, Is.EqualTo(settings.AddExtension));
            Assert.That(dialog.CheckFileExists, Is.EqualTo(settings.CheckFileExists));
            Assert.That(dialog.CheckPathExists, Is.EqualTo(settings.CheckPathExists));
            Assert.That(dialog.CreatePrompt, Is.EqualTo(settings.CreatePrompt));
            Assert.That(dialog.CustomPlaces, Is.EqualTo(settings.CustomPlaces));
            Assert.That(dialog.DefaultExt, Is.EqualTo(settings.DefaultExt));
            Assert.That(dialog.DereferenceLinks, Is.EqualTo(settings.DereferenceLinks));
            Assert.That(dialog.FileName, Is.EqualTo(settings.FileName));
            Assert.That(dialog.FileNames, Is.EqualTo(settings.FileNames));
            Assert.That(dialog.Filter, Is.EqualTo(settings.Filter));
            Assert.That(dialog.FilterIndex, Is.EqualTo(settings.FilterIndex));
            Assert.That(dialog.InitialDirectory, Is.EqualTo(settings.InitialDirectory));
            Assert.That(dialog.OverwritePrompt, Is.EqualTo(settings.OverwritePrompt));
            Assert.That(dialog.SafeFileName, Is.EqualTo(settings.SafeFileName));
            Assert.That(dialog.SafeFileNames, Is.EqualTo(settings.SafeFileNames));
            Assert.That(dialog.Title, Is.EqualTo(settings.Title));
            Assert.That(dialog.ValidateNames, Is.EqualTo(settings.ValidateNames));
        }

        [Test]
        public void ToSettings()
        {
            // Arrange
            var dialog = new SaveFileDialog();
            var settings = new SaveFileDialogSettings();
            var sync = new SaveFileDialogSettingsSync(dialog, settings);

            dialog.FileName = "SomeFile.txt";
            dialog.FilterIndex = 2;

            // Act
            sync.ToSettings();

            // Assert
            Assert.That(settings.FileName, Is.EqualTo(dialog.FileName));
            Assert.That(settings.FileNames, Is.EqualTo(dialog.FileNames));
            Assert.That(settings.FilterIndex, Is.EqualTo(dialog.FilterIndex));
            Assert.That(settings.SafeFileName, Is.EqualTo(dialog.SafeFileName));
            Assert.That(settings.SafeFileNames, Is.EqualTo(dialog.SafeFileNames));
        }
    }
}
