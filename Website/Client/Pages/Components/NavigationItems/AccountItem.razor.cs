using BlazorContextMenu;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Shared.Core;

namespace Client.Pages.Components.NavigationItems
{
    public class AccountItemRazor : MyComponentBase
    {
        [Inject] public IToastService toastService { get; set; }
        [CascadingParameter] public IModalService Modal { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        public void LoginClick(ItemClickEventArgs e)
        {
            NavigationManager.NavigateTo("/account/login");
            // toastService.ShowInfo("login");
            // var options = new ModalOptions {Animation = ModalAnimation.FadeIn(2)};
            // Modal.Show<LoginPanel>("Animation: Fade-In", options);
        }

        public void RegisterClick(ItemClickEventArgs e)
        {
            NavigationManager.NavigateTo("/account/register");
            // var options = new ModalOptions {Animation = ModalAnimation.FadeIn(2)};
            // Modal.Show<RegisterPanel>("Animation: Fade-In", options);
        }

        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
        }
    }
}