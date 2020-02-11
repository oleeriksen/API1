using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API1.Controllers
{
    [ApiController]
    [Route("")]
    public class LoadBalancerController : ControllerBase
    {
        private readonly ILogger<LoadBalancerController> _logger;


        private static readonly string[] _servers = {"https://localhost:5003", "https://localhost:5005"};

        private static int next = 0;


        public LoadBalancerController(ILogger<LoadBalancerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{count}")]
        public IEnumerable<int> GetNumbers(int count)
        {
            _logger.LogInformation("LoadBalancer server requested");

            string server = _servers[next] + "/numbers/" + count;
            next = (next + 1) % _servers.Length;

            Response.Redirect(server);

            IEnumerable<int> result = new List<int>();

            return result;
        }
    }
}
