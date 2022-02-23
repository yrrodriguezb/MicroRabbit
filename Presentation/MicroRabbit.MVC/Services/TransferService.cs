

using System.Net.Http;
using System.Threading.Tasks;
using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;

    public TransferService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5001/api/banking";
            var transferContent = new StringContent(
                content: JsonConvert.SerializeObject(transferDto), 
                encoding: System.Text.Encoding.UTF8,
                mediaType: "application/json"
            );

            var response = await _httpClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}