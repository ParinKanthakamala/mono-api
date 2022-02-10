using System;
using System.Collections.Generic;

namespace Shared.Entities
{
    public partial class UserMeta
    {
        public ulong UmetaId { get; set; }
        public ulong UserId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
