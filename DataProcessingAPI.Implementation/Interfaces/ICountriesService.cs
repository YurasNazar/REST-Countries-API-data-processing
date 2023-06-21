using DataProcessingAPI.Models;

namespace DataProcessingAPI.Interfaces
{
    public interface ICountriesService
    {
        /// <summary>
        /// Retrieves countries data collection based on provided filters, sort and pagination criterias
        /// </summary>
        /// <param name="name">Value to filter by country `name/common` field.</param>
        /// <param name="population">Value to filter by country `population` field.</param>
        /// <param name="orderDirection">Value to specify order direction for 'name/common`field'</param>
        /// <param name="take">Value to specify number of first n' records to return</param>
        /// <returns>Returns service result object that contains filtered, sorted and paginated list of <see cref="Country"/> objects and result of operation</returns>
        Task<ServiceResult<List<Country>>> GetCountries(string? name, int? population, string? orderDirection, int? take);
    }
}
