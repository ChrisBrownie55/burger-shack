using System.Threading.Tasks;
using burgershack.Models;
using burgershack.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers {
    [Route("[controller]")]
    public class AccountController : Controller {
      readonly UserRepository _repo;
      public AccountController(UserRepository repo) {
        _repo = repo;
      }

      [HttpPost("Register")]
      public async Task<User> Register([FromBody] UserRegistration creds) {
        if (!ModelState.IsValid) {
          return null;
        }

        User user = _repo.Register(creds);
        if (user == null) {
          return null;
        }

        user.SetClaims();
        await HttpContext.SignInAsync(user._principal);
        return user;
      }


      [HttpPost("Login")]
      public async Task<User> Login([FromBody] UserLogin creds) {
        if (!ModelState.IsValid) {
          return null;
        }

        User user = _repo.Login(creds);
        if (user == null) {
          return null;
        }

        user.SetClaims();
        await HttpContext.SignInAsync(user._principal);
        return user;
      }

      [HttpDelete]
      public async Task<bool> Logout() {
        await HttpContext.SignOutAsync();
        return true;
      }

      [Authorize]
      [HttpGet("Authenticate")]
      public User Authenticate() {
        var id = HttpContext.User.Identity.Name;
        return _repo.GetUserById(id);
      }
    }
}