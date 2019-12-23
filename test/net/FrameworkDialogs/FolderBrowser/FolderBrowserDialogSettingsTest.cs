using System;
using System.Reflection;
using System.Windows.Forms;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    [TestFixture]
    public class FolderBrowserDialogSettingsTest
    {
        [Test]
        public void NativeDialogSettingsParity()
        {
            var nativeProperties = typeof(FolderBrowserDialog).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var x in nativeProperties)
            {
                Console.WriteLine(x.Name);
            }

            throw new NotImplementedException();
        }
    }
}
