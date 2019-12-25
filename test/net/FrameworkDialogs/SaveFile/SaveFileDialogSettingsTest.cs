using System.Linq;
using Microsoft.Win32;
using MvvmDialogs.FrameworkDialogs.Utils;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    [TestFixture]
    public class SaveFileDialogSettingsTest
    {
        [Test]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var saveFileDialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(SaveFileDialog)).Except(DialogSettings.ExcludedPropertyNames));

            var saveFileDialogSettingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(SaveFileDialogSettings)));

            // Assert
            Assert.That(saveFileDialogSettingsPropertyNames, Is.EqualTo(saveFileDialogPropertyNames));
        }
    }
}
