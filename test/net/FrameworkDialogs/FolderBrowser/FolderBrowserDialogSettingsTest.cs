using System.Linq;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs.Utils;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    [TestFixture]
    public class FolderBrowserDialogSettingsTest
    {
        [Test]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var folderBrowserDialogSettingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(FolderBrowserDialogSettings)));

            var folderBrowserDialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(FolderBrowserDialog)).Except(DialogSettings.ExcludedPropertyNames));

            // Assert
            Assert.That(folderBrowserDialogSettingsPropertyNames, Is.EqualTo(folderBrowserDialogPropertyNames));
        }
    }
}