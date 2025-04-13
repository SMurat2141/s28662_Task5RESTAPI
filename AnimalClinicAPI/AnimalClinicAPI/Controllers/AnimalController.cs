using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AnimalClinicAPI.Data;
using AnimalClinicAPI.Models;

namespace AnimalClinicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        // GET: api/animal
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> GetAllAnimals()
        {
            return Ok(FakeDatabase.Animals);
        }
        
        // GET: api/animal/{id}
        [HttpGet("{id}")]
        public ActionResult<Animal> GetAnimalById(int id)
        {
            var animal = FakeDatabase.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound($"Animal with ID {id} not found.");
            return Ok(animal);
        }
        
        // POST: api/animal
        [HttpPost]
        public ActionResult<Animal> CreateAnimal([FromBody] Animal animal)
        {
            if (animal == null)
                return BadRequest("Invalid animal data.");

            int newId = FakeDatabase.Animals.Any() ? FakeDatabase.Animals.Max(a => a.Id) + 1 : 1;
            animal.Id = newId;
            FakeDatabase.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
        }
        
        // PUT: api/animal/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
        {
            if (updatedAnimal == null || updatedAnimal.Id != id)
                return BadRequest("Animal data is invalid.");

            var existingAnimal = FakeDatabase.Animals.FirstOrDefault(a => a.Id == id);
            if (existingAnimal == null)
                return NotFound($"Animal with ID {id} not found.");

            // Update properties.
            existingAnimal.Name = updatedAnimal.Name;
            existingAnimal.Category = updatedAnimal.Category;
            existingAnimal.Weight = updatedAnimal.Weight;
            existingAnimal.FurColor = updatedAnimal.FurColor;

            return NoContent();
        }
        
        // DELETE: api/animal/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = FakeDatabase.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound($"Animal with ID {id} not found.");
            FakeDatabase.Animals.Remove(animal);
            return NoContent();
        }
    }
}
