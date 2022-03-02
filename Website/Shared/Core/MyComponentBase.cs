using Microsoft.AspNetCore.Components;
using Shared.Entities;
using Shared.Libraries;

namespace Shared.Core
{
    public abstract class MyComponentBase : ComponentBase
    {
        public App app = App.getInstance();
        public MyContext context = new();
        public string description = "";
        public abstract void OnUpdate();

        protected override void OnInitialized()
        {
            app.components.Add(this);
        }
    }
}