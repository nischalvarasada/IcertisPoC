using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IcertisPoC.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return Ok("Hello World!");
        }

        [HttpPost]
        [Route("divide")]
        public async Task<IActionResult> Divide([FromQuery] int num1, [FromQuery] int num2)
        {
            float result;

            try
            {
                result = num1 / num2;
                return CreatedAtAction("Division", result);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        [HttpPut]
        [Route("greeting")]
        public async Task<IActionResult> Greeting([FromQuery] string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            return Ok($"Hello, {name}!");
        }
    }
}
