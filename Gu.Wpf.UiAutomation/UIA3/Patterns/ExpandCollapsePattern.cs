﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;

    public class ExpandCollapsePattern : ExpandCollapsePatternBase<Interop.UIAutomationClient.IUIAutomationExpandCollapsePattern>
    {
        public static readonly PatternId Pattern = PatternId.GetOrCreate(Interop.UIAutomationClient.UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse", AutomationObjectIds.IsExpandCollapsePatternAvailableProperty);
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.GetOrCreate(Interop.UIAutomationClient.UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        public ExpandCollapsePattern(BasicAutomationElementBase basicAutomationElement, Interop.UIAutomationClient.IUIAutomationExpandCollapsePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Collapse()
        {
            Com.Call(() => this.NativePattern.Collapse());
        }

        public override void Expand()
        {
            Com.Call(() => this.NativePattern.Expand());
        }
    }
}
