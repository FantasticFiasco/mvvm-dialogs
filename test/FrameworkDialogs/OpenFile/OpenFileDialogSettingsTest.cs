//using System.Linq;
//using Microsoft.Win32;
//using MvvmDialogs.FrameworkDialogs.Utils;

//namespace MvvmDialogs.FrameworkDialogs.OpenFile
//{
//    public class OpenFileDialogSettingsTest
//    {
//        [Fact]
//        public void NativeDialogSettingsParity()
//        {
//            // Arrange
//            var settingsPropertyNames = string.Join(
//                ", ",
//                DialogSettings.GetPropertyNames(typeof(OpenFileDialogSettings)));

//            var dialogPropertyNames = string.Join(
//                ", ",
//                DialogSettings.GetPropertyNames(typeof(OpenFileDialog)).Except(DialogSettings.ExcludedPropertyNames));

//            // Assert
//            Assert.That(settingsPropertyNames, Is.EqualTo(dialogPropertyNames));
//        }
//    }
//}
