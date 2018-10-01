using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using burgershack.Models;

namespace burgershack.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : Controller {

    List<Burger> burgers = new List<Burger>();
    public BurgersController() {
      burgers.Add(new Burger("The plain Jane", "Burger on a bun", 7.99m));
      burgers.Add(new Burger("The plain Joe", "Burger on a bun, bacon", 7.99m));
      burgers.Add(new Burger("The plain John", "Burger on a seed bun", 7.99m));
      burgers.Add(new Burger("The plain Doe", "Bun on a burger", 7.99m));
      burgers.Add(new Burger("The plain", "Just the paddy", 7.99m));
    }

    [HttpGet]
    public IEnumerable<Burger> Get() {
      return burgers;
    }

    [HttpPost]
    public Burger Post([FromBody] Burger burger) {
      burgers.Add(burger);
      return burger;
    }
  }
}