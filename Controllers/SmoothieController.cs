using System;
using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;
using burgershack.Repositories;

namespace burgershack.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SmoothiesController : Controller {
      SmoothiesRepository _repo;
      public SmoothiesController(SmoothiesRepository repo) {
        _repo = repo;
      }
      [HttpGet]
      public IEnumerable<Smoothie> Get() {
        return _repo.GetAll();
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