using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private int state = 3;
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Random/{count}")]
        public IEnumerable<WeatherForecast> Get(string count)
        {
            int counter = 5;
            var rng = new Random();
            if (!string.IsNullOrEmpty(count))
                counter = int.Parse(count);
                
            return Enumerable.Range(1, counter).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("Primes/{count}")]
        public IEnumerable<int> GetPrimes(string count)
        {
            
            int amountNeeded = string.IsNullOrEmpty(count) ? 5 : int.Parse(count);
            // 5 is default

            int p = 2;
            List<int> result = new List<int>();

            result.Add(state);
            state++;
            while (result.Count < amountNeeded) {
                if (IsPrime(p))
                    result.Add(p);
                p++;
            }


            return result;
        }

        private bool IsPrime(int p) {
            for (int d = 2; d < p; d++)
                if (p % d == 0) return false;
            return true;
        }
    }
}
