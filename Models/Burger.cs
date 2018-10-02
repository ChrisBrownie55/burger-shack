using System.ComponentModel.DataAnnotations;

namespace burgershack.Models {
  public class Burger {
    public int Id { get; set; }
    [Required]
    [MinLength(6)]
    public string Name { get; private set; }
    [Required]
    [MaxLength(255)]
    public string Description { get; private set; }
    [Required]
    public decimal Price { get; private set; }

    public Burger (string name, string description, decimal price, int id) {
      Name = name;
      Description = description;
      Price = price > 5 ? price : 5;
      Id = id;
    }
  }
}