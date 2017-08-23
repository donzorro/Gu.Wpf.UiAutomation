﻿namespace Gu.Wpf.UiAutomation.UITests.TestFramework
{
    using System;
    using System.IO;
    using Gu.Wpf.UiAutomation.UIA3;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;

    /// <summary>
    /// Base class for ui test with some helper methods
    /// </summary>
    public abstract class UITestBase
    {
        /// <summary>
        /// Flag which indicates if any test was run on a new instance of the app
        /// </summary>
        private bool wasTestRun;

        protected TestApplicationType ApplicationType { get; }

        /// <summary>
        /// Path of the directory for the screenshots
        /// </summary>
        protected string ScreenshotDir { get; }

        /// <summary>
        /// Instance of the current running application
        /// </summary>
        protected Application App { get; private set; }

        protected AutomationBase Automation { get; }

        protected UITestBase(TestApplicationType appType)
        {
            this.ApplicationType = appType;
            this.ScreenshotDir = @"c:\FailedTestsScreenshots";
            this.wasTestRun = false;
            this.Automation = new UIA3Automation();
        }

        /// <summary>
        /// Setup which starts the application (once per test-class)
        /// </summary>
        [OneTimeSetUp]
        public void BaseSetup()
        {
            switch (this.ApplicationType)
            {
                case TestApplicationType.Custom:
                    this.App = this.StartApplication();
                    break;
                case TestApplicationType.Wpf:
                    this.App = Application.Launch(Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\TestApplications\WpfApplication\bin\WpfApplication.exe"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.App.WaitWhileMainHandleIsMissing();
        }

        /// <summary>
        /// Closes the application after all tests were run
        /// </summary>
        [OneTimeTearDown]
        public void BaseTeardown()
        {
            this.Automation.Dispose();
            this.App.Dispose();
            this.App = null;
        }

        /// <summary>
        /// Takes screenshot on failed tests
        /// </summary>
        [TearDown]
        public void BaseTestTeardown()
        {
            // Mark that a test was run on this application
            this.wasTestRun = true;

            // Make a screenshot if the test failed
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                this.TakeScreenshot(TestContext.CurrentContext.Test.FullName);
            }
        }

        /// <summary>
        /// Method which starts the custom application to test
        /// </summary>
        protected virtual Application StartApplication()
        {
            return null;
        }

        /// <summary>
        /// Restarts the application to test
        /// </summary>
        protected void RestartApp()
        {
            // Don't restart if no test was already run on it
            if (!this.wasTestRun)
            {
                return;
            }

            // Restart the application
            this.BaseTeardown();
            this.BaseSetup();
            this.wasTestRun = false;
        }

        private void TakeScreenshot(string screenshotName)
        {
            var imagename = screenshotName + ".png";
            imagename = imagename.Replace("\"", string.Empty);
            var imagePath = Path.Combine(this.ScreenshotDir, imagename);
            try
            {
                Directory.CreateDirectory(this.ScreenshotDir);
                ScreenCapture.CaptureScreenToFile(imagePath);
                Console.WriteLine("Screenshot taken: {0}", imagePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save screenshot to directory: {0}, filename: {1}, Ex: {2}", this.ScreenshotDir, imagePath, ex);
            }
        }
    }
}