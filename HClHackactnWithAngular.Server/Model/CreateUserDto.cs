namespace HClHackactnWithAngular.Server.Model
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        // Optionally, add staff info fields if needed

        public UserDataDto UserData { get; set; }
    }
}
