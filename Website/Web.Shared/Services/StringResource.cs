using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Web.Shared.Helpers.Extensions;
using Web.Shared.Entities.Multisite;
using Web.Shared.Helpers;

namespace Web.Shared.Services
{
    public class StringResource : SystemEntity
    {
        [Required] public virtual string Key { get; set; }

        [Required] public virtual string Value { get; set; }

        public virtual Site Site { get; set; }

        public virtual string UICulture { get; set; }

        public virtual string DisplayUICulture =>
            IsDefaultUICulture ? "Default" : CultureInfo.GetCultureInfo(UICulture).DisplayName;

        public virtual string DisplaySite => IsGlobal ? "System Default" : Site.DisplayName;

        public virtual string DisplayKey
        {
            get
            {
                if (Key == null || Key.LastIndexOf(".", StringComparison.Ordinal) == -1) return Key;
                var typeName = Key.Substring(0, Key.LastIndexOf(".", StringComparison.Ordinal));
                var type = TypeHelper.GetTypeByName(typeName);
                if (type != null)
                    return type.Name.BreakUpString() + " - " +
                           Key.Substring(Key.LastIndexOf(".", StringComparison.Ordinal) + 1).BreakUpString();
                return Key;
            }
        }

        public virtual bool IsDefault => IsDefaultUICulture && IsGlobal;

        public virtual bool IsDefaultUICulture => string.IsNullOrWhiteSpace(UICulture);

        public virtual bool IsGlobal => Site == null;
    }
}