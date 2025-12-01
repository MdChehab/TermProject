using System;

namespace TermProject2025.DesignPatterns.Mediator
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Mediator (Concrete Mediator)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Coordinate interactions between MainForm UI components
     *
     * PATTERN MAPPING:
     * - UIMediator → ConcreteMediator
     * - IMediator → Mediator interface
     * - Various UI components → Colleague objects
     *
     * IMPLEMENTATION NOTES:
     * - Coordinates communication between vault list, details panel, and notification panel
     * - Handles events like: item selected, item edited, copy to clipboard, show notification
     * - Reduces direct dependencies between UI components
     * ═══════════════════════════════════════════════════════════════════
     */
    public class UIMediator : IMediator
    {
        // Event handlers for components to subscribe to
        public event EventHandler<object>? ItemSelected;
        public event EventHandler<object>? ItemAdded;
        public event EventHandler<object>? ItemEdited;
        public event EventHandler<object>? ItemDeleted;
        public event EventHandler<string>? DataCopied;
        public event EventHandler<object>? ShowNotification;
        public event EventHandler? RefreshList;
        public event EventHandler? UnmaskData;
        public event EventHandler? MaskData;
        public void Notify(object sender, string eventName, object? data = null)
        {
            switch (eventName)
            {
                case "ItemSelected":
                    ItemSelected?.Invoke(this, data ?? new object());
                    break;

                case "ItemAdded":
                    ItemAdded?.Invoke(this, data ?? new object());
                    RefreshList?.Invoke(this, EventArgs.Empty);
                    break;

                case "ItemEdited":
                    ItemEdited?.Invoke(this, data ?? new object());
                    RefreshList?.Invoke(this, EventArgs.Empty);
                    break;

                case "ItemDeleted":
                    ItemDeleted?.Invoke(this, data ?? new object());
                    RefreshList?.Invoke(this, EventArgs.Empty);
                    break;

                case "CopyToClipboard":
                    if (data is string text)
                    {
                        DataCopied?.Invoke(this, text);
                    }
                    break;

                case "ShowNotification":
                    ShowNotification?.Invoke(this, data ?? new object());
                    break;

                case "RefreshList":
                    RefreshList?.Invoke(this, EventArgs.Empty);
                    break;

                case "UnmaskData":
                    UnmaskData?.Invoke(this, EventArgs.Empty);
                    break;

                case "MaskData":
                    MaskData?.Invoke(this, EventArgs.Empty);
                    break;

                default:
                    // Unknown event - can be logged or ignored
                    break;
            }
        }
    }
}
