using System;
using System.Collections.Generic;

namespace Web.Shared.Libraries.HubManager
{
    public class DataResponse
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public Guid SurveyId { get; init; }

        // public string Option { get; init; }
        public List<OptionCreateModel> Option { get; init; } = new();
    }
}