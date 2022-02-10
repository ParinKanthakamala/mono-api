﻿using System;
using System.Collections.Generic;

namespace Shared.Entities
{
    public partial class CommentMeta
    {
        public ulong MetaId { get; set; }
        public ulong CommentId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
