using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Abstraction;
using Shared;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IServiceManager _serviceManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
            _logger = logger;

        }


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("Persons")]
        public async Task<IEnumerable<PersonDto>> GetPersons()
        {
            return await _serviceManager.PersonServices.GetPersons();
        }
        [HttpPost("Person")]
        public async Task<bool> Addperson([FromForm] PersonDto personDto)
        {
            return (await _serviceManager.PersonServices.CreatePerson(personDto)) != null;
        }
    }
}
