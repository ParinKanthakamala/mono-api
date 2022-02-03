using System.Collections.Generic;
using Web.Shared.Core;

namespace Web.Shared.Libraries
{
    public class App
    {
        private static App instance;
        public List<MyComponentBase> components = new();

        private bool update_sassion;

        private App()
        {
        }

        public void Update()
        {
            if (update_sassion) return;

            update_sassion = true;

            foreach (var component in components)
                try
                {
                    component.OnUpdate();
                }
                catch
                {
                }

            update_sassion = false;
        }

        public static App getInstance()
        {
            return instance ??= new App();
        }
    }
}