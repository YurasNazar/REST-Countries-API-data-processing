using DataProcessingAPI.Models;

namespace DataProcessingAPI.Interfaces
{
    public interface ICountriesService
    {
        Task<ServiceResult<List<Country>>> GetCountries(string name);
    }
}
