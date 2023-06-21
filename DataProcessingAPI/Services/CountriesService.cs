using DataProcessingAPI.Interfaces;
using DataProcessingAPI.Models;
using Newtonsoft.Json;

namespace DataProcessingAPI.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly IConfiguration _configuration;
        public CountriesService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<ServiceResult<List<Country>>> GetCountries()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_configuration.GetValue<string>("AppSettings:RESTCountriesAPIUrl"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Country>>(content);

                return ServiceResult<List<Country>>.CreateSuccess(data);
            }
            else return ServiceResult<List<Country>>.CreateFailure("Can't reach the REST Countries API");
        }
    }
}
