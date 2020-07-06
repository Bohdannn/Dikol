using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dikol.API.Errors;
using Dikol.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Dikol.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DikolDbContext _dikolDbContext;

        public BuggyController(DikolDbContext dikolDbContext)
        {
            _dikolDbContext = dikolDbContext;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _dikolDbContext.Products.Find(999);

            if (thing == null)
                return NotFound(new ApiResponse(404));

            return Ok();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var thing = _dikolDbContext.Products.Find(999);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
