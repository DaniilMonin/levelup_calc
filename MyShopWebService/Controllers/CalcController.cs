using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyShopWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        public CalcController(ICalcservice container)
        {
            /*
             *
             * ado.net
             * ef
             * dapper
             *
             *
             */
        }

        public string DoCalculation(int operationid, int b, int c)
        {
            return 
        }
    }
}
