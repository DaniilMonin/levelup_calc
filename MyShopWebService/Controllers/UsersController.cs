using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopWebService.Composition;
using Ninject;
using ShopManager.Data;
using ShopManager.Implement.Users;

namespace MyShopWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(CompositionRoot compositionRoot)
        {
            _userManager = compositionRoot.UserManager;
        }

        [HttpGet]
        public IReadOnlyList<User> Get()
        {
            if (_userManager is null)
            {
                return Array.Empty<User>();
            }

            _userManager.Refresh();

            return _userManager.Entities;
        }
    }
}
