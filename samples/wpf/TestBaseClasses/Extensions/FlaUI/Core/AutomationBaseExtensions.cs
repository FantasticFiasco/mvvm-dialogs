using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

// ReSharper disable once CheckNamespace
namespace FlaUI.Core
{
    public static class AutomationBaseExtensions
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(1);

        public static T? WaitForMainWindow<T>(this AutomationBase self, Application? application) where T : Window =>
            Retry.WhileNull(() => application?.GetMainWindow(self), Timeout).Result.As<T>();
    }
}
