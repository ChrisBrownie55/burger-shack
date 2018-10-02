using System;
using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    SmoothiesRepository _repo;
    public class SmoothiesController : Controller {
      public SmoothiesController(SmoothiesRepository repo) {
        _repo = repo;
      }
      [HttpGet]
      public IEnumerable<Smoothie> Get() {
        _repo.GetAll();
      }
      [HttpPost]
      public Smoothie Post([FromBody] Smoothie smoothie) {
        if (!ModelState.IsValid) {
          throw new Exception("Invalid Smoothie");
        }
        return _repo.Create(smoothie);
      }
    }
}