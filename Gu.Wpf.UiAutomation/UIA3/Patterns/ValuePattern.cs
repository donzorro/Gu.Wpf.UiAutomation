﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;

    public class ValuePattern : ValuePatternBase<Interop.UIAutomationClient.IUIAutomationValuePattern>
    {
        public static readonly PatternId Pattern = PatternId.GetOrCreate(Interop.UIAutomationClient.UIA_PatternIds.UIA_ValuePatternId, "Value", AutomationObjectIds.IsValuePatternAvailableProperty);
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.GetOrCreate(Interop.UIAutomationClient.UIA_PropertyIds.UIA_ValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.GetOrCreate(Interop.UIAutomationClient.UIA_PropertyIds.UIA_ValueValuePropertyId, "Value");

        public ValuePattern(BasicAutomationElementBase basicAutomationElement, Interop.UIAutomationClient.IUIAutomationValuePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        public override void SetValue(string value)
        {
            Com.Call(() => this.NativePattern.SetValue(value));
        }
    }
}
