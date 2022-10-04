using PostCodes.Domain.Interfaces;
using Newtonsoft.Json;
using PostCodes.Domain.Responses;

namespace PostCodes.Infrastructure.ExternalServices
{
    public class PostCodeIoService : IPostCodeIoService
    {
        private readonly HttpClient _httpClient;
        public PostCodeIoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://api.postcodes.io/");
        }

        public async Task<CommonResponse<PostCodeResponse>> GetPostCode(string postCodeNumber)
        {
            var response = await _httpClient.GetAsync($"postcodes/{postCodeNumber}");

            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<PostCodeResponse>(content);

            if (response.IsSuccessStatusCode)
            {
                return CommonResponse<PostCodeResponse>.Success(result);
            }
            else
            {
                return CommonResponse<PostCodeResponse>.Fail(result.error);
            }
        }
    }
}
