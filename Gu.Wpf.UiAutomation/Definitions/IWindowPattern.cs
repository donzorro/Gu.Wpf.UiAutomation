namespace Gu.Wpf.UiAutomation
{
    public interface IWindowPattern : IPattern
    {
        IWindowPatternProperties Properties { get; }

        IWindowPatternEvents Events { get; }

        AutomationProperty<bool> CanMaximize { get; }

        AutomationProperty<bool> CanMinimize { get; }

        AutomationProperty<bool> IsModal { get; }

        AutomationProperty<bool> IsTopmost { get; }

        AutomationProperty<WindowInteractionState> WindowInteractionState { get; }

        AutomationProperty<WindowVisualState> WindowVisualState { get; }

        void Close();

        void SetWindowVisualState(WindowVisualState state);

        bool WaitForInputIdle(int milliseconds);
    }
}