using FindPets.Shared.Pets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace FindPets.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> Get(bool? type, bool status, string? search, int page, int take )
        {
            var pets = await _petService.GetAllPets(new SearchPet(search, type, status, page, take));

            return Ok(pets);
        }

        [HttpGet("{id}", Name = "GetPet")]
        public async Task<ActionResult<Pet>> Get(Guid id)
        {
            var pet = await _petService.GetPetById(id);

            if (pet == null)
                return NotFound();

            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPet = await _petService.AddPet(pet);

            return CreatedAtRoute("GetPet", new { id = createdPet.Id }, createdPet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != pet.Id)
                return BadRequest();

            var updatedPet = await _petService.UpdatePet(pet);

            return Ok(updatedPet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _petService.DeletePet(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
