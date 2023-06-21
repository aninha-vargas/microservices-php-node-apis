using envio_mensagens_api_c_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace envio_mensagens_api_c_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly RabbitMQSenderService _senderService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, RabbitMQSenderService senderService)
        {
            _logger = logger;
            _senderService = senderService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("SendMessage")]
        public IActionResult SendMessage([FromBody] WeatherForecast weather)
        {
            _senderService.SendMessage(weather.Message, "routing_key"); // Altere a routing key conforme necessário
            return Ok();
        }
    }
}