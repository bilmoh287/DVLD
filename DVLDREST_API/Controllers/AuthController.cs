using DVLDDataAccessLayer.DTOs;
using DVLDBussinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Username and Password are required.");
            }

            // Find user in the business layer
            clsUser user = clsUser.FindByUserNameAndPassword(loginRequest.Username, loginRequest.Password);

            if (user == null || !user.IsActive)
            {
                return Unauthorized("Invalid credentials or inactive account.");
            }

            // For now, mapping role based on permissions or assuming 'Applicant'
            // To make it simpler, we just assign the role based on internal logic.
            // For a mobile app, this is typically an applicant.
            string role = "Applicant"; // In a real app, query UserRole or Permissions

            var token = GenerateJwtToken(user, role);

            var response = new AuthResponseDTO(token, user.UserID, user.PersonID, user.UserName, role);

            return Ok(response);
        }

        // POST /api/auth/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterApplicantDTO registerRequest)
        {
            if (registerRequest == null) return BadRequest("Invalid request.");

            // 1. Validation Checks
            if (clsPerson.IsPersonExist(registerRequest.NationalNo))
            {
                return Conflict("A person with this National Number already exists.");
            }

            if (clsUser.IsUserExist(registerRequest.Username))
            {
                return Conflict("This Username is already taken.");
            }

            // 2. Create Person Record
            clsPerson person = new clsPerson();
            person.NationalNo = registerRequest.NationalNo;
            person.FirstName = registerRequest.FirstName;
            person.SecondName = registerRequest.SecondName;
            person.ThirdName = registerRequest.ThirdName;
            person.LastName = registerRequest.LastName;
            person.DateOfBirth = registerRequest.DateOfBirth;
            person.Gender = registerRequest.Gender;
            person.Address = registerRequest.Address;
            person.Phone = registerRequest.Phone;
            person.Email = registerRequest.Email;
            person.CountryID = registerRequest.NationalityCountryID;
            person.ImagePath = registerRequest.ImagePath;

            if (!person.Save())
            {
                return StatusCode(500, "Error occurred while saving person details.");
            }

            // 3. Create User Account
            clsUser user = new clsUser();
            user.PersonID = person.PersonID;
            user.UserName = registerRequest.Username;
            user.SetPassword(registerRequest.Password);
            user.IsActive = true;

            if (!user.Save())
            {
                // Note: In a production app, you might want to delete the person record if user creation fails
                return StatusCode(500, "Error occurred while creating user account.");
            }

            // 4. Generate Token and Respond
            string role = "Applicant";
            var token = GenerateJwtToken(user, role);
            var response = new AuthResponseDTO(token, user.UserID, user.PersonID, person.FullName, role);

            return Ok(response);
        }

        private string GenerateJwtToken(clsUser user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
                new Claim("PersonID", user.PersonID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
