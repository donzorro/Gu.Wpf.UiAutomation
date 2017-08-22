﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.Identifiers;
    using Gu.Wpf.UiAutomation.Patterns;
    using Gu.Wpf.UiAutomation.UIA3.Converters;
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;
    using UIA = Interop.UIAutomationClient;

    public class TablePattern : TablePatternBase<UIA.IUIAutomationTablePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TablePatternId, "Table", AutomationObjectIds.IsTablePatternAvailableProperty);
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableColumnHeadersPropertyId, "ColumnHeaders").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowHeadersPropertyId, "RowHeaders").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowOrColumnMajorPropertyId, "RowOrColumnMajor");

        public TablePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTablePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }
    }

    public class TablePatternProperties : ITablePatternProperties
    {
        public PropertyId ColumnHeaders => TablePattern.ColumnHeadersProperty;
        public PropertyId RowHeaders => TablePattern.RowHeadersProperty;
        public PropertyId RowOrColumnMajor => TablePattern.RowOrColumnMajorProperty;
    }
}
