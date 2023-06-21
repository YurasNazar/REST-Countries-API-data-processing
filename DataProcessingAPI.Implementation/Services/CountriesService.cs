using DataProcessingAPI.Interfaces;
using DataProcessingAPI.Models;
using DataProcessingAPI.Models.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DataProcessingAPI.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly AppSettings _appSettings;

        public CountriesService(IOptions<AppSettings> appSettingsAccessor) 
        {
            _appSettings = appSettingsAccessor.Value;
        }

        public async Task<ServiceResult<List<Country>>> GetCountries(string? name, int? population, string? orderDirection, int? take)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_appSettings.RESTCountriesAPIUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Country>>(content);

                data = FilterCountriesByName(name, data);
                data = FilterCountriesByPopulation(population, data);
                data = SortCountriesByName(orderDirection, data);
                data = ApplyPagination(take, data);

                return ServiceResult<List<Country>>.CreateSuccess(data);
            }
            else return ServiceResult<List<Country>>.CreateFailure("Can't reach the REST Countries API");
        }

        public static List<Country> FilterCountriesByName(string? name, List<Country>? data)
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

        public static List<Country> FilterCountriesByPopulation(int? population, List<Country>? data)
        {
            if (!population.HasValue)
            {
                return data ?? new List<Country> { };
            }

            if (data == null)
            {
                return new List<Country> { };
            }

            return data.Where(x => x.Population/1000000 < population.Value).ToList();
        }

        public static List<Country> SortCountriesByName(string? order, List<Country>? data)
        {
            if (string.IsNullOrWhiteSpace(order) || (!order.Equals("ascend") && !order.Equals("descend")))
            {
                return data ?? new List<Country> { };
            }

            if (data == null)
            {
                return new List<Country> { };
            }

            if (order.Equals("descend")) 
            {
                return data.OrderByDescending(x => x.Name?.Common).ToList();

            }

            return data.OrderBy(x => x.Name?.Common).ToList();
        }

        public static List<Country> ApplyPagination(int? take, List<Country>? data)
        {
            if (!take.HasValue || take.Value < 0)
            {
                return data ?? new List<Country> { };
            }

            if (data == null)
            {
                return new List<Country> { };
            }

            return data.Take(take.Value).ToList();
        }
    }
}
