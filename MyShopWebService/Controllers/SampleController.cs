using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyShopWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SampleController : ControllerBase
    {


        [HttpGet]
        public string Locale()
        {
            return "ru_RU";
        }


        [HttpGet("{a}")]
        public string SetLocale(int a)
        {
            return $"I got an {a}";
        }
      
    }
}
