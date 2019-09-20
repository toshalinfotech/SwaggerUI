using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerUI.Models;
using System.Linq;

namespace SwaggerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalController : ControllerBase
    {
        private readonly MyDBContext _context;

        public PortalController(MyDBContext context)
        {
            _context = context;
        }

        // GET api/values
        [ProducesResponseType(typeof(PortalInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PortalInfo), StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<PortalInfo>> Get()
        {
            return _context.PortalInfo.ToList<PortalInfo>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<PortalInfo> Get(int id)
        {
            return _context.PortalInfo.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        [ProducesResponseType(typeof(PortalInfo), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(PortalInfo), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] PortalInfo value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PortalInfo value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
