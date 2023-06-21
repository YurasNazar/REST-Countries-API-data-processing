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

        public async Task<ServiceResult<List<Country>>> GetCountries(string name)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_configuration.GetValue<string>("AppSettings:RESTCountriesAPIUrl"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Country>>(content);

                data = FilterCountriesByName(name, data);

                return ServiceResult<List<Country>>.CreateSuccess(data);
            }
            else return ServiceResult<List<Country>>.CreateFailure("Can't reach the REST Countries API");
        }

        public List<Country> FilterCountriesByName(string name, List<Country>? data)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return data ?? new List<Country> { };
            }

            if (data == null) 
            {
                return new List<Country> { };
            }

            return data
                .Where(x => x.Name?.Common?.Contains(name, StringComparison.OrdinalIgnoreCase) ?? false)
                .ToList();
        }
    }
}
