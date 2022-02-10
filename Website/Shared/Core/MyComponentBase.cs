using Microsoft.AspNetCore.Components;
using Shared.Entities;
using Shared.Libraries;

namespace Shared.Core
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