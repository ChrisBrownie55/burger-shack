using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using burgershack.Models;
using System;

namespace burgershack.Controllers {
      [Route("api/[controller]")]
      [ApiController]
      public class SmoothiesController : Controller {
        List<Smoothie> smoothies = new List<Smoothie>();
        public SmoothiesController() {}
        [HttpGet]
        public IEnumerable<Smoothie> Get() {
          return smoothies;
        }
        [HttpPost]
        public Smoothie Post([FromBody] Smoothie smoothie) {
          if (ModelState.IsValid) {
            smoothie = new Smoothie(smoothie);
            smoothies.Add(smoothie);
            return smoothie;
          }
          throw new Exception("Invalid Smoothie");
        }
      }
}