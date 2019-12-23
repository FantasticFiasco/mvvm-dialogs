using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    [TestFixture]
    public class FolderBrowserDialogSettingsTest
    {
        private static readonly string[] ExcludedPropertyNames =
        {
            "Container",
            "Site",
            "Tag"
        };

        [Test]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var folderBrowserDialogPropertyNames = string.Join(
                ", ",
                GetPropertyNames(typeof(FolderBrowserDialog)).Except(ExcludedPropertyNames));

            var folderBrowserDialogSettingsPropertyNames = string.Join(
                ", ",
                GetPropertyNames(typeof(FolderBrowserDialogSettings)));

            // Assert
            Assert.That(folderBrowserDialogPropertyNames, Is.EqualTo(folderBrowserDialogSettingsPropertyNames));
        }

        private static IEnumerable<string> GetPropertyNames(Type type) =>
            type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(p => p.Name)
                .Select(p => p.Name);
    }
}
