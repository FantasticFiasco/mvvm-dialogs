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
            var settingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(OpenFileDialogSettings)));

            var dialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(OpenFileDialog)).Except(DialogSettings.ExcludedPropertyNames));

            // Assert
            Assert.That(settingsPropertyNames, Is.EqualTo(dialogPropertyNames));
        }
    }
}
