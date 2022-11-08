using Microservices_API.Models;
using Microservices_API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animal;
        private readonly ISpeciesRepository _species;
        public AnimalController(IAnimalRepository animal, ISpeciesRepository species)
        {
            _animal = animal ??
                throw new ArgumentNullException(nameof(animal));
            _species = species ??
                throw new ArgumentNullException(nameof(species));
        }
        [HttpGet]
        [Route("GetAnimal")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _animal.GetAnimals());
        }
        [HttpGet]
        [Route("GetAnimalByID/{Id}")]
        public async Task<IActionResult> GetAnimalByID(int Id)
        {
            return Ok(await _animal.GetAnimalByID(Id));
        }
        [HttpPost]
        [Route("AddAnimal")]
        public async Task<IActionResult> Post(Animal anim)
        {
            var result = await _animal.InsertAnimal(anim);
            if (result.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateAnimal")]
        public async Task<IActionResult> Put(Animal anim)
        {
            await _animal.UpdateAnimal(anim);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteAnimal")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _animal.DeleteAnimal(id);
            return new JsonResult("Deleted Successfully");
        }



        [HttpGet]
        [Route("GetSpecies")]
        public async Task<IActionResult> GetAllSpeciesNames()
        {
            return Ok(await _species.GetAnimalSpecies());
        }
    }
}
