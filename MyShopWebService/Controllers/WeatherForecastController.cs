using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyShopWebService.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger, SampleService sampleService)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<User> Get()
        {
            User user = new User
            {
                Name = "Vasiya",
                SurName = "Petrov",
                Age = 14
            };

            return new List<User>()
            {
                user,
                new User()
                {
                    Name = "Kolya",
                    SurName = "Unknow"
                }
            };
        }
    }


    public class User
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public int Age { get; set; }
    }

   
}
