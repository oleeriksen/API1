using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeLogic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrimeServer.Controllers
{
    [ApiController]
    [Route("numbers")]
    public class PrimeController : ControllerBase
    {
        private readonly ILogger<PrimeController> _logger;

        public PrimeController(ILogger<PrimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{count}")]
        public IEnumerable<int> GetPrimes(int count)
        {
            _logger.LogInformation("Prime server requested");
            PrimeCalculator pc = new PrimeCalculator();
            IEnumerable<int> result = pc.GetAmountNeeded(count);
            Thread.Sleep(2000);
            return result;
        }

    }

}
