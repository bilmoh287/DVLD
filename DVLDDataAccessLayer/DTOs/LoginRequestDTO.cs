namespace DVLDDataAccessLayer.DTOs
{
    public class LoginRequestDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginRequestDTO(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        // Empty constructor for JSON serialization
        public LoginRequestDTO() { }
    }
}
