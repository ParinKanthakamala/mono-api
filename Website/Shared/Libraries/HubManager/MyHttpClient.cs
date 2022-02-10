using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shared.Libraries.HubManager
{
    public class MyHttpClient
    {
        private readonly HttpClient http;

        public MyHttpClient(HttpClient http)
        {
            this.http = http;
        }

        public async Task<DataSummary[]> GetSurveys()
        {
            return await http.GetFromJsonAsync<DataSummary[]>("api/survey");
        }

        public async Task<Data> GetSurvey(Guid surveyId)
        {
            return await http.GetFromJsonAsync<Data>($"api/survey/{surveyId}");
        }

        public async Task<HttpResponseMessage> AddSurvey(DataRequest survey)
        {
            return await http.PutAsJsonAsync("api/survey", survey);
        }

        public async Task<HttpResponseMessage> AnswerSurvey(Guid surveyId, DataRequest answer)
        {
            return await http.PostAsJsonAsync($"api/survey/{surveyId}/answer", answer);
        }
    }
}