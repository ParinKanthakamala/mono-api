using System;
using System.Collections.Generic;

namespace Web.Shared.Libraries.HubManager
{
    public class DataSummary
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public DateTime ExpiresAt { get; init; }
        public List<string> Options { get; init; }
    }
}