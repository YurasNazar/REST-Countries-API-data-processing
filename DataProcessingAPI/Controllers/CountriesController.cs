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
        /// 
        /// </summary>
        /// <param name="name">Value to filter by country `name/common` property.</param>
        /// <param name="population">Value to filter by country `population` property.</param>
        /// <param name="param3"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(string? name, int? population, string param3)
        {
            try
            {
                var result = await _countriesService.GetCountries(name, population);
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
