using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Souq.API.Middlewares;
using Souq.Service;
using Souq.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Souq.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IProductService _service;

        public FileController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<Response<string>> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return new FailureResponse<string>("407");

            var newName = Guid.NewGuid() + ".png";
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",newName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new SuccessResponse<string>(newName);
        }

    }
}
