﻿namespace Gu.Wpf.UiAutomation.Conditions
{
    using System;

    public class BoolCondition : ConditionBase
    {
        public BoolCondition(bool booleanValue)
        {
            this.BooleanValue = booleanValue;
        }

        public bool BooleanValue { get; }

        public override string ToString()
        {
            return String.Format("BOOL: {0}", this.BooleanValue);
        }
    }

    public class TrueCondition : BoolCondition
    {
        public TrueCondition()
            : base(true)
        {
        }
    }

    public class FalseCondition : BoolCondition
    {
        public FalseCondition()
            : base(false)
        {
        }
    }
}
