using MarkingTestTask.BLL.Contracts;
using MarkingTestTask.BLL.Dtos;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace MarkingTestTask.BLL.Services
{
    public class MissionInfoRetrievalService : IMissionInfoRetrievalService
    {
        private const string ProductUrl = "http://promark94.marking.by/client/api/get/task/";
        private readonly HttpClient _httpClient;

        public MissionInfoRetrievalService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<MissionDto> GetMissionInfoAsync()
        {
            var response = await _httpClient.GetAsync(ProductUrl);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonResponse = JObject.Parse(responseBody);


            var package = jsonResponse["mission"]["lot"]["package"];
            var product = jsonResponse["mission"]["lot"]["product"];

            var mission = new MissionDto
            {
                MissionId = jsonResponse["mission"]["id"].Value<int>(),
                Volume = package["volume"].Value<string>(),
                BoxFormat = package["boxFormat"].Value<int>(),
                PalletFormat = package["palletFormat"].Value<int>(),
                Name = product["name"].Value<string>(),
                Gtin = product["gtin"].Value<string>()
            };

            return mission;
        }

    }

}
