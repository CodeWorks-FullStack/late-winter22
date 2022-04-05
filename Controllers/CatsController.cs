using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CatsController : ControllerBase
{
  private readonly CatsService _cs;

  public CatsController(CatsService cs)
  {
    _cs = cs;
  }

  // get all
  [HttpGet]
  public ActionResult<List<Cat>> Get()
  {
    try
    {
      List<Cat> cats = _cs.GetAll();
      return Ok(cats);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")] // translation '/:id' === "{id}"
  public ActionResult<Cat> GetById(string id) // req.params.id is just a parameter on the method now
  {
    try
    {
      Cat cat = _cs.GetById(id);
      return Ok(cat);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Cat> Create([FromBody] Cat newCat) // req.body is now [FromBody]
  {
    try
    {
      Cat cat = _cs.Create(newCat);
      return Ok(cat);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Cat> Update(string id, [FromBody] Cat updates)
  {
    try
    {
      updates.Id = id;
      Cat updated = _cs.Update(updates);
      return Ok(updated);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }




  [HttpDelete("{id}")]
  public ActionResult<String> Delete(string Id)
  {
    try
    {
      _cs.Delete(Id);
      return Ok("Delorted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



}