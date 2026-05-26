using DVLDDataAccessLayer.DTOs;
using DVLDBussinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data;
using System.IO;

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
                return BadRequest(new { message = "Username and Password are required." });
            }

            // Find user in the business layer
            clsUser user = clsUser.FindByUserNameAndPassword(loginRequest.Username, loginRequest.Password);

            if (user == null || !user.IsActive)
            {
                return Unauthorized(new { message = "Invalid credentials or inactive account." });
            }

            // Find role and check school association
            int instituteId = clsDrivingInstitute.GetInstituteIDByUserID(user.UserID);
            
            // Query roles
            DataTable dtRoles = clsUserRole.GetRolesByUserID(user.UserID);
            string role = "Applicant"; // Default role
            
            if (dtRoles.Rows.Count > 0)
            {
                role = dtRoles.Rows[0]["RoleName"].ToString();
                
                // Normalize role names to standard camel-case tokens used by Next.js and Flutter clients
                if (role == "Registration Officer" || role == "Test Officer" || role == "License Issuer" || role == "Officer")
                {
                    role = "Officer";
                }
                else if (role == "Admin" || role == "SystemAdmin")
                {
                    role = "SystemAdmin";
                }
                else if (role == "Institute Manager" || role == "InstituteManager")
                {
                    role = "InstituteManager";
                }
                else if (role == "Institute Instructor" || role == "InstituteInstructor")
                {
                    role = "InstituteInstructor";
                }
            }
            else
            {
                int permissions = clsUserPermission.GetUserPermissions(user.UserID);
                if (permissions == (int)clsUserPermission.enPermissions.FullAccess)
                {
                    role = "SystemAdmin";
                }
                else if (instituteId > 0)
                {
                    bool isInstructor = clsUserPermission.HasPermission(permissions, clsUserPermission.enPermissions.InstituteInstructor);
                    role = isInstructor ? "InstituteInstructor" : "InstituteManager";
                }
                else if (permissions > 0)
                {
                    role = "Officer";
                }
            }

            // Fetch person details for dynamic full name
            clsPerson person = clsPerson.Find(user.PersonID);
            string fullName = person != null ? person.FullName : user.UserName;

            var token = GenerateJwtToken(user, role);

            var response = new AuthResponseDTO(token, user.UserID, user.PersonID, fullName, role, instituteId > 0 ? instituteId : (int?)null);

            return Ok(response);
        }

        // POST /api/auth/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterApplicantDTO registerRequest)
        {
            if (registerRequest == null) return BadRequest(new { message = "Invalid request." });

            // 1. Validation Checks
            if (clsPerson.IsPersonExist(registerRequest.NationalNo))
            {
                return Conflict(new { message = "A person with this National Number already exists." });
            }

            if (clsUser.IsUserExist(registerRequest.Username))
            {
                return Conflict(new { message = "This Username is already taken." });
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
            
            // Save Profile Image to Disk if provided
            person.ImagePath = SaveProfileImageToDisk(registerRequest.ImagePath, registerRequest.NationalNo);

            if (!person.Save())
            {
                return StatusCode(500, new { message = "Error occurred while saving person details." });
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
                return StatusCode(500, new { message = "Error occurred while creating user account." });
            }

            // 4. Generate Token and Respond
            string role = "Applicant";
            var token = GenerateJwtToken(user, role);
            var response = new AuthResponseDTO(token, user.UserID, user.PersonID, person.FullName, role);

            return Ok(response);
        }

        private string SaveProfileImageToDisk(string base64String, string nationalNo)
        {
            if (string.IsNullOrEmpty(base64String)) return "";

            try
            {
                string folderPath = @"C:\DVLD_Uploads\Profiles";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (base64String.Contains(","))
                {
                    base64String = base64String.Substring(base64String.IndexOf(",") + 1);
                }

                byte[] imageBytes = Convert.FromBase64String(base64String);
                string fileName = $"PROFILE_{nationalNo}_{Guid.NewGuid().ToString("N")}.jpg";
                string fullPath = Path.Combine(folderPath, fileName);

                System.IO.File.WriteAllBytes(fullPath, imageBytes);
                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving profile image: {ex.Message}");
                return "";
            }
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
