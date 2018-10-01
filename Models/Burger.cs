namespace burgershack.Models {
  public class Burger {
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    public Burger (string name, string description, decimal price) {
      Name = name;
      Description = description;
      Price = price;
    }
  }
}