using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models {
  public class Smoothie {

    public Guid id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public Smoothie(string name, string description, decimal price) {}

    public Smoothie(Smoothie smoothie)
    {
      smoothie.id = Guid.NewGuid();
    }
  }
}