﻿namespace Gu.Wpf.UiAutomation.AutomationElements.PatternElements
{
    using System;
    using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
    using Gu.Wpf.UiAutomation.Definitions;
    using Gu.Wpf.UiAutomation.Patterns;

    public class ToggleAutomationElement : AutomationElement
    {
        public ToggleAutomationElement(BasicAutomationElementBase basicAutomationElement)
            : base(basicAutomationElement)
        {
        }

        public ITogglePattern TogglePattern => this.Patterns.Toggle.Pattern;

        public ToggleState State
        {
            get => this.TogglePattern.ToggleState;
            set
            {
                // Loop for all states
                for (var i = 0; i < Enum.GetNames(typeof(ToggleState)).Length; i++)
                {
                    // Break if we're in the correct state
                    if (this.State == value)
                    {
                        return;
                    }

                    // Toggle to the next state
                    this.Toggle();
                }
            }
        }

        public void Toggle()
        {
            this.TogglePattern.Toggle();
        }
    }
}