using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    [HttpGet("animal/{animalId}")]
    public IActionResult GetVisitsByAnimalId(int animalId)
    {
        var visits = Database.Visits.Where(v => v.AnimalId == animalId).ToList();
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        var animalExists = Database.Animals.Any(a => a.Id == visit.AnimalId);
        if (!animalExists) return BadRequest("Animal does not exist.");

        visit.Id = Database.Visits.Count > 0 ? Database.Visits.Max(v => v.Id) + 1 : 1;
        Database.Visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsByAnimalId), new { animalId = visit.AnimalId }, visit);
    }
}