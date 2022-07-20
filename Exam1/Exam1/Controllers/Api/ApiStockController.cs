using Exam1.Handler;
using Exam1.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiStockController : ControllerBase
    {
        private readonly IStockHandler _handler;

        public ApiStockController(IStockHandler handler)
        {
            _handler = handler;
        }


        // api/apistock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAll()
        {
            return Ok(await _handler.GetAllAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Stock>> Update(string id, Stock stock)
        {
            if(id != stock.Ma)
            {
                return BadRequest();
            }    
            return Ok(await _handler.UpdateAsync(stock));
        }

    }
}
