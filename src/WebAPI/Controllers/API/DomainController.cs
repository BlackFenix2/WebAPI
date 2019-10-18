using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.API
{
    public class DomainController : ApiController
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { message = "nothing new here yet" });
        }
    }
}