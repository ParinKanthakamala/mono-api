using System;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Shared.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Server.Areas.Admin.Pages.Auth
{
    public class SigninBase : MyComponentBase
    {
        protected string Email = "";
        protected string Password = "";
        [Inject] protected NavigationManager NavManager { get; set; }
        [Inject] private IJSRuntime JsRuntime { get; set; }
        [Inject] private IToastService toastService { get; set; }

        protected void ForgotPassword()
        {
            NavManager.NavigateTo("/admin/auth/forgot");
        }

        // Install-Package CurrieTechnologies.Blazor.SweetAlert2 -Version 0.1.4-preview
        protected Task OnValidSubmit()
        {
            if (string.IsNullOrEmpty(Email))
                // toastService.ShowToast("please enter email", ToastLevel.Error);
                return null;
            if (string.IsNullOrEmpty(Password))
                // toastService.ShowToast("please enter password", ToastLevel.Error);
                return null;
            try
            {
                if (Email == "admin" && Password == "password")
                    // if (model.Signin(Email, Password))
                    // toastService.ShowError("I'm an ERROR message");
                    // sharePoint["name"] = "John Doe";
                    NavManager.NavigateTo("/admin/dashboard");
            }
            catch //(Exception exception)
            {
                // toastService.ShowToast(exception.ToString(), ToastLevel.Error);
            }

            return null;
        }

        // protected override async void OnInitialized()
        // {
        //     // context.Users.Where();
        //     //NavManager.NavigateTo("/admin/dashboard");
        //     // toastService.ShowToast("please enter email", ToastLevel.Error);
        // }
        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
            
        }
    }
}