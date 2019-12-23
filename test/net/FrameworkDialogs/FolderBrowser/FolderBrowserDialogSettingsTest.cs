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
            var nativePropertyNames = typeof(FolderBrowserDialog)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToHashSet(p => p.Name);

            foreach (var x in nativePropertyNames)
            {
                Console.WriteLine(x);
            }

            throw new NotImplementedException();
        }
    }
}
