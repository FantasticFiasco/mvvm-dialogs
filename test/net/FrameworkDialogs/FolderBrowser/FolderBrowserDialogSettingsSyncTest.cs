using System.Windows.Forms;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    [TestFixture]
    public class FolderBrowserDialogSettingsSyncTest
    {
        private FolderBrowserDialog dialog;
        private FolderBrowserDialogSettings settings;
        private FolderBrowserDialogSettingsSync sync;

        [SetUp]
        public void SetUp()
        {
            dialog = new FolderBrowserDialog();
            settings = new FolderBrowserDialogSettings();
            sync = new FolderBrowserDialogSettingsSync(dialog, settings);
        }

        [Test]
        public void ToDialog()
        {
            // Arrange
            settings.Description = "Some description";
            settings.SelectedPath = @"C:\temp";
            settings.ShowNewFolderButton = true;

            // Act
            sync.ToDialog();

            // Assert
            Assert.That(dialog.Description, Is.EqualTo(settings.Description));
            Assert.That(dialog.SelectedPath, Is.EqualTo(settings.SelectedPath));
            Assert.That(dialog.ShowNewFolderButton, Is.EqualTo(settings.ShowNewFolderButton));
        }

        [Test]
        public void ToSettings()
        {
            // Arrange
            dialog.SelectedPath = @"C:\temp";

            // Act
            sync.ToSettings();

            // Assert
            Assert.That(settings.SelectedPath, Is.EqualTo(dialog.SelectedPath));
        }
    }
}
