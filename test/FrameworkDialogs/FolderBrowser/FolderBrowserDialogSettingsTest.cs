using MvvmDialogs.FrameworkDialogs.Utils;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    public class FolderBrowserDialogSettingsTest
    {
        [Fact]
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
            Assert.Equal(dialogPropertyNames, settingsPropertyNames);
        }
    }
}
