using Microservices_API.Models;
using Microservices_API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesRepository _species;
        public SpeciesController(ISpeciesRepository species)
        {
            _species = species ??
                throw new ArgumentNullException(nameof(species));
        }
        [HttpGet]
        [Route("GetSpecies")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _species.GetAnimalSpecies());
        }
        [HttpGet]
        [Route("GetSpeciesByID/{Id}")]
        public async Task<IActionResult> GetAnimalSpeciesById(int Id)
        {
            return Ok(await _species.GetAnimalSpeciesByID(Id));
        }
        [HttpPost]
        [Route("AddSpecies")]
        public async Task<IActionResult> Post(AnimalSpecies spec)
        {
            var result = await _species.InsertAnimalSpecies(spec);
            if (result.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateSpecies")]
        public async Task<IActionResult> Put(AnimalSpecies spec)
        {
            await _species.UpdateAnimalSpecies(spec);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteSpecies")]
        public JsonResult Delete(int id)
        {
            _species.DeleteAnimalSpecies(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
