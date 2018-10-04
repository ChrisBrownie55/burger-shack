using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using burgershack.Models;
using burgershack.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace burgershack.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : Controller {
    BurgersRepository _repo;
    public BurgersController(BurgersRepository repo) {
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<Burger> Get() {
      return _repo.GetAll();
    }

    [Authorize]
    [HttpPost]
    public Burger Post([FromBody] Burger burger) {
      if (!ModelState.IsValid) {
        throw new System.Exception("Invalid burger");
      }
      return _repo.Create(burger);
    }
  }
}