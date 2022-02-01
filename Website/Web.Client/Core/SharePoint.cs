using System.Collections.Generic;

namespace Web.Client.Core
{
    public class SharePoint
    {
        private static SharePoint instance;
        private readonly Dictionary<string, object> data = new Dictionary<string, object>();

        private SharePoint()
        {
        }

        public void SystemNotification()
        {
            // PermissionType permission = await _notificationService.RequestPermissionAsync();
            // await _notificationService.CreateAsync("Title", "Description", "images/github.png");
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

        public static SharePoint GetInstance()
        {
            return instance ??= new SharePoint();
        }
    }
}