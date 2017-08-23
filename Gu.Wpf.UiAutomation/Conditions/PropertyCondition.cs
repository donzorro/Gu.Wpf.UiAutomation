﻿namespace Gu.Wpf.UiAutomation.Conditions
{
    using Gu.Wpf.UiAutomation.Definitions;
    using Gu.Wpf.UiAutomation.Identifiers;

    public class PropertyCondition : ConditionBase
    {
        public PropertyCondition(PropertyId property, object value)
            : this(property, value, PropertyConditionFlags.None)
        {
        }

        public PropertyCondition(PropertyId property, object value, PropertyConditionFlags propertyConditionFlags)
        {
            this.Property = property;
            this.Value = value;
            this.PropertyConditionFlags = propertyConditionFlags;
        }

        public PropertyId Property { get; }

        public PropertyConditionFlags PropertyConditionFlags { get; private set; }

        public object Value { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Property}: {this.Value}";
        }
    }
}