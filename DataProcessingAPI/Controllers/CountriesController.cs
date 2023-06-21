using DataProcessingAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataProcessingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;
        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        /// <summary>
        /// Retrieves countries collection based on provided filters, sort and pagination criterias
        /// </summary>
        /// <param name="name">Value to filter by country `name/common` field.</param>
        /// <param name="population">Value to filter by country `population` field.</param>
        /// <param name="orderDirection">Value to specify order direction for 'name/common`field'</param>
        /// <param name="take">Value to specify number of first n' records to return</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(string? name, int? population, string? orderDirection, int? take)
        {
            try
            {
                var result = await _countriesService.GetCountries(name, population, orderDirection, take);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
