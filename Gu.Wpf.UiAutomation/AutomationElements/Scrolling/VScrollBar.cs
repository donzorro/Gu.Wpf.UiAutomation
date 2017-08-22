﻿namespace Gu.Wpf.UiAutomation.AutomationElements.Scrolling
{
    using System;

    public class VScrollBar : ScrollBarBase
    {
        public VScrollBar(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected override string SmallDecrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PART_LineUpButton";
                    case FrameworkType.WinForms:
                    case FrameworkType.Win32:
                        switch (AutomationType)
                        {
                            case AutomationType.UIA2:
                                return "SmallDecrement";
                            case AutomationType.UIA3:
                                return "UpButton";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected override string SmallIncrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PART_LineDownButton";
                    case FrameworkType.WinForms:
                    case FrameworkType.Win32:
                        switch (AutomationType)
                        {
                            case AutomationType.UIA2:
                                return "SmallIncrement";
                            case AutomationType.UIA3:
                                return "DownButton";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected override string LargeDecrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PageUp";
                    case FrameworkType.WinForms:
                    case FrameworkType.Win32:
                        switch (AutomationType)
                        {
                            case AutomationType.UIA2:
                                return "LargeDecrement";
                            case AutomationType.UIA3:
                                return "DownPageButton";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected override string LargeIncrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PageDown";
                    case FrameworkType.WinForms:
                    case FrameworkType.Win32:
                        switch (AutomationType)
                        {
                            case AutomationType.UIA2:
                                return "LargeIncrement";
                            case AutomationType.UIA3:
                                return "UpPageButton";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void ScrollUp()
        {
            SmallDecrementButton.Invoke();
        }

        public void ScrollDown()
        {
            SmallIncrementButton.Invoke();
        }

        public void ScrollUpLarge()
        {
            LargeDecrementButton.Invoke();
        }

        public void ScrollDownLarge()
        {
            LargeIncrementButton.Invoke();
        }
    }
}
