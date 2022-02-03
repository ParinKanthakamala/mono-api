using System;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Tools.Label
{
    public static class LabelExtension
    {
        public static string example(this ILabel source)
        {
            return source.get("page:key");
        }

        // info : use this function 
        public static string get(this ILabel source, string key)
        {
            return source.Keys[key];
        }

        public static void InitLocalizedComponent(this ILabel language, ComponentBase component)
        {
            if (component == null)
                throw new ArgumentNullException(nameof(component));
            // Init the extension 
            var extension = new ComponentExtension
            {
                Component = component
            };

            var action = new Action<object>(e =>
            {
                // Call the StateHasChanged function for the component 
                var type = typeof(ComponentBase);
                var stateHasChangedMethod =
                    type.GetMethod("StateHasChanged", BindingFlags.Instance | BindingFlags.NonPublic);

                stateHasChangedMethod.Invoke(extension.Component, null);
            });

            extension.Action = action;

            language.AddExtension(extension);
        }

        public static IServiceCollection AddLanguageContainer<TKeysProvider>(this IServiceCollection services,
            Assembly assembly, string folderName = "Resources")
            where TKeysProvider : KeysProvider
        {
            services.AddSingleton<IKeysProvider, TKeysProvider>(s =>
                (TKeysProvider) Activator.CreateInstance(typeof(TKeysProvider), assembly, folderName));
            return services.AddSingleton<ILabel, LanguageContainer>(s =>
            {
                var keysProvider = s.GetService<IKeysProvider>();
                return new LanguageContainer(keysProvider);
            });
        }
    }
}