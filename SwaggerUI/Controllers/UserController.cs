using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerUI.Models;

namespace SwaggerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDBContext _context;

        public UserController(MyDBContext context)
        {
            _context = context;
        }

        [ProducesResponseType(typeof(IEnumerable<UserInfo>), StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<UserInfo>> GetAllAsync()
        {
            return _context.UserInfo.ToList<UserInfo>();
        }

        // GetById api/values/5
        [ProducesResponseType(typeof(UserInfo), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<UserInfo> GetById(int id)
        {
            return _context.UserInfo.FirstOrDefault(x => x.Id == id);
        }

        // Save api/values
        [ProducesResponseType(typeof(UserInfo), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(UserInfo), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Save([FromBody] UserInfo value)
        {
            _context.UserInfo.Update(value);
            _context.SaveChangesAsync();

            return Ok(value);
        }

        // EditById api/values/5
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult EditById(int id, [FromBody] UserInfo value)
        {
            value.Id = id;
            _context.UserInfo.Update(value);
            _context.SaveChangesAsync();

            return Ok(HttpStatusCode.OK);
        }

        // DeleteById api/values/5
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(HttpStatusCode.OK);
        }
    }
}