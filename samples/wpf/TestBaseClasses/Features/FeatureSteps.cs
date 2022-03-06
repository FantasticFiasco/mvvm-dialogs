using System;
using System.IO;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Capturing;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace TestBaseClasses.Features
{
    /// <summary>
    /// Base class for UI tests with some helper methods.
    /// This class allows recording videos, taking screen shots on failed tests and
    /// starts and stops the application under test for each test or fixture.
    /// </summary>
    public abstract class FeatureSteps<T> where T : Window
    {
        private string? testMethodName;
        private VideoRecorder? recorder;
        private T? mainScreen;

        /// <summary>
        /// Instance of the current used automation object.
        /// </summary>
        protected AutomationBase? Automation { get; private set; }

        /// <summary>
        /// Specifies the starting mode of the application to test. Defaults to OncePerFixture.
        /// </summary>
        protected virtual ApplicationStartMode ApplicationStartMode => ApplicationStartMode.OncePerFixture;

        /// <summary>
        /// Instance of the current running application.
        /// </summary>
        protected Application? Application { get; set; }

        /// <summary>
        /// Main screen of the application.
        /// </summary>
        protected T MainScreen => mainScreen ?? throw new Exception("Main screen has not been set");

        /// <summary>
        /// Specifies the mode of the video recorder. Defaults to OnePerTest.
        /// </summary>
        protected virtual VideoRecordingMode VideoRecordingMode => VideoRecordingMode.OnePerTest;

        /// <summary>
        /// Flag to indicate if videos should be kept even if the test did not fail. Defaults to
        /// false.
        /// </summary>
        protected virtual bool KeepVideoForSuccessfulTests => false;

        /// <summary>
        /// Path of the directory for the screenshots and videos for the tests. Defaults to
        /// c:\temp\testsmedia.
        /// </summary>
        protected virtual string TestsMediaPath => @"c:\temp\testsmedia";

        /// <summary>
        /// Gets the automation instance that should be used.
        /// </summary>
        protected virtual AutomationBase GetAutomation() => new UIA3Automation();

        /// <summary>
        /// Starts the application which should be tested.
        /// </summary>
        protected abstract Application LaunchApplication();

        /// <summary>
        /// Setup method for the test fixture.
        /// </summary>
        [BeforeScenario]
        public virtual async Task UITestBaseOneTimeSetUp()
        {
            //Logger.Default = new NUnitProgressLogger();

            Automation = GetAutomation();

            if (VideoRecordingMode == VideoRecordingMode.OnePerFixture)
            {
                await StartVideoRecorder(TestContext.CurrentContext.Test.FullName);
            }

            if (ApplicationStartMode == ApplicationStartMode.OncePerFixture)
            {
                Application = LaunchApplication();
            }

            mainScreen = Automation.WaitForMainWindow<T>(Application);
        }

        /// <summary>
        /// Teardown method of the test fixture.
        /// </summary>
        [AfterScenario]
        public virtual Task UITestBaseOneTimeTearDown()
        {
            if (VideoRecordingMode == VideoRecordingMode.OnePerFixture)
            {
                StopVideoRecorder();
            }

            if (ApplicationStartMode == ApplicationStartMode.OncePerFixture)
            {
                CloseApplication();
            }

            if (Automation != null)
            {
                Automation.Dispose();
                Automation = null;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Setup method for each test.
        /// </summary>
        [SetUp]
        public virtual async Task UITestBaseSetUp()
        {
            // Due to the recorder running in an own thread, it is necessary to save the current
            // method name for that thread
            testMethodName = TestContext.CurrentContext.Test.MethodName;

            if (VideoRecordingMode == VideoRecordingMode.OnePerTest)
            {
                await StartVideoRecorder(TestContext.CurrentContext.Test.FullName);
            }

            if (ApplicationStartMode == ApplicationStartMode.OncePerTest)
            {
                Application = LaunchApplication();
            }

            mainScreen = Automation!.WaitForMainWindow<T>(Application);
        }

        /// <summary>
        /// Teardown method for each test.
        /// </summary>
        [TearDown]
        public virtual Task UITestBaseTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TakeScreenShot(TestContext.CurrentContext.Test.FullName);
            }

            if (ApplicationStartMode == ApplicationStartMode.OncePerTest)
            {
                CloseApplication();
            }

            if (VideoRecordingMode == VideoRecordingMode.OnePerTest)
            {
                StopVideoRecorder();
            }

            testMethodName = null;

            return Task.CompletedTask;
        }

        /// <summary>
        /// Closes and starts the application.
        /// </summary>
        protected void RestartApplication()
        {
            CloseApplication();
            Application = LaunchApplication();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void CloseApplication()
        {
            if (Application == null)
            {
                return;
            }
            
            Application.Close();
            Retry.WhileFalse(() => Application.HasExited, TimeSpan.FromSeconds(2), ignoreException: true);
            Application.Dispose();
            Application = null;
        }

        /// <summary>
        /// Method which captures the image for the video and screen shots.
        /// By default captures the main screen.
        /// </summary>
        protected virtual CaptureImage CaptureImage() => Capture.MainScreen();

        /// <summary>
        /// Starts the video recorder.
        /// </summary>
        private async Task StartVideoRecorder(string testName)
        {
            SystemInfo.RefreshAll();

            var settings = new VideoRecorderSettings
            {
                VideoFormat = VideoFormat.xvid,
                VideoQuality = 6,
                TargetVideoPath = Path.Combine(TestsMediaPath, $"{SanitizeFileName(testName)}.avi")
            };

            await AdjustRecorderSettings(settings);

            recorder = new VideoRecorder(settings, r =>
            {
                var image = CaptureImage();

                var infoOverlay = new InfoOverlay(image)
                {
                    RecordTimeSpan = r.RecordTimeSpan,
                    OverlayStringFormat = @"{rt:hh\:mm\:ss\.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc}) / " +
                                          TestContext.CurrentContext.Test.ClassName + "." + (testMethodName ?? "[SetUp]")
                };

                var mouseOverlay = new MouseOverlay(image);

                image.ApplyOverlays(infoOverlay, mouseOverlay);

                return image;
            });

            await Task.Delay(500);
        }

        /// <summary>
        /// Method which allows customizing the settings for the video recorder.
        /// By default downloads ffmpeg and sets the path to ffmpeg.
        /// </summary>
        private async Task AdjustRecorderSettings(VideoRecorderSettings videoRecorderSettings)
        {
            var ffmpegPath = await VideoRecorder.DownloadFFMpeg(@"C:\temp");
            videoRecorderSettings.ffmpegPath = ffmpegPath;
        }

        /// <summary>
        /// Stops the video recorder.
        /// </summary>
        private void StopVideoRecorder()
        {
            if (recorder == null)
            {
                return;
            }
            
            recorder.Stop();

            if (!KeepVideoForSuccessfulTests && TestContext.CurrentContext.Result.FailCount == 0)
            {
                File.Delete(recorder.TargetVideoPath);
            }

            recorder.Dispose();
            recorder = null;
        }

        /// <summary>
        /// Takes a screen shot.
        /// </summary>
        private void TakeScreenShot(string testName)
        {
            var name = $"{SanitizeFileName(testName)}.png"
                .Replace("\"", string.Empty);

            var path = Path.Combine(TestsMediaPath, name);

            try
            {
                Directory.CreateDirectory(TestsMediaPath);
                CaptureImage().ToFile(path);
            }
            catch (Exception e)
            {
                Logger.Default.Warn("Failed to save screen shot to directory: {0}, filename: {1}, Ex: {2}", TestsMediaPath, path, e);
            }
        }

        /// <summary>
        /// Replaces all invalid characters with underlines.
        /// </summary>
        private static string SanitizeFileName(string fileName) =>
            string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
    }
}
