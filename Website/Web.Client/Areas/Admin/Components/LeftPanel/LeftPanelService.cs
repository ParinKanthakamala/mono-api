using System;
using System.Timers;

namespace Web.Client.Areas.Admin.Components.LeftPanel
{
    public enum PanelContent
    {
        Search,
        Collapse,
        MyApps,
        MyNotification,
        MyTasks,
        MyEvent,
        MyContact,
        MyChat,
        FullScreen,
        Settings,
        Signout
    }

    public class LeftPanelService : IDisposable
    {
        public void Dispose()
        {
        }


        public event Action<string, PanelContent> OnShow;
        public event Action OnHide;

        public void Show(string message, PanelContent panel)
        {
            if (panel == PanelContent.MyApps)
            {
                OnShow?.Invoke(message, panel);
                OnShow?.Invoke(message, panel);
            }
            else if (panel == PanelContent.MyNotification)
            {
                OnShow?.Invoke(message, panel);
                OnShow?.Invoke(message, panel);
            }
            else if (panel == PanelContent.MyTasks)
            {
                OnShow?.Invoke(message, panel);
                OnShow?.Invoke(message, panel);
            }

            OnShow?.Invoke(message, panel);
        }

        private void Hide(object source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }
    }
}