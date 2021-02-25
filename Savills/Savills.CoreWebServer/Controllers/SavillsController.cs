using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuzzySharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Savills.Data;
using Savills.DB;
using Savills.Service;

namespace Savills.CoreWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("api/[controller]")]
    public class SavillsController : ControllerBase
    {
        private readonly ILogger<SavillsController> _logger;
        private readonly ISavillsService _service;
        public SavillsController(ILogger<SavillsController> logger, ISavillsService service)
        {
            _logger = logger;
            _service = service;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<String>> Get()
        {
            List<string> result = new List<string>();
            result.Add("Savills Server is Running");
            result.Add("OK");
            return Ok(result);
        }
        //[HttpGet("{id}")]
        //public ActionResult<ShoppingItem> Get(Guid id)
        //{
        //    var item = _service.GetById(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(item);
        //}
        //[HttpPost]
        //public ActionResult Post([FromBody] ShoppingItem value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var item = _service.Add(value);
        //    return CreatedAtAction("Get", new { id = item.Id }, item);
        //}
        //[HttpDelete("{id}")]
        //public ActionResult Remove(Guid id)
        //{
        //    var existingItem = _service.GetById(id);
        //    if (existingItem == null)
        //    {
        //        return NotFound();
        //    }
        //    _service.Remove(id);
        //    return Ok();
        //}
        // Post: api/S1

        [HttpPost("S1")]
        public ActionResult S1([FromBody] S1 value)
        {
            _service.S1(value);
            return Ok();
        }
        
        // Post: api/S1
        [HttpPost("S2")]
        public ActionResult S2([FromBody] S2 value)
        {
            _service.S2(value);
            return Ok();
        }
    }
}
