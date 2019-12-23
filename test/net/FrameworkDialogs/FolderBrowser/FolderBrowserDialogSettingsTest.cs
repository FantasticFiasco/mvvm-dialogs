using System;
using System.Linq;
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
            var folderBrowserDialogPropertyNames = typeof(FolderBrowserDialog)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToArray();

            var folderBrowserDialogSettingsPropertyNames = typeof(FolderBrowserDialogSettings)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToArray();

            Assert.That(folderBrowserDialogPropertyNames, Is.EqualTo(folderBrowserDialogSettingsPropertyNames));
        }
    }
}
