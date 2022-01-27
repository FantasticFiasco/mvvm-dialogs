using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.ScreenObjects;

namespace TestBaseClasses.Features
{
    /// <summary>
    /// Base class for all tests that are driven by SpecFlow.
    /// </summary>
    public abstract class FeatureSteps<T> where T : AppScreen
    {
        protected Application? Application { get; private set; }

        protected ScreenRepository? ScreenRepository { get; private set; }

        protected T? MainScreen { get; private set; }

        [BeforeScenario]
        public void InitialBeforeScenario()
        {
            Application = LaunchApplication();
            ScreenRepository = new ScreenRepository(Application.ApplicationSession);
            MainScreen = GetMainScreen(ScreenRepository);
        }

        [AfterScenario]
        public void InitialAfterScenario()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TakeScreenshot();
            }

            Application?.Close();
        }

        protected abstract Application LaunchApplication();

        protected abstract T GetMainScreen(ScreenRepository screenRepository);

        private static void TakeScreenshot()
        {
            string directoryName = Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                "FailedTestScreenshots");

            string filePath = Path.Combine(
                directoryName,
                $"Failed_{TestContext.CurrentContext.Test.FullName}.png");

            try
            {
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                Desktop.TakeScreenshot(filePath, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Trace.TraceError($"Unable to take screenshot and save it to '{filePath}'.{Environment.NewLine}{e}");
            }
        }
    }
}
