using DataProcessingAPI.Interfaces;
using DataProcessingAPI.Models;
using Newtonsoft.Json;

namespace DataProcessingAPI.Services
{
    public class CountriesService : ICountriesService
    {
        public const string RESTCountriesAPIUrl = "https://restcountries.com/v3.1/all";
        public CountriesService() { }

        public async Task<ServiceResult<List<Country>>> GetCountries()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(RESTCountriesAPIUrl);
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
