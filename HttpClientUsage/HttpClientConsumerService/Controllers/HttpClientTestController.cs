using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientConsumerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientTestController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public HttpClientTestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
         }

        [HttpGet]
        public async Task<string> TestHttpClient()
        {
            var url = "http://localhost:5014/WeatherForecast";
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        } 
    }
}
