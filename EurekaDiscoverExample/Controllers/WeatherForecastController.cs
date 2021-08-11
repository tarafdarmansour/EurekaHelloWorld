using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace EurekaDiscoverExample.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        DiscoveryHttpClientHandler _handler;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDiscoveryClient client)
        {
            _logger = logger;
            _handler = new DiscoveryHttpClientHandler(client);
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            try
            {
                var client = new HttpClient(_handler, false);
                using (var resp = await client.GetAsync("http://EurekaRegisterExample/WeatherForecast"))
                {
                    if (resp.IsSuccessStatusCode)
                    {
                        var res2 = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(await resp.Content.ReadAsStringAsync());
                        return res2;
                    }
                }
                return new List<WeatherForecast>();
            }
            catch (Exception wx)
            {
                return new List<WeatherForecast>();
            }



        }
    }


}
