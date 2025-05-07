using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(Database.Animals);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        animal.Id = Database.Animals.Count > 0 ? Database.Animals.Max(a => a.Id) + 1 : 1;
        Database.Animals.Add(animal);
        return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Animal updated)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        animal.Name = updated.Name;
        animal.Category = updated.Category;
        animal.Weight = updated.Weight;
        animal.FurColor = updated.FurColor;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        Database.Animals.Remove(animal);
        return NoContent();
    }

    [HttpGet("search")]
    public IActionResult SearchByName([FromQuery] string name)
    {
        var results = Database.Animals.Where(a => a.Name.ToLower().Contains(name.ToLower())).ToList();
        return Ok(results);
    }
}