using MvvmDialogs.FrameworkDialogs.Utils;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    public class SaveFileDialogSettingsTest
    {
        [Fact]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var settingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(SaveFileDialogSettings)));

            var dialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(Microsoft.Win32.SaveFileDialog)).Except(DialogSettings.ExcludedPropertyNames));

            // Assert
            Assert.Equal(dialogPropertyNames, settingsPropertyNames);
        }
    }
}
