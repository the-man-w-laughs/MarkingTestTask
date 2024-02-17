using MarkingTestTask.BLL.Contracts;
using MarkingTestTask.BLL.Dtos;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace MarkingTestTask.BLL.Services
{
    public class ProductInfoRetrievalService : IProductInfoRetrievalService
    {
        private const string ProductUrl = "http://promark94.marking.by/client/api/get/task/";
        private readonly HttpClient _httpClient;

        public ProductInfoRetrievalService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ProductLayoutInfoDto> GetProductLayoutInfoAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ProductUrl);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonResponse = JObject.Parse(responseBody);

            var lot = jsonResponse["mission"]["lot"];
            var package = lot["package"];
            var product = lot["product"];

            var layoutInfo = new ProductLayoutInfoDto
            {
                Volume = (string)package["volume"],
                BoxFormat = (int)package["boxFormat"],
                PalletFormat = (int)package["palletFormat"],
                Name = (string)product["name"],
                Gtin = (string)product["gtin"]
            };

            return layoutInfo;
        }
    }

}
