using System.ComponentModel.DataAnnotations;

namespace burgershack.Models {
  public class Smoothie {
    public int Id { get; set; }

    [Required]
    [MinLength(6)]
    public string Name { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }
    public Smoothie() {}
  }
}