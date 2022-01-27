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
#if NETCOREAPP3_0_OR_GREATER
        [Ignore("Need to fix for .Net Core and later")]
#endif
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var settingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(FolderBrowserDialogSettings)));

            var dialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(FolderBrowserDialog)).Except(DialogSettings.ExcludedPropertyNames));

            // Assert
            Assert.That(settingsPropertyNames, Is.EqualTo(dialogPropertyNames));
        }
    }
}
