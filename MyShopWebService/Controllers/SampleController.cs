using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MyShopWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SampleController : ControllerBase
    {


        [HttpGet()] //  http://localhost:8080/api/Sample/Locale
        public async Task<string> Locale()
        {
            return "ru_RU";
        }


        [HttpGet("{a}")] //  http://localhost:8080/api/Sample/SetLocale/6767
        public string SetLocale(int a)
        {
            return $"I got an {a}";
        }

        [HttpGet("~/day/{a}")] //  http://localhost:8080/day/6767
        public string SetDay(int a)
        {
            return $"I got an {a}";
        }

        [HttpGet("~/anotherday")] //  http://localhost:8080/anotherday?a=89&zx=100&fx=50
        public string SetDayAnother(int a, int zx, int fx)
        {
            return $"I got an {a}";
        }

        [HttpGet("~/setxanother")] //  http://localhost:60672/setxanother?a=89&z=100&z=101&z=102&z=103&fx=50
        public string SetXAnother(int a, [FromQuery] int[] zx, int fx)
        {
            return $"I got an {a}";
        }

    }
}
