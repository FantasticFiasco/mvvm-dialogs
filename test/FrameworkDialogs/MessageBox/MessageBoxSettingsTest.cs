using MvvmDialogs.FrameworkDialogs.Utils;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    public class MessageBoxSettingsTest
    {
        [Fact]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var messageBoxSettingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(MessageBoxSettings)));

            var messageBoxPropertyNames = string.Join(
                ", ",
                DialogSettings.GetMessageBoxParameters().Except(DialogSettings.ExcludedMessageBoxPropertyNames));

            // Assert
            Assert.Equal(messageBoxPropertyNames, messageBoxSettingsPropertyNames);
        }
    }
}
