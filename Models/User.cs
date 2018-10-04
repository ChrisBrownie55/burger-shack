using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace burgershack.Models {
  public class UserRegistration { // Helper model
    [Required]
    public string Name { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
  }

  public class UserLogin { // Helper model
    [Required]
    [MinLength(8)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
  }

  public class User {
    public string Id { get; set; }
    public string Name { get; set; }

    [Required]
    internal string Hash { get;  set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public bool Active { get; set; } = true;

    public ClaimsPrincipal _principal { get; private set; }
    internal void SetClaims() {
      List<Claim> claims = new List<Claim> {
        new Claim(ClaimTypes.Name, Id)
      };

      ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
      _principal = new ClaimsPrincipal(userIdentity);
    }
  }
}