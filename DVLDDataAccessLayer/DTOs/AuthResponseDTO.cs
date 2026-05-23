namespace DVLDDataAccessLayer.DTOs
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public int? InstituteID { get; set; }

        public AuthResponseDTO(string token, int userId, int personId, string fullName, string role, int? instituteId = null)
        {
            this.Token = token;
            this.UserID = userId;
            this.PersonID = personId;
            this.FullName = fullName;
            this.Role = role;
            this.InstituteID = instituteId;
        }

        public AuthResponseDTO() { }
    }
}
