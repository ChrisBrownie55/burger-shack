using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : Controller { // apparently Controller is better than ControllerBase
    // GET api/values
    [HttpGet] // <- a decorator (extends functionality on the thing it is attached to) (c# calls them attributes tho)
    public ActionResult<IEnumerable<string>> Get() {
      // ActionResult is a way to respond to a web request
      // IEnumerable represents anything you can iterate over
      return new string[] { "value1", "value2", "value3", "value4" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id) {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value) {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }
  }
}
