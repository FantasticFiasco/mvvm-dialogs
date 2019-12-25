using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MvvmDialogs.FrameworkDialogs.Utils
{
    public static class DialogSettings
    {
        public static readonly string[] ExcludedPropertyNames =
        {
            "Container",
            "RestoreDirectory",
            "Site",
            "Tag"
        };

        public static IEnumerable<string> GetPropertyNames(Type type) =>
            type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(p => p.Name)
                .Select(p => p.Name);

        public static IEnumerable<string> GetMessageBoxParameters() =>
            typeof(System.Windows.MessageBox)
                .GetMethods()
                .Where(m => m.Name == "Show")
                .SelectMany(m => m.GetParameters())
                .OrderBy(p => p.Length)
                .Last()
                .Select(p => p.Name);
    }
}
