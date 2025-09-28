using ProfileWebAPI.Models;
using ProfileWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProfileWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController(PersonStore store) : ControllerBase
{
    [HttpGet("{id:int}")]
    public ActionResult<Person> Get(int id)
        => store.TryGet(id, out var p) ? Ok(p) : NotFound();

    [HttpPost]
    public ActionResult<Person> Create(Person p)
    {
        store.Upsert(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Person p)
    {
        if (id != p.Id) return BadRequest(new { error = "Id mismatch" });
        store.Upsert(p);
        return NoContent();
    }
}
