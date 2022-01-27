using System;
using System.Linq;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;

namespace TestBaseClasses.Features
{
    public static class WindowExtensions
    {

        static readonly TimeSpan RetryTimeSpan = TimeSpan.FromSeconds(1);

        public static T GetModal<T>(this Window window, string name) where T : Window =>
            Retry.WhileNull(() => window.ModalWindows.FirstOrDefault(x => x.Name == name), RetryTimeSpan).Result.As<T>();

        public static T? GetChildWindow<T>(this Window window, string name) where T : Window
        {
            T? GetNamedChild()
            {
                var children = window.FindAllChildren(cf => cf.ByControlType(ControlType.Window));
                var windows = children.Select(e => e.AsWindow());

                // This is the correct way, but the title is not being captured
                //return windows.FirstOrDefault(x => x.Name == name)?.As<T>();

                // Title is displaying wrong attribute
                return windows.FirstOrDefault(x => x.Title.ToLowerInvariant().Contains(name.ToLowerInvariant()))?.As<T>();
            }

            return Retry.WhileNull(() => GetNamedChild(), RetryTimeSpan).Result;
        }
        public static T? GetChildWindow<T>(this Window window) where T : Window
        {
            T? GetNamedChild()
            {
                var children = window.FindAllChildren(cf => cf.ByControlType(ControlType.Window));
                var windows = children.Select(e => e.AsWindow());
                return windows.FirstOrDefault()?.As<T>();
            }

            return Retry.WhileNull(() => GetNamedChild(), RetryTimeSpan).Result;
        }
    }
}
