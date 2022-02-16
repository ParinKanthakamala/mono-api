using System.Threading.Tasks;
using Append.Blazor.Notifications;
using Blazored.Modal;
using Blazored.Modal.Services;
using Server.Areas.Admin.Components.Modal;
using Shared.Core;
using Microsoft.AspNetCore.Components;

namespace Server.Areas.Admin.Layout
{
    public class AdminMiniLeftBarBase : MyComponentBase
    {
        protected string AppIcon { get; set; }
        protected string Title { get; set; }
        [Inject] private INotificationService _notificationService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }
        [CascadingParameter] public IModalService Modal { get; set; }

        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
            AppIcon = "assets/admin/images/logo.svg";
            Title = "AppName";
        }


        protected void Search()
        {
        }


        public void ContactList()
        {
            NavigationManager.NavigateTo("/admin/contact/list");
        }


        protected void MyApps()
        {
            var result = Modal.Show<ApplicationList>("App Application");

            // if (result.Result.IsCompleted)
            // {
            //     SharePoint["name"] = null;
            //     NavigationManager.NavigateTo("admin/auth/signin");
            // }
        }

        protected void MyMenu()
        {
        }

        protected void MyNotification()
        {
            var result = Modal.Show<NotificationList>("My Notification");
        }

        protected void MyTasks()
        {
            var result = Modal.Show<TasksList>("Tasks List");
        }

        protected void MyEvents()
        {
            NavigationManager.NavigateTo("/admin/calendar");
        }

        protected void MyChat()
        {
            NavigationManager.NavigateTo("admin/chat");
        }

        protected async Task MakeFullScreen()
        {
            var IsSupportedByBrowser = await _notificationService.IsSupportedByBrowserAsync();
            if (!IsSupportedByBrowser)
            {
                var permission = await _notificationService.RequestPermissionAsync();
            }
            else
            {
                await _notificationService.CreateAsync("Title", "Description", "images/logo.svg");
            }
        }

        protected void Settings()
        {
            // NavigationManager.NavigateTo("admin/settings");
            // var result = Modal.Show<AddEvent>();
            var options = new ModalOptions {Class = "blazored-prompt-modal"};
            Modal.Show<AddEvent>("Custom Style", options);
        }

        protected void Signout()
        {
            var result = Modal.Show<SignoutPrompt>("Are you want to signout ?");

            if (result.Result.IsCompleted)
                // this.sharepoint["name"] = null; 
                NavigationManager.NavigateTo("admin/auth/signin");
        }
    }
}