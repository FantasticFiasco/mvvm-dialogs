using System;
using System.Collections.Generic;
using Microsoft.Win32;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    [TestFixture]
    public class SaveFileDialogSettingsSyncTest
    {
        private SaveFileDialog dialog;
        private SaveFileDialogSettings settings;
        private SaveFileDialogSettingsSync sync;

        [SetUp]
        public void SetUp()
        {
            dialog = new SaveFileDialog();
            settings = new SaveFileDialogSettings();
            sync = new SaveFileDialogSettingsSync(dialog, settings);
        }

        [Test]
        public void ToDialog()
        {
            // Arrange
            settings.AddExtension = false;
            settings.CheckFileExists = false;
            settings.CheckPathExists = false;
            settings.CreatePrompt = true;
            settings.CustomPlaces = new List<FileDialogCustomPlace>(new[] { new FileDialogCustomPlace(Guid.NewGuid()) });
            settings.DefaultExt = "txt";
            settings.FileName = "SomeFile.txt";
            settings.FileNames = new[] { "SomeFile.txt" };
            settings.Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*";
            settings.FilterIndex = 2;
            settings.InitialDirectory = @"C:\temp";
            settings.OverwritePrompt = true;
            settings.Title = "Some Title";

            // Act
            sync.ToDialog();

            // Assert
            Assert.That(dialog.AddExtension, Is.EqualTo(settings.AddExtension));
            Assert.That(dialog.CheckFileExists, Is.EqualTo(settings.CheckFileExists));
            Assert.That(dialog.CheckPathExists, Is.EqualTo(settings.CheckPathExists));
            Assert.That(dialog.CreatePrompt, Is.EqualTo(settings.CreatePrompt));
            Assert.That(dialog.CustomPlaces, Is.EqualTo(settings.CustomPlaces));
            Assert.That(dialog.DefaultExt, Is.EqualTo(settings.DefaultExt));
            Assert.That(dialog.FileName, Is.EqualTo(settings.FileName));
            Assert.That(dialog.FileNames, Is.EqualTo(settings.FileNames));
            Assert.That(dialog.Filter, Is.EqualTo(settings.Filter));
            Assert.That(dialog.FilterIndex, Is.EqualTo(settings.FilterIndex));
            Assert.That(dialog.InitialDirectory, Is.EqualTo(settings.InitialDirectory));
            Assert.That(dialog.OverwritePrompt, Is.EqualTo(settings.OverwritePrompt));
            Assert.That(dialog.Title, Is.EqualTo(settings.Title));
        }

        [Test]
        public void ToSettings()
        {
            // Arrange
            dialog.FileName = "SomeFile.txt";
            dialog.FilterIndex = 2;

            // Act
            sync.ToSettings();

            // Assert
            Assert.That(settings.FileName, Is.EqualTo(dialog.FileName));
            Assert.That(settings.FileNames, Is.EqualTo(dialog.FileNames));
            Assert.That(settings.FilterIndex, Is.EqualTo(dialog.FilterIndex));
        }
    }
}
