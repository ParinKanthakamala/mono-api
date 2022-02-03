using Microsoft.AspNetCore.Components;
using Web.Shared.Entities;
using Web.Shared.Libraries;

namespace Web.Shared.Core
{
    public abstract class MyComponentBase : ComponentBase
    {
        public MyContext context = new();
        public string description = "";
        public App app = App.getInstance();
        public abstract void OnUpdate();

        protected override void OnInitialized()
        {
            this.app.components.Add(this);
        }
    }
}