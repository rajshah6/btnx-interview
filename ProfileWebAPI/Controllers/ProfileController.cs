using Microsoft.AspNetCore.Mvc;
using ProfileWebAPI.Models;
using ProfileWebAPI.Services;

namespace ProfileWebAPI.Controllers;

[ApiController]
[Route("api/profile")]
public class ProfileController : ControllerBase
{
    private readonly PersonStore _store;

    public ProfileController(PersonStore store)
    {
        _store = store;
    }

    [HttpGet]
    public IActionResult Get()
    {
        if (_store.TryGet(1, out var person))
        {
            return Ok(person);
        }

        return NotFound();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        if (_store.TryGet(id, out var person))
        {
            return Ok(person);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Upsert(Person person)
    {
        _store.Upsert(person);
        return NoContent();
    }
}


