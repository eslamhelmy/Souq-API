using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Souq.Service;
using Souq.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Register")]
        public Response<string> Register(UserCreateViewModel viewModel)
        {
            var res = _service.Register(viewModel);

            return res;
        }

        [HttpPost]
        [Route("Login")]
        public Response<string> Login(UserCreateViewModel viewModel)
        {
            var res = _service.Login(viewModel);

            return res;
        }

    }
}
