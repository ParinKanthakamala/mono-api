using System;
using System.Collections.Generic;

namespace Web.Shared.Libraries.HubManager
{
    public class Data : IExpirable
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Title { get; init; }
        public List<string> Options { get; init; } = new();
        public List<DataRequest> Requests { get; init; } = new();
        public DateTime ExpiresAt { get; init; }

        public DataSummary ToSummary()
        {
            return new()
            {
                Id = Id,
                Title = Title,
                Options = Options,
                ExpiresAt = ExpiresAt
            };
        }
    }
}