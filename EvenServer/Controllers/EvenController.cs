using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeLogic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvenServer.Controllers
{
    [ApiController]
    [Route("numbers")]
    public class EvenController : ControllerBase
    {
        private readonly ILogger<EvenController> _logger;

        public EvenController(ILogger<EvenController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{count}")]
        public IEnumerable<int> GetPrimes(int count)
        {

            _logger.LogInformation("Even server requested");
            IEnumerable<int> result = GetEvenNumbersByAmount(count);
            Thread.Sleep(2000);
            return result;
        }

        private IEnumerable<int> GetEvenNumbersByAmount(int amountNeeded)
        {
            List<int> result = new List<int>();
            int c = 0;
            while (result.Count < amountNeeded) {
                result.Add(c);
                c += 2;
            }
            return result;
        }

    }

}