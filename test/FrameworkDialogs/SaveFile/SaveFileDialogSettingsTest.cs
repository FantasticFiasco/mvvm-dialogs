//using System.Linq;
//using Microsoft.Win32;
//using MvvmDialogs.FrameworkDialogs.Utils;

//namespace MvvmDialogs.FrameworkDialogs.SaveFile
//{
//    public class SaveFileDialogSettingsTest
//    {
//        [Fact]
//        public void NativeDialogSettingsParity()
//        {
//            // Arrange
//            var settingsPropertyNames = string.Join(
//                ", ",
//                DialogSettings.GetPropertyNames(typeof(SaveFileDialogSettings)));

//            var dialogPropertyNames = string.Join(
//                ", ",
//                DialogSettings.GetPropertyNames(typeof(SaveFileDialog)).Except(DialogSettings.ExcludedPropertyNames));

//            // Assert
//            Assert.That(settingsPropertyNames, Is.EqualTo(dialogPropertyNames));
//        }
//    }
//}
