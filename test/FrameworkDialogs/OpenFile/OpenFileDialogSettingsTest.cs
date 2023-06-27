using MvvmDialogs.FrameworkDialogs.Utils;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    public class OpenFileDialogSettingsTest
    {
        [Fact]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var settingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(OpenFileDialogSettings)));

            var dialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(Microsoft.Win32.OpenFileDialog)).Except(DialogSettings.ExcludedPropertyNames));

            // Assert
            Assert.Equal(dialogPropertyNames, settingsPropertyNames);
        }
    }
}
