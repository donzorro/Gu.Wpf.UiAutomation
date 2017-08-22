﻿namespace Gu.Wpf.UiAutomation.Patterns
{
    using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
    using Gu.Wpf.UiAutomation.Identifiers;
    using Gu.Wpf.UiAutomation.Patterns.Infrastructure;

    public interface ISelectionItemPattern : IPattern
    {
        ISelectionItemPatternProperties Properties { get; }
        ISelectionItemPatternEvents Events { get; }

        AutomationProperty<bool> IsSelected { get; }
        AutomationProperty<AutomationElement> SelectionContainer { get; }

        void AddToSelection();
        void RemoveFromSelection();
        void Select();
    }

    public interface ISelectionItemPatternProperties
    {
        PropertyId IsSelected { get; }
        PropertyId SelectionContainer { get; }
    }

    public interface ISelectionItemPatternEvents
    {
        EventId ElementAddedToSelectionEvent { get; }
        EventId ElementRemovedFromSelectionEvent { get; }
        EventId ElementSelectedEvent { get; }
    }

    public abstract class SelectionItemPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISelectionItemPattern
    {
        private AutomationProperty<bool> isSelected;
        private AutomationProperty<AutomationElement> selectionContainer;

        protected SelectionItemPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        public ISelectionItemPatternProperties Properties => this.Automation.PropertyLibrary.SelectionItem;
        public ISelectionItemPatternEvents Events => this.Automation.EventLibrary.SelectionItem;

        public AutomationProperty<bool> IsSelected => this.GetOrCreate(ref this.isSelected, this.Properties.IsSelected);
        public AutomationProperty<AutomationElement> SelectionContainer => this.GetOrCreate(ref this.selectionContainer, this.Properties.SelectionContainer);

        public abstract void AddToSelection();
        public abstract void RemoveFromSelection();
        public abstract void Select();
    }
}
