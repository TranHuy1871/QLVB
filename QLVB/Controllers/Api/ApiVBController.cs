using Microsoft.AspNetCore.Mvc;
using QLVB.Handler;
using QLVB.Models.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLVB.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVBController: ControllerBase
    {
        private readonly IVBHandler _handler;

        public ApiVBController(IVBHandler handler)
        {
            _handler = handler;
        }

        // api/apistock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VanBan>>> GetAll()
        {
            return Ok(await _handler.GetAllAsync());
        }
    }


}
