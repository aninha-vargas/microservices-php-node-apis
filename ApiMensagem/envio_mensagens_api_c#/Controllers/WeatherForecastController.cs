using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace envio_mensagens_api_c_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Mensagem 1", "Mensagem 2", "Mensagem 3" };
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var message = $"Mensagem com ID {id}";
            return Ok(message);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string message)
        {
            return Ok($"Mensagem recebida: {message}");
        }
    }
}