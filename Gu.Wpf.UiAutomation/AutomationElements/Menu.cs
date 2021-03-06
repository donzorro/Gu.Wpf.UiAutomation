﻿namespace Gu.Wpf.UiAutomation
{
    /// <summary>
    /// Represents a menu or a menubar, which contains menuitems
    /// </summary>
    public class Menu : Control
    {
        public Menu(BasicAutomationElementBase basicAutomationElement)
            : base(basicAutomationElement)
        {
        }

        public MenuItems Items
        {
            get
            {
                var childItems = this.FindAllChildren(
                    cf => cf.ByControlType(ControlType.MenuItem),
                    x => new MenuItem(x) { IsWin32Menu = this.IsWin32Menu });
                return new MenuItems(childItems);
            }
        }

        /// <summary>
        /// Flag to indicate if the menu is a Win32 menu because that one needs special handling
        /// </summary>
        public bool IsWin32Menu { get; set; }
    }
}
