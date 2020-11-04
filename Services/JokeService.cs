using EmailService.Interface;
using EmailService.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmailService.Services
{
    class JokeService : IJokeService
    {
        private readonly IHttpClientFactory _clientFactory;
        private IConfiguration _config;


        public JokeService(IHttpClientFactory clientFactory, IConfiguration configRoot)
        {
            _clientFactory = clientFactory;
            _config = (IConfigurationRoot)configRoot;
        }

        public async Task<JokeTemplate> GetJokeAsync()
        {
            JokeTemplate Joke = null;
            try
            {
                var IcanhazdadjokeConfig = _config.Get<AppConfig>().IcanhazdadjokeConfig;
                string url = IcanhazdadjokeConfig.GET_URL;

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");
                HttpClient client = _clientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(result))
                    {
                        Joke = JsonConvert.DeserializeObject<JokeTemplate>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
            return Joke;
        }
    }
}
