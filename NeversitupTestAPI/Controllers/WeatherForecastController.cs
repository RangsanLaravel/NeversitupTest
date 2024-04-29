using Microsoft.AspNetCore.Mvc;
using NeversitupTestAPI.BusinessLogic;

namespace NeversitupTestAPI.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            this.Configuration = Configuration;
            this.service = new ServiceAction(this.Configuration.GetConnectionString("ConnectionSQLServer"), Configuration["ConfigSetting:DBENV"]);
        }
        private readonly IConfiguration Configuration = null;
        private readonly ServiceAction service;

        [HttpGet("GET_STATUS/{status_type}")]
        public IActionResult GET_STATUS(string status_type)
        {
            try
            {
               this.service.GET_STATUS(status_type);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
    }
}
