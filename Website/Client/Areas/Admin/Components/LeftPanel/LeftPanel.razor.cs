using Microsoft.AspNetCore.Components;

namespace Client.Areas.Admin.Components.LeftPanel
{
    public class LeftPanelBase : ComponentBase
    {
        [Inject] private LeftPanelService LeftPanelService { get; set; }
        protected bool IsVisible { get; set; }


        protected override void OnInitialized()
        {
            LeftPanelService.OnShow += Show;
            LeftPanelService.OnHide += Hide;
        }

        private void Show(string message, PanelContent level)
        {
            BuildToastSettings(level, message);
            IsVisible = true;
            StateHasChanged();
        }

        private void Hide()
        {
            IsVisible = false;
            StateHasChanged();
        }

        private void BuildToastSettings(PanelContent content, string message)
        {
            switch (content)
            {
                case PanelContent.MyApps:
                {
                    break;
                }
                case PanelContent.MyNotification:
                {
                    break;
                }
                case PanelContent.MyTasks:
                {
                    break;
                }
            }
        }
    }
}