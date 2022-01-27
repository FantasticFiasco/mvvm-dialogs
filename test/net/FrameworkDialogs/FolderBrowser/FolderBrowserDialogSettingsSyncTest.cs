using System;
using System.Windows.Forms;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    [TestFixture]
    public class FolderBrowserDialogSettingsSyncTest
    {
        [Test]
        public void ToDialog()
        {
            // Arrange
            var dialog = new FolderBrowserDialog();
            var settings = new FolderBrowserDialogSettings();
            var sync = new FolderBrowserDialogSettingsSync(dialog, settings);

            settings.Description = "Some description";
            settings.RootFolder = Environment.SpecialFolder.ProgramFiles;
            settings.SelectedPath = @"C:\temp";
            settings.ShowNewFolderButton = !settings.ShowNewFolderButton;

            // Act
            sync.ToDialog();

            // Assert
            Assert.That(dialog.Description, Is.EqualTo(settings.Description));
            Assert.That(dialog.RootFolder, Is.EqualTo(settings.RootFolder));
            Assert.That(dialog.SelectedPath, Is.EqualTo(settings.SelectedPath));
            Assert.That(dialog.ShowNewFolderButton, Is.EqualTo(settings.ShowNewFolderButton));
        }

        [Test]
        public void ToSettings()
        {
            // Arrange
            var dialog = new FolderBrowserDialog();
            var settings = new FolderBrowserDialogSettings();
            var sync = new FolderBrowserDialogSettingsSync(dialog, settings);

            dialog.SelectedPath = @"C:\temp";

            // Act
            sync.ToSettings();

            // Assert
            Assert.That(settings.SelectedPath, Is.EqualTo(dialog.SelectedPath));
        }
    }
}
