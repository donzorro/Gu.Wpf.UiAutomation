﻿namespace Gu.Wpf.UiAutomation.Conditions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrCondition : JunctionConditionBase
    {
        public OrCondition(ConditionBase condition1, ConditionBase condition2)
            : this(new[] { condition1, condition2 })
        {
        }

        public OrCondition(IEnumerable<ConditionBase> conditions)
        {
            Conditions.AddRange(conditions);
        }

        public override string ToString()
        {
#if NET35
            var conditions = String.Join(" OR ", Conditions.Select(c => c.ToString()).ToArray());
#else
            var conditions = String.Join(" OR ", Conditions.Select(c => c.ToString()));
#endif
            return $"({conditions})";
        }
    }
}
