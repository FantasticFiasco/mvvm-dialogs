using System;
using System.Linq;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;

// ReSharper disable once CheckNamespace
namespace FlaUI.Core.AutomationElements
{
    public static class WindowExtensions
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(1);

        public static T WaitForModalWindow<T>(this Window self, string name) where T : Window =>
            Retry.WhileNull(() => self.ModalWindows.FirstOrDefault(x => x.Name == name), Timeout).Result.As<T>();

        public static T? WaitForChildWindow<T>(this Window self, string name) where T : Window
        {
            T? GetNamedChild()
            {
                var children = self.FindAllChildren(cf => cf.ByControlType(ControlType.Window));
                var windows = children.Select(e => e.AsWindow());

                // This is the correct way, but the title is not being captured
                //return windows.FirstOrDefault(x => x.Name == name)?.As<T>();

                // Title is displaying wrong attribute
                return windows.FirstOrDefault(x => x.Title.ToLowerInvariant().Contains(name.ToLowerInvariant()))?.As<T>();
            }

            return Retry.WhileNull(GetNamedChild, Timeout).Result;
        }

        public static T? WaitForChildWindow<T>(this Window self) where T : Window
        {
            T? GetNamedChild()
            {
                var children = self.FindAllChildren(cf => cf.ByControlType(ControlType.Window));
                var windows = children.Select(e => e.AsWindow());
                return windows.FirstOrDefault()?.As<T>();
            }

            return Retry.WhileNull(GetNamedChild, Timeout).Result;
        }
    }
}
