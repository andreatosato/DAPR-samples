using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/[controller]")]
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

        //[HttpGet("weather")]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogDebug("Call WeatherForecastController");
            //var message = "Welcome to this awesome service";
            //var metadata = new Dictionary<string, string>
            //{
            //  { "toNumber", "555-3277" }
            //};
            //await daprClient.InvokeBindingAsync("sms", "create", message, metadata);

            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();

            await daprClient.PublishEventAsync<WeatherForecast[]>(ComponetHelper.PubSubName, "topicSample", data, HttpContext.RequestAborted);
            _logger.LogInformation("Data inviata {@data}", data);
            return new OkObjectResult(data);
        }

        [HttpPost]
        [Topic(ComponetHelper.PubSubName, "topicSample")]
        public async Task ReadMessageAsync(WeatherForecast[] data)
        {
            _logger.LogInformation("Data arrivata {@data}", data);
        }
    }
}
// sysctl -w vm.max_map_count=262144