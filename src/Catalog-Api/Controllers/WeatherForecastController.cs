using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_Api.Controllers
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
        private readonly DaprClient daprClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient)
        {
            _logger = logger;
            this.daprClient = daprClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            //var message = "Welcome to this awesome service";
            //var metadata = new Dictionary<string, string>
            //{
            //  { "toNumber", "555-3277" }
            //};
            //await daprClient.InvokeBindingAsync("sms", "create", message, metadata);

            await daprClient.PublishEventAsync("rabbitmq", "topicSample", HttpContext.RequestAborted);


            var rng = new Random();
            return new OkObjectResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray()
            );
        }
    }
}
