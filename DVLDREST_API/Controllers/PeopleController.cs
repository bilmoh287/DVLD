using DVLDDataAccessLayer.DTOs;
using DVLDBussinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PeopleController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            clsPerson person = clsPerson.Find(id);

            if (person == null)
                return NotFound($"Person with ID {id} not found.");

            var personDto = new PersonDTO(
                person.PersonID,
                person.NationalNo,
                person.FirstName,
                person.SecondName,
                person.ThirdName,
                person.LastName,
                person.DateOfBirth,
                person.Gender,
                person.Address,
                person.Phone,
                person.Email,
                person.CountryID,
                person.CountryInfo?.CountryName ?? "Unknown",
                person.ImagePath
            );

            return Ok(personDto);
        }

        [HttpGet("national/{nationalNo}")]
        public IActionResult GetPersonByNationalNo(string nationalNo)
        {
            clsPerson person = clsPerson.Find(nationalNo);

            if (person == null)
                return NotFound($"Person with National No {nationalNo} not found.");

            var personDto = new PersonDTO(
                person.PersonID,
                person.NationalNo,
                person.FirstName,
                person.SecondName,
                person.ThirdName,
                person.LastName,
                person.DateOfBirth,
                person.Gender,
                person.Address,
                person.Phone,
                person.Email,
                person.CountryID,
                person.CountryInfo?.CountryName ?? "Unknown",
                person.ImagePath
            );

            return Ok(personDto);
        }

        [HttpPut("{id}/profile")]
        public IActionResult UpdateProfile(int id, [FromBody] PersonDTO personDto)
        {
            if (personDto == null) return BadRequest("Invalid data.");

            clsPerson person = clsPerson.Find(id);
            if (person == null) return NotFound("Person not found.");

            // We only allow updating contact details for security
            person.Address = personDto.Address;
            person.Phone = personDto.Phone;
            person.Email = personDto.Email;

            if (person.Save())
            {
                return Ok("Profile updated successfully.");
            }

            return StatusCode(500, "Error updating profile.");
        }
    }
}
