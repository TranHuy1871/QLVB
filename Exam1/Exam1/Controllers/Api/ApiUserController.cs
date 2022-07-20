using Exam1.Handler;
using Exam1.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        private readonly IUserHandler _handler;

        public ApiUserController(IUserHandler handler)
        {
            _handler = handler;
        }
        // api/apiUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            return Ok(await _handler.GetAllAsync());
        }


    }
}
