﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.Identifiers;
    using Gu.Wpf.UiAutomation.Patterns;
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;
    using UIA = Interop.UIAutomationClient;

    public class DropTargetPattern : DropTargetPatternBase<UIA.IUIAutomationDropTargetPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_DropTargetPatternId, "DropTarget", AutomationObjectIds.IsDropTargetPatternAvailableProperty);
        public static readonly PropertyId DropTargetEffectProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DropTargetDropTargetEffectPropertyId, "DropTargetEffect");
        public static readonly PropertyId DropTargetEffectsProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DropTargetDropTargetEffectsPropertyId, "DropTargetEffects");
        public static readonly EventId DragEnterEvent = EventId.Register(UIA.UIA_EventIds.UIA_DropTarget_DragEnterEventId, "DragEnter");
        public static readonly EventId DragLeaveEvent = EventId.Register(UIA.UIA_EventIds.UIA_DropTarget_DragLeaveEventId, "DragLeave");
        public static readonly EventId DragCompleteEvent = EventId.Register(UIA.UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");

        public DropTargetPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationDropTargetPattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }
    }
}