using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using burgershack.Models;

namespace burgershack.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : Controller {
      [HttpGet]
      public string Get() {
        return "Hello World";
      }
      [HttpPost]
      public string Post([FromBody] string name) {
        if (!ModelState.IsValid) {
          throw new Exception("Invalid input");
        }
        return $"Hello World {name}";
      }
    }
}