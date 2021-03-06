﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;

    public class TogglePattern : TogglePatternBase<Interop.UIAutomationClient.IUIAutomationTogglePattern>
    {
        public static readonly PatternId Pattern = PatternId.GetOrCreate(Interop.UIAutomationClient.UIA_PatternIds.UIA_TogglePatternId, "Toggle", AutomationObjectIds.IsTogglePatternAvailableProperty);
        public static readonly PropertyId ToggleStateProperty = PropertyId.GetOrCreate(Interop.UIAutomationClient.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        public TogglePattern(BasicAutomationElementBase basicAutomationElement, Interop.UIAutomationClient.IUIAutomationTogglePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Toggle()
        {
            Com.Call(() => this.NativePattern.Toggle());
        }
    }
}
