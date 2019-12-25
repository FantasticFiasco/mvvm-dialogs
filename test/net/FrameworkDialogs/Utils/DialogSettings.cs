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

        public static readonly string[] ExcludedMessageBoxPropertyNames =
        {
            "Owner"
        };

        public static IEnumerable<string> GetPropertyNames(Type type) =>
            type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => p.Name)
                .OrderBy(name => name);

        public static IEnumerable<string> GetMessageBoxParameters() =>
            typeof(System.Windows.MessageBox)
                .GetMethods()
                .Where(m => m.Name == "Show")
                .OrderBy(m => m.GetParameters().Length)
                .Select(m => m.GetParameters())
                .Last()
                .Select(p => Char.ToUpperInvariant(p.Name[0]) + p.Name.Substring(1))    // To camel case
                .OrderBy(name => name);
    }
}
