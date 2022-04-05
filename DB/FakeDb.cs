using PetShop.Models;

namespace PetShop.DB;

public static class FakeDb
{
  public static List<Cat> Cats { get; set; } = new List<Cat>() {
        new Cat("Dudley", 1),
        new Cat("Falcon", 2),
        new Cat("Ironman", 4),
        new Cat("Gopher", 2)
     };
}
