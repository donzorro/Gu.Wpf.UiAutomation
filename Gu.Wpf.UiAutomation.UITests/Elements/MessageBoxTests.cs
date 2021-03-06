﻿namespace Gu.Wpf.UiAutomation.UiTests.Elements
{
    using NUnit.Framework;

    public class MessageBoxTests
    {
        private const string ExeFileName = "WpfApplication.exe";

        [Test]
        public void MessageBox()
        {
            using (var app = Application.Launch(ExeFileName, "DialogWindow"))
            {
                var window = app.MainWindow;
                window.FindButton("Show MessageBox").Click();
                var messageBox = window.FindMessageBox();
                Assert.AreEqual("Message", messageBox.FindLabel().Text);
                messageBox.Close();
            }
        }
    }
}