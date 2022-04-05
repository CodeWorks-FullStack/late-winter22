using PetShop.DB;
using PetShop.Models;

namespace PetShop.Services;

public class CatsService
{
  internal List<Cat> GetAll()
  {
    return FakeDb.Cats;
  }

  internal Cat GetById(string id)
  {
    Cat found = FakeDb.Cats.Find(c => c.Id == id);
    if (found == null)
    {
      throw new Exception("Invalid Id");
    }
    return found;
  }

  internal Cat Create(Cat newCat)
  {
    FakeDb.Cats.Add(newCat);
    return newCat;
  }

  internal Cat Update(Cat updates)
  {
    Cat original = GetById(updates.Id);
    // original.Age = updates.Age != null ? updates.Age : original.Age;
    original.Age = updates.Age ?? original.Age; // ?? = null-coalescing operator 
    original.Name = updates.Name ?? original.Name;
    // SAVE CHANGES
    return original;
  }

  internal void Delete(string id)
  {
    Cat found = GetById(id);
    FakeDb.Cats.Remove(found);
  }


}
