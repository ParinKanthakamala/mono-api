using System;
using System.Threading.Tasks;
using Web.Shared.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Web.Shared.Libraries.HubManager
{
    public class DataHub : Hub<IDataHub>
    {
        // No need to implement here the methods defined by ISurveyHub, their purpose is simply
        // to provide a strongly typed interface.
        // Users of IHubContext still have to decide to whom should the events be sent
        // as in: await this.hubContext.Clients.All.SendSurveyUpdated(survey);

        // These 2 methods will be called from the client
        public async Task Join(Guid surveyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, surveyId.ToString());
        }

        public async Task Data(Guid surveyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, surveyId.ToString());
        }

        public async Task Leave(Guid surveyId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, surveyId.ToString());
        }
    }
}