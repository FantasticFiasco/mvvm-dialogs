using System.Linq;
using Microsoft.Win32;
using MvvmDialogs.FrameworkDialogs.Utils;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    [TestFixture]
    public class OpenFileDialogSettingsTest
    {
        [Test]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var folderBrowserDialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(OpenFileDialog)).Except(DialogSettings.ExcludedPropertyNames));

            var folderBrowserDialogSettingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(OpenFileDialogSettings)));

            // Assert
            Assert.That(folderBrowserDialogPropertyNames, Is.EqualTo(folderBrowserDialogSettingsPropertyNames));
        }
    }
}
