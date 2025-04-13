using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AnimalClinicAPI.Data;
using AnimalClinicAPI.Models;

namespace AnimalClinicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Visit>> GetVisits([FromQuery] int animalId)
        {
            if (animalId == 0)
            {
                return Ok(FakeDatabase.Visits);
            }
            
            var animal = FakeDatabase.Animals.FirstOrDefault(a => a.Id == animalId);
            if (animal == null)
                return NotFound($"Animal with ID {animalId} not found.");
            return Ok(animal.Visits);
        }
        [HttpPost]
        public ActionResult<Visit> CreateVisit([FromQuery] int animalId, [FromBody] Visit visit)
        {
            var animal = FakeDatabase.Animals.FirstOrDefault(a => a.Id == animalId);
            if (animal == null)
                return NotFound($"Animal with ID {animalId} not found.");
            
            int newId = FakeDatabase.Visits.Any() ? FakeDatabase.Visits.Max(v => v.Id) + 1 : 1;
            visit.Id = newId;
            visit.AnimalId = animalId;
            if (visit.DateOfVisit == default)
            {
                visit.DateOfVisit = DateTime.Now;
            }
            
            FakeDatabase.Visits.Add(visit);
            animal.Visits.Add(visit);
            
            return CreatedAtAction(nameof(GetVisits), new { animalId = animalId }, visit);
        }
    }
}