using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetFinderAPI.Models;
using PetFinderAPI.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;


namespace PetFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FindPetController : ControllerBase
    {
        private readonly PetService _petService;
        public FindPetController()
        {
            _petService = new PetService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<List<PetModel>> FindAllLostPets()
        {
            var allPets = _petService.GetAllLostPets();
            return Ok(allPets);
        }

        [HttpGet("{Name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(Summary = "Find a lost pet by name")]
        public ActionResult<List<PetResponseModel>> FindPet(string Name)
        {
            var allPets = _petService.GetAllLostPets();
            var myLostPet = allPets.Find(r => r.Name == Name);
            if (myLostPet == null)
            {
                return NotFound($"Oopsy, '{Name}' is probably lost forever! :-( ");
            }

            var pet = _petService.FindPetByName(myLostPet);
            return Ok(pet);
        }

        [HttpPost("{Name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(Summary = "Post alert to our response team")]
        public ActionResult AlertTeam(string Name)
        {
            var allPets = _petService.GetAllLostPets();
            var myLostPet = allPets.Find(r => r.Name == Name);
            if (myLostPet == null)
            {
                return NotFound($"Pet with name '{Name}' could not be found!");
            }

            var pet = _petService.FindPetByName(myLostPet);
            var message = _petService.AlertResponseTeam(pet);

            return Ok(message);
        }
    }
}
