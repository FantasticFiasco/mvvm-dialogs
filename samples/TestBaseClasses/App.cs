using System.IO;
using System.Reflection;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Xunit;

namespace TestBaseClasses
{
    public class Application : IDisposable
    {
        private readonly string relativeExePath;

        private FlaUI.Core.Application? app;
        private UIA3Automation? automation;

        public Application(string relativeExePath) => this.relativeExePath = relativeExePath;

        public Application Launch()
        {
            if (app != null) throw new InvalidOperationException("Application has already been launched.");

            var filePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(),
                relativeExePath);

            app = FlaUI.Core.Application.Launch(filePath);

            return this;
        }

        public Window GetMainWindow(string title)
        {
            if (app == null) throw new InvalidOperationException("Application has not been launched.");
            
            automation = new UIA3Automation();

            var window = app.GetMainWindow(automation, TimeSpan.FromSeconds(3));
            Assert.Equal(title, window.Title);

            return window;
        }

        public void Dispose()
        {
            app?.Close();
            app?.Dispose();
            automation?.Dispose();
        }
    }
}
