using System.Collections.Generic;

namespace Server.Core
{
    public class SharePoint
    {
        private static SharePoint instance;
        private readonly Dictionary<string, object> data = new();

        private SharePoint()
        {
        }

        public object this[string key]
        {
            get => data.ContainsKey(key) ? data[key] : null;
            set
            {
                if (data.ContainsKey(key)) data.Remove(key);
                if (value != null) data.Add(key, value);
            }
        }

        public void SystemNotification()
        {
            // PermissionType permission = await _notificationService.RequestPermissionAsync();
            // await _notificationService.CreateAsync("Title", "Description", "images/github.png");
        }

        public static SharePoint GetInstance()
        {
            return instance ??= new SharePoint();
        }
    }
}