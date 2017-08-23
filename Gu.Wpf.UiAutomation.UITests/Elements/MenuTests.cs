﻿namespace Gu.Wpf.UiAutomation.UITests.Elements
{
    using Gu.Wpf.UiAutomation.UITests.TestFramework;
    using NUnit.Framework;

    public class MenuTests : UITestBase
    {
        public MenuTests()
            : base(TestApplicationType.Wpf)
        {
        }

        [Test]
        public void TestMenuWithSubMenus()
        {
            var window = this.App.GetMainWindow(this.Automation);
            var menu = window.FindFirstChild(cf => cf.Menu()).AsMenu();
            Assert.That(menu, Is.Not.Null);
            var items = menu.MenuItems;
            Assert.That(items, Has.Length.EqualTo(2));
            Assert.That(items[0].Properties.Name, Is.EqualTo("File"));
            Assert.That(items[1].Properties.Name, Is.EqualTo("Edit"));
            var subitems1 = items[0].SubMenuItems;
            Assert.That(subitems1, Has.Length.EqualTo(1));
            Assert.That(subitems1[0].Properties.Name, Is.EqualTo("Exit"));
            var subitems2 = items[1].SubMenuItems;
            Assert.That(subitems2, Has.Length.EqualTo(2));
            Assert.That(subitems2[0].Properties.Name, Is.EqualTo("Copy"));
            Assert.That(subitems2[1].Properties.Name, Is.EqualTo("Paste"));
            var subsubitems1 = subitems2[0].SubMenuItems;
            Assert.That(subsubitems1, Has.Length.EqualTo(2));
            Assert.That(subsubitems1[0].Properties.Name, Is.EqualTo("Plain"));
            Assert.That(subsubitems1[1].Properties.Name, Is.EqualTo("Fancy"));
        }

        [Test]
        public void TestMenuWithSubMenusByName()
        {
            var window = this.App.GetMainWindow(this.Automation);
            var menu = window.FindFirstChild(cf => cf.Menu()).AsMenu();
            var edit = menu.MenuItems["Edit"];
            Assert.That(edit, Is.Not.Null);
            Assert.That(edit.Properties.Name.Value, Is.EqualTo("Edit"));
            var copy = edit.SubMenuItems["Copy"];
            Assert.That(copy, Is.Not.Null);
            Assert.That(copy.Properties.Name.Value, Is.EqualTo("Copy"));
            var fancy = copy.SubMenuItems["Fancy"];
            Assert.That(fancy, Is.Not.Null);
            Assert.That(fancy.Properties.Name.Value, Is.EqualTo("Fancy"));
        }
    }
}