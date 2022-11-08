using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalExam_HumanRegistrationSystem.Controllers
{
    [Route("api/[controller]")]

    public class PlaceOfResidenceController : ControllerBase
    {
        private readonly IPlaceOfResidenceService _placeOfResidenceService;
        public PlaceOfResidenceController(IPlaceOfResidenceService placeOfResidenceService)
        {
            _placeOfResidenceService = placeOfResidenceService;
        }
        [HttpPut("Update City")]
        [Authorize]
        public async Task<IActionResult> ChangeCityAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _placeOfResidenceService.ChangeCityAsync(userId, city);
            return Ok();
        }
        [HttpPut("Update Street")]
        [Authorize]
        public async Task<IActionResult> ChangeStreetAsync(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _placeOfResidenceService.ChangeStreetAsync(userId, street);
            return Ok();
        }
        [HttpPut("Update House")]
        [Authorize]
        public async Task<IActionResult> ChangeHouseAsync(string house)
        {
            if (string.IsNullOrWhiteSpace(house))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _placeOfResidenceService.ChangeHouseNumberAsync(userId, house);
            return Ok();
        }
        [HttpPut("Update Apartment")]
        [Authorize]
        public async Task<IActionResult> ChangeApartmentAsync(string apartment)
        {
            if (string.IsNullOrWhiteSpace(apartment))
            {
                return BadRequest("Info can't be null or whistespace");
            }
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await _placeOfResidenceService.ChangeApartmentNumberAsync(userId, apartment);
            return Ok();
        }
    }
}
